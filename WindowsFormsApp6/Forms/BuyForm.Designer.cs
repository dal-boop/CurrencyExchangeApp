namespace WindowsFormsApp6
{
    partial class BuyForm
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
            this.lblWithoutCommission = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxBank12 = new System.Windows.Forms.PictureBox();
            this.txtAmount = new ReaLTaiizor.Controls.CrownTextBox();
            this.cmbBank = new ReaLTaiizor.Controls.CrownComboBox();
            this.cmbFromCurrency = new ReaLTaiizor.Controls.CrownComboBox();
            this.cmbToCurrency = new ReaLTaiizor.Controls.CrownComboBox();
            this.btnCalculate = new ReaLTaiizor.Controls.CrownButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.crownButton1 = new ReaLTaiizor.Controls.CrownButton();
            this.foxLabel2 = new ReaLTaiizor.Controls.FoxLabel();
            this.foxLabel3 = new ReaLTaiizor.Controls.FoxLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.foxLabel4 = new ReaLTaiizor.Controls.FoxLabel();
            this.foxLabel5 = new ReaLTaiizor.Controls.FoxLabel();
            this.foxLabel6 = new ReaLTaiizor.Controls.FoxLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBank12)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWithoutCommission
            // 
            this.lblWithoutCommission.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWithoutCommission.AutoSize = true;
            this.lblWithoutCommission.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWithoutCommission.Location = new System.Drawing.Point(3, 22);
            this.lblWithoutCommission.Name = "lblWithoutCommission";
            this.lblWithoutCommission.Size = new System.Drawing.Size(114, 18);
            this.lblWithoutCommission.TabIndex = 9;
            this.lblWithoutCommission.Text = "Без комиссии: ";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "С учетом комиссии: ";
            // 
            // pictureBoxBank12
            // 
            this.pictureBoxBank12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxBank12.Location = new System.Drawing.Point(6, 20);
            this.pictureBoxBank12.Name = "pictureBoxBank12";
            this.pictureBoxBank12.Size = new System.Drawing.Size(32, 29);
            this.pictureBoxBank12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBank12.TabIndex = 15;
            this.pictureBoxBank12.TabStop = false;
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtAmount.Location = new System.Drawing.Point(247, 71);
            this.txtAmount.Multiline = true;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(145, 29);
            this.txtAmount.TabIndex = 16;
            // 
            // cmbBank
            // 
            this.cmbBank.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(44, 21);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(151, 28);
            this.cmbBank.TabIndex = 17;
            // 
            // cmbFromCurrency
            // 
            this.cmbFromCurrency.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbFromCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbFromCurrency.FormattingEnabled = true;
            this.cmbFromCurrency.Location = new System.Drawing.Point(38, 131);
            this.cmbFromCurrency.Name = "cmbFromCurrency";
            this.cmbFromCurrency.Size = new System.Drawing.Size(144, 28);
            this.cmbFromCurrency.TabIndex = 18;
            // 
            // cmbToCurrency
            // 
            this.cmbToCurrency.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbToCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbToCurrency.FormattingEnabled = true;
            this.cmbToCurrency.Location = new System.Drawing.Point(233, 131);
            this.cmbToCurrency.Name = "cmbToCurrency";
            this.cmbToCurrency.Size = new System.Drawing.Size(159, 28);
            this.cmbToCurrency.TabIndex = 19;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCalculate.Location = new System.Drawing.Point(135, 218);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Padding = new System.Windows.Forms.Padding(5);
            this.btnCalculate.Size = new System.Drawing.Size(155, 24);
            this.btnCalculate.TabIndex = 20;
            this.btnCalculate.Text = "Обменять";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxBank12);
            this.groupBox1.Controls.Add(this.cmbBank);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(32, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 62);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // crownButton1
            // 
            this.crownButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.crownButton1.Location = new System.Drawing.Point(194, 132);
            this.crownButton1.Name = "crownButton1";
            this.crownButton1.Padding = new System.Windows.Forms.Padding(5);
            this.crownButton1.Size = new System.Drawing.Size(28, 28);
            this.crownButton1.TabIndex = 23;
            this.crownButton1.Text = "⇄";
            this.crownButton1.Click += new System.EventHandler(this.crownButton1_Click);
            // 
            // foxLabel2
            // 
            this.foxLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.foxLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(100)))));
            this.foxLabel2.Location = new System.Drawing.Point(60, 165);
            this.foxLabel2.Name = "foxLabel2";
            this.foxLabel2.Size = new System.Drawing.Size(142, 22);
            this.foxLabel2.TabIndex = 26;
            this.foxLabel2.Text = "У меня есть";
            // 
            // foxLabel3
            // 
            this.foxLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.foxLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(100)))));
            this.foxLabel3.Location = new System.Drawing.Point(277, 165);
            this.foxLabel3.Name = "foxLabel3";
            this.foxLabel3.Size = new System.Drawing.Size(144, 22);
            this.foxLabel3.TabIndex = 27;
            this.foxLabel3.Text = "Я получу";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblWithoutCommission);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(32, 286);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 81);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(154, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 18);
            this.label3.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(115, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 18);
            this.label1.TabIndex = 11;
            // 
            // foxLabel4
            // 
            this.foxLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.foxLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(100)))));
            this.foxLabel4.Location = new System.Drawing.Point(38, 43);
            this.foxLabel4.Name = "foxLabel4";
            this.foxLabel4.Size = new System.Drawing.Size(195, 22);
            this.foxLabel4.TabIndex = 29;
            this.foxLabel4.Text = "Выберите банк";
            // 
            // foxLabel5
            // 
            this.foxLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.foxLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(100)))));
            this.foxLabel5.Location = new System.Drawing.Point(247, 43);
            this.foxLabel5.Name = "foxLabel5";
            this.foxLabel5.Size = new System.Drawing.Size(145, 22);
            this.foxLabel5.TabIndex = 30;
            this.foxLabel5.Text = "Введите сумму:";
            // 
            // foxLabel6
            // 
            this.foxLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.foxLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(100)))));
            this.foxLabel6.Location = new System.Drawing.Point(35, 267);
            this.foxLabel6.Name = "foxLabel6";
            this.foxLabel6.Size = new System.Drawing.Size(111, 22);
            this.foxLabel6.TabIndex = 31;
            this.foxLabel6.Text = "Результат:";
            // 
            // BuyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(441, 484);
            this.Controls.Add(this.foxLabel6);
            this.Controls.Add(this.foxLabel5);
            this.Controls.Add(this.foxLabel4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.foxLabel3);
            this.Controls.Add(this.foxLabel2);
            this.Controls.Add(this.crownButton1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.cmbToCurrency);
            this.Controls.Add(this.cmbFromCurrency);
            this.Controls.Add(this.txtAmount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BuyForm";
            this.Text = "BuyForm";
            this.Load += new System.EventHandler(this.BuyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBank12)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblWithoutCommission;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxBank12;
        private ReaLTaiizor.Controls.CrownTextBox txtAmount;
        private ReaLTaiizor.Controls.CrownComboBox cmbBank;
        private ReaLTaiizor.Controls.CrownComboBox cmbFromCurrency;
        private ReaLTaiizor.Controls.CrownComboBox cmbToCurrency;
        private ReaLTaiizor.Controls.CrownButton btnCalculate;
        private System.Windows.Forms.GroupBox groupBox1;
        private ReaLTaiizor.Controls.CrownButton crownButton1;
        private ReaLTaiizor.Controls.FoxLabel foxLabel2;
        private ReaLTaiizor.Controls.FoxLabel foxLabel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private ReaLTaiizor.Controls.FoxLabel foxLabel4;
        private ReaLTaiizor.Controls.FoxLabel foxLabel5;
        private ReaLTaiizor.Controls.FoxLabel foxLabel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}