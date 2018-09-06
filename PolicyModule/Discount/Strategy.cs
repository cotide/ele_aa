using System;
namespace PolicyModule
{
    /// <summary>
    /// 折扣基类
    /// </summary>
    public abstract class Strategy
    {
        /// <summary>
        /// 折扣名称
        /// </summary>
        public readonly String DiscountName;
        
        /// <summary>
        /// 折扣金额
        /// </summary>
        protected decimal Money { get; set; }


        protected Strategy(String name,decimal money)
        {
            DiscountName = name;
            Money = money;
        }

        /// <summary>
        /// 折扣
        /// </summary>
        /// <returns>The discount.</returns>
        public virtual decimal Discount()
        {
            return Money;
        }
    }
}
