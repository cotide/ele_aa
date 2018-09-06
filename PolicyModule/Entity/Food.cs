using System;

namespace PolicyModule
{ 
   
    /// <summary>
    /// 食物
    /// </summary>
    public class Food
    {
        /// <summary>
        /// 名称
        /// </summary>
        public readonly String Name;
 
        /// <summary>
        /// 总金额 (原价)
        /// </summary>
        public readonly decimal SumMony;
 
        
        /// <summary>
        /// 数量
        /// </summary>
        public readonly int Count;

        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">菜名</param>
        /// <param name="sumMony">总金额</param>
        /// <param name="count">数量</param>
        public Food(String name,decimal sumMony,int count)
        {
            
            this.Name = name;
            this.SumMony = sumMony;
            this.Count = count;
        }
        
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">菜名</param>
        /// <param name="sumMony">总金额</param>
        public Food(String name,decimal sumMony)
        {
            this.Name = name;
            this.SumMony = sumMony;
            this.Count = 1;
        } 
        
        /// <summary>
        /// 人均（原价）
        /// </summary>
        public decimal AvgMoney => SumMony / Count;
    }
}