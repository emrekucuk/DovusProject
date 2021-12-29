using DovusProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DovusProject.DataAccess.Concrete.Configuration
{
    public class DovuscuOzellikleriConfiguration : IEntityTypeConfiguration<DovuscuOzellikleri>
    {
        public void Configure(EntityTypeBuilder<DovuscuOzellikleri> builder)
        {
            builder.HasData(
                new DovuscuOzellikleri { Id = 1, Ad = "Armor King", CanDegeri = 100, ZırhDegeri = 100, DuzVurusHasari = 10, 
                    Yetenek1 = "Aparkat", Yetenek1Hasari = 25, Yetenek2 = "Döner Tekme", Yetenek2Hasari = 35 }
            );
        }
    }
}
