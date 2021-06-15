using ExemploAPI.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ExemploAPI.Mapeamento
{
    public class EnderecosMap : EntityTypeConfiguration<Enderecos>
    {
        public EnderecosMap()
        {
            ToTable("tblEndereco");

            HasKey(x => x.Id);

            //Usar o id como GUID
            //Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.Titulo).HasMaxLength(30).IsRequired();
            Property(x => x.Rua).HasMaxLength(120).IsRequired();
            Property(x => x.Numero).IsRequired();
            Property(x => x.Bairro).HasMaxLength(60).IsRequired();
            Property(x => x.Cidade).HasMaxLength(60).IsRequired();
            Property(x => x.Estado).HasMaxLength(60).IsRequired();
            Property(x => x.CEP).HasMaxLength(60).IsRequired();
            Property(x => x.Latitude).HasMaxLength(120).IsRequired();
            Property(x => x.Longitude).HasMaxLength(120).IsRequired();

            Property(x => x.PontoReferencia).HasMaxLength(120).IsRequired();
            Property(x => x.Complemento).HasMaxLength(60).IsRequired();

            HasRequired<Usuarios>(t => t.Usuarios).WithMany(t => t.EnderecosObj);

        }
    }
}