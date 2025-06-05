
using Model;
using Model.Core;
using Model.Data;

namespace Lab_10
{
    public partial class Main : Form

    {
        private FoodQualityAnalyzer analyzer = new FoodQualityAnalyzer();
        private FoodQualityAnalyzer selected = new FoodQualityAnalyzer();
        private Form2 table;
        private CreateProduct creater;
        private Serialization ser;
        public string Extension { get; private set; }
        public Main()
        {
            InitializeComponent();
            
            StartProgram();
            Extension = "json";
            comboBox1.Items.Add("json");
            comboBox1.Items.Add("xml");
        }


        private void button1_Click(object sender, EventArgs e)
        {

            creater = new CreateProduct();
            if (creater.ShowDialog() == DialogResult.OK)
            {
                analyzer.Add(creater.newProduct);
                checkedListBox1.Items.Add(creater.newProduct.Name);
                ser = new JsonSerialization();
                ser.Serialize(analyzer.Products);
            }


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*  //перешло в обновление при выборе элемента
            for(int i = 0; i<checkedListBox1.CheckedIndices.Count; i++)
            {
                selected.Add(analyzer.Products[checkedListBox1.CheckedIndices[i]]);
            }*/
            table = new Form2(selected.Products, Extension);
            table.Show();


        }
        private void StartProgram()
        {

            ser = new JsonSerialization();
            analyzer = ser.Deserialize();
            ser = new XMLSerialization();
            analyzer.Add(ser.Deserialize().Products);
            analyzer.Add(StartProducts());
            foreach (var product in analyzer.Products)
            {
                checkedListBox1.Items.Add(product.Name);
            }

            ser.Serialize(analyzer.Products);
            ser = new JsonSerialization();
            ser.Serialize(analyzer.Products);
        }
        private FoodProduct[] StartProducts()
        {
            var products = new FoodProduct[14]
            {
                new Vegetable("Морковь", 5, 10, true, "orange"),
                new Vegetable("Картофель", 15, 30, false, "brown"),
                new Vegetable("Помидор", 7, 10, false, "red"),
                new Vegetable("Огурец", 3, 10, true, "green"),
                new Fruit("Яблоко", 7, 14, 7, true),
                new Fruit("Банан", 3, 10, 9, false),
                new Fruit("Груша", 2, 7, 2, true),
                new Fruit("Мандарин", 10, 11, 4, false),
                new Meat("Курица", 2, 7, 10, true),
                new Meat("Говядина", 5, 10, 25, false),
                new Backery("Хлеб", 2, 5, false, 5),
                new Backery("Безглютеновый кекс", 3, 7, true, 15),
                new Backery("Булочка", 4, 5, false, 10),
                new Backery("Кекс", 4, 7, false, 14)
                

            };
            return products;
            
        }
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((Action)delegate { ChangeVisible(e); });


            this.BeginInvoke((Action)delegate { if (e.NewValue == CheckState.Checked) AddToDiagram(e); else RemoveFromDiagram(e); });
        }
        private void ChangeVisible(ItemCheckEventArgs e)
        {
            //if (e.NewValue == CheckState.Checked) button2.Visible = true;//не нужно, стало работать после смены значения
            if (checkedListBox1.CheckedItems.Count > 0) button2.Visible = true;
            else button2.Visible = false;
        }
        private delegate void mydelegat();
        private void AddToDiagram(ItemCheckEventArgs e)
        {
            selected.Add(analyzer.Products[e.Index]);
            if (table != null && table.Created) table.NewDiagram(selected.Products);
        }
        private void RemoveFromDiagram(ItemCheckEventArgs e)
        {
            selected.Remove(analyzer.Products[e.Index]);
            if (table != null && table.Created)
            {
                table.NewDiagram(selected.Products);
                if (checkedListBox1.CheckedItems.Count == 0) table.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string newext = comboBox1.SelectedItem.ToString();
            
            if (Extension != newext)
            {
                var files = Directory.GetFiles("Reports");
                for (int i = 0; i < files.Length; i++)
                {
                    if (Extension == "json"&& Path.GetExtension(files[i])==".json")
                    {
                        ser = new JsonSerialization();
                        var arr = ser.LoadReport(files[i]);
                        
                        ser=new XMLSerialization();
                        ser.SaveReport(arr, Path.GetFileNameWithoutExtension(files[i]));
                        File.Delete(files[i]);

                    }
                    else if(Extension == "xml" && Path.GetExtension(files[i]) == ".xml")
                    {
                        ser = new XMLSerialization();
                        var arr = ser.LoadReport(files[i]);
                        ser=new JsonSerialization();
                        ser.SaveReport(arr, Path.GetFileNameWithoutExtension(files[i]));
                        File.Delete(files[i]);
                    }
                }


                Extension = comboBox1.SelectedItem.ToString();

            }
            
            
        }

       
    }
}
