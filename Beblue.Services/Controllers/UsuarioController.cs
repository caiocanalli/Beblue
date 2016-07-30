using Beblue.Application.Interfaces;
using Beblue.Domain.Entities;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Beblue.Services.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioAppService _usuarioApp;

        public UsuarioController(IUsuarioAppService usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        [HttpPost]
        [Route("api/usuarios/cadastrar")]
        public HttpResponseMessage Post([FromBody] dynamic body)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                string email = body.email;

                Usuario usuario = _usuarioApp.GetByEmail(email);

                if (usuario == null)
                {
                    usuario = new Usuario();
                    usuario.Nome = body.nome;
                    usuario.Email = body.email;

                    string senha = body.senha;

                    usuario.Senha = usuario.CriptografarSenha(senha);

                    _usuarioApp.Add(usuario);

                    response = Request.CreateResponse(HttpStatusCode.Created, usuario);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.Ambiguous, "O e-mail já existe na base de dados");
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("api/usuarios/senha")]
        public HttpResponseMessage Senha([FromBody] dynamic body)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                string email = body.email;

                Usuario usuario = _usuarioApp.GetByEmail(email);

                if (usuario != null)
                {
                    usuario.Senha = usuario.CriptografarSenha("12345678");

                    _usuarioApp.Update(usuario);

                    response = Request.CreateResponse(HttpStatusCode.OK, "Nova senha: 12345678");
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, "E-mail inválido ou inexistente");
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
