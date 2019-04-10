using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EventHub_StreamAnalytics_Prototype
{
    public static partial class Functions
    {
        [FunctionName("Consumer")]
        public static async Task<IActionResult> Consumer(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Stream Analytics Consumer Triggered");

            return new OkResult();
        }
    }
}
