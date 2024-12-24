    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    namespace WindowsFormsApp6.Classes
    {
        public class TinkoffApiService
        {
            private readonly HttpClient _httpClient;

            public TinkoffApiService()
            {
                _httpClient = new HttpClient();
            }

            // Асинхронно получаем курсы валют от API Тинькофф
            public async Task<Dictionary<string, double>> GetCurrencyRatesAsync(bool isBuyOperation)
            {
                string url = "https://api.tinkoff.ru/v1/currency_rates"; // API endpoint Тинькофф

                try
                {
                    var response = await _httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    var json = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Ответ API Тинькофф: {json}");

                    return ParseTinkoffCurrencyData(json, isBuyOperation);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при запросе к API Тинькофф: {ex.Message}");
                    return null;
                }
            }

        // Парсим JSON-строку с данными о курсах валют
        private Dictionary<string, double> ParseTinkoffCurrencyData(string json, bool isBuyOperation)
        {
            var apiResponse = JsonConvert.DeserializeObject<TinkoffApiResponse>(json);

            if (apiResponse == null || apiResponse.payload == null || apiResponse.payload.rates == null)
            {
                Console.WriteLine("Ошибка: пустой ответ или неверный формат данных.");
                return null;
            }

            var result = new Dictionary<string, double>();

            foreach (var rate in apiResponse.payload.rates)
            {
                if (rate.category == "DepositPayments")
                {
                    // Добавляем индивидуальные валюты вместо пар
                    var fromCurrency = rate.fromCurrency.name;
                    var toCurrency = rate.toCurrency.name;

                    // Добавляем покупку или продажу в зависимости от операции
                    if (isBuyOperation && !result.ContainsKey(fromCurrency))
                        result[fromCurrency] = rate.buy;
                    else if (!isBuyOperation && !result.ContainsKey(toCurrency))
                        result[toCurrency] = rate.sell;
                }
            }

            return result;
        }

        // Вложенные классы для парсинга ответа API
        public class TinkoffApiResponse
            {
                public string trackingId { get; set; }
                public string resultCode { get; set; }
                public TinkoffPayload payload { get; set; }
            }

            public class TinkoffPayload
            {
                // Заменим long на тип, который будет правильно обрабатывать объект
                public TinkoffLastUpdate lastUpdate { get; set; }
                public List<TinkoffRate> rates { get; set; }
            }

            public class TinkoffLastUpdate
            {
                public long milliseconds { get; set; }  // Поле milliseconds остается числовым
            }

            public class TinkoffRate
            {
                public string category { get; set; }
                public TinkoffCurrency fromCurrency { get; set; }
                public TinkoffCurrency toCurrency { get; set; }
                public double buy { get; set; }
                public double sell { get; set; }
            }

            public class TinkoffCurrency
            {
                public int code { get; set; }
                public string name { get; set; }
                public string strCode { get; set; }
            }
        }
    }
