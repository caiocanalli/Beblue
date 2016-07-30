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
    public class PrioridadeController : ApiController
    {
        private readonly IPrioridadeAppService _prioridadeApp;

        public PrioridadeController(IPrioridadeAppService prioridade)
        {
            _prioridadeApp = prioridade;
        }

        [HttpGet]
        [Route("api/prioridades")]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result = _prioridadeApp.GetAll();
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("api/prioridades")]
        public HttpResponseMessage Post([FromBody] dynamic body)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                Prioridade prioridade = new Prioridade();
                prioridade.Nome = body.nome;

                _prioridadeApp.Add(prioridade);

                response = Request.CreateResponse(HttpStatusCode.OK, "Prioridade adicionada com sucesso.");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
    }
}
