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
    [RoutePrefix("api/Produtos")]
    public class ProdutosController : ApiController
    {

        private static List<Produtos> produtos = new List<Produtos>();


        private BaseContext _context = new BaseContext();


        
        public List<Produtos> Get()
        {
            return _context.Produto.ToList();
        }


        [Route("obterProdutosId/{id}")]
        [HttpGet]
        public Produtos getProdutosbyID(int id)
        {
            Produtos Produto = _context.Produto.Where(x => x.Id == id).FirstOrDefault();

            return Produto;
        }

        [Route("alteraProduto")]
        [HttpPost]
        public String alterarProduto(Produtos objProduto)
        {
            var original = _context.Produto.Where(x => x.Id == objProduto.Id).FirstOrDefault();

            if(original != null)
            {
                objProduto.DataCriacao = original.DataCriacao;
                objProduto.DataAlteracao = DateTime.Now;
                _context.Entry(original).CurrentValues.SetValues(objProduto);
            }
            else{
                objProduto.DataAlteracao = DateTime.Now;
                objProduto.DataCriacao = DateTime.Now;
                _context.Produto.Add(objProduto);
            }

            try
            {
                _context.SaveChanges();
                return "Salvo com sucesso";
            }
            catch
            {
                return "Erro ao salvar o produto";
            }
        }


        [Route("deletarProduto/{id}")]
        [HttpDelete]
        public void deletarProduto(int id)
        {
            var itemToRemove = _context.Produto.SingleOrDefault(x => x.Id == id);

            if (itemToRemove != null)
            {
                _context.Produto.Remove(itemToRemove);
                _context.SaveChanges();
            }
        }


    }
}
