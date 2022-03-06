using GK.BRE.Models;
using GK.BRE.Models.Enums;
using GK.BRE.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace GK.BRE.BC.BusinessRules
{
    public class BookBR : IBusinessRule
    {
        public string Name => "Book Business Rule";

        public Result ExecuteRule(Product product)
        {
            try
            {
                if (product.ProductType == ProductType.Book)
                {
                    //Create duplicate packing slip for the royalty department
                    return new Result
                    {
                        ResultCode = ResultCode.Success,
                        Comments = "Created duplicate packing slip for the royalty department successfully"
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
