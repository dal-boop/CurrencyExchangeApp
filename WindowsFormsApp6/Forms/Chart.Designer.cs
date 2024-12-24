namespace WindowsFormsApp6.Forms
{
    partial class Chart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend15 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cmbCurrency = new ReaLTaiizor.Controls.CrownComboBox();
            this.chartCurrency = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblCurrencyInfo = new System.Windows.Forms.Label();
            this.lblChangePercentage = new System.Windows.Forms.Label();
            this.crownButton1 = new ReaLTaiizor.Controls.CrownButton();
            this.crownButton2 = new ReaLTaiizor.Controls.CrownButton();
            this.crownButton3 = new ReaLTaiizor.Controls.CrownButton();
            this.btnExportToExcel = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpEndDate = new WindowsFormsApp6.Classes.dtp();
            this.dtpStartDate = new WindowsFormsApp6.Classes.dtp();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.poisonToolTip1 = new ReaLTaiizor.Controls.PoisonToolTip();
            ((System.ComponentModel.ISupportInitialize)(this.chartCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportToExcel)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(12, 17);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(309, 28);
            this.cmbCurrency.TabIndex = 19;
            this.cmbCurrency.SelectedIndexChanged += new System.EventHandler(this.cmbCurrency_SelectedIndexChanged);
            // 
            // chartCurrency
            // 
            chartArea15.Name = "ChartArea1";
            this.chartCurrency.ChartAreas.Add(chartArea15);
            legend15.Name = "Legend1";
            this.chartCurrency.Legends.Add(legend15);
            this.chartCurrency.Location = new System.Drawing.Point(-37, 142);
            this.chartCurrency.Name = "chartCurrency";
            series15.ChartArea = "ChartArea1";
            series15.Legend = "Legend1";
            series15.Name = "Series1";
            this.chartCurrency.Series.Add(series15);
            this.chartCurrency.Size = new System.Drawing.Size(692, 297);
            this.chartCurrency.TabIndex = 24;
            this.chartCurrency.Text = "chart1";
            // 
            // lblCurrencyInfo
            // 
            this.lblCurrencyInfo.AutoSize = true;
            this.lblCurrencyInfo.Location = new System.Drawing.Point(-1, -2);
            this.lblCurrencyInfo.Name = "lblCurrencyInfo";
            this.lblCurrencyInfo.Size = new System.Drawing.Size(44, 16);
            this.lblCurrencyInfo.TabIndex = 28;
            this.lblCurrencyInfo.Text = "label1";
            this.lblCurrencyInfo.Visible = false;
            // 
            // lblChangePercentage
            // 
            this.lblChangePercentage.AutoSize = true;
            this.lblChangePercentage.Location = new System.Drawing.Point(-1, -2);
            this.lblChangePercentage.Name = "lblChangePercentage";
            this.lblChangePercentage.Size = new System.Drawing.Size(44, 16);
            this.lblChangePercentage.TabIndex = 29;
            this.lblChangePercentage.Text = "label1";
            this.lblChangePercentage.Visible = false;
            this.lblChangePercentage.Click += new System.EventHandler(this.lblChangePercentage_Click);
            // 
            // crownButton1
            // 
            this.crownButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.crownButton1.Location = new System.Drawing.Point(9, 7);
            this.crownButton1.Name = "crownButton1";
            this.crownButton1.Padding = new System.Windows.Forms.Padding(5);
            this.crownButton1.Size = new System.Drawing.Size(131, 28);
            this.crownButton1.TabIndex = 32;
            this.crownButton1.Text = "Месяц";
            this.crownButton1.Click += new System.EventHandler(this.crownButton1_Click);
            // 
            // crownButton2
            // 
            this.crownButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.crownButton2.Location = new System.Drawing.Point(146, 7);
            this.crownButton2.Name = "crownButton2";
            this.crownButton2.Padding = new System.Windows.Forms.Padding(5);
            this.crownButton2.Size = new System.Drawing.Size(120, 28);
            this.crownButton2.TabIndex = 33;
            this.crownButton2.Text = "Год";
            this.crownButton2.Click += new System.EventHandler(this.crownButton2_Click);
            // 
            // crownButton3
            // 
            this.crownButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.crownButton3.Location = new System.Drawing.Point(272, 7);
            this.crownButton3.Name = "crownButton3";
            this.crownButton3.Padding = new System.Windows.Forms.Padding(5);
            this.crownButton3.Size = new System.Drawing.Size(120, 28);
            this.crownButton3.TabIndex = 34;
            this.crownButton3.Text = "Все время";
            this.crownButton3.Click += new System.EventHandler(this.crownButton3_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExportToExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.btnExportToExcel.Image = global::WindowsFormsApp6.Properties.Resources.icons8_pdf_28;
            this.btnExportToExcel.Location = new System.Drawing.Point(443, 10);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(42, 41);
            this.btnExportToExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnExportToExcel.TabIndex = 37;
            this.btnExportToExcel.TabStop = false;
            this.poisonToolTip1.SetToolTip(this.btnExportToExcel, "Экспортирует график в формате .pdf");
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.crownButton3);
            this.groupBox1.Controls.Add(this.crownButton1);
            this.groupBox1.Controls.Add(this.crownButton2);
            this.groupBox1.Location = new System.Drawing.Point(2, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 35);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.dtpEndDate.BorderSize = 0;
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dtpEndDate.Location = new System.Drawing.Point(220, 10);
            this.dtpEndDate.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(208, 35);
            this.dtpEndDate.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.dtpEndDate.TabIndex = 35;
            this.dtpEndDate.TextColor = System.Drawing.Color.White;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.dtpStartDate.BorderSize = 0;
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.dtpStartDate.Location = new System.Drawing.Point(6, 10);
            this.dtpStartDate.MinimumSize = new System.Drawing.Size(4, 35);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(208, 35);
            this.dtpStartDate.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.dtpStartDate.TabIndex = 31;
            this.dtpStartDate.TextColor = System.Drawing.Color.White;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpStartDate);
            this.groupBox2.Controls.Add(this.dtpEndDate);
            this.groupBox2.Controls.Add(this.btnExportToExcel);
            this.groupBox2.Location = new System.Drawing.Point(6, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(521, 51);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            // 
            // poisonToolTip1
            // 
            this.poisonToolTip1.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue;
            this.poisonToolTip1.StyleManager = null;
            this.poisonToolTip1.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light;
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(574, 405);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblChangePercentage);
            this.Controls.Add(this.lblCurrencyInfo);
            this.Controls.Add(this.chartCurrency);
            this.Controls.Add(this.cmbCurrency);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Chart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chart";
            ((System.ComponentModel.ISupportInitialize)(this.chartCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExportToExcel)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.CrownComboBox cmbCurrency;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCurrency;
        private System.Windows.Forms.Label lblCurrencyInfo;
        private System.Windows.Forms.Label lblChangePercentage;
        private Classes.dtp dtpStartDate;
        private ReaLTaiizor.Controls.CrownButton crownButton1;
        private ReaLTaiizor.Controls.CrownButton crownButton2;
        private ReaLTaiizor.Controls.CrownButton crownButton3;
        private Classes.dtp dtpEndDate;
        private System.Windows.Forms.PictureBox btnExportToExcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ReaLTaiizor.Controls.PoisonToolTip poisonToolTip1;
    }
}