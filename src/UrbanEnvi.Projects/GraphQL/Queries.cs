using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using UrbanEnvi.DataLoaders;
using UrbanEnvi.Features.AssessmentTypes;
using UrbanEnvi.Features.ProjectCategories;
using UrbanEnvi.Features.Projects;
using UrbanEnvi.Persistence;

namespace UrbanEnvi.GraphQL;

[ExtendObjectType(OperationTypeNames.Query)]
public class Queries
{
    [UseDbContext(typeof(ProjectsContext))]
    [Authorize]
    [UseOffsetPaging(IncludeTotalCount = true)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<AssessmentType> GetAssessmentTypes(
        [ScopedService] ProjectsContext context) =>
        context.AssessmentTypes;

    [Authorize]
    public Task<IReadOnlyList<AssessmentType>> GetAssessmentTypesByIdAsync(
        [ID(nameof(AssessmentType))] Guid[] ids,
        AssessmentTypeLoader loader,
        CancellationToken cancellationToken) =>
        loader.LoadAsync(ids, cancellationToken);

    [Authorize]
    public Task<AssessmentType> GetAssessmentTypeByIdAsync(
        [ID(nameof(AssessmentType))] Guid id,
        AssessmentTypeLoader loader,
        CancellationToken cancellationToken) =>
        loader.LoadAsync(id, cancellationToken);

    [UseDbContext(typeof(ProjectsContext))]
    [Authorize]
    [UseOffsetPaging(IncludeTotalCount = true)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<ProjectCategory> GetProjectCategories(
        [ScopedService] ProjectsContext context) =>
        context.ProjectCategories;

    [Authorize]
    public Task<IReadOnlyList<ProjectCategory>> GetProjectCategoriesByIdAsync(
        [ID(nameof(ProjectCategory))] Guid[] ids,
        ProjectCategoryLoader loader,
        CancellationToken cancellationToken) =>
        loader.LoadAsync(ids, cancellationToken);

    [Authorize]
    public Task<ProjectCategory> GetProjectCategoryByIdAsync(
        [ID(nameof(ProjectCategory))] Guid id,
        ProjectCategoryLoader loader,
        CancellationToken cancellationToken) =>
        loader.LoadAsync(id, cancellationToken);

    [UseDbContext(typeof(ProjectsContext))]
    [Authorize]
    [UseOffsetPaging(IncludeTotalCount = true)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Project> GetProjects(
        [ScopedService] ProjectsContext context) =>
        context.Projects;

    [Authorize]
    public Task<IReadOnlyList<Project>> GetProjectsByIdAsync(
        [ID(nameof(Project))] ulong[] ids,
        ProjectLoader loader,
        CancellationToken cancellationToken) =>
        loader.LoadAsync(ids, cancellationToken);

    [Authorize]
    public Task<Project> GetProjectByIdAsync(
        [ID(nameof(Project))] ulong id,
        ProjectLoader loader,
        CancellationToken cancellationToken) =>
        loader.LoadAsync(id, cancellationToken);
}