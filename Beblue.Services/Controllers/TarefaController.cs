using Beblue.Application.Interfaces;
using Beblue.Domain.Entities;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Beblue.Services.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TarefaController : ApiController
    {
        private readonly ITarefaAppService _tarefaApp;
        private readonly IUsuarioAppService _usuarioApp;

        public TarefaController(ITarefaAppService tarefaApp, IUsuarioAppService usuarioApp)
        {
            _tarefaApp = tarefaApp;
            _usuarioApp = usuarioApp;
        }

        [HttpGet]
        [Route("api/tarefas/{id}")]
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result = _tarefaApp.GetByIdUsuario(id);

                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("api/tarefas")]
        public HttpResponseMessage Post([FromBody] dynamic body)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                Tarefa tarefa = new Tarefa();
                tarefa.Nome = body.nome;
                tarefa.Descricao = body.descricao;
                tarefa.Concluida = body.concluida;
                tarefa.IdCategoria = body.categoria.idCategoria;
                tarefa.IdPrioridade = body.prioridade.idPrioridade;
                tarefa.IdUsuario = body.idUsuario;
                tarefa.DataCadastro = DateTime.Now;

                _tarefaApp.Add(tarefa);

                response = Request.CreateResponse(HttpStatusCode.Created, tarefa);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        [HttpPut]
        [Route("api/tarefas/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] dynamic body)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                Tarefa tarefa = _tarefaApp.GetById(id);

                if (tarefa == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, "Tarefa inválida.");
                }
                else
                {
                    tarefa.Nome = body.nome;
                    tarefa.Descricao = body.descricao;
                    tarefa.Concluida = body.concluida;
                    tarefa.IdCategoria = body.categoria.idCategoria;
                    tarefa.IdPrioridade = body.prioridade.idPrioridade;

                    _tarefaApp.Update(tarefa);

                    response = Request.CreateResponse(HttpStatusCode.OK, tarefa);
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        [HttpDelete]
        [Route("api/tarefas/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                Tarefa tarefa = _tarefaApp.GetById(id);

                if (tarefa == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, "Tarefa inválida.");
                }
                else
                {
                    _tarefaApp.Remove(tarefa);

                    response = Request.CreateResponse(HttpStatusCode.OK, "Tarefa removida com sucesso.");
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
    }
}
