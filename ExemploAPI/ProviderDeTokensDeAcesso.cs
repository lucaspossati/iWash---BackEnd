﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using ExemploAPI.Models;
using ExemploAPI.Controllers;

namespace ExemploAPI
{
    public class ProviderDeTokensDeAcesso : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        private BaseContext _context = new BaseContext();

        public bool logarUsuarios(string login, string password)
        {
            return _context.Usuario.Where(x => x.Login == login && x.Senha == password).Count() > 0;
        }

        public bool logarParceiros(string login, string password)
        {
            return _context.Parceiro.Where(x => x.CNPJ == login && x.Senha == password).Count() > 0;
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            
            if (logarUsuarios(context.UserName, context.Password) == true)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("Acesso inválido", "As credenciais do usuário não conferem....");
                return;
            }
        }

       
    }
}