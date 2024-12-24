using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6.Classes
{
    public class SberBankApiService
    {
        private readonly HttpClient _httpClient;

        public SberBankApiService()
        {
            _httpClient = new HttpClient();
        }

       
        public async Task<Dictionary<string, double>> GetCurrencyRatesAsync(bool isBuyOperation)
        {
            string url = "https://www.sberbank.ru/proxy/services/rates/public/v2/actual?rateType=ERNP-2&isoCodes[]=USD&isoCodes[]=EUR&isoCodes[]=CNY&isoCodes[]=TRY&isoCodes[]=BYN&isoCodes[]=KZT&isoCodes[]=AED&isoCodes[]=GBP&isoCodes[]=SGD&isoCodes[]=INR&isoCodes[]=SEK&isoCodes[]=NOK&isoCodes[]=CAD&isoCodes[]=CHF&isoCodes[]=JPY&regionId=042";

            try
            {
                var response = await _httpClient.GetAsync(url);

                Console.WriteLine($"HTTP Status Code: {response.StatusCode}");

                var json = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"Ответ API Сбербанка: {json}");

                if (json.StartsWith("{") || json.StartsWith("["))
                {
                    return ParseSberBankCurrencyData(json, isBuyOperation);
                }
                else
                {
                    Console.WriteLine("Ошибка: ответ не является JSON.");
                    
                    if (json.Contains("<html>"))
                    {
                        Console.WriteLine("Ответ от сервера выглядит как HTML-страница (возможно ошибка).");
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при запросе к API Сбербанка: {ex.Message}");
                return null;
            }
        }

        private Dictionary<string, double> ParseSberBankCurrencyData(string json, bool isBuyOperation)
        {
            var rates = JsonConvert.DeserializeObject<Dictionary<string, SberBankRate>>(json);

            if (rates == null || rates.Count == 0)
            {
                Console.WriteLine("Ошибка: пустой ответ или неверный формат данных.");
                return null;
            }

            var result = new Dictionary<string, double>();

            foreach (var currency in rates)
            {
                var rateList = currency.Value.rateList?.FirstOrDefault();
                if (rateList != null)
                {
                    double rate = isBuyOperation ? rateList.rateBuy : rateList.rateSell;
                    if (rate > 0)
                    {
                        result[currency.Key.ToUpper()] = rate;
                    }
                }
            }

            return result;
        }


        public class SberBankRate
        {
            public List<SberBankRateDetails> rateList { get; set; }
        }

        public class SberBankRateDetails
        {
            public double rateBuy { get; set; }
            public double rateSell { get; set; }
        }
    }
}
