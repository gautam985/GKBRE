using GK.BRE.Models;
using GK.BRE.Models.Enums;
using GK.BRE.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace GK.BRE.BC.BusinessRules
{
    public class MembershipEmailNotificationBR : IBusinessRule
    {
        public string Name => "Membership Email Notification Business Rule";

        public Result ExecuteRule(Product product)
        {
            if (product.ProductType == ProductType.Membership || product.ProductType == ProductType.MembershipUpgrade)
            {
                try
                {
                    //Send email notification to the subscriber for the membership activation/upgrade.
                    return new Result
                    {
                        ResultCode = ResultCode.Success,
                        Comments = "Email notification sent successfully"
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
