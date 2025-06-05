using Model.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_10
{
    public partial class CreateProduct : Form
    {
        public FoodProduct newProduct {  get; private set; }
        public CreateProduct()
        {
            InitializeComponent();
            AddTypes();
        }
        private void AddTypes()
        {
            comboBox1.Items.Add("Vegetable");
            comboBox1.Items.Add("Fruit");
            comboBox1.Items.Add("Meat");
            comboBox1.Items.Add("Backery");

        }
        private void checkfullness()
        {
            if (groupBox1.Visible == true && textBox1.Text != "" && label8.Visible == false && textBox5.Text != "" && (radioButton1.Checked || radioButton2.Checked))
            {
                label9.Visible = false;
                button1.Enabled = true;
            }
            else
            {
                label9.Visible = true;
                button1.Enabled = false;
            }
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = comboBox1.SelectedItem.ToString();
            label6.Visible = true;
            label7.Visible = true;
            groupBox1.Visible = true;
            textBox5.Visible = true;

            if (select == "Vegetable")
            {
                label6.Text = "Washed?";
                label7.Text = "Color:";
            }
            else if (select == "Fruit")
            {
                label6.Text = "IsRipe?";
                label7.Text = "SweetnessLevel(1-10):";
            }
            else if (select == "Meat")
            {
                label6.Text = "IsFrozen?";
                label7.Text = "FatContent, %";
            }
            else if (select == "Backery")
            {
                label6.Text = "IsGlutenFree?";
                label7.Text = "SugarContent, g";
            }
            checkfullness();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            checkfullness();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox2.Text, out int value))
            {
                label8.Visible = true;
                checkfullness();
            }
            else
            {
                label8.Visible = false;
                if (textBox2.Text != "") checkfullness();
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox3.Text, out int value))
            {
                label8.Visible = true;
                checkfullness();
            }
            else
            {
                label8.Visible = false;
                if (textBox3.Text != "") checkfullness();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Vegetable" && textBox5.Text != "") checkfullness();
            else
            {
                if (!int.TryParse(textBox5.Text, out int value))
                {
                    label8.Visible = true;
                    checkfullness();
                }
                else
                {
                    label8.Visible = false;
                    if (textBox2.Text != "") checkfullness();
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            checkfullness();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            checkfullness();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FoodProduct newpr;
            if (comboBox1.SelectedItem.ToString() == "Vegetable")
            {
                newpr = new Vegetable(textBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox3.Text), radioButton1.Checked, textBox5.Text);

            }
            else if(comboBox1.SelectedItem.ToString() =="Fruit")
                newpr = new Fruit(textBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox5.Text), radioButton1.Checked );
            else if (comboBox1.SelectedItem.ToString() == "Meat")
                newpr = new Meat(textBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox3.Text), double.Parse(textBox5.Text), radioButton1.Checked);
            else 
                newpr = new Backery(textBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox3.Text),  radioButton1.Checked, int.Parse(textBox5.Text));
            newProduct = newpr;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        
    }
}
