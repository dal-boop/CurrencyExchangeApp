using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    public class AlfaBankApiService
    {
        private readonly HttpClient _httpClient; //Экземпляр для выполнения HTTP запросов

        public AlfaBankApiService()
        {
            _httpClient = new HttpClient();
        }
        //Получаем АСИНХРОННО курсы валют от API Альфа банка, 
        public async Task<Dictionary<string, double>> GetCurrencyRatesAsync(bool isBuyOperation)
        {
            string url = "https://alfabank.ru/ext-json/0.2/exchange/cash/?offset=0&limit=2&mode=rest";
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Ответ API Alfa-Bank: {json}"); 

                return ParseAlfaBankCurrencyData(json, isBuyOperation);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при запросе к API Альфа-Банка: {ex.Message}");
                return null;
            }
        }
        //Парсим JSON-строку с данными о курсах валют
        private Dictionary<string, double> ParseAlfaBankCurrencyData(string json, bool isBuyOperation)
        {
            var rates = JsonConvert.DeserializeObject<Dictionary<string, List<AlfaRate>>>(json);

            if (rates == null || rates.Count == 0)
            {
                Console.WriteLine("Ошибка: пустой ответ или неверный формат данных.");
                return null;
            }

            var result = new Dictionary<string, double>();

            foreach (var currency in rates)
            {
                var rate = currency.Value.FirstOrDefault(r => r.type == (isBuyOperation ? "buy" : "sell"));
                if (rate != null)
                {
                    result[currency.Key.ToUpper()] = rate.value;
                }
            }

            return result;
        }
        //Аналогичная ситуация как у ЦБ РФ. Определяем класс для представления данных о курсе валюты
        public class AlfaRate
        {
            public string type { get; set; } //Тип валюты (имеется ввиду продажа или покупка, ведь курс у них от этого меняется)
            public string date { get; set; } //Дата обновления API (Не используется)
            public double value { get; set; } //Отношение валюты к рублю
            public string order { get; set; }
        }
    }
}
