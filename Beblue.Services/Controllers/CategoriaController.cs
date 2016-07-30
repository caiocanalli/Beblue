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
    public class CategoriaController : ApiController
    {
        private readonly ICategoriaAppService _categoriaApp;

        public CategoriaController(ICategoriaAppService categoriaApp)
        {
            _categoriaApp = categoriaApp;
        }

        [HttpGet]
        [Route("api/categorias")]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result = _categoriaApp.GetAll();
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        [HttpGet]
        [Route("api/categorias/{id}")]
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result = _categoriaApp.GetById(id);
                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("api/categorias")]
        public HttpResponseMessage Post([FromBody] dynamic body)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                Categoria categoria = new Categoria();
                categoria.Nome = body.nome;

                _categoriaApp.Add(categoria);

                response = Request.CreateResponse(HttpStatusCode.OK, "Categoria adicionada com sucesso.");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        [HttpPut]
        [Route("api/categorias/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] dynamic body)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                Categoria categoria = _categoriaApp.GetById(id);

                if (categoria == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, "Categoria inválida.");
                }
                else
                {
                    categoria.Nome = body.nome;

                    _categoriaApp.Update(categoria);

                    response = Request.CreateResponse(HttpStatusCode.OK, "Categoria atualizada com sucesso.");
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        [HttpDelete]
        [Route("api/categorias/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                Categoria categoria = _categoriaApp.GetById(id);

                if (categoria == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, "Categoria inválida.");
                }
                else
                {
                    _categoriaApp.Remove(categoria);

                    response = Request.CreateResponse(HttpStatusCode.BadRequest, "Categoria removida com sucesso.");
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
