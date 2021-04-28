using ExemploAPI.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ExemploAPI.Mapeamentos
{
    public class ParceirosMap : EntityTypeConfiguration<Parceiros>
    {
        public ParceirosMap()
        {
            ToTable("tblParceiro");

            HasKey(x => x.Id);

            //Usar o id como GUID
            //Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.NomeFantasia).HasMaxLength(60).IsRequired();
            Property(x => x.RazaoSocial).HasMaxLength(60).IsRequired();
            Property(x => x.CNPJ).HasMaxLength(60).IsRequired();
            Property(x => x.Endereco).HasMaxLength(60).IsRequired();
            Property(x => x.Numero).HasMaxLength(60).IsRequired();
            Property(x => x.Bairro).HasMaxLength(60).IsRequired();
            Property(x => x.Cidade).HasMaxLength(60).IsRequired();
            Property(x => x.CEP).HasMaxLength(60).IsRequired();
            Property(x => x.Senha).HasMaxLength(60).IsRequired();


        }
    }


}

