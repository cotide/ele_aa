using System;
using System.Collections.Generic;
using System.Linq;

namespace PolicyModule
{
    public class FoodManager
    {
        public IList<Food> Foods = new List<Food>();


        public void Add(Food food)
        {
            if (Foods == null)
            {
                Foods = new List<Food>();
            }
            
            Foods.Add(food);
        }

        /// <summary>
        /// 总数量
        /// </summary>
        public int Count => Foods?.Count ?? 0;
  
        /// <summary>
        /// 总费用
        /// </summary>
        public decimal SumMoney => Foods.Sum(x => x.SumMony);

         
        /// <summary>
        /// 是否有折扣数据
        /// </summary>
        public bool IsHaveFoot => Count > 0;

         
        
        /// <summary>
        /// 总公摊费用
        /// </summary>
        /// <returns></returns>
        public decimal GetSumMoney(){
            return Foods.Sum(x=>x.SumMony);
        }

        
        public void PrintDetail(){

            if (Foods != null)
            {
                foreach (var item in Foods)
                {
                    Console.WriteLine($"[菜名=] {item.Name}");
                    Console.WriteLine($"[单价=] ¥{item.AvgMoney}");
                    Console.WriteLine($"[数量=] {item.Count}");
                    Console.WriteLine($"[小计=] ¥{item.SumMony}");
                }
                
            }
           
        }
    }
}