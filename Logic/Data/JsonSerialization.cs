using Model.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static Model.Data.XMLSerialization;

namespace Model.Data
{
    public class JsonSerialization : Serialization
    {

        private static int numberofreport = 1;
        private string path = Path.Combine("Datas", "ListOfProducts.json");

        public override void Serialize(FoodProduct[] products)
        {
            Directory.CreateDirectory("Datas");
            var newjobjects = new JObject[products.Length];
            for (int i = 0; i < products.Length; i++)
            {
                JObject newpr = JObject.FromObject(products[i]);
                newpr.Add("Type", products[i].GetType().Name);
                newjobjects[i] = newpr;
            }
            string json = JsonConvert.SerializeObject(newjobjects);
            File.WriteAllText(path, json);
        }
        public override FoodQualityAnalyzer Deserialize()
        {

            var res = new FoodQualityAnalyzer();
            if (!File.Exists(path)) return res;
            JObject[] jproducts = JsonConvert.DeserializeObject<JObject[]>(File.ReadAllText(path));

            for (int i = 0; i < jproducts.Length; i++)
            {
                if (jproducts[i] == null || jproducts[i]["Type"] == null) continue;
                string type = jproducts[i]["Type"].ToString();

                FoodProduct pr;
                if (type == nameof(Vegetable)) pr = jproducts[i].ToObject<Vegetable>();
                else if (type == nameof(Fruit)) pr = jproducts[i].ToObject<Fruit>();
                else if (type == nameof(Meat)) pr = jproducts[i].ToObject<Meat>();
                else if (type == nameof(Backery)) pr = jproducts[i].ToObject<Backery>();
                else continue;
                res.Add(pr);

            }
            return res;
        }
        
        public override void SaveReport<T>(T[] products, string date)
        {
            string Folder = "Reports";
            Directory.CreateDirectory(Folder);
            string filepath;
            if (date == "") filepath = $"Отчет_№{numberofreport}_от_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.json";
            else filepath = $"{date}.json";
            numberofreport++;
            //
            string path = Path.Combine(Folder, filepath);
            FPforReport_DTO[] arr;
            if (products[0] is FoodProduct)
            {
                arr = products.Select(x => new FPforReport_DTO(x as FoodProduct)).ToArray();
                string s = JsonConvert.SerializeObject(arr);
                File.WriteAllText(path, s);
            }
            else if (products[0] is FPforReport_DTO)
            {
                string s = JsonConvert.SerializeObject(products);
                File.WriteAllText(path, s);
            }
            else return;
            
            

        }

        

        public override FPforReport_DTO[] LoadReport(string filepath)
        {
            var array = JsonConvert.DeserializeObject<FPforReport_DTO[]>(File.ReadAllText(filepath));
            return array;

        }

    }

}
