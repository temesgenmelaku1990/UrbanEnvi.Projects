using NetTopologySuite.Geometries;
using UrbanEnvi.Persistence;

namespace UrbanEnvi.Features.Projects;

public record CreateProject(
    string Name,
    Guid OrganizationId,
    Guid ProjectCategoryId,
    Point Location
) : IRequest<Result<Project>>;

public class CreateProjectHandler : IRequestHandler<CreateProject, Result<Project>>
{
    private readonly ProjectsContext _context;

    public CreateProjectHandler(ProjectsContext context) =>
        _context = context;

    public async Task<Result<Project>> Handle(CreateProject request, CancellationToken cancellationToken) =>
        await Result
            .Try(() => request.Adapt<Project>())
            .Tap(async project => await _context.Projects.AddAsync(project, cancellationToken))
            .Tap(() => _context.SaveChangesAsync(cancellationToken));
}
