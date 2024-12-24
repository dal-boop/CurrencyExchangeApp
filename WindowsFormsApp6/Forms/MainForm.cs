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
using WindowsFormsApp6.Forms;

namespace WindowsFormsApp6
{
    public partial class MainForm : Form
    {
        private Timer GraphicsTimer;
        private int targetWidth = 666;
        bool sidebarExpand = true;
        private int originalWidth = 550;
        private bool isExpanding = true;
        private Button activeButton;
        private Dictionary<Button, Color> originalButtonColors = new Dictionary<Button, Color>();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        public MainForm()
        {
            InitializeComponent();
            GraphicsTimer = new Timer();
            GraphicsTimer.Interval = 10; // Интервал в миллисекундах
            GraphicsTimer.Tick += GraphicsTimer_Tick;
            originalButtonColors.Add(btnBuy, btnBuy.BackColor);
            originalButtonColors.Add(btnSell, btnSell.BackColor);
            originalButtonColors.Add(btnRates, btnRates.BackColor);
            btnBuy.Click += Button_Click;
            btnSell.Click += Button_Click;
            btnRates.Click += Button_Click;
            this.Resize += MainForm_Resize;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }
        private void mdiProp()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232, 234, 237);
        }

        private void LoadFormInPanel(Form form)
        {
            panelContainer.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(form);
            form.Show();
        }




        private void MainForm_Resize(object sender, EventArgs e)
        {
            UpdatePanelContainer();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdatePanelContainer();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            if (activeButton != null && originalButtonColors.ContainsKey(activeButton))
            {
                activeButton.BackColor = originalButtonColors[activeButton];
            }
            activeButton = (Button)sender;
            activeButton.BackColor = Color.FromArgb(102, 102, 153);
            string buttonName = activeButton.Name;
            switch (buttonName)
            {
                case "btnBuy":
                    LoadFormInPanel(new BuyForm());
                    break;
                case "btnSell":
                    LoadFormInPanel(new SelllForm());
                    break;
                case "btnRates":
                    LoadFormInPanel(new Table());
                    break;

            }
        }




        private void btnSell_Click(object sender, EventArgs e)
        {

        }

        private void btnBuy_Click(object sender, EventArgs e)
        {

        }

        private void btnRates_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            var buyForm = new BuyForm();
            LoadFormInPanel(buyForm);
            label1.Text = "Покупка";
            isExpanding = false;
            GraphicsTimer.Start();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            var selllForm = new SelllForm();
            LoadFormInPanel(selllForm);
            label1.Text = "Продажа";
            isExpanding = false;
            GraphicsTimer.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var tableForm = new Table();
            LoadFormInPanel(tableForm);
            label1.Text = "Курс валют";
            isExpanding = false;
            GraphicsTimer.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximaze_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimaze_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxBank_Click(object sender, EventArgs e)
        {

        }
        private void AdjustFormSize()
        {
            if (panelContainer.Controls.Count > 0)
            {
                var form = panelContainer.Controls[0];
                form.Dock = DockStyle.Fill;
            }
        }


        bool menuExpand = false;
        private void MenuTimer_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                MenuContainer.Height += 10;
                if (MenuContainer.Height >= 270)
                {
                    MenuTimer.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                MenuContainer.Height -= 10;
                if (MenuContainer.Height <= 60)
                {
                    MenuTimer.Stop();
                    menuExpand = false;
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MenuTimer.Start();

            

        }


        private void timerSideBar_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 5;
                if (sidebar.Width <= 63)
                {
                    sidebarExpand = false;
                    timerSideBar.Stop();
                    UpdatePanelContainer();
                }
            }
            else
            {
                sidebar.Width += 5;
                if (sidebar.Width >= 202)
                {
                    sidebarExpand = true;
                    timerSideBar.Stop();
                    UpdatePanelContainer();
                }
            }
        }

        private void UpdatePanelContainer()
        {
            if (sidebar.Width > 0)
            {
                panelContainer.Location = new Point(sidebar.Width, panelContainer.Location.Y);
                panelContainer.Width = this.ClientSize.Width - sidebar.Width;
            }
            else
            {
                panelContainer.Location = new Point(0, panelContainer.Location.Y);
                panelContainer.Width = this.ClientSize.Width;
            }

            if (panelContainer.Controls.Count > 0)
            {
                var form = panelContainer.Controls[0] as Form;
                if (form != null)
                {
                    form.Dock = DockStyle.Fill;
                }
            }
        }


        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            timerSideBar.Start();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void controlBoxEdit1_Click(object sender, EventArgs e)
        {

        }

        private void nightControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblDragAreaTwo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.RememberMe = false;
            Properties.Settings.Default.SavedUsername = "";
            Properties.Settings.Default.Save();

            Auth authForm = new Auth();
            authForm.Show();
            this.Close();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var s = new Chart();
            LoadFormInPanel(s);
            label1.Text = "Покупка";

            isExpanding = true;
            GraphicsTimer.Start();


        }

        private void GraphicsTimer_Tick(object sender, EventArgs e)
        {
            if (isExpanding)
            {
                // Увеличиваем ширину формы
                if (this.Width < targetWidth)
                {
                    this.Width += 20; // Шаг увеличения
                }
                else
                {
                    GraphicsTimer.Stop(); // Останавливаем таймер, если достигли целевой ширины
                }
            }
            else
            {
                // Уменьшаем ширину формы
                if (this.Width > originalWidth)
                {
                    this.Width -= 20; // Шаг уменьшения
                }
                else
                {
                    GraphicsTimer.Stop(); // Останавливаем таймер, если вернулись к исходной ширине
                }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            var oper = new Currencyop();
            LoadFormInPanel(oper);
            label1.Text = "Продажа";
            isExpanding = false;
            GraphicsTimer.Start();
        }
    }
}
