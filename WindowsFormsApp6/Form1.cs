using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;  // Для работы с JSON (если используется)


namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        private BankApiService _bankApiService;
        public Form1()
        {
            InitializeComponent();
            btnCalculate.Click += btnCalculate_Click;
            _bankApiService = new BankApiService();
            LoadCurrencyRates();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private async void LoadCurrencyRates()
        {
            try
            {
                List<Currency> currencies = await _bankApiService.GetCurrencyRatesAsync();

                cmbFromCurrency.Items.Clear();
                cmbToCurrency.Items.Clear();

                foreach (var currency in currencies)
                {
                    cmbFromCurrency.Items.Add(currency.CharCode);  // Добавляем валюту в ComboBox
                    cmbToCurrency.Items.Add(currency.CharCode);    // Добавляем валюту в ComboBox
                }

                // Устанавливаем первую валюту по умолчанию
                if (cmbFromCurrency.Items.Count > 0)
                    cmbFromCurrency.SelectedIndex = 0;

                if (cmbToCurrency.Items.Count > 0)
                    cmbToCurrency.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке курсов валют: {ex.Message}");
            }
        }

        // Обработчик кнопки для расчёта
        private async void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем выбранные валюты и сумму
                var fromCurrency = cmbFromCurrency.SelectedItem.ToString();
                var toCurrency = cmbToCurrency.SelectedItem.ToString();
                double amount = double.Parse(txtAmount.Text);

                // Получаем курсы валют от ЦБ РФ
                List<Currency> currencies = await _bankApiService.GetCurrencyRatesAsync();

                // Находим курс для выбранных валют
                double fromCurrencyValue = GetCurrencyValue(currencies, fromCurrency);
                double toCurrencyValue = GetCurrencyValue(currencies, toCurrency);

                // Переводим валюту
                double result = (amount / fromCurrencyValue) * toCurrencyValue;

                // Отображаем результат без комиссии
                lblWithoutCommission.Text = $"Без комиссии: {result:F2} {toCurrency}";

                // Учитываем комиссию
                double commission = 0.01; // Например, 1% комиссия
                double resultWithCommission = result - result * commission;

                // Отображаем результат с комиссией
                lblResult.Text = $"Вы получите с учётом комиссии: {resultWithCommission:F2} {toCurrency}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчёте: {ex.Message}");
            }
        }

        // Метод для получения значения валюты по её коду
        private double GetCurrencyValue(List<Currency> currencies, string charCode)
        {
            var currency = currencies.Find(c => c.CharCode == charCode);
            return currency?.Value ?? 1; // Возвращаем 1, если курс не найден
        }

        private void lblWithoutCommission_Click(object sender, EventArgs e)
        {

        }
    }

}


