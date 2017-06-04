using Autofac;
using PortStatusApp;

namespace portstatus.IoC
{
    public class Bootstrap
    {
        public IContainer InitialiseContainer()
        {
            // Create your builder.
            var builder = new ContainerBuilder();
            ConfigureContainer(builder);
            return builder.Build();
        }

        private void ConfigureContainer(ContainerBuilder builder)
        {

            builder.RegisterType<Networking>().As<INetworking>();

        }
    }
}