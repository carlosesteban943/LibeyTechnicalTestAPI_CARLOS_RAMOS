using LibeyTechnicalTestDomain.UbigeoAggregate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LibeyTechnicalTestDomain.EFCore.Configuration
{
    internal class UbigeoConfiguration : IEntityTypeConfiguration<Ubigeo>
    {
        public void Configure(EntityTypeBuilder<Ubigeo> builder)
        {
            builder.ToTable("Ubigeo").HasKey(x => x.UbigeoCode);

            builder.HasOne(u => u.Province).WithMany(p => p.Ubigeo)
               .HasForeignKey(u => u.ProvinceCode)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_Ubigeo_Province");

            builder.HasOne(u => u.Region).WithMany(p => p.Ubigeo)
            .HasForeignKey(u => u.RegionCode)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Ubigeo_Region");
        }
    }
}