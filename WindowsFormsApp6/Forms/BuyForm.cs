using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp6.Classes;

namespace WindowsFormsApp6
{
    public partial class BuyForm : Form
    {
        
        private BankApiService _bankApiService;
        private RaiffeisenApiService _raiffeisenApiService;
        private AlfaBankApiService _alfaBankApiService;
        private TinkoffApiService _tinkoffApiService;
        private SberBankApiService _salberBankApiService;
        public event EventHandler<string> BankChanged;


        private const double Commission = 0.10;
        public BuyForm()
        {
            InitializeComponent();

            _bankApiService = new BankApiService();
            _raiffeisenApiService = new RaiffeisenApiService();
            _alfaBankApiService = new AlfaBankApiService();
            _tinkoffApiService = new TinkoffApiService(); 
            _salberBankApiService = new SberBankApiService();
            cmbBank.Items.Add("Раффайзен");
            cmbBank.Items.Add("Альфа-Банк");
            cmbBank.Items.Add("Т-Банк");
            cmbBank.SelectedIndex = 0;

            btnCalculate.Click += BtnCalculate_Click;
            cmbBank.SelectedIndexChanged += CmbBank_SelectedIndexChanged;
            cmbBank.SelectedIndexChanged += cmbBank_SelectedIndexChanged_1;
            cmbBank.SelectedIndexChanged += (sender, args) =>
            {
                BankChanged?.Invoke(this, cmbBank.SelectedItem.ToString());
            };
            this.Load += async (sender, args) =>
            {
                await LoadCurrencyRatesAsync();
                cmbBank_SelectedIndexChanged_1(null, EventArgs.Empty);

            };
            }


        private void BuyForm_Load(object sender, EventArgs e)
        {
            var userId = GetCurrentUserId();
            if (userId == null)
            {
                MessageBox.Show("Вы должны быть авторизованы для выполнения операции.");
                this.Close(); // Закрытие формы, если не авторизован
            }
        }
    
        private async void CmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadCurrencyRatesAsync();
        }
        private async Task LoadCurrencyRatesAsync()
        {
            var selectedFromCurrency = cmbFromCurrency.SelectedItem?.ToString();
            var selectedToCurrency = cmbToCurrency.SelectedItem?.ToString();

            cmbFromCurrency.Items.Clear();
            cmbToCurrency.Items.Clear();

            Dictionary<string, double> rates = null;

            if (cmbBank.SelectedItem.ToString() == "Раффайзен")
            {
                rates = await _raiffeisenApiService.GetCurrencyRatesAsync(true); // Покупка
            }
            else if (cmbBank.SelectedItem.ToString() == "Альфа-Банк")
            {
                rates = await _alfaBankApiService.GetCurrencyRatesAsync(true); // Покупка
            }
            else if (cmbBank.SelectedItem.ToString() == "Т-Банк")
            {
                rates = await _tinkoffApiService.GetCurrencyRatesAsync(true); // Покупка
            }
            else if(cmbBank.SelectedItem.ToString()== "Сбербанк")
            {
                rates = await _salberBankApiService.GetCurrencyRatesAsync(true);
            }

            if (rates != null && rates.Any())
            {
                // Исключаем рубль и добавляем остальные валюты
                foreach (var currency in rates.Keys)
                {
                    if (currency != "RUB")
                    {
                        if (!cmbFromCurrency.Items.Contains(currency))
                            cmbFromCurrency.Items.Add(currency);

                        if (!cmbToCurrency.Items.Contains(currency))
                            cmbToCurrency.Items.Add(currency);
                    }
                }

                // Восстанавливаем выбранные значения, если они доступны
                if (selectedFromCurrency != null && cmbFromCurrency.Items.Contains(selectedFromCurrency))
                {
                    cmbFromCurrency.SelectedItem = selectedFromCurrency;
                }

                if (selectedToCurrency != null && cmbToCurrency.Items.Contains(selectedToCurrency))
                {
                    cmbToCurrency.SelectedItem = selectedToCurrency;
                }
            }
            else
            {
                MessageBox.Show("Не удалось загрузить курсы валют для выбранного банка.");
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {

        }
        private async void BtnCalculate_Click(object sender, EventArgs e)
        {
            var userId = GetCurrentUserId();
            if (userId == null)  // Проверка на авторизацию
            {
                MessageBox.Show("Вы должны быть авторизованы для выполнения операции.");
                return;
            }

            var fromCurrency = cmbFromCurrency.SelectedItem?.ToString();
            var toCurrency = cmbToCurrency.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(fromCurrency) || string.IsNullOrEmpty(toCurrency))
            {
                MessageBox.Show("Выберите валюты для обмена.");
                return;
            }

            if (!double.TryParse(txtAmount.Text, out double amount) || amount <= 0)
            {
                MessageBox.Show("Введите корректную сумму.");
                return;
            }

            Dictionary<string, double> rates = null;

            if (cmbBank.SelectedItem.ToString() == "Раффайзен")
            {
                rates = await _raiffeisenApiService.GetCurrencyRatesAsync(true);
            }
            else if (cmbBank.SelectedItem.ToString() == "Альфа-Банк")
            {
                rates = await _alfaBankApiService.GetCurrencyRatesAsync(true);
            }
            else if (cmbBank.SelectedItem.ToString() == "Т-Банк")
            {
                rates = await _tinkoffApiService.GetCurrencyRatesAsync(true);
            }

            if (rates == null || !rates.ContainsKey(fromCurrency) || !rates.ContainsKey(toCurrency))
            {
                MessageBox.Show("Выбранные валюты отсутствуют в данных.");
                return;
            }

            double fromRate = rates[fromCurrency];
            double toRate = rates[toCurrency];

            double result = (amount * fromRate) / toRate;
            double resultWithCommission = result - (result * Commission);

            label1.Text = $" {result:F2} {toCurrency}";
            label3.Text = $" {resultWithCommission:F2} {toCurrency}";

            // Сохранение операции
            var currencyOperationService = new CurrencyOperationService();
            currencyOperationService.SaveOperation(userId.Value, fromCurrency, toCurrency, amount, result, Commission, cmbBank.SelectedItem.ToString(), "Buy");
        }


        private int? GetCurrentUserId()
        {
            if (SessionManager.CurrentUserId != null)
            {
                return SessionManager.CurrentUserId;
            }
            else
            {
                MessageBox.Show("Вы должны быть авторизованы для выполнения операции.");
                return null;
            }
        }



        private void cmbBank_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbBank.Text == "Раффайзен")
            {
                pictureBoxBank12.Image = Properties.Resources.raffaisenlogo;
            }
            else if (cmbBank.Text == "Альфа-Банк")
            {
                pictureBoxBank12.Image = Properties.Resources.alfaicon;
            }
            else if (cmbBank.Text == "Т-Банк")
            {
                pictureBoxBank12.Image = Properties.Resources.tinkofflogo;
            }
        }

        private void pictureBoxBank12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxBank12_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void crownButton1_Click(object sender, EventArgs e)
        {
            string a = cmbFromCurrency.Text;
            string b = cmbToCurrency.Text;
            cmbFromCurrency.Text = b;
            cmbToCurrency.Text = a;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
    
}


