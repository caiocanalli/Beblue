using System;

namespace Beblue.Domain.Entities
{
    public class Tarefa
    {
        public long IdTarefa { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Concluida { get; set; }

        public virtual int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }

        public virtual short IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }

        public virtual short IdPrioridade { get; set; }
        public virtual Prioridade Prioridade { get; set; }
    }
}
