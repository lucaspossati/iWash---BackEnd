using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Cors;
using ExemploAPI.Domain;

namespace ExemploAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController
    {
        private static List<Usuarios> Usuarios = new List<Usuarios>();

        private BaseContext _context = new BaseContext();


        
        public List<Usuarios> Get()
        {
            return _context.Usuario.ToList();
        }


        [Route("getUsuariosbyID")]
        [HttpGet]
        public Usuarios getUsuariosbyID(int id)
        {
            Usuarios usuario = _context.Usuario.Where(x => x.Id == id).FirstOrDefault();

            return usuario;
        }

        [Route("aluno")]
        [Authorize]
        [HttpPost]
        public String AlterarUsuario(Usuarios usuario)
        {          
                      
            _context.Usuario.Add(usuario);

            try
            {
                _context.SaveChanges();
                return "Salvo com sucesso";
            }
            catch
            {
                return "Erro ao salvar o usuário";
            }       

        }

        [Route("login")]
        public Usuarios Login(UsuariosLogin login)
        {

            Usuarios usuario = _context.Usuario.Where(x => x.Login == login.login && x.Senha == login.senha).FirstOrDefault();

            return usuario;

        }

        [Authorize]
        public void Delete(int id)
        {
            Usuarios.RemoveAt(Usuarios.IndexOf(Usuarios.First(x => x.Id.Equals(id))));
        }


    }
}
