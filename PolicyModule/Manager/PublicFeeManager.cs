using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PolicyModule.Fee;

namespace PolicyModule
{
    /// <summary>
    /// 公摊管理
    /// </summary>
    public class PublicFeeManager
    {
        private readonly IList<PublicFee> _publicFee = new List<PublicFee>();

        public PublicFeeManager(params PublicFee[] publicFees)
        {
            if (publicFees.Any())
            {
                foreach (var item in publicFees)
                {
                    _publicFee.Add(item);
                }
            }
            
        }
 
        /// <summary>
        /// 添加公摊费用项目
        /// </summary>
        /// <param name="publicFee"></param>
        public void Add(PublicFee publicFee)
        { 
             _publicFee.Add(publicFee);  
        }

         
         
        /// <summary>
        /// 总公摊费用
        /// </summary>
        /// <returns></returns>
        public decimal GetSumFee(){
            return _publicFee.Sum(x=>x.Fee());
        }

        /// <summary>
        /// 是否有公摊费用
        /// </summary>
        public bool IsHavePublicFee => _publicFee != null && _publicFee.Count > 0;

        public void PrintFee(){
            foreach (var item in _publicFee)
            { 
                Console.WriteLine($"[公费名称=]{item.FeeName}");
                Console.WriteLine($"[金额(¥)=]{item.Fee()}");
            } 
        }
    }
}