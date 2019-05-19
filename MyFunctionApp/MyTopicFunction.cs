using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace MyFunctionApp
{
    public static class MyTopicFunction
    {
        [FunctionName("MyTopicFunction")]
        public static void Run([ServiceBusTrigger("mytopic", "mysub1", Connection = "ServiceBusConnectionString")]string message, ILogger log)
        {
            log.LogInformation($"Message received from subscription: {message}");
        }
    }
}