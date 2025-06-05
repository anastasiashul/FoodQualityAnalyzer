using Model.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model.Core
{
    public partial class FoodQualityAnalyzer : ISpreadable
    {
        private FoodProduct[] _products;
        public FoodProduct[] Products { get 
            { if (_products == null) return null;
                FoodProduct[] newarr=new FoodProduct[_products.Length]; 
                Array.Copy(_products, newarr, _products.Length); 
                return newarr; 
            } }

        public void Add(FoodProduct product)
        {
            if (_products == null) _products = new FoodProduct[0];
            if (_products.Any(x=>x==product)) return;
            Array.Resize(ref _products, _products.Length+1);
            _products[_products.Length-1] = product;
        }

        public void Add(FoodProduct[] products)
        {
            if(products == null) return;
            foreach(FoodProduct product in products) Add(product);
        }
        /*
        private bool Equal(FoodProduct p1, FoodProduct p2)    //перешел в ==
        {
            bool equal = p1.GetType()==p2.GetType() && p1.Name==p2.Name&&p1.MaxShelfLife==p2.MaxShelfLife&&p1.DaysToExpire==p2.DaysToExpire;
            if (!equal) return equal;
            //if (!(p1.GetType() == p2.GetType())) return false;
            string s1 = JsonConvert.SerializeObject(p1);
            string s2 = JsonConvert.SerializeObject(p2);
            return(s1==s2);

        }*/
        
    }
}
