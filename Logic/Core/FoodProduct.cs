using Newtonsoft.Json;

namespace Model.Core
{
    public abstract class FoodProduct
    {
        public string Name { get; private set;}
        public int DaysToExpire {  get; private set;}
        public int MaxShelfLife {  get; private set;}
        public FoodProduct(string name, int days, int maxshelflife)
        {
            Name = name;
            DaysToExpire = days;
            MaxShelfLife = maxshelflife;
        }
        public abstract double GetQuality();
        public static bool operator ==(FoodProduct p1, FoodProduct p2)
        {
            bool equal = p1.GetType() == p2.GetType() && p1.Name == p2.Name && p1.MaxShelfLife == p2.MaxShelfLife && p1.DaysToExpire == p2.DaysToExpire;
            if (!equal) return equal;
            
            string s1 = JsonConvert.SerializeObject(p1);
            string s2 = JsonConvert.SerializeObject(p2);
            return (s1 == s2);
        }
        public static bool operator !=(FoodProduct p1, FoodProduct p2)
        {
            return !(p1 == p2);
        }
    }
}
