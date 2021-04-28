
using ExemploAPI.Domain;
using System.Data.Entity.ModelConfiguration;

namespace ExemploAPI.Mapeamentos
{
    public class ProdutosMap : EntityTypeConfiguration<Produtos>
    {
        public ProdutosMap()
        {
            ToTable("tblProduto");

            HasKey(x => x.Id);

            //Usar o id como GUID
            //Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasMaxLength(60).IsRequired();
            Property(x => x.Preco).HasPrecision(13, 3).IsRequired();
            Property(x => x.Descricao).HasMaxLength(300).IsRequired();


            HasRequired<Parceiros>(t => t.Parceiros).WithMany(t => t.ProdutosObj);

        }

    }
}

