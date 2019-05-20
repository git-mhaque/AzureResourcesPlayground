using Autofac;

namespace PlaygroundApp.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new NotificationService(c.Resolve<IServiceBus>())).As<INotificationService>();
        }
    }
}