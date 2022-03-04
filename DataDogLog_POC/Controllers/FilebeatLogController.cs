using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
//using Microsoft.Extensions.Logging;
using DataDogLog_POC.Utility;
using Microsoft.Extensions.Logging;

namespace DataDogLog_POC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilebeatLogController : ControllerBase
    {
        private readonly ILogger<ConsoleLogController> _logger;

        public FilebeatLogController(ILogger<ConsoleLogController> logger)
        {
            _logger = logger;

        }

        [HttpGet]
        public IEnumerable<LogDetails> Get()
        {

            _logger.LogInformation(" Writing to log file with INFORMATION severity level.");

            _logger.LogDebug("Writing to log file with DEBUG severity level.");

            _logger.LogWarning("Writing to log file with WARNING severity level.");

            _logger.LogError("Writing to log file with ERROR severity level.");

            _logger.LogCritical("Writing to log file with CRITICAL severity level.");

            var logDetails = new List<LogDetails> {
             new LogDetails{ Id = 2324 , Message="Ifomartion Log "},
             new LogDetails{ Id = 3454 , Message="Worrning Log "},
             new LogDetails{ Id = 7686 , Message="Error Log" }
            };


            foreach (var log in logDetails)
            {
                _logger.LogInformation("log details {@log}", log);
            }

            return logDetails.ToArray();
        }
    }

    public class LogDetails
    {
        public int Id { get; set; }
        public string Message { get; set; }

    }
}
