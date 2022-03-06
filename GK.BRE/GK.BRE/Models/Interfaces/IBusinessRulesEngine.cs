using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GK.BRE.Models.Interfaces
{
    public interface IBusinessRulesEngine
    {
        List<ProductBusinessRuleExecutionResult> ExecuteBusinessRules(List<Product> products);
    }
}
