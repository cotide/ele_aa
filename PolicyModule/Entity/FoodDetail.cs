using System;
using System.Globalization;

namespace PolicyModule
{
    public class FoodDetail : Food
    {

        public FoodDetail(string name, decimal sumMony, int count) : base(name, sumMony, count)
        {
        }

        public FoodDetail(string name, decimal sumMony) : base(name, sumMony)
        {
        }

        /// <summary>
        /// 总公摊费用
        /// </summary>
        private decimal sumPublicFee;


        /// <summary>
        /// 总折扣费用
        /// </summary>
        private decimal sumDiscount;

        /// <summary>
        /// 设置总公摊费用
        /// </summary>
        /// <param name="money"></param>
        public void SetSumPublicFee(decimal money)
        {
            sumPublicFee = money;
        }

        /// <summary>
        /// 设置总折扣费用
        /// </summary>
        /// <param name="money"></param>
        public void SetSumDiscount(decimal money)
        {
            sumDiscount = money;
        }

        /// <summary>
        /// 总实付 
        /// </summary>
        public decimal SumResultMoney => (SumMony + sumPublicFee - sumDiscount); 
        
        /// <summary>
        /// 平均实付
        /// </summary>
        public decimal AvgResultMoney => SumResultMoney/ Count;

        /// <summary>
        /// 平均公摊费用
        /// </summary>
        private decimal AvgPublicFee => sumPublicFee / Count;

        /// <summary>
        /// 平均折扣费用
        /// </summary>
        private decimal AvgDisCount => sumDiscount / Count;


        public void PrintDetail()
        {
            Console.WriteLine($"[菜式=] {Name}"); 
            Console.WriteLine($"[数量=] {Count}");
            Console.WriteLine($"[总实付=] ¥{SumResultMoney}");
            Console.WriteLine($"[每位/原价金额=] ¥{AvgMoney}");
            Console.WriteLine($"[每位/公摊金额=] ¥{AvgPublicFee}");
            Console.WriteLine($"[每位/折扣金额=] ¥{-AvgDisCount}");
            Console.WriteLine($"[每位/实付=] ¥{AvgResultMoney}"); 
            Console.WriteLine("------------------------------");
             
        }
    }
}