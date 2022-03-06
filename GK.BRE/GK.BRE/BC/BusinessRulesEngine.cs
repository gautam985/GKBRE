using GK.BRE.Models;
using GK.BRE.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GK.BRE.BC
{
    public class BusinessRulesEngine : IBusinessRulesEngine
    {
        private readonly List<IBusinessRule> _businessRules;

        public BusinessRulesEngine()
        {
            _businessRules = LoadBusinessRules(); ;
        }

        public List<ProductBusinessRuleExecutionResult> ExecuteBusinessRules(List<Product> products)
        {
            List<ProductBusinessRuleExecutionResult> productBRExecutionResultList = null;
            Result result;

            if (products?.Count > 0)
            {
                productBRExecutionResultList = new List<ProductBusinessRuleExecutionResult>();

                foreach (var product in products)
                {
                    var productBRExecutionResult = new ProductBusinessRuleExecutionResult();

                    foreach (var businessRule in _businessRules)
                    {
                        result = businessRule.ExecuteRule(product);

                        if (result != null)
                        {
                            productBRExecutionResult.Results.Add(
                                new BusinessRuleExecutionResult()
                                {
                                    RuleName = businessRule.Name,
                                    Result = result
                                });
                        }
                    }

                    productBRExecutionResultList.Add(productBRExecutionResult);
                }
            }

            return productBRExecutionResultList;
        }

        private List<IBusinessRule> LoadBusinessRules()
        {
            var businessRules = new List<IBusinessRule>();
            Assembly executingAssembly = Assembly.GetAssembly(typeof(BusinessRulesEngine));

            if (executingAssembly != null)
            {
                Type[] businessRuleTypes = executingAssembly
                    .GetTypes()
                    .Where(t => typeof(IBusinessRule).IsAssignableFrom(t) && t.IsClass)
                    .ToArray();

                foreach (Type rule in businessRuleTypes)
                {
                    IBusinessRule businessRule = Activator.CreateInstance(rule) as IBusinessRule;
                    businessRules.Add(businessRule);
                }
            }

            return businessRules;
        }
    }
}