using Model.Core;
using Model.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab_10
{
    public partial class Form2 : Form
    {
        
        
        public Form2(FoodProduct[] products, string ext)
        {
            InitializeComponent();
            FillDiagram(products);
            Serialization ser;
            if (ext == "json")
                ser = new JsonSerialization();
            else ser = new XMLSerialization();
            ser.SaveReport(products, "");
        }
        private void FillDiagram(FoodProduct[] products)
        {
            
            chart1.Series[0].Points.Clear();
            chart1.Series[0].IsXValueIndexed = false;
            chart1.AlignDataPointsByAxisLabel(chart1.Series[0].Name);
            chart1.Series[0].ChartType = SeriesChartType.Column;
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.ChartAreas[0].AxisX.LabelStyle.IsStaggered = false;

            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.Series[0]["PointWidth"] = "0.5";
            foreach (FoodProduct product in products)
            {
                chart1.Series[0].Points.AddXY(product.Name, product.GetQuality());
            }
            
        }
        public void NewDiagram(FoodProduct[] products) { FillDiagram(products); }
        

    }
}
