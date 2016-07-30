using Beblue.Domain.Entities;
using System.Collections.Generic;

namespace Beblue.Application.Interfaces
{
    public interface ITarefaAppService : IAppServiceBase<Tarefa>
    {
        IEnumerable<Tarefa> GetByIdUsuario(int idUsuario);
    }
}
