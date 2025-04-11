namespace _1A28JT_AYEMINPHYO_プログラミングⅡ課題解決型授業
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            Inputbox = new TextBox();
            Incomebtn = new Button();
            Outcomebtn = new Button();
            ResultLbl = new Label();
            label2 = new Label();
            datebox = new TextBox();
            ResultDate = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(139, 115);
            label1.Name = "label1";
            label1.Size = new Size(194, 25);
            label1.TabIndex = 0;
            label1.Text = "金額を入力してください：";
            // 
            // Inputbox
            // 
            Inputbox.Location = new Point(339, 112);
            Inputbox.Name = "Inputbox";
            Inputbox.Size = new Size(150, 31);
            Inputbox.TabIndex = 1;
            // 
            // Incomebtn
            // 
            Incomebtn.Location = new Point(259, 207);
            Incomebtn.Name = "Incomebtn";
            Incomebtn.Size = new Size(112, 34);
            Incomebtn.TabIndex = 2;
            Incomebtn.Text = "収入";
            Incomebtn.UseVisualStyleBackColor = true;
            Incomebtn.Click += Incomebtn_Click;
            // 
            // Outcomebtn
            // 
            Outcomebtn.Location = new Point(429, 207);
            Outcomebtn.Name = "Outcomebtn";
            Outcomebtn.Size = new Size(112, 34);
            Outcomebtn.TabIndex = 3;
            Outcomebtn.Text = "支出";
            Outcomebtn.UseVisualStyleBackColor = true;
            Outcomebtn.Click += Outcomebtn_Click;
            // 
            // ResultLbl
            // 
            ResultLbl.AutoSize = true;
            ResultLbl.Location = new Point(295, 285);
            ResultLbl.Name = "ResultLbl";
            ResultLbl.Size = new Size(66, 25);
            ResultLbl.TabIndex = 5;
            ResultLbl.Text = "残高：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(139, 48);
            label2.Name = "label2";
            label2.Size = new Size(194, 25);
            label2.TabIndex = 6;
            label2.Text = "日付を入力してください：";
            // 
            // datebox
            // 
            datebox.Location = new Point(339, 45);
            datebox.Name = "datebox";
            datebox.Size = new Size(150, 31);
            datebox.TabIndex = 7;
            // 
            // ResultDate
            // 
            ResultDate.AutoSize = true;
            ResultDate.Location = new Point(295, 328);
            ResultDate.Name = "ResultDate";
            ResultDate.Size = new Size(48, 25);
            ResultDate.TabIndex = 8;
            ResultDate.Text = "日付";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(783, 450);
            Controls.Add(ResultDate);
            Controls.Add(datebox);
            Controls.Add(label2);
            Controls.Add(ResultLbl);
            Controls.Add(Outcomebtn);
            Controls.Add(Incomebtn);
            Controls.Add(Inputbox);
            Controls.Add(label1);
            Name = "Form1";
            Text = "家計簿（お小遣い帳）のアプリ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox Inputbox;
        private Button Incomebtn;
        private Button Outcomebtn;
        private Label ResultLbl;
        private Label label2;
        private TextBox datebox;
        private Label ResultDate;
    }
}
