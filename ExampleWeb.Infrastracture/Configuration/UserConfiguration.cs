using ExampleWeb.Domain;
using ExampleWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExampleWeb.Infrastracture.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(
                "user",
                t =>
                {
                    t.HasComment("Пользователь");
                });

            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
               .IsRequired()
               .HasMaxLength(255)
               .HasComment("Имя");

            builder.Property(e => e.LastName)
               .IsRequired()
               .HasMaxLength(255)
               .HasComment("Фамилия");

            builder.Property(e => e.PassportId)
                .HasComment("Индетификатор паспорта");

            builder.HasOne(u => u.Passport)
           .WithOne(p => p.User)
           .HasForeignKey<User>(u => u.PassportId);

            builder.HasMany(u => u.Contacts)
               .WithOne(c => c.User)
               .HasForeignKey(c => c.UserId);
        }
    }
}
