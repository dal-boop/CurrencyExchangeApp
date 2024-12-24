using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WindowsFormsApp6.Classes;


namespace WindowsFormsApp6
{
    public partial class SignUp : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

        private Color placeholderColor = Color.Black;
        private Color textColor = Color.Black;

        private bool isPasswordVisible = false;
        public SignUp()
        {
            InitializeComponent();
            SetupPlaceholder(txtLogin, "Введите логин");
            SetupPlaceholder(txtEmail, "Введите email");
            AddMaterialLabel(txtLogin);
            AddMaterialLabel(txtPassword);
            AddMaterialLabel(txtRePassword);
            AddMaterialLabel(txtEmail);
            lblDragArea.MouseDown += lblDragArea_MouseDown;
            lblDragAreaTwo.MouseDown += lblDragArea_MouseDown;

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

        private void lblDragArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }


        private void SetupPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }



        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {
                return;
            }

            
            if (!Char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '_')
            {
                e.Handled = true; 
            }
        }
    

        private void textBox1_Leave(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panelRight_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void label7_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void label7_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtLogin.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string confirmpassword = txtRePassword.Text;

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пароль не может быть пустым.");
                return;
            }

            if (password != confirmpassword)
            {
                MessageBox.Show("Пароли не совпадают. Повторите ввод.");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Неверный формат электронной почты.");
                return;
            }

            UserRegistration userRegistration = new UserRegistration();
            bool success = userRegistration.RegisterUser(username, email, password);

            if (success)
            {
                MessageBox.Show("Регистрация успешна!");
            }
            else
            {
                MessageBox.Show("Пользователь с таким именем или почтой уже существует. Выберите другие данные.", "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsValidEmail(string email)
        {
            var emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDragAreaTwo_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            {
                if (isPasswordVisible)
                {
                    txtPassword.PasswordChar = '•'; 
                    txtRePassword.PasswordChar= '•';
                    pictureBoxEye.Image = Properties.Resources.eye; 
                    isPasswordVisible = false; 
                }
                else
                {
                    txtPassword.PasswordChar = char.MinValue;
                    txtRePassword.PasswordChar = char.MinValue;
                    pictureBoxEye.Image = Properties.Resources.hide; 
                    isPasswordVisible = true; 
                }
            }
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var myForm = new Auth();
            myForm.Show();
        }
    }

    
}
