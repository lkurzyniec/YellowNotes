using Autofac;

namespace YellowNotes.Api.Services
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FakeLogger>().As<ILogger>();
        }
    }
}
