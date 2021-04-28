using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExemploAPI.Domain
{
    public class Usuarios
    {
        
        public int Id { get; set; }
        public string PrimeiroNome{ get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Endereco{ get; set; }
        public string Numero{ get; set; }
        public string Bairro{ get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string CPF { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public char Sexo { get; set; }
        public string DatadeNascimento { get; set; }
        

    }

    public class UsuariosLogin
    {
        public string login { get; set; }
        public string senha { get; set; }

    }
}