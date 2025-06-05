using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public interface ISpreadable
    {

        FoodProduct[] Products { get; }
        void Add(FoodProduct product);
        void Add(FoodProduct[] products);
    }

    public interface IShrinkable
    {
        void Remove(FoodProduct product);
        void Remove(int index);
        void Remove();
    }
    public interface IStatistic
    {
        double GetMaxQuality();


        double GetMinQuality();



        double GetAverageQuality();


        public double GetMedianQuality();
        
    }
}
