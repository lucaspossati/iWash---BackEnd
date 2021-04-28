﻿using ExemploAPI.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ExemploAPI.Mapeamentos
{
    public class UsuariosMap : EntityTypeConfiguration<Usuarios>
    {
        public UsuariosMap()
        {
            ToTable("tblUsuario");

            HasKey(x => x.Id);

            //Usar o id como GUID
            //Property(x => x.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.PrimeiroNome).HasMaxLength(60).IsRequired();
            Property(x => x.Sobrenome).HasMaxLength(60).IsRequired();
            Property(x => x.Email).HasMaxLength(60).IsRequired();
            Property(x => x.Endereco).HasMaxLength(200).IsRequired();
            Property(x => x.Numero).HasMaxLength(60).IsRequired();
            Property(x => x.Bairro).HasMaxLength(60).IsRequired();
            Property(x => x.Cidade).HasMaxLength(60).IsRequired();
            Property(x => x.Estado).HasMaxLength(60).IsRequired();
            Property(x => x.CEP).HasMaxLength(60).IsRequired();
            Property(x => x.Login).HasMaxLength(60).IsRequired();
            Property(x => x.Senha).HasMaxLength(60).IsRequired();
            Property(x => x.DatadeNascimento).HasMaxLength(60).IsRequired();

        }
        
    }

}