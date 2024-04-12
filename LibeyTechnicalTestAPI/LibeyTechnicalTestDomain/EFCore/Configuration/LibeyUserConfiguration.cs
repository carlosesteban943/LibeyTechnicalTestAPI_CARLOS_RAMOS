using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LibeyTechnicalTestDomain.EFCore.Configuration
{
    internal class LibeyUserConfiguration : IEntityTypeConfiguration<LibeyUser>
    {
        public void Configure(EntityTypeBuilder<LibeyUser> builder)
        {
            builder.ToTable("LibeyUser").HasKey(x => x.DocumentNumber);

            builder.HasOne(l => l.Ubigeo).WithMany(u => u.LibeyUsers)
                .HasForeignKey(l => l.UbigeoCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LibeyUser_Ubigeo");
        }
    }
}