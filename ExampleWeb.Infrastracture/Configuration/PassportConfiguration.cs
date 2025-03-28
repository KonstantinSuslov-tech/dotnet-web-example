using ExampleWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExampleWeb.Infrastracture.Configuration
{
    internal class PassportConfiguration : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            builder.ToTable(
                "pasport",
                t =>
                {
                    t.HasComment("Паспорт");
                });

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Number)
               .HasComment("Номер");

            builder.Property(e => e.Series)
               .HasComment("Серия");

            builder.Property(e => e.IssueDate)
                .IsRequired()
                .HasComment("Дата выдачи");

            builder.Property(e => e.Birthday)
               .IsRequired()
               .HasComment("День рождения");

            builder.HasOne(p => p.User)
               .WithOne(u => u.Passport)
               .HasForeignKey<User>(u => u.PassportId);
        }
    }
}
