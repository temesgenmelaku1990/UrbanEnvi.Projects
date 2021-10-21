using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UrbanEnvi.EntityFrameworkCore;
using UrbanEnvi.Features.AssessmentTypes;
using UrbanEnvi.Features.ProjectCategories;
using UrbanEnvi.Features.Projects;

namespace UrbanEnvi.Persistence;

public class ProjectsContext : AppDbContext
{
    public ProjectsContext(DbContextOptions<ProjectsContext> options) : base(options)
    {
    }

    public DbSet<AssessmentType> AssessmentTypes { get; set; } = null!;
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<ProjectCategory> ProjectCategories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        _ = modelBuilder
            .HasDefaultSchema("Projects")
            .HasPostgresExtension("postgis")
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
