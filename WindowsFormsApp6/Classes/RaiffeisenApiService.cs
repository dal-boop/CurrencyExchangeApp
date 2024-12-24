using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    public class RaiffeisenApiService
    {
        private readonly HttpClient _httpClient; // Экземпляр для выполнения HTTP-запросов

        public RaiffeisenApiService()
        {
            _httpClient = new HttpClient();
        }
        //Асинхронно получаем курсы валют от API Райффайзенбанка
        public async Task<Dictionary<string, double>> GetCurrencyRatesAsync(bool isBuyOperation)
        {
            string url = "https://www.raiffeisen.ru/oapi/currency_rate/get/?source=RCONNECT&currencies=AUD,GBP,DKK,USD,EUR,KZT,CAD,CNY,NOK,SEK,CHF";

            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Ответ API Raiffeisen: {json}");

                return ParseRaiffeisenCurrencyData(json, isBuyOperation);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при запросе к API Райффайзен: {ex.Message}");
                return null;
            }
        }
        //Парсим JSON-строку с данными о курсах валют
        private Dictionary<string, double> ParseRaiffeisenCurrencyData(string json, bool isBuyOperation)
        {
            var apiResponse = JsonConvert.DeserializeObject<RaiffeisenApiResponse>(json);

            if (apiResponse == null || apiResponse.data == null || apiResponse.data.rates == null)
            {
                Console.WriteLine("Ошибка: пустой ответ или неверный формат данных.");
                return null;
            }

            var rubRates = apiResponse.data.rates.FirstOrDefault(rate => rate.code == "RUB");
            if (rubRates == null || rubRates.exchange == null)
            {
                Console.WriteLine("Ошибка: не найдены курсы для RUB.");
                return null;
            }
            return rubRates.exchange
                .Where(exchange => (isBuyOperation ? exchange.rates.buy != null : exchange.rates.sell != null)) 
                .ToDictionary(
                    exchange => exchange.code,
                    exchange => isBuyOperation ? exchange.rates.buy.value : exchange.rates.sell.value
                );
        }

        // Вложенные классы
        public class RaiffeisenApiResponse
        {
            public bool success { get; set; }
            public RaiffeisenData data { get; set; }
        }

        public class RaiffeisenData
        {
            public List<RaiffeisenRate> rates { get; set; }
        }

        public class RaiffeisenRate
        {
            public string code { get; set; } 
            public List<ExchangeRate> exchange { get; set; }
        }

        public class ExchangeRate
        {
            public string code { get; set; }
            public ExchangeValues rates { get; set; }
        }

        public class ExchangeValues
        {
            public RateValue sell { get; set; }
            public RateValue buy { get; set; } 
        }

        public class RateValue
        {
            public double value { get; set; }  
            public int direction { get; set; }  
            public int multiplier { get; set; }  
        }
    }
}


