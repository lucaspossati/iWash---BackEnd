using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemploAPI.Domain
{
    public class Enderecos
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public string PontoReferencia { get; set; }
        public string CEP { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public int UsuariosId { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }

        public Usuarios Usuarios { get; set; }

    }
}