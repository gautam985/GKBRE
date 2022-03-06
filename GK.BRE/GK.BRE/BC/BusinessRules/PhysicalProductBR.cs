using GK.BRE.Models;
using GK.BRE.Models.Enums;
using GK.BRE.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace GK.BRE.BC.BusinessRules
{
    public class PhysicalProductBR : IBusinessRule
    {
        public string Name => "Physical Product Business Rule";

        public Result ExecuteRule(Product product)
        {
            try
            {
                if (product.ProductType == ProductType.Physical)
                {
                    // Create packing slip for the shipping
                    return new Result
                    {
                        ResultCode = ResultCode.Success,
                        Comments = "Packing slip for the shipping created successfully"
                    };
                }

                return null;
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
    }
}
