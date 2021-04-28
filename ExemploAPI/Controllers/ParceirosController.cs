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

        [Route("getParceirosComProdutos")]
        [HttpGet]
        public Parceiros getParceirosComProdutos(int id)
        {
            Parceiros Parceiro = _context.Parceiro.Where(x => x.Id == id).FirstOrDefault();

            return Parceiro;
        }

        [Route("getParceirosbyID")]
        [HttpGet]
        public Parceiros getParceirosbyID(int id)
        {
            Parceiros Parceiro = _context.Parceiro.Where(x => x.Id == id).FirstOrDefault();

            return Parceiro;
        }

        [Route("aluno")]
        [Authorize]
        [HttpPost]
        public String AlterarParceiro(Parceiros parceiro)
        {

            _context.Parceiro.Add(parceiro);

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
        public Parceiros Login(ParceirosLogin login)
        {

            Parceiros parceiro = _context.Parceiro.Where(x => x.CNPJ == login.CNPJ && x.Senha == login.senha).FirstOrDefault();

            return parceiro;

        }

        [Authorize]
        public void Delete(int id)
        {
            parceiros.RemoveAt(parceiros.IndexOf(parceiros.First(x => x.Id.Equals(id))));
        }


    }
}
