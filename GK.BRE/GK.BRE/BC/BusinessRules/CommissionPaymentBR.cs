using GK.BRE.Models;
using GK.BRE.Models.Enums;
using GK.BRE.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace GK.BRE.BC.BusinessRules
{
    public class CommissionPaymentBR : IBusinessRule
    {
        public string Name => "Commission Payment Business Rule";

        public Result ExecuteRule(Product product)
        {
            if (product.ProductType == ProductType.Book || product.ProductType == ProductType.Physical)
            {
                try
                {
                    //Create commission payment for the agent
                    return new Result
                    {
                        ResultCode = ResultCode.Success,
                        Comments = "Generated commission payment to the agent successfully"
                    };
                }
                catch (Exception e)
                {
                    return new Result
                    {
                        ResultCode = ResultCode.Error,
                        Errors = new List<string> { e.Message }
                    };
                }
            }

            return null;
        }
    }
}
