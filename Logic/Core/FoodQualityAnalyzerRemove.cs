using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Core;

namespace Model.Core
{
    public partial class FoodQualityAnalyzer : IShrinkable
    {
        public void Remove(FoodProduct product)
        {
            if (Products==null||Products.Length == 0) return;
            bool changed = false;
            var newproducts = new FoodProduct[Products.Length - 1];
            for(int i = 0; i<Products.Length; i++)
            {
                if (Products[i]== product)
                {
                    Array.Copy(Products, newproducts, i);
                    Array.Copy(Products, i+1, newproducts, i, Products.Length-i-1);
                    changed = true;
                    break;
                }
            }
            if (!changed) return;
            Array.Resize(ref _products, newproducts.Length);
            Array.Copy(newproducts, _products, _products.Length);
            
        }

        public void Remove(int index)
        {

            if (Products == null || Products.Length == 0 || Products.Length<=index || index<0) return;
            var newproducts = new FoodProduct[Products.Length - 1];
            Array.Copy(Products, newproducts, index);
            Array.Copy(Products, index+1, newproducts, index, Products.Length-index-1);
            Array.Resize(ref _products, newproducts.Length);
            Array.Copy(newproducts, _products, _products.Length);
        }

        public void Remove()
        {
            if (Products == null || Products.Length == 0) return;
            Array.Resize(ref _products, _products.Length-1);
        }
    }
}
