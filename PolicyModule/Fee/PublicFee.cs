using System;

namespace PolicyModule.Fee
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class PublicFee
    {
        /// <summary>
        /// 公费金额
        /// </summary>
        protected decimal Money { get; set; }
        
        /// <summary>
        /// 公费名称
        /// </summary>
        public readonly String FeeName;

        protected PublicFee(String name,decimal money)
        {
            FeeName = name;
            Money = money;
        }

        /// <summary>ee
        /// 公费
        /// </summary>
        /// <returns>The discount.</returns>
        public virtual decimal Fee()
        {
            return Money;
        }

    }
}