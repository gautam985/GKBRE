using GK.BRE.Models;
using GK.BRE.Models.Enums;
using GK.BRE.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace GK.BRE.BC.BusinessRules
{
    public class VideoBR : IBusinessRule
    {
        public string Name => "Video Business Rule";
        private const string Title = "LEARNING TO SKI";

        public Result ExecuteRule(Product product)
        {
            try
            {
                if (product.ProductType == ProductType.Video && product.Name.ToUpper() == Title)
                {
                    //Add a free “First Aid” video to the packing slip
                    return new Result
                    {
                        ResultCode = ResultCode.Success,
                        Comments = "Added a free First Aid video to the packing slip successfully"
                    };
                }
                else if (product.ProductType == ProductType.Video)
                {
                    //Create packing slip for the shipping
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
