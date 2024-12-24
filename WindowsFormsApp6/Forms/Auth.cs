using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp6.Classes;

namespace WindowsFormsApp6
{
    public partial class Auth : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private bool isPasswordVisible = false;
        public Auth()
        {
            InitializeComponent();
            AddMaterialLabel(textBoxlogin);
            AddMaterialLabel(textBoxPassword);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public void AddMaterialLabel(TextBox textBox)
        {
            var label = new Label()
            {
                Height = 1,
                Dock = DockStyle.Bottom,
                BackColor = Color.Black
            };

            textBox.Controls.Add(label);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            var myForm = new SignUp();
            myForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string loginOrEmail = textBoxlogin.Text;
            string password = textBoxPassword.Text;

            UserLogin userLogin = new UserLogin();
            int? userId = userLogin.GetUserId(loginOrEmail, password);

            if (userId != null)
            {
                MessageBox.Show("Авторизация успешна!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Сохраняем данные текущего пользователя
                SessionManager.CurrentUserId = userId;
                SessionManager.CurrentUsername = loginOrEmail;

                // Сохраняем состояние "Оставаться в системе"
                if (chkRememberMe.Checked)
                {
                    Properties.Settings.Default.RememberMe = true;
                    Properties.Settings.Default.SavedUsername = loginOrEmail;
                    Properties.Settings.Default.SavedUserId = userId.Value;
                    Properties.Settings.Default.IsLoggedIn = true;
                }
                else
                {
                    Properties.Settings.Default.RememberMe = false;
                    Properties.Settings.Default.IsLoggedIn = false;
                    Properties.Settings.Default.SavedUsername = "";
                    Properties.Settings.Default.SavedUserId = 0;
                }

                Properties.Settings.Default.Save();

                // Переход на главную форму
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неправильный логин/почта или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void label5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var myForm = new SignUp();
            myForm.FormClosed += (x, y) => this.Close();
            myForm.Show();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxEye_Click(object sender, EventArgs e)
        {
            {
                if (isPasswordVisible)
                {
                    textBoxPassword.PasswordChar = '•';
                    pictureBoxEye.Image = Properties.Resources.eye;
                    isPasswordVisible = false;
                }
                else
                {
                    textBoxPassword.PasswordChar = char.MinValue;
                    pictureBoxEye.Image = Properties.Resources.hide;
                    isPasswordVisible = true;
                }
            }
        }

        private void lblDragAreaTwo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Auth_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RememberMe)
            {
                string savedUsername = Properties.Settings.Default.SavedUsername;
                textBoxlogin.Text = savedUsername;
                chkRememberMe.Checked = true;

                // Попробуем авторизовать пользователя по имени
                UserLogin userLogin = new UserLogin();
                int? userId = userLogin.GetUserId(savedUsername, null); // Не передаем пароль, так как он уже сохранен

                if (userId != null)
                {
                    // Устанавливаем текущего пользователя в SessionManager
                    SessionManager.CurrentUserId = userId;
                    SessionManager.CurrentUsername = savedUsername;
                }
            }
            else
            {
                textBoxlogin.Text = "";
                chkRememberMe.Checked = false;
            }
        }
    }
}

    

