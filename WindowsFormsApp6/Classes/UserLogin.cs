using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6.Classes
{
    public class UserLogin
    {
        private string connectionString = "Server=DALERDERDEN;Database=exchangeapp;Integrated Security=True;";

        public bool LoginUser(string loginOrEmail, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return false; // Пароль не может быть пустым
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string hashedPassword = HashPassword(password);

                    string query = @"SELECT COUNT(*) 
                             FROM Users 
                             WHERE (Username = @LoginOrEmail OR Email = @LoginOrEmail) 
                             AND PasswordHash = @PasswordHash";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LoginOrEmail", loginOrEmail);
                        cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                        int count = (int)cmd.ExecuteScalar();

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public int? GetUserId(string loginOrEmail, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string hashedPassword = HashPassword(password);

                    string query = @"SELECT ID 
                             FROM Users 
                             WHERE (Username = @LoginOrEmail OR Email = @LoginOrEmail) 
                             AND PasswordHash = @PasswordHash";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LoginOrEmail", loginOrEmail);
                        cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                        object result = cmd.ExecuteScalar();
                        return result != null ? (int?)Convert.ToInt32(result) : null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
