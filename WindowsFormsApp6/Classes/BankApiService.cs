using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static WindowsFormsApp6.RaiffeisenApiService;

namespace WindowsFormsApp6
{
    public class BankApiService
    {
        private readonly HttpClient _httpClient;

        public BankApiService()
        {
            _httpClient = new HttpClient();
        }

        // Получаем курсы валют от API ЦБ РФ за конкретную дату
        public async Task<List<Currency>> GetCurrencyRatesAsync(DateTime date)
        {
            // Формируем URL с параметром даты
            string url = $"https://www.cbr.ru/scripts/XML_daily.asp?date_req={date:dd/MM/yyyy}";
            var response = await _httpClient.GetStringAsync(url);

            return ParseCurrencyData(response);
        }

        private List<Currency> ParseCurrencyData(string xmlResponse)
        {
            var currencies = new List<Currency>();
            var xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml(xmlResponse);

            var nodes = xmlDoc.GetElementsByTagName("Valute");

            foreach (System.Xml.XmlNode node in nodes)
            {
                var charCode = node["CharCode"]?.InnerText;
                var name = node["Name"]?.InnerText;
                var valueString = node["Value"]?.InnerText;
                var nominalString = node["Nominal"]?.InnerText;

                if (double.TryParse(valueString, out var value) &&
                    int.TryParse(nominalString, out var nominal) &&
                    !string.IsNullOrEmpty(charCode))
                {
                    value = value / nominal; // Учет номинала

                    currencies.Add(new Currency
                    {
                        CharCode = charCode,
                        Name = name,
                        Rate = value
                    });
                }
            }

            return currencies;
        }
    }
}









