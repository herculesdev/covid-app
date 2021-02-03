using CovidApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CovidApp.Infra.Data.Mappings
{
    public class CasoCovidMap : IEntityTypeConfiguration<CasoCovid>
    {
        public void Configure(EntityTypeBuilder<CasoCovid> builder)
        {
            builder.ToTable("casos_covid")
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Pais)
                .HasColumnName("nome_pais");

            builder.Property(x => x.Confirmados)
                .HasColumnName("confirmados");

            builder.Property(x => x.Mortes)
                .HasColumnName("mortes");

            builder.Property(x => x.Recuperados)
                .HasColumnName("recuperados");

            builder.Property(x => x.Data)
                .HasColumnName("data");
        }
    }
}