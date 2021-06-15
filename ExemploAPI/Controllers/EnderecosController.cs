using ExemploAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ExemploAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Enderecos")]
    public class EnderecosController : ApiController
    {
        private static List<Enderecos> enderecos = new List<Enderecos>();

        private static List<Parceiros> parceiros = new List<Parceiros>();

        private static List<Usuarios> usuarios = new List<Usuarios>();

        private BaseContext _context = new BaseContext();


        public List<Enderecos> Get()
        {
            return _context.Endereco.ToList();
        }


        [Route("obterEnderecosId/{id}")]
        [HttpGet]
        public List<Enderecos> obterEnderecosId(int id)
        {
            return _context.Endereco.Where(x => x.UsuariosId == id).ToList();
        }

        [Route("obterEnderecoId/{id}")]
        [HttpGet]
        public Enderecos obterEnderecoId(int id)
        {
            return _context.Endereco.Where(x => x.Id == id).FirstOrDefault();
        }

        [Route("alterarEndereco")]
        [HttpPost]
        public int alterarEndereco(Enderecos endereco)
        {
            var original = _context.Endereco.Where(x => x.Id == endereco.Id).FirstOrDefault();


            if (original != null)
            {
                endereco.DataCriacao = original.DataCriacao;
                endereco.DataAlteracao = DateTime.Now;
                _context.Entry(original).CurrentValues.SetValues(endereco);
            }
            else
            {
                endereco.UsuariosId = endereco.UsuariosId;
                endereco.DataAlteracao = DateTime.Now;
                endereco.DataCriacao = DateTime.Now;
                _context.Endereco.Add(endereco);
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



        [Route("existeEndereco")]
        [HttpPost]
        public int existeEndereco(Enderecos usuariosId)
        {
            var contarEndereco = _context.Endereco.Where(x => x.UsuariosId == usuariosId.UsuariosId).Count();

            if (contarEndereco == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }


        [Route("deletarEndereco/{id}")]
        [HttpDelete]
        public string deletarEndereco(int id)
        {
            var enderecoParaRemover = _context.Endereco.SingleOrDefault(x => x.Id == id);

            if (enderecoParaRemover != null)
            {
                try
                {
                    _context.Endereco.Remove(enderecoParaRemover);
                    _context.SaveChanges();
                    return "Deletado com sucesso.";
                }
                catch
                {
                    return "Erro.";
                }
               
            }
            else
            {
                return "Não existe endereço com o ID que foi passado para ser removido.";
            }
        }
    }
}