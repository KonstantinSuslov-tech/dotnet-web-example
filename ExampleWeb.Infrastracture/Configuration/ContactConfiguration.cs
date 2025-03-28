using ExampleWeb.Domain;
using ExampleWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExampleWeb.Infrastracture.Configuration
{
    internal class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable(
                "contact",
                t =>
                {
                    t.HasComment("Контакт");
                });

            builder.HasKey(e => e.Id);

            builder.Property(e => e.UserId)
               .HasComment("Индетификатор юзера");

            builder.Property(e => e.Email)
               .HasComment("Почта");

            builder.Property(e => e.Phone)
                .IsRequired()
                .HasComment("Телефон");

            builder.HasOne(c => c.User)
               .WithMany(u => u.Contacts)
               .HasForeignKey(c => c.UserId);
        }
    }
}
