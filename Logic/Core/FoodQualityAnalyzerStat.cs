using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public partial class FoodQualityAnalyzer : IStatistic
    {
        public double GetAverageQuality()
        {
            if (_products==null||_products.Length == 0) return 0;
            return _products.Average(x => x.GetQuality());

        }

        public double GetMaxQuality()
        {
            if (Products == null || Products.Length == 0) return 0;
            return _products.Max(x => x.GetQuality());
            
        }

        public double GetMedianQuality()
        {
            
                if (_products==null ||_products.Length == 0) return 0;
                double[] sorted = _products.Select(x => x.GetQuality()).OrderBy(q => q).ToArray();
                int count = sorted.Length;
                if (count % 2 == 1) return sorted[count / 2];
                else return (sorted[count / 2 - 1] + sorted[count / 2]) /2;
            
        }

        public double GetMinQuality()
        {
            if (Products==null ||_products.Length == 0) return 0;
            return _products.Min(x => x.GetQuality());
            
        }
    }
}
