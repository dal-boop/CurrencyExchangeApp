using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp6.Forms;

namespace WindowsFormsApp6
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Проверка флага IsLoggedIn
            if (Properties.Settings.Default.IsLoggedIn && Properties.Settings.Default.RememberMe)
            {
                // Если авторизован, открываем сразу главную форму
                Application.Run(new MainForm());
            }
            else
            {
                // Иначе показываем форму авторизации
                Application.Run(new Auth());
            }
        }
    }
}
