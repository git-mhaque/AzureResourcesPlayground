using System.Threading.Tasks;

namespace PlaygroundApp.Core
{
    public interface INotificationService
    {
        Task NotifyMessage(string message);
    }
}