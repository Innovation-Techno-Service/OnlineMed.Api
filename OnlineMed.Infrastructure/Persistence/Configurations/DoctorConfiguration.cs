using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMed.Domain.Entities;
using OnlineMed.Infrastructure.Extensions;

namespace OnlineMed.Infrastructure.Persistence.Configurations;

internal sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable(nameof(Doctor));

        builder.HasKey(d => d.Id);

        #region Properties

        builder.Property(d => d.FullName)
            .IsRequired()
            .HasMaxLength(ConfigurationConstants.DefaultStringLength);

        builder.Property(d => d.Email)
            .IsRequired();

        builder.Property(d => d.PhoneNumber)
            .IsRequired();

        builder.Property(d => d.Specialization)
            .IsRequired();

        builder.Property(d => d.ConversationLanguages)
            .IsRequired()
            .HasMaxLength(ConfigurationConstants.MaxStringLength);

        builder.Property(d => d.Experience)
            .IsRequired();

        builder.Property(d => d.Age)
            .IsRequired();

        builder.Property(d => d.Price)
            .IsRequired()
            .HasCurrencyPrecision();

        builder.Property(d => d.Rating)
            .IsRequired()
            .HasCurrencyPrecision();

        builder.Property(d => d.Gender)
            .IsRequired();

        #endregion
    }
}
