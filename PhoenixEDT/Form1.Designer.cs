namespace PhoenixEDT
{
    partial class Form1
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
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.To = new System.Windows.Forms.Label();
            this.From = new System.Windows.Forms.Label();
            this.EziDebitSingleID = new System.Windows.Forms.TextBox();
            this.GetPaymentsBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.responseText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.digitalKey = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.GetCustomerListBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CustomerStatus = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.responseText2 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.paymentCountLabel = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.serviceTimer = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "yyyy-MM-dd";
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(460, 60);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(119, 20);
            this.dateTo.TabIndex = 9;
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "yyyy-MM-dd";
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(460, 12);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(119, 20);
            this.dateFrom.TabIndex = 8;
            // 
            // To
            // 
            this.To.AutoSize = true;
            this.To.Location = new System.Drawing.Point(424, 66);
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(20, 13);
            this.To.TabIndex = 7;
            this.To.Text = "To";
            // 
            // From
            // 
            this.From.AutoSize = true;
            this.From.Location = new System.Drawing.Point(424, 19);
            this.From.Name = "From";
            this.From.Size = new System.Drawing.Size(30, 13);
            this.From.TabIndex = 6;
            this.From.Text = "From";
            // 
            // EziDebitSingleID
            // 
            this.EziDebitSingleID.Location = new System.Drawing.Point(91, 2);
            this.EziDebitSingleID.Name = "EziDebitSingleID";
            this.EziDebitSingleID.Size = new System.Drawing.Size(199, 20);
            this.EziDebitSingleID.TabIndex = 10;
            // 
            // GetPaymentsBtn
            // 
            this.GetPaymentsBtn.Location = new System.Drawing.Point(12, 114);
            this.GetPaymentsBtn.Name = "GetPaymentsBtn";
            this.GetPaymentsBtn.Size = new System.Drawing.Size(185, 23);
            this.GetPaymentsBtn.TabIndex = 11;
            this.GetPaymentsBtn.Text = "GetPayments for Ezidebit ID";
            this.GetPaymentsBtn.UseVisualStyleBackColor = true;
            this.GetPaymentsBtn.Click += new System.EventHandler(this.GetPaymentsBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ezidebit ID:";
            // 
            // responseText
            // 
            this.responseText.Location = new System.Drawing.Point(22, 203);
            this.responseText.Multiline = true;
            this.responseText.Name = "responseText";
            this.responseText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.responseText.Size = new System.Drawing.Size(854, 297);
            this.responseText.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "DIGITAL KEY:";
            // 
            // digitalKey
            // 
            this.digitalKey.Location = new System.Drawing.Point(91, 46);
            this.digitalKey.Name = "digitalKey";
            this.digitalKey.Size = new System.Drawing.Size(286, 20);
            this.digitalKey.TabIndex = 15;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(22, 79);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 17);
            this.radioButton1.TabIndex = 16;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "PAYMENT";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(112, 79);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(97, 17);
            this.radioButton2.TabIndex = 17;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "SETTLEMENT";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // GetCustomerListBtn
            // 
            this.GetCustomerListBtn.Location = new System.Drawing.Point(872, 9);
            this.GetCustomerListBtn.Name = "GetCustomerListBtn";
            this.GetCustomerListBtn.Size = new System.Drawing.Size(190, 23);
            this.GetCustomerListBtn.TabIndex = 18;
            this.GetCustomerListBtn.Text = "GetCustomerList";
            this.GetCustomerListBtn.UseVisualStyleBackColor = true;
            this.GetCustomerListBtn.Click += new System.EventHandler(this.GetCustomerListBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(818, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Status(ALL|HOLD|PENDING|CANCELLED|ACTIVE):";
            // 
            // CustomerStatus
            // 
            this.CustomerStatus.Location = new System.Drawing.Point(924, 55);
            this.CustomerStatus.Name = "CustomerStatus";
            this.CustomerStatus.Size = new System.Drawing.Size(147, 20);
            this.CustomerStatus.TabIndex = 20;
            this.CustomerStatus.Text = "ALL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(892, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Pages to retrieve (max 100):";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1028, 80);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(43, 20);
            this.textBox2.TabIndex = 23;
            this.textBox2.Text = "1";
            // 
            // responseText2
            // 
            this.responseText2.Location = new System.Drawing.Point(882, 203);
            this.responseText2.Multiline = true;
            this.responseText2.Name = "responseText2";
            this.responseText2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.responseText2.Size = new System.Drawing.Size(189, 297);
            this.responseText2.TabIndex = 24;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(872, 124);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(199, 23);
            this.progressBar1.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(355, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(290, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "GetPayments for GetCustomerList";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(22, 160);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(1049, 23);
            this.progressBar2.TabIndex = 27;
            // 
            // paymentCountLabel
            // 
            this.paymentCountLabel.AutoSize = true;
            this.paymentCountLabel.Location = new System.Drawing.Point(424, 187);
            this.paymentCountLabel.Name = "paymentCountLabel";
            this.paymentCountLabel.Size = new System.Drawing.Size(85, 13);
            this.paymentCountLabel.TabIndex = 28;
            this.paymentCountLabel.Text = "Payment Count: ";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(895, 101);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(122, 17);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Text = "Only get single page";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // serviceTimer
            // 
            this.serviceTimer.AutoSize = true;
            this.serviceTimer.Location = new System.Drawing.Point(587, 35);
            this.serviceTimer.Name = "serviceTimer";
            this.serviceTimer.Size = new System.Drawing.Size(109, 17);
            this.serviceTimer.TabIndex = 30;
            this.serviceTimer.Text = "Service timer only";
            this.serviceTimer.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 512);
            this.Controls.Add(this.serviceTimer);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.paymentCountLabel);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.responseText2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CustomerStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GetCustomerListBtn);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.digitalKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.responseText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GetPaymentsBtn);
            this.Controls.Add(this.EziDebitSingleID);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.To);
            this.Controls.Add(this.From);
            this.Name = "Form1";
            this.Text = "PhoenixEDT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label To;
        private System.Windows.Forms.Label From;
        private System.Windows.Forms.TextBox EziDebitSingleID;
        private System.Windows.Forms.Button GetPaymentsBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox responseText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox digitalKey;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button GetCustomerListBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CustomerStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox responseText2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label paymentCountLabel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox serviceTimer;
    }
}

