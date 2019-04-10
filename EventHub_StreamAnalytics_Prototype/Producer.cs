using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using System;

namespace EventHub_StreamAnalytics_Prototype
{
    public static partial class Functions
    {
        [FunctionName("Producer")]
        [return: EventHub("test-event-hub", Connection = "test-event-hub-connection")]
        public static string Producer(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest request,
            ExecutionContext executionContext,
            Microsoft.Extensions.Logging.ILogger log)
        {
            Initialize(executionContext);

            log.LogInformation("Producer function processed a request.");

            if (Convert.ToBoolean(_configuration["teamsAlertEnabled"]))
            {
                var webHookUri = "";
                var testLog = new LoggerConfiguration()
                    .WriteTo.MicrosoftTeams(webHookUri, title: "This is a test alert")
                    .CreateLogger();

                testLog.Information("Testing new Alert");
            }

            return JsonConvert.SerializeObject(new { Hello = "World" });
        }
    }
}
