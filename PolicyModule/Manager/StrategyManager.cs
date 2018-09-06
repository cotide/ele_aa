using System;
using System.Collections.Generic;
using System.Linq;
using PolicyModule.Fee;

namespace PolicyModule
{
    public class StrategyManager
    {  
        
        private readonly IList<Strategy> _strategys = new List<Strategy>();
 
        public StrategyManager(params Strategy[] strategies)
        {
            if (strategies.Any())
            {
                foreach (var item in strategies)
                {
                    _strategys.Add(item);
                }
            }
            
        }

        public void Add(Strategy publicFee)
        { 
            _strategys.Add(publicFee);  
        }

         
        /// <summary>
        /// 总折扣
        /// </summary>
        /// <returns></returns>
        public decimal GetSumDiscount(){
            return _strategys.Sum(x=>x.Discount());
        }
        
        
        /// <summary>
        /// 是否有折扣数据
        /// </summary>
        public bool IsHaveDiscount => _strategys != null && _strategys.Count > 0;
        
        
        public void PrintDiscount(){   
            foreach (var item in _strategys)
            {
                Console.WriteLine($"[折扣名称=]{item.DiscountName}");  
                Console.WriteLine($"[金额(¥)=]{item.Discount()}");  
            } 
        }
    }
}
