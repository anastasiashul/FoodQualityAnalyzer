using Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Data.XMLSerialization;

namespace Model.Data
{
    public abstract class Serialization
    {
        
        
        
        public abstract void Serialize(FoodProduct[] products);
        
        public abstract FoodQualityAnalyzer Deserialize();
        public abstract void SaveReport<T>(T[] products, string date="");
        //public abstract void SaveReport(FPforReport_DTO[] products, string date="");  //ушло в Т
        public abstract FPforReport_DTO[] LoadReport(string filepath);
        
    }
}
