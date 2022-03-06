using GK.BRE.BC;
using GK.BRE.Models;
using GK.BRE.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GK.BRE.UnitTest
{
    [TestClass]
    public class BusinessRuleExecutionTest
    {
        private BusinessRulesEngine _businessRulesEngine;

        #region Private Method

        private void InitilizeBusinessObjects()
        {
            _businessRulesEngine = new BusinessRulesEngine();
        }

        #endregion Private Method

        #region Test Method

        [TestMethod]
        public void PhysicalProductTest()
        {
            InitilizeBusinessObjects();
            var result = _businessRulesEngine.ExecuteBusinessRules(new List<Product>() { new Product { ProductType = ProductType.Physical } });

            Assert.IsTrue(result[0].Results.Count == 2);
        }

        #endregion Test Method
    }
}
