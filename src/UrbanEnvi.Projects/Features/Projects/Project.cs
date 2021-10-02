using NetTopologySuite.Geometries;
using UrbanEnvi.Features.ProjectCategories;

namespace UrbanEnvi.Features.Projects;

public class Project : Entity<ulong>
{
    public string Name { get; set; } = null!;

    public ulong Number =>
        Id;

    public Point Location { get; set; } = null!;

    public Guid OrganizationId { get; set; }

    public Guid ProjectCategoryId { get; set; }

    public virtual ProjectCategory ProjectCategory { get; set; } = null!;
}
