using Beblue.Application;
using Beblue.Application.Interfaces;
using Beblue.Domain.Interfaces.Repository;
using Beblue.Domain.Interfaces.Service;
using Beblue.Domain.Services;
using Beblue.Infrastructure.Repository.Repositories;
using Ninject.Modules;

namespace Beblue.Infrastructure.CrossCutting.IoC
{
    public class PrioridadeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPrioridadeRepository>().To<PrioridadeRepository>();

            Bind<IPrioridadeService>().To<PrioridadeService>();

            Bind<IPrioridadeAppService>().To<PrioridadeAppService>();
        }
    }
}
