using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Table : Form
    {
        private BankApiService _bankApiService;
        public Table()
        {
            InitializeComponent();
            _bankApiService = new BankApiService();
            dgvCurrencyRates.AutoGenerateColumns = true;
            dgvCurrencyRates.ReadOnly = true;
            SetupDataGridView();
            dgvCurrencyRates.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvCurrencyRates.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            dgvCurrencyRates.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            LoadCurrencyRatesToGridAsync(DateTime.Now);
            //label1.Text = $"Курсы валют к рублю. Данные предоставлены ЦБ РФ. Обновлено: {DateTime.Now:dd.MM.yyyy}";
        }

        private void Table_Load(object sender, EventArgs e)
        {

        }
        private void SetupDataGridView()
        {
            dgvCurrencyRates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCurrencyRates.AllowUserToResizeColumns = false;
            dgvCurrencyRates.AllowUserToResizeRows = false;
            dgvCurrencyRates.RowHeadersVisible = false;
            dgvCurrencyRates.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Выравнивание по центру
            dgvCurrencyRates.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dgvCurrencyRates.Columns.Count > 0)
            {
                dgvCurrencyRates.Columns["CharCode"].FillWeight = 30;
                dgvCurrencyRates.Columns["Name"].FillWeight = 70;
                dgvCurrencyRates.Columns["Rate"].FillWeight = 20;
            }
        }
        private async Task LoadCurrencyRatesToGridAsync(DateTime date)
        {
            try
            {
                var currencies = await _bankApiService.GetCurrencyRatesAsync(date);
                if (currencies != null && currencies.Any())
                {
                    dgvCurrencyRates.DataSource = currencies.Select(c => new
                    {
                        Код = c.CharCode,
                        Название = c.Name,
                        Курс = c.Rate
                    }).ToList();
                }
                else
                {
                    MessageBox.Show("Не удалось загрузить курсы валют ЦБ РФ.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных. Проверьте подключение к интернету.\n\n" + ex.Message,
                    "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dgvCurrencyRates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadRates_Click(object sender, EventArgs e)
        {
            LoadCurrencyRatesToGridAsync(dateTimePicker.Value);
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (dgvCurrencyRates.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Сохранить таблицу в Excel";
                saveFileDialog.FileName = "CurrencyRates.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string excelFilePath = saveFileDialog.FileName;

                    try
                    {
                        // Создаем новый Excel-документ
                        using (ExcelPackage package = new ExcelPackage())
                        {
                            // Добавляем рабочий лист
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Курсы валют");

                            // Настройка заголовков
                            worksheet.Cells[1, 1].Value = "Код";
                            worksheet.Cells[1, 2].Value = "Название";
                            worksheet.Cells[1, 3].Value = "Курс";

                            using (var range = worksheet.Cells[1, 1, 1, 3])
                            {
                                range.Style.Font.Bold = true;
                                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                            }

                            // Заполнение данных
                            int row = 2;
                            foreach (DataGridViewRow dgvRow in dgvCurrencyRates.Rows)
                            {
                                if (dgvRow.Cells[0].Value != null)
                                {
                                    worksheet.Cells[row, 1].Value = dgvRow.Cells[0].Value.ToString();
                                    worksheet.Cells[row, 2].Value = dgvRow.Cells[1].Value.ToString();
                                    worksheet.Cells[row, 3].Value = dgvRow.Cells[2].Value.ToString();
                                    row++;
                                }
                            }

                            // Автоширина колонок
                            worksheet.Cells.AutoFitColumns();

                            // Сохраняем файл
                            FileInfo fileInfo = new FileInfo(excelFilePath);
                            package.SaveAs(fileInfo);

                            MessageBox.Show($"Таблица успешно сохранена в Excel: {excelFilePath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при сохранении файла.\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
