using Beblue.Application;
using Beblue.Application.Interfaces;
using Beblue.Domain.Interfaces.Repository;
using Beblue.Domain.Interfaces.Service;
using Beblue.Domain.Services;
using Beblue.Infrastructure.Repository.Repositories;
using Ninject.Modules;

namespace Beblue.Infrastructure.CrossCutting.IoC
{
    public class TarefaModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITarefaRepository>().To<TarefaRepository>();

            Bind<ITarefaService>().To<TarefaService>();

            Bind<ITarefaAppService>().To<TarefaAppService>();
        }
    }
}
