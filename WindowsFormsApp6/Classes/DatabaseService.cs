using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WindowsFormsApp6.RaiffeisenApiService;

namespace WindowsFormsApp6
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Сохраняем операцию обмена
        public void SaveExchangeOperation(ExchangeOperation operation)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    @"INSERT INTO ExchangeOperations (FromCurrency, ToCurrency, Amount, ResultAmount, ExchangeRate, Commission, OperationDate)
                  VALUES (@from, @to, @amount, @result, @rate, @commission, @date)", connection);

                command.Parameters.AddWithValue("@from", operation.FromCurrency);
                command.Parameters.AddWithValue("@to", operation.ToCurrency);
                command.Parameters.AddWithValue("@amount", operation.Amount);
                command.Parameters.AddWithValue("@result", operation.ResultAmount);
                command.Parameters.AddWithValue("@rate", operation.ExchangeRate);
                command.Parameters.AddWithValue("@commission", operation.Commission);
                command.Parameters.AddWithValue("@date", operation.OperationDate);

                command.ExecuteNonQuery();
            }
        }
    }
}

        // Сохраняем данные о курсах валют
    //    public void SaveCurrencyRates(List<Currency> currencies)
    //    {
    //        using (var connection = new SqlConnection(_connectionString))
    //        {
    //            connection.Open();
    //            foreach (var currency in currencies)
    //            {
    //                var command = new SqlCommand(
    //                    @"IF NOT EXISTS (SELECT 1 FROM ExchangeRates WHERE CurrencyId = 
    //                  (SELECT CurrencyId FROM Currencies WHERE CharCode = @charCode) AND Date = @date)
    //                  BEGIN
    //                      INSERT INTO ExchangeRates (CurrencyId, Rate, Date)
    //                      VALUES ((SELECT CurrencyId FROM Currencies WHERE CharCode = @charCode), @rate, @date)
    //                  END", connection);

    //                command.Parameters.AddWithValue("@charCode", currency.CharCode);
    //                command.Parameters.AddWithValue("@rate", currency.Rate);
    //                command.Parameters.AddWithValue("@date", currency.Date);

    //                command.ExecuteNonQuery();
    //            }
    //        }
    //    }
    //}
//}

