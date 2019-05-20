using PlaygroundApp.Core;
using Microsoft.Azure.ServiceBus;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundApp.ServiceBus.Azure
{
    public class AzureServiceBus : IServiceBus
    {
        private const string ServiceBusConnectionString = "Endpoint=sb://mh-messaging.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=zq2dnRSYcFZEG2ldDJRlhKAABXFWElTCon31dre5MmI=";
        private const string TopicName = "mytopic";

        public async Task SendMessage(string messageToSend)
        {
            var topicClient = new TopicClient(ServiceBusConnectionString, TopicName);
            var message = new Message(Encoding.UTF8.GetBytes(messageToSend));
            await topicClient.SendAsync(message);
        }
    }
}