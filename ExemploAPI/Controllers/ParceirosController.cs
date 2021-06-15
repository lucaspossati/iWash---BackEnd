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
    [RoutePrefix("api/Parceiros")]
    public class ParceirosController : ApiController
    {
        private static List<Parceiros> parceiros = new List<Parceiros>();

        private static List<Produtos> produtos = new List<Produtos>();


        private BaseContext _context = new BaseContext();


        
        public List<Parceiros> Get()
        {
            return _context.Parceiro.ToList();
        }


        [Route("obterParceirosId/{id}")]
        [HttpGet]
        public Parceiros obterParceirosId(int id)
        {
            Parceiros Parceiro = _context.Parceiro.Where(x => x.Id == id).FirstOrDefault();

            return Parceiro;
        }


        [Route("alteraParceiro")]
        [HttpPost]
        public String alterarParceiro( Parceiros parceiro)
        {

            var original = _context.Parceiro.Where(x => x.Id == parceiro.Id).FirstOrDefault();

            if(original != null)
            {
                parceiro.DataCriacao = original.DataCriacao;
                parceiro.DataAlteracao = DateTime.Now;
                _context.Entry(original).CurrentValues.SetValues(parceiro);
            }
            else
            {
                parceiro.DataAlteracao = DateTime.Now;
                parceiro.DataCriacao = DateTime.Now;
                _context.Parceiro.Add(parceiro);
            }


            try
            {
                _context.SaveChanges();
                return "Salvo com sucesso";
            }
            catch
            {
                return "Erro ao salvar o parceiro";
            }

        }

        [Route("loginParceiro")]
        public Parceiros logarParceiro(ParceirosLogin login)
        {

            Parceiros parceiro = _context.Parceiro.Where(x => x.CNPJ == login.CNPJ && x.Senha == login.senha).FirstOrDefault();

            return parceiro;

        }

        [Route("deletarParceiro/{id}")]
        [HttpDelete]
        public void deletarParceiro(int id)
        {
            var itemToRemove = _context.Parceiro.SingleOrDefault(x => x.Id == id);

            if (itemToRemove != null)
            {
                _context.Parceiro.Remove(itemToRemove);
                _context.SaveChanges();
            }
            
        }


    }
}
