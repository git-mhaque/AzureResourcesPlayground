using System.Threading.Tasks;

namespace PlaygroundApp.Core
{
    public class NotificationService : INotificationService
    {
        private readonly IServiceBus _serviceBus;

        public NotificationService(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        public async Task NotifyMessage(string message)
        {
            await _serviceBus.SendMessage(message);
        }
    }
}