using System.Collections.Generic;

namespace GK.BRE.Models
{
    public class ProductBusinessRuleExecutionResult
    {
        public ProductBusinessRuleExecutionResult()
        {
            Results = new List<BusinessRuleExecutionResult>();
        }
        public Product Product { get; set; }

        public List<BusinessRuleExecutionResult> Results { get; set; }
    }
}
