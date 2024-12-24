using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6.Forms
{
    public partial class Currencyop : Form
    {
        private string connectionString = "Server=DALERDERDEN;Database=exchangeapp;Integrated Security=True;";

        public Currencyop()
        {
            InitializeComponent();
            LoadHistory();
        }

        private void LoadHistory()
        {
            try
            {
                int? userId = GetCurrentUserId();
                if (userId == null)
                {
                    MessageBox.Show("Пользователь не авторизован.");
                    return; // Выход из метода, если пользователь не авторизован
                }

                // Загрузка данных из базы
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT c.ID, c.DateCreated, c.BankName, c.FromCurrency, c.ToCurrency, 
                             c.Amount, c.Result, c.Commision 
                             FROM CurrencyOperations c
                             WHERE c.UserID = @UserID";  // Фильтруем по UserID

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId.Value); // Передаем userId в запрос

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        dataGridViewHistory.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке истории операций: {ex.Message}");
            }
        }

        private int? GetCurrentUserId()
        {
            // Проверяем, что пользователь авторизован и есть сохраненный userId
            if (Properties.Settings.Default.IsLoggedIn && Properties.Settings.Default.SavedUserId != 0)
            {
                return Properties.Settings.Default.SavedUserId;
            }
            return null; // Если пользователь не авторизован
        }
    }
}

