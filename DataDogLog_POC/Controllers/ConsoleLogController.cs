using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using DataDogLog_POC.Utility;

namespace DataDogLog_POC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsoleLogController : ControllerBase
    {
        private readonly ILogger<ConsoleLogController> _logger;

        public ConsoleLogController(ILogger<ConsoleLogController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<AccountDetails> Get()
        {
            var accountDetails = new List<AccountDetails> {
             new AccountDetails{ UserId = 2324 , AccountId = Guid.NewGuid().ToString() , Balance=9004 },
             new AccountDetails{ UserId = 3454 , AccountId = Guid.NewGuid().ToString() , Balance=7594 },
             new AccountDetails{ UserId = 7686 , AccountId = Guid.NewGuid().ToString() , Balance=94455 }
            };

            Serilog.ILogger Logger = LoggerExtension.Logger();

            //_logger.LogInformation

            foreach (var account in accountDetails)
            {
                Logger.Information("account details {@account}", account);
            }

            return accountDetails.ToArray();
        }
    }

    public class AccountDetails
    {
        public int UserId { get; set; }
        public string AccountId { get; set; }
        public int Balance { get; set; }

    }
}
