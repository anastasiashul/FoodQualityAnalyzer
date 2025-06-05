using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public class Vegetable : FoodProduct
    {
        public bool Washed { get; private set; }
        public string Color { get; private set; }
        public Vegetable(string name, int daysToExpire, int maxShelfLife, bool washed, string color) : base(name, daysToExpire, maxShelfLife)
        {
            Washed = washed;
            Color = color;
        }
        public override double GetQuality()
        {
            if (MaxShelfLife <= 0) return 0;
            double res = 0;
            if (Washed) res += 5;
            res += (double)DaysToExpire / MaxShelfLife * 100;
            return Math.Round(Math.Min(100, Math.Max(0, res)));
        }
    }
    public class Fruit : FoodProduct
    {
        public int SweetnessLevel { get; private set; } // 1-10
        public bool IsRipe { get; private set; }
        public Fruit(string name, int daysToExpire, int maxShelfLife, int sweetnessLevel, bool isRipe)
            : base(name, daysToExpire, maxShelfLife)
        {
            if (sweetnessLevel > 10) SweetnessLevel = 10;
            else if (sweetnessLevel < 0) SweetnessLevel = 0;
            else SweetnessLevel = sweetnessLevel;
            IsRipe = isRipe;
        }
        public override double GetQuality()
        {
            if (MaxShelfLife <= 0) return 0;
            double res = (double)DaysToExpire / MaxShelfLife * 100;
            res += IsRipe ? 10 : -10;
            res += SweetnessLevel;

            return Math.Round(Math.Min(100, Math.Max(0, res)));
        }
    }
    public class Meat : FoodProduct
    {
        public double FatContent { get; private set; } // в процентах
        public bool IsFrozen { get; private set; }
        public Meat(string name, int daysToExpire, int maxShelfLife, double fatContent, bool isFrozen)
            : base(name, daysToExpire, maxShelfLife)
        {
            FatContent = fatContent;
            IsFrozen = isFrozen;
        }
        public override double GetQuality()
        {
            if (MaxShelfLife <= 0) return 0;
            double res = (double)DaysToExpire / MaxShelfLife * 100;
            res += IsFrozen ? 10 : 0;
            res += FatContent > 20 ? -10 : 0;

            return Math.Round(Math.Min(100, Math.Max(0, res)));
        }

    }
    public class Backery : FoodProduct
    {
        public bool IsGlutenFree { get; private set; }
        public int SugarContent { get; private set; } // граммы

        public Backery(string name, int daysToExpire, int maxShelfLife, bool isGlutenFree, int sugarContent)
            : base(name, daysToExpire, maxShelfLife)
        {
            IsGlutenFree = isGlutenFree;
            SugarContent = sugarContent;
        }

        public override double GetQuality()
        {
            if (MaxShelfLife <= 0) return 0;
            double res = (double)DaysToExpire / MaxShelfLife * 100;
            res += IsGlutenFree ? 5 : 0;
            res += SugarContent > 30 ? -5 : 0;
            return Math.Round(Math.Min(100, Math.Max(0, res)));
        }
    }
}
