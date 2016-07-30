using Beblue.Domain.Entities;
using Beblue.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Beblue.Infrastructure.Repository.Repositories
{
    public class TarefaRepository : RepositoryBase<Tarefa>, ITarefaRepository
    {
        public IEnumerable<Tarefa> GetByIdUsuario(int idUsuario)
        {
            return db.Tarefas.Where(x => x.IdUsuario == idUsuario).ToList();
        }
    }
}
