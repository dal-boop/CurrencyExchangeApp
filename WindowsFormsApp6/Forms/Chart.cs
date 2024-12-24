using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace WindowsFormsApp6.Forms
{
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
            ChartDesigne();

            // Добавляем валюты в ComboBox
            cmbCurrency.Items.AddRange(new CurrencyItem[]
            {
                new CurrencyItem { Code = "USD", Name = "Доллар США" },
                new CurrencyItem { Code = "EUR", Name = "Евро" },
                new CurrencyItem { Code = "GBP", Name = "Фунт стерлингов" },
                new CurrencyItem { Code = "JPY", Name = "Японская иена" },
                new CurrencyItem { Code = "AUD", Name = "Австралийский доллар" },
                new CurrencyItem { Code = "CNY", Name = "Китайский юань" },
                new CurrencyItem { Code = "CAD", Name = "Канадский доллар" },
                new CurrencyItem { Code = "CHF", Name = "Швейцарский франк" },
                new CurrencyItem { Code = "INR", Name = "Индийская рупия" },
                new CurrencyItem { Code = "RUB", Name = "Российский рубль" }
            });

            cmbCurrency.SelectedIndex = 0; // Устанавливаем первую валюту по умолчанию

            // Устанавливаем временной период
            dtpStartDate.Value = DateTime.Now.AddMonths(-1); // Месяц назад
            dtpEndDate.Value = DateTime.Now;

            // Привязываем события
            cmbCurrency.SelectedIndexChanged += UpdateChart;
            dtpStartDate.ValueChanged += UpdateChart;
            dtpEndDate.ValueChanged += UpdateChart;
            UpdateChart(null, null);

        }

        

        private void DateRangeChanged(object sender, EventArgs e)
        {

        }

        private void CurrencyChanged(object sender, EventArgs e)
        {

        }
        private void UpdateChart(object sender, EventArgs e)
        {
            // Получаем выбранную валюту
            var selectedCurrency = cmbCurrency.SelectedItem as CurrencyItem;
            if (selectedCurrency == null) return;

            string currencyCode = selectedCurrency.Code;
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            // Получаем курсы валют
            var exchangeRates = GetExchangeRates(currencyCode, startDate, endDate);

            if (exchangeRates == null || exchangeRates.Count == 0)
            {
                MessageBox.Show("Не удалось получить данные за указанный период.");
                return;
            }

            // Отображаем данные на графике
            DisplayChart(exchangeRates);
        }




        private decimal GetRateAgainstRuble(string currency)
        {
            // Получаем курс валюты к рублю (например, для USD, EUR и других валют)
            switch (currency)
            {
                case "USD":
                    return 100.0348m; // Замените на актуальные данные
                case "EUR":
                    return 105.7338m; // Замените на актуальные данные
                case "GBP":
                    return 126.444m;  // Замените на актуальные данные
                case "JPY":
                    return 64.781m;   // Замените на актуальные данные
                default:
                    return 0;
            }
        }

        private decimal GetRateAgainstCurrency(string fromCurrency, string toCurrency)
        {
            // Для примера используем прямое получение курса валют через API, замените логику по необходимости
            decimal fromCurrencyRate = GetRateAgainstRuble(fromCurrency);
            decimal toCurrencyRate = GetRateAgainstRuble(toCurrency);

            if (fromCurrencyRate == 0 || toCurrencyRate == 0)
            {
                return 0;
            }

            // Рассчитываем курс одной валюты относительно другой
            return fromCurrencyRate / toCurrencyRate;
        }



        private decimal CalculateChangeForPeriod(Dictionary<DateTime, decimal> exchangeRates, DateTime startDate, DateTime endDate)
        {
            var startRate = exchangeRates.FirstOrDefault(x => x.Key >= startDate).Value;
            var endRate = exchangeRates.LastOrDefault(x => x.Key <= endDate).Value;

            if (startRate == 0 || endRate == 0)
                return 0;

            return ((endRate - startRate) / startRate) * 100;
        }

        private decimal CalculateChangeForAllTime(Dictionary<DateTime, decimal> exchangeRates)
        {
            var startRate = exchangeRates.First().Value;
            var endRate = exchangeRates.Last().Value;

            if (startRate == 0 || endRate == 0)
                return 0;

            return ((endRate - startRate) / startRate) * 100;
        }


        public void ChartDesigne()
        {
            chartCurrency.ChartAreas[0].BackColor = Color.WhiteSmoke;
            chartCurrency.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Century Gothic", 10, FontStyle.Regular);
            chartCurrency.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Century Gothic", 10, FontStyle.Regular);

            chartCurrency.ChartAreas[0].AxisX.LabelStyle.Format = "dd.MM.yyyy";
            chartCurrency.ChartAreas[0].AxisY.LabelStyle.Format = "F2";

            chartCurrency.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

            chartCurrency.Series[0].Color = Color.Blue;
            chartCurrency.Series[0].BorderWidth = 3;
            chartCurrency.Series[0].MarkerStyle = MarkerStyle.Circle;
            chartCurrency.Series[0].MarkerSize = 8;
            chartCurrency.Series[0].MarkerColor = Color.Red;
            chartCurrency.Series[0].ToolTip = "Дата: #VALX{dd.MM.yyyy}\nКурс: #VALY{F2}";

            // Убираем легенду
            chartCurrency.Legends.Clear();  // Удаляем все легенды
            chartCurrency.Series[0].IsVisibleInLegend = false;  // Отключаем отображение легенды для серии
        }

        private void btnShowChart_Click(object sender, EventArgs e)
        {

        }

        private Dictionary<DateTime, decimal> GetExchangeRates(string currency, DateTime startDate, DateTime endDate)
        {
            var rates = new Dictionary<DateTime, decimal>();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = $"https://www.cbr.ru/scripts/XML_dynamic.asp?date_req1={startDate:dd/MM/yyyy}&date_req2={endDate:dd/MM/yyyy}&VAL_NM_RQ={GetCurrencyCode(currency)}";
                    var response = httpClient.GetAsync(url).Result;

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Ошибка соединения с API ЦБ РФ.");
                        return null;
                    }

                    var responseString = response.Content.ReadAsStringAsync().Result;

                    var xmlDoc = new System.Xml.XmlDocument();
                    xmlDoc.LoadXml(responseString);

                    foreach (System.Xml.XmlNode node in xmlDoc.SelectNodes("//Record"))
                    {
                        if (node.Attributes["Date"] != null && node["Value"] != null)
                        {
                            DateTime date = DateTime.Parse(node.Attributes["Date"].Value);
                            decimal value = decimal.Parse(node["Value"].InnerText.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);

                            rates[date] = value;
                        }
                    }
                }

                return rates;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка получения данных: {ex.Message}");
                return null;
            }
        }

        public class CurrencyItem
        {
            public string Code { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return $"{Name} ({Code})";
            }
        }

        private string GetCurrencyCode(string currency)
        {
            switch (currency)
            {
                case "USD":
                    return "R01235";  // Доллар США
                case "EUR":
                    return "R01239";  // Евро
                case "GBP":
                    return "R01035";  // Британский фунт
                case "JPY":
                    return "R01820";  // Японская иена
                case "AUD":
                    return "R01010";  // Австралийский доллар
                case "CNY":
                    return "R01375";  // Китайский юань
                case "CAD":
                    return "R01350";  // Канадский доллар
                case "CHF":
                    return "R01720";  // Швейцарский франк
                case "INR":
                    return "R01815";  // Индийская рупия
                case "RUB":
                    return "R01090";  // Российский рубль
                default:
                    throw new ArgumentException("Валюта не поддерживается");
            }
        }
        private void DisplayChart(Dictionary<DateTime, decimal> exchangeRates)
        {
            chartCurrency.Series.Clear();

            var series = new Series
            {
                Name = "Курс к рублю",
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime
            };

            // Добавляем точки на график и устанавливаем цвет в зависимости от тренда
            DataPoint previousPoint = null;
            foreach (var rate in exchangeRates)
            {
                var point = new DataPoint
                {
                    XValue = rate.Key.ToOADate(),
                    YValues = new[] { (double)rate.Value }
                };

                if (previousPoint != null)
                {
                    if (point.YValues[0] > previousPoint.YValues[0])
                    {
                        point.Color = Color.Green; // Рост
                    }
                    else if (point.YValues[0] < previousPoint.YValues[0])
                    {
                        point.Color = Color.Red; // Падение
                    }
                }

                series.Points.Add(point);
                previousPoint = point;
            }

            chartCurrency.Series.Add(series);

            // Настройки графика
            chartCurrency.ChartAreas[0].AxisX.LabelStyle.Format = "dd.MM.yyyy";
            chartCurrency.ChartAreas[0].RecalculateAxesScale();
        }

        private void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void crownButton1_Click(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Now.AddMonths(-1);
            DateTime endDate = DateTime.Now;

            dtpStartDate.Value = startDate;
            dtpEndDate.Value = endDate;

            UpdateChart(null, null);  // Обновление графика
        }

        private void crownButton2_Click(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Now.AddYears(-1);
            DateTime endDate = DateTime.Now;

            dtpStartDate.Value = startDate;
            dtpEndDate.Value = endDate;

            UpdateChart(null, null);  // Обновление графика
        }

        private void crownButton3_Click(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(2000, 1, 1);
            DateTime endDate = DateTime.Now;

            dtpStartDate.Value = startDate;
            dtpEndDate.Value = endDate;

            UpdateChart(null, null);  // Обновление графика
        }
        private void ExportChartToPdfWithPdfSharp()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "Сохранить график в PDF";
                saveFileDialog.FileName = "CurrencyChart.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pdfFilePath = saveFileDialog.FileName;

                    // Создаем временный файл для сохранения изображения графика
                    using (var ms = new MemoryStream())
                    {
                        // Сохраняем график как изображение в формате PNG
                        chartCurrency.SaveImage(ms, ChartImageFormat.Png);

                        // Создаем новый PDF-документ
                        using (PdfDocument doc = new PdfDocument())
                        {
                            // Добавляем страницу в документ
                            PdfPage page = doc.AddPage();

                            // Создаем графику для страницы
                            XGraphics gfx = XGraphics.FromPdfPage(page);

                            // Загружаем изображение из MemoryStream
                            ms.Seek(0, SeekOrigin.Begin);
                            XImage xImage = XImage.FromStream(ms);

                            // Рисуем изображение на странице PDF
                            gfx.DrawImage(xImage, 0, 0);

                            // Сохраняем PDF файл
                            doc.Save(pdfFilePath);
                        }

                        // Информируем пользователя
                        MessageBox.Show($"График успешно сохранён в PDF: {pdfFilePath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblChangePercentage_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportChartToPdfWithPdfSharp();
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }
    }
}

