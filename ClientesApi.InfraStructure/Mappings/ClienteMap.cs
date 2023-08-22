using ClientesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApi.InfraStructure.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTE");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("ID");

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnName("EMAIL")
                .IsRequired();

            builder.Property(c => c.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(c => c.Telefone)
            .HasColumnName("TELEFONE")
            .HasColumnType("varchar(20)")
            .HasMaxLength(20)
            .IsRequired();

            builder.Property(c => c.DataHoraCriacao)
                .HasColumnName("DATAHORACRIACAO")
                .IsRequired();


        }
    }
}
