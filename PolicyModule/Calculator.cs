using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PolicyModule.Fee;

namespace PolicyModule
{ 
    /// <summary>
    /// 计算模块
    /// </summary>
    public class Calculator
    {

        public static Calculator Builder => new Calculator();

        /// <summary>
        /// 菜式管理
        /// </summary>
        private readonly FoodManager _foodManager =new FoodManager();
  
        /// <summary>
        /// 公摊管理
        /// </summary>
        private readonly PublicFeeManager _publicFeeManager = new PublicFeeManager();
        
        /// <summary>
        /// 折扣管理
        /// </summary>
        private readonly StrategyManager _strategyManager = new StrategyManager();
        
        
        public Calculator(params Food[] foods)
        {
            if (foods.Any())
            {
                foreach (var item in foods)
                {
                    _foodManager.Add(item);
                }
            }
        }


        public Calculator AddFoot(Food food)
        {  
            _foodManager.Add(food);
            return this;
        }


        public Calculator AddPublicFee(PublicFee publicFee)
        {
            _publicFeeManager.Add(publicFee);
            return this;
        }

        public Calculator AddDiscount(Strategy strategy)
        {
            _strategyManager.Add(strategy);
            return this;
        }


        /// <summary>
        /// 统计
        /// </summary>
        public void Count()
        {
            if (!_foodManager.IsHaveFoot)
            {
                Console.WriteLine("请添加您的菜式"); 
                return; 
            }
            
            List<FoodDetail> result = new List<FoodDetail>(); 
             
             
            // 人均公摊费用
            decimal avgPublicFee =  _publicFeeManager.GetSumFee() / _foodManager.Count;
            
            // 人均折扣费用
            decimal avgDiscount = _strategyManager.GetSumDiscount() / _foodManager.Count;


            foreach (var food in _foodManager.Foods)
            {
                
                FoodDetail foodDetail = new FoodDetail(food.Name,food.SumMony,food.Count);
                foodDetail.SetSumPublicFee(avgPublicFee);
                foodDetail.SetSumDiscount(avgDiscount);
                result.Add(foodDetail);
            }
             
            
            // 菜式
            // 公费 
            Console.WriteLine("====== 基本信息 ======");
            _foodManager.PrintDetail(); 
            Console.WriteLine("[总菜价(原价)(¥)=]"+_foodManager.GetSumMoney()); 

               
            // 公费 
            if (_publicFeeManager.IsHavePublicFee)
            {
                Console.WriteLine("------------------------------");
                 _publicFeeManager.PrintFee();  
                Console.WriteLine("[总公摊费用(¥)=]"+_publicFeeManager.GetSumFee()); 
                
            } 
            // 折扣
            if (_strategyManager.IsHaveDiscount)
            { 
                
                Console.WriteLine("------------------------------");
                _strategyManager.PrintDiscount(); 
                Console.WriteLine("[总折扣(¥)=]"+_strategyManager.GetSumDiscount()); 
            } 
            
            Console.WriteLine("====== 结算 ======");
            foreach (var item in result)
            { 
                item.PrintDetail();   
            }
            Console.WriteLine("[总实付(¥)=]"+ result.Sum(x=>x.SumResultMoney)); 
        }
        
        
    }
}