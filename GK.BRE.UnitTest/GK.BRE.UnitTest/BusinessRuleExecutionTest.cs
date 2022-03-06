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

        [TestMethod]
        public void BookTest()
        {
            InitilizeBusinessObjects();
            var result = _businessRulesEngine.ExecuteBusinessRules(new List<Product>() { new Product { ProductType = ProductType.Book } });

            Assert.IsTrue(result[0].Results.Count == 2);
        }

        [TestMethod]
        public void MembershipTest()
        {
            InitilizeBusinessObjects();
            var result = _businessRulesEngine.ExecuteBusinessRules(new List<Product>() { new Product { ProductType = ProductType.Membership } });

            Assert.IsTrue(result[0].Results.Count == 2);
        }

        [TestMethod]
        public void MembershipUpgradeTest()
        {
            InitilizeBusinessObjects();
            var result = _businessRulesEngine.ExecuteBusinessRules(new List<Product>() { new Product { ProductType = ProductType.MembershipUpgrade } });

            Assert.IsTrue(result[0].Results.Count == 2);
        }

        [TestMethod]
        public void VideoFreeFirstAidTest()
        {
            InitilizeBusinessObjects();
            var result = _businessRulesEngine.ExecuteBusinessRules(new List<Product>() { new Product { Name = "Learning to Ski", ProductType = ProductType.Video } });

            Assert.IsTrue(result[0].Results.Count == 1 && result[0].Results[0].Result.Comments == "Added a free First Aid video to the packing slip successfully");
        }

        [TestMethod]
        public void VideoTest()
        {
            InitilizeBusinessObjects();
            var result = _businessRulesEngine.ExecuteBusinessRules(new List<Product>() { new Product { Name = "Learning C#", ProductType = ProductType.Video } });

            Assert.IsTrue(result[0].Results.Count == 1 && result[0].Results[0].Result.Comments == "Packing slip for the shipping created successfully");
        }

        [TestMethod]
        public void TwoProductsTest()
        {
            InitilizeBusinessObjects();
            var result = _businessRulesEngine.ExecuteBusinessRules(new List<Product>()
            {
                new Product { Name = "Learning C#", ProductType = ProductType.Video },
                new Product { Name = "Product 1", ProductType = ProductType.Physical }
            });

            Assert.IsTrue(result.Count == 2);
        }

        [TestMethod]
        public void ProductsNullTest()
        {
            InitilizeBusinessObjects();
            var result = _businessRulesEngine.ExecuteBusinessRules(null);

            Assert.IsTrue(result == null);
        }

        #endregion Test Method
    }
}
