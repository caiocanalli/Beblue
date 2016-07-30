using Beblue.Application;
using Beblue.Application.Interfaces;
using Beblue.Domain.Interfaces.Repository;
using Beblue.Domain.Interfaces.Service;
using Beblue.Domain.Services;
using Beblue.Infrastructure.Repository.Repositories;
using Ninject.Modules;

namespace Beblue.Infrastructure.CrossCutting.IoC
{
    public class BaseModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));

            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));

            Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
        }
    }
}
