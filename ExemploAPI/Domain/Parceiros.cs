using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExemploAPI.Domain
{
    public class Parceiros
    {
        public Parceiros()
        {
            this.ProdutosObj = new List<Produtos>();

        }

        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; } 
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Senha { get; set; }
        public virtual ICollection<Produtos> ProdutosObj { get; set; }

    }

    public class ParceirosLogin
    {
        public string CNPJ { get; set; }
        public string senha { get; set; }

    }
}

