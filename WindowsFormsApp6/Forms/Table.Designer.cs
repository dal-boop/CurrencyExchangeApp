namespace WindowsFormsApp6
{
    partial class Table
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCurrencyRates = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportToExcel = new System.Windows.Forms.PictureBox();
            this.btnLoadRates = new ReaLTaiizor.Controls.CrownButton();
            this.dateTimePicker = new WindowsFormsApp6.Classes.dtp();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.poisonToolTip1 = new ReaLTaiizor.Controls.PoisonToolTip();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrencyRates)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportToExcel)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCurrencyRates
            // 
            this.dgvCurrencyRates.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvCurrencyRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrencyRates.Location = new System.Drawing.Point(25, 91);
            this.dgvCurrencyRates.Name = "dgvCurrencyRates";
            this.dgvCurrencyRates.RowHeadersWidth = 51;
            this.dgvCurrencyRates.Size = new System.Drawing.Size(388, 381);
            this.dgvCurrencyRates.TabIndex = 0;
            this.dgvCurrencyRates.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCurrencyRates_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.dgvCurrencyRates);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 484);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExportToExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.btnExportToExcel.Image = global::WindowsFormsApp6.Properties.Resources.icons8_xlsx_42;
            this.btnExportToExcel.Location = new System.Drawing.Point(338, 15);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(50, 41);
            this.btnExportToExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnExportToExcel.TabIndex = 38;
            this.btnExportToExcel.TabStop = false;
            this.poisonToolTip1.SetToolTip(this.btnExportToExcel, "Экспортирует таблицу в формат .xlsx");
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnLoadRates
            // 
            this.btnLoadRates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.btnLoadRates.Location = new System.Drawing.Point(193, 15);
            this.btnLoadRates.Name = "btnLoadRates";
            this.btnLoadRates.Padding = new System.Windows.Forms.Padding(5);
            this.btnLoadRates.Size = new System.Drawing.Size(139, 41);
            this.btnLoadRates.TabIndex = 39;
            this.btnLoadRates.Text = "Загрузить";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.dateTimePicker.BorderSize = 0;
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dateTimePicker.Location = new System.Drawing.Point(0, 16);
            this.dateTimePicker.MinimumSize = new System.Drawing.Size(0, 35);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(187, 35);
            this.dateTimePicker.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.dateTimePicker.TabIndex = 40;
            this.dateTimePicker.TextColor = System.Drawing.Color.White;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.btnLoadRates);
            this.groupBox1.Controls.Add(this.dateTimePicker);
            this.groupBox1.Controls.Add(this.btnExportToExcel);
            this.groupBox1.Location = new System.Drawing.Point(24, -7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 57);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // poisonToolTip1
            // 
            this.poisonToolTip1.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            this.poisonToolTip1.StyleManager = null;
            this.poisonToolTip1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            // 
            // Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(441, 484);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Table";
            this.Text = "Table";
            this.Load += new System.EventHandler(this.Table_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrencyRates)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExportToExcel)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCurrencyRates;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnExportToExcel;
        private ReaLTaiizor.Controls.CrownButton btnLoadRates;
        private Classes.dtp dateTimePicker;
        private System.Windows.Forms.GroupBox groupBox1;
        private ReaLTaiizor.Controls.PoisonToolTip poisonToolTip1;
    }
}