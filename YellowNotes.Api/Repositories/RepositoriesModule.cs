using Autofac;

namespace YellowNotes.Api.Repositories
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NotesRepository>().As<INotesRepository>();
        }
    }
}
