namespace Lab_10
{
    partial class CreateProduct
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
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox5 = new TextBox();
            label8 = new Label();
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            button1 = new Button();
            label9 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(39, 37);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(265, 38);
            comboBox1.TabIndex = 0;
            comboBox1.Text = "Выберите тип продукта:";
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(39, 128);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(175, 35);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 95);
            label1.Name = "label1";
            label1.Size = new Size(190, 30);
            label1.TabIndex = 2;
            label1.Text = "Введите название:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 193);
            label2.Name = "label2";
            label2.Size = new Size(396, 30);
            label2.TabIndex = 3;
            label2.Text = "До истечения срока годности осталось:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 274);
            label3.Name = "label3";
            label3.Size = new Size(157, 30);
            label3.TabIndex = 4;
            label3.Text = "Срок годности:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(39, 226);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(175, 35);
            textBox2.TabIndex = 5;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(39, 307);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(175, 35);
            textBox3.TabIndex = 6;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(220, 231);
            label4.Name = "label4";
            label4.Size = new Size(96, 30);
            label4.TabIndex = 7;
            label4.Text = "day/days";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(220, 307);
            label5.Name = "label5";
            label5.Size = new Size(96, 30);
            label5.TabIndex = 8;
            label5.Text = "day/days";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(39, 377);
            label6.Name = "label6";
            label6.Size = new Size(68, 30);
            label6.TabIndex = 9;
            label6.Text = "label6";
            label6.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(39, 508);
            label7.Name = "label7";
            label7.Size = new Size(68, 30);
            label7.TabIndex = 10;
            label7.Text = "label7";
            label7.Visible = false;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(39, 541);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(175, 35);
            textBox5.TabIndex = 12;
            textBox5.Visible = false;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(324, 274);
            label8.Name = "label8";
            label8.Size = new Size(188, 30);
            label8.TabIndex = 13;
            label8.Text = "неверный формат";
            label8.Visible = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(39, 410);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(236, 72);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Visible = false;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(124, 20);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(81, 34);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "false";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(6, 20);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(75, 34);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "true";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(595, 193);
            button1.Name = "button1";
            button1.Size = new Size(131, 73);
            button1.TabIndex = 15;
            button1.Text = "Создать продукт";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(560, 133);
            label9.Name = "label9";
            label9.Size = new Size(204, 30);
            label9.TabIndex = 16;
            label9.Text = "Заполните все поля";
            // 
            // CreateProduct
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 192, 192);
            ClientSize = new Size(976, 736);
            Controls.Add(label9);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(label8);
            Controls.Add(textBox5);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Name = "CreateProduct";
            Text = "CreateProduct";
            
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox5;
        private Label label8;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button1;
        private Label label9;
    }
}