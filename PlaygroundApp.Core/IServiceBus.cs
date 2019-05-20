using System.Threading.Tasks;

namespace PlaygroundApp.Core
{
    public interface IServiceBus
    {
        Task SendMessage(string messageToSend);
    }
}