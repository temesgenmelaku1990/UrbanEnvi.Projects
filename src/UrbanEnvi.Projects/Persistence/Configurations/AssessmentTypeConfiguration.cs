using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanEnvi.Features.AssessmentTypes;
using UrbanEnvi.Persistence.Comparers;

namespace UrbanEnvi.Persistence.Configurations;

internal class AssessmentTypeConfiguration : IEntityTypeConfiguration<AssessmentType>
{
    public void Configure(EntityTypeBuilder<AssessmentType> builder) =>
        builder
            .Property(x => x.Types)
            .SetJsonComparison()
            .HasColumnType("jsonb");
}
