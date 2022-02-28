using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataDogLog_POC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogTestController : ControllerBase
    {
        // GET: api/<LogTestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {

            using (var log = new LoggerConfiguration().WriteTo.DatadogLogs(
                   "fa96881e39e42687ab8675a4f071d43a",
                    host: "Test Host",
                    source: "Test Source",
                    service: "Test log Service",
                    tags: new string[] { "<TAG_1>:<VALUE_1>", "<TAG_2>:<VALUE_2>" }).CreateLogger())
            {
                Exception ex = new Exception();
                var message = "Test Log ";
                
                //Error Log
                log.Error("Error Message {@ErrorMessage}, Exception {@Exception} ", message, ex);
               
                //Info Log
                log.Information("Info Message {@Message}", message);
               
                //Warning Log
                log.Warning("Warning Message {@Message}", message);

            }

            return new string[] { "Log Posted successfully in DataDog" };
        }

        // GET api/<LogTestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LogTestController>
        [HttpPost]
        public void Post(string value)
        {

            using (var  log = new LoggerConfiguration().WriteTo.DatadogLogs(
                    "fa96881e39e42687ab8675a4f071d43a",
                     host: "<HOST_NAME>",
                     source: "<SOURCE_NAME>",
                     service: "<SERVICE_NAME>",
                     tags: new string[] { "<TAG_1>:<VALUE_1>", "<TAG_2>:<VALUE_2>" }).CreateLogger()) 
            {
                Exception ex = new Exception();
                var message = value + "on" + DateTime.Now.ToString();

                //Error Log
                log.Error("Error Message {@ErrorMessage}, Exception {@Exception} ", message, ex);
                //Info Log
                log.Information("Info Message {@Message}", message);
                //Warning Log
                log.Warning("Warning Message {@Message}", message);

            }

        }

        // PUT api/<LogTestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LogTestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
