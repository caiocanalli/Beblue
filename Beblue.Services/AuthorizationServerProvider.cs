using Beblue.Application.Interfaces;
using Beblue.Domain.Utils;
using Beblue.Infrastructure.Repository.Repositories;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Beblue.Services
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private UsuarioRepository usuarioRepository = new UsuarioRepository();

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");

            if (allowedOrigin == null) allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            string user = context.UserName;
            string password = context.Password;

            var usuario = usuarioRepository.Authenticate(user, MD5.HashMD5(password));

            if (usuario != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("sub", context.UserName));

                var retorno = new Dictionary<string, string>();
                retorno.Add("userName", context.UserName);
                retorno.Add("id", usuario.IdUsuario.ToString());
                retorno.Add("nome", usuario.Nome);

                var props = new AuthenticationProperties(retorno);

                var ticket = new AuthenticationTicket(identity, props);
                context.Validated(ticket);
            }
            else
            {
                context.SetError("invalid_grant", "O e-mail ou a senha estão incorretos");
                return;
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}
