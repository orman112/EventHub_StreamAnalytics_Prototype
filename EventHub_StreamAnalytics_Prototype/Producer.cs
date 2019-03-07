using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EventHub_StreamAnalytics_Prototype
{
    public static class Producer
    {
        [FunctionName("Producer")]
        [return: EventHub("health-monitoring-event-hub-v2", Connection = "health-monitoring-event-hub-connection")]
        public static string Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Producer function processed a request.");

            return JsonConvert.SerializeObject(new { Hello = "World" });
        }
    }
}
