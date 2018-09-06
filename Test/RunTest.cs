using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolicyModule;
using PolicyModule.Fee;

namespace Test
{
    [TestClass]
    public class RunTest
    {  
        
        [TestMethod]
        public void Print()
        {     
            
            Calculator.Builder
                 // 添加菜式
                .AddFoot(new Food("支竹牛腩套餐(菜干汤)-例",63.8M,2))
                .AddFoot(new Food("支竹牛腩饭简餐-例",47.8M,2))
                .AddFoot(new Food("酸菜卤肉饭简餐-例",45.8M,2))
                .AddFoot(new Food("榄菜肉松饭简餐-例",14.9M))
                 // 添加额外公摊的费用
                .AddPublicFee(new OtherPublicFee("餐盒",10.5M))
                .AddPublicFee(new OtherPublicFee("蜂鸟转送",1)) 
                 // 添加折扣
                .AddDiscount(new OtherStrategy("在线支付立减优惠",15))
                .AddDiscount(new OtherStrategy("店铺红包",4.4M))
                // 统计
                .Count(); 
        }
    }
}
