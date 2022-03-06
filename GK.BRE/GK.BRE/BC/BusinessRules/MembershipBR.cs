using GK.BRE.Models;
using GK.BRE.Models.Enums;
using GK.BRE.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace GK.BRE.BC.BusinessRules
{
    public class MembershipBR : IBusinessRule
    {
        public string Name => "Membership Business Rule";

        public Result ExecuteRule(Product product)
        {
            try
            {
                if (product.ProductType == ProductType.Membership)
                {
                    // Activate membership
                    return new Result
                    {
                        ResultCode = ResultCode.Success,
                        Comments = "Membership activated successfully"
                    };
                }
                else if (product.ProductType == ProductType.MembershipUpgrade)
                {
                    // Upgrade membership
                    return new Result
                    {
                        ResultCode = ResultCode.Success,
                        Comments = "Membership upgraded successfully"
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
