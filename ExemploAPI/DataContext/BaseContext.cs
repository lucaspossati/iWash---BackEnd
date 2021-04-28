using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using ExemploAPI.Models;
using ExemploAPI.Domain;

namespace ExemploAPI
{
    public class BaseContext : DbContext
    {
        public BaseContext() : base("Wash") { }
        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Parceiros> Parceiro { get; set; }
        public DbSet<Produtos> Produto { get; set; }

    }
}