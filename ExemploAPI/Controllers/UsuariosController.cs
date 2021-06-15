using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Cors;
using ExemploAPI.Domain;
using System.Data.Entity;

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


        [Route("obterUsuariosId/{id}")]
        [HttpGet]
        public Usuarios obterUsuariosID(int id)
        {
            Usuarios usuario = _context.Usuario.Where(x => x.Id == id).FirstOrDefault();

            return usuario;
        }

        [Route("alterarUsuario")]       
        [HttpPost]
        public int alterarUsuario(Usuarios usuario)
        {
            var original = _context.Usuario.Where(x => x.Id == usuario.Id).FirstOrDefault();

            var usuarioExistente = _context.Usuario.Where(x => x.Email == usuario.Email).Count();

            if(usuarioExistente > 0)
            {
                return 2;
            }

            if (original != null)
            {
                usuario.DataCriacao = original.DataCriacao;
                usuario.DataAlteracao = DateTime.Now;
                _context.Entry(original).CurrentValues.SetValues(usuario);
            }
            else
            {
                
                usuario.DataAlteracao = DateTime.Now;
                usuario.DataCriacao = DateTime.Now;
                _context.Usuario.Add(usuario);              
            }
   

            try
            {
                _context.SaveChanges();
                return 0;
            }
            catch
            {
                return 1;
            }       

        }
  

        [Route("loginUsuario")]
       
        public Usuarios logarUsuario(UsuariosLogin login)
        {

            Usuarios usuario = _context.Usuario.Where(x => x.Email == login.email && x.Senha == login.senha).FirstOrDefault();

            return usuario;

        }

        [Route("deletarUsuario/{id}")]
        [HttpDelete]
        public void deletarUsuario(int id)
        {
            var itemToRemove = _context.Usuario.SingleOrDefault(x => x.Id == id);

            if (itemToRemove != null)
            {
                _context.Usuario.Remove(itemToRemove);
                _context.SaveChanges();
            }
        }


    }
}
