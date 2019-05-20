using Autofac;
using PlaygroundApp.Core;

namespace PlaygroundApp.ServiceBus.Azure
{
    public class AzureServiceBusModule : Module 
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new AzureServiceBus()).As<IServiceBus>();
        }
    }
}