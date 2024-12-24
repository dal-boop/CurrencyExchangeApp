using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6.Classes
{
    public class CurrencyOperationService
    {
        private string connectionString = "Server=DALERDERDEN;Database=exchangeapp;Integrated Security=True;";

        public void SaveOperation(int userId, string fromCurrency, string toCurrency, double amount, double result, double commission, string bankName, string operationType)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO CurrencyOperations 
                                (UserID, FromCurrency, ToCurrency, Amount, Result, Commission, DateCreated, BankName, OperationType) 
                                VALUES 
                                (@UserID, @FromCurrency, @ToCurrency, @Amount, @Result, @Commission, @DateCreated, @BankName, @OperationType)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@FromCurrency", fromCurrency);
                        cmd.Parameters.AddWithValue("@ToCurrency", toCurrency);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@Result", result);
                        cmd.Parameters.AddWithValue("@Commission", commission);
                        cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);
                        cmd.Parameters.AddWithValue("@BankName", bankName);
                        cmd.Parameters.AddWithValue("@OperationType", operationType);  // Используем динамический тип операции

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении операции: {ex.Message}");
            }
        }
    }
}

