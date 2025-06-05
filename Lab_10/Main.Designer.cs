namespace Lab_10
{
    partial class Main
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
            button1 = new Button();
            button2 = new Button();
            checkedListBox1 = new CheckedListBox();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 192, 255);
            button1.ForeColor = SystemColors.HotTrack;
            button1.Location = new Point(676, 229);
            button1.Name = "button1";
            button1.Size = new Size(152, 83);
            button1.TabIndex = 0;
            button1.Text = "Новый продукт";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 192, 255);
            button2.ForeColor = SystemColors.HotTrack;
            button2.Location = new Point(470, 45);
            button2.Name = "button2";
            button2.Size = new Size(156, 68);
            button2.TabIndex = 1;
            button2.Text = "Показать качество";
            button2.UseVisualStyleBackColor = false;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.BackColor = Color.FromArgb(255, 192, 255);
            checkedListBox1.ForeColor = SystemColors.HotTrack;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.HorizontalScrollbar = true;
            checkedListBox1.IntegralHeight = false;
            checkedListBox1.Location = new Point(45, 45);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(400, 400);
            checkedListBox1.TabIndex = 2;
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.FromArgb(255, 192, 255);
            comboBox1.ForeColor = SystemColors.HotTrack;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(682, 372);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(212, 38);
            comboBox1.TabIndex = 3;
            comboBox1.Text = "Выберите формат отчета:";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 192, 192);
            ClientSize = new Size(1076, 586);
            Controls.Add(comboBox1);
            Controls.Add(checkedListBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Red;
            Name = "Main";
            Text = "FoodQualityAnalyzer";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private CheckedListBox checkedListBox1;
        private ComboBox comboBox1;
    }
}
