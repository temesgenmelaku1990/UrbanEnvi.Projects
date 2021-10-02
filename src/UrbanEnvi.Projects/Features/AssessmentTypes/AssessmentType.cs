using System.Collections.Immutable;

namespace UrbanEnvi.Features.AssessmentTypes;

public class AssessmentType : Entity<Guid>
{
    public string Name { get; set; } = null!;

    public ISet<CoreAssessmentType> Types { get; set; } = ImmutableHashSet<CoreAssessmentType>.Empty;
}
