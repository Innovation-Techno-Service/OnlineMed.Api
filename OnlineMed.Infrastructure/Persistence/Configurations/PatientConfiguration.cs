using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineMed.Domain.Entities;

namespace OnlineMed.Infrastructure.Persistence.Configurations;

internal sealed class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable(nameof(Patient));

        builder.HasKey(p => p.Id);

        #region Property

        builder.Property(p => p.FullName)
            .IsRequired()
            .HasMaxLength(ConfigurationConstants.DefaultStringLength);

        builder.Property(p => p.Email)
            .IsRequired(false);

        #endregion         
    }
}
