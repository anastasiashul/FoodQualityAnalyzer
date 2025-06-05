using Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Model.Data
{
    public class XMLSerialization : Serialization
    {
        
        private static int numberofreport = 1;
        private string path = Path.Combine("Datas", "ListOfProducts.xml");
       

        public override FoodQualityAnalyzer Deserialize()
        {
            FoodQualityAnalyzer analyzer =new FoodQualityAnalyzer();
            if (!File.Exists(path)) return analyzer;
            using StreamReader reader = new StreamReader(path);
            var deser = new XmlSerializer(typeof(FQA_DTO));
            var predanalyzer =(FQA_DTO) deser.Deserialize(reader);
            reader.Close();
            foreach(var predpr in predanalyzer.foodProducts)
            {
                if (predpr.GetType().Name == nameof(V)) analyzer.Add(new Vegetable(predpr.Name, predpr.DaysToExpire, predpr.MaxShelfLife, (predpr as V).Washed, (predpr as V).Color));
                else if (predpr.GetType().Name == nameof(F)) analyzer.Add(new Fruit(predpr.Name, predpr.DaysToExpire, predpr.MaxShelfLife, (predpr as F).SweetnessLevel, (predpr as F).IsRipe));
                else if (predpr.GetType().Name == nameof(M)) analyzer.Add(new Meat(predpr.Name, predpr.DaysToExpire, predpr.MaxShelfLife, (predpr as M).FatContent, (predpr as M).IsFrozen));
                else if (predpr.GetType().Name == nameof(B)) analyzer.Add(new Backery(predpr.Name, predpr.DaysToExpire, predpr.MaxShelfLife, (predpr as B).IsGlutenFree, (predpr as B).SugarContent));
                else return null;

            }
            return analyzer;
            
        }

        public override void SaveReport<T>(T[] products, string date)
        {
            //throw new NotImplementedException();
            string Folder = "Reports";
            Directory.CreateDirectory(Folder);
            string filepath;
            if (date == "") filepath = $"Отчет_№{numberofreport}_от_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.xml";
            else filepath = $"{date}.xml";
            numberofreport++;
            
            string path = Path.Combine(Folder, filepath);
            using (var wr = new StreamWriter(path))
            {
                XmlSerializer ser = new XmlSerializer(typeof(FQAforReport_DTO));
                if (products is FoodProduct[] prod)
                    ser.Serialize(wr, new FQAforReport_DTO(prod));
                else if (products is FPforReport_DTO[] pro)
                {
                    var a = new FQAforReport_DTO();
                    a.foodProducts = pro;
                    ser.Serialize(wr, a);
                }
                else return;
            }
        }
        



        public override void Serialize(FoodProduct[] products)
        {
            
            Directory.CreateDirectory("Datas");
            using (var wr = new StreamWriter(path))
            {
                XmlSerializer ser = new XmlSerializer(typeof(FQA_DTO));

                ser.Serialize(wr, new FQA_DTO(products));
            }

        }
        public override FPforReport_DTO[] LoadReport(string filepath)
        {
            using StreamReader reader = new StreamReader(filepath);
            var deser = new XmlSerializer(typeof(FQAforReport_DTO));
            var predanalyzer = (FQAforReport_DTO)deser.Deserialize(reader);
            reader.Close();
            return predanalyzer.foodProducts;
        }
        public class FQAforReport_DTO
        {
            public FPforReport_DTO[] foodProducts {  get; set; }
            public FQAforReport_DTO()
            {

            }
            public FQAforReport_DTO(FoodProduct[] products)
            {
                foodProducts = products.Select(x=>new FPforReport_DTO(x)).ToArray();
            }
        }
        public class FPforReport_DTO
        {
            public string Name { get; set; }
            public double Quality { get; set; }
            public FPforReport_DTO() { }
            public FPforReport_DTO(FoodProduct pr)
            {
                Name = pr.Name;
                Quality = pr.GetQuality();
            }
        }
        public class FQA_DTO
        {
            public FP_DTO[] foodProducts { get; set; }
            public FQA_DTO()
            {

            }
            public FQA_DTO(FoodProduct[] products)
            {
                foodProducts = products.Select(x =>
                { 
                    if (x.GetType() == typeof(Vegetable)) return new V(x as Vegetable) as FP_DTO; 
                    else if (x.GetType() == typeof(Fruit)) return new F(x as Fruit) as FP_DTO;
                    else if (x.GetType() == typeof(Meat)) return new M(x as Meat) as FP_DTO;
                    else  return new B(x as Backery) as FP_DTO;
                }).ToArray();
            }
        }
        [XmlInclude(typeof(V))]
        [XmlInclude(typeof(F))]
        [XmlInclude(typeof(M))]
        [XmlInclude(typeof(B))]
        public class FP_DTO
        {
            public string Name { get; set; }
            public int DaysToExpire { get;  set; }
            public int MaxShelfLife { get; set; }

            public FP_DTO() { }
            public FP_DTO(FoodProduct pr)
            {
                Name = pr.Name;
                DaysToExpire = pr.DaysToExpire;
                MaxShelfLife = pr.MaxShelfLife;
            }
        }
        public class V:FP_DTO
        {
            public bool Washed { get;  set; }
            public string Color { get; set; }
            public V() { }
            public V(Vegetable pr):base(pr as FoodProduct)  
            {
                Washed = pr.Washed;
                Color = pr.Color;
            }
        }
        public class F : FP_DTO
        {
            public int SweetnessLevel { get;set; }
            public bool IsRipe { get; set; }
            public F() { }
            public F(Fruit pr) : base(pr as FoodProduct)
            {
                SweetnessLevel = pr.SweetnessLevel;
                IsRipe = pr.IsRipe;
            }
        }
        public class M : FP_DTO
        {
            public double FatContent { get;  set; }
            public bool IsFrozen { get;  set; }
            public M() { }
            public M(Meat pr) : base(pr as FoodProduct)
            {
                FatContent = pr.FatContent;
                IsFrozen = pr.IsFrozen;
            }
        }
        public class B : FP_DTO
        {
            public bool IsGlutenFree { get;  set; }
            public int SugarContent { get;  set; }
            public B() { }
            public B(Backery pr) : base(pr as FoodProduct)
            {
                IsGlutenFree = pr.IsGlutenFree;
                SugarContent = pr.SugarContent;
            }
        }


    }
}
