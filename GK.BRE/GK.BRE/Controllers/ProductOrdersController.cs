using GK.BRE.Models;
using GK.BRE.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace GK.BRE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOrdersController : ControllerBase
    {
        private readonly ILogger<ProductOrdersController> _logger;
        private readonly IBusinessRulesEngine _businessRulesEngine;

        public ProductOrdersController(ILogger<ProductOrdersController> logger, IBusinessRulesEngine businessRulesEngine)
        {
            _logger = logger;
            _businessRulesEngine = businessRulesEngine;
        }

        [HttpPost]
        public List<ProductBusinessRuleExecutionResult> Post([FromBody] List<Product> products)
        {
            return _businessRulesEngine.ExecuteBusinessRules(products);
        }
    }
}
