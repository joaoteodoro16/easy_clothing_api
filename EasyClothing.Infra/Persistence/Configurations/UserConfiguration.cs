using EasyClothing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyClothing.Infra.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Role)
                .IsRequired();

            builder.Property(x => x.Street)
                .HasMaxLength(200);

            builder.Property(x => x.City)
                .HasMaxLength(100);

            builder.Property(x => x.State)
                .HasMaxLength(50);

            builder.Property(x => x.Country)
                .HasMaxLength(50);

            builder.Property(x => x.Complement)
                .HasMaxLength(200);

            // VALUE OBJECTS

            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(e => e.Address)
                    .HasColumnName("Email")
                    .IsRequired();
            });

            builder.OwnsOne(x => x.Cpf, cpf =>
            {
                cpf.Property(c => c.Number)
                    .HasColumnName("Cpf");
            });

            builder.OwnsOne(x => x.Cep, cep =>
            {
                cep.Property(c => c.Code)
                    .HasColumnName("Cep");
            });

            builder.OwnsOne(x => x.CellPhone, phone =>
            {
                phone.Property(p => p.Number)
                    .HasColumnName("CellPhone");
            });
        }
    }
}
