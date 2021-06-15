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
        public BaseContext()
            : base("Wash")
        {
            //Database.SetInitializer<BookStoreDataContext>(null);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Parceiros> Parceiro { get; set; }
        public DbSet<Produtos> Produto { get; set; }
        public DbSet<Enderecos> Endereco { get; set; }


    }
}