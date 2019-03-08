using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;

namespace EventHub_StreamAnalytics_Prototype
{
    public static class Producer
    {
        [FunctionName("Producer")]
        [return: EventHub("health-monitoring-event-hub-v2", Connection = "health-monitoring-event-hub-connection")]
        public static string Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req,
            Microsoft.Extensions.Logging.ILogger log)
        {
            log.LogInformation("Producer function processed a request.");

            var webHookUri = "";
            var testLog = new LoggerConfiguration()
                .WriteTo.MicrosoftTeams(webHookUri, title: "This is a test alert")
                .CreateLogger();

            testLog.Information("Testing new Alert");

            return JsonConvert.SerializeObject(new { Hello = "World" });
        }
    }
}
