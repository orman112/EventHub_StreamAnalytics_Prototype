using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace EventHub_StreamAnalytics_Prototype
{
    public static class ConsumerServiceBus
    {
        [FunctionName("ConsumerServiceBus")]
        public static void Run([ServiceBusTrigger("health-monitoring", "catch-all", Connection = "health-monitoring-topic-connection")]string mySbMsg, ILogger log)
        {
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}
