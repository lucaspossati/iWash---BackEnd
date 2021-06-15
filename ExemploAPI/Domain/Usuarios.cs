using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExemploAPI.Domain
{
    public class Usuarios
    {

        public Usuarios()
        {
            this.EnderecosObj = new List<Enderecos>();

        }

        public int Id { get; set; }
        public string ImagePerfil{ get; set; }
        public string PrimeiroNome{ get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }   
        public string CPF { get; set; }
        public string Senha { get; set; }
        public string Sexo { get; set; }
        public string DatadeNascimento { get; set; }
        public DateTime DataCriacao{ get; set; }
        public DateTime DataAlteracao { get; set; }

        public virtual ICollection<Enderecos> EnderecosObj { get; set; }

    }

    public class UsuariosLogin
    {
        public string email { get; set; }
        public string senha { get; set; }

    }
}