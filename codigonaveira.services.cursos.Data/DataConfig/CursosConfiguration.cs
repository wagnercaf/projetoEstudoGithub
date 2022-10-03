using codigonaveia.services.cursos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codigonaveia.services.cursos.Data.DataConfig
{
    public class CursosConfiguration : IEntityTypeConfiguration<EntidadeCursos>
    {
        public void Configure(EntityTypeBuilder<EntidadeCursos> builder)
        {
            builder.ToTable("Cursos");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            builder.Property(t => t.Titulo)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(t => t.Descricao)
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Property(t => t.Valor)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

           /* builder.Property(t => t.DataRegistro)
                .HasColumnType("varchar(50)")
                .IsRequired();
           */
        }
    }
}
