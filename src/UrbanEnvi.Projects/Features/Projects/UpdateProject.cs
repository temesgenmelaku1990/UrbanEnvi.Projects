using NetTopologySuite.Geometries;
using UrbanEnvi;
using UrbanEnvi.Persistence;

namespace UrbanEnvi.Features.Projects;

public record UpdateProject(
    ulong Id,
    string Name,
    Guid ProjectCategoryId,
    Point Location
) : IRequest<Result<Project>>;

public class UpdateProjectHandler : IRequestHandler<UpdateProject, Result<Project>>
{
    private readonly ProjectsContext _context;

    public UpdateProjectHandler(ProjectsContext context) =>
        _context = context;

    public async Task<Result<Project>> Handle(UpdateProject request, CancellationToken cancellationToken) =>
        await Result
            .Try(async () => await _context.Projects.FindAsync(request.Id))
            .EnsureEntity(request.Id)
            .Tap(project => request.Adapt(project))
            .Tap(() => _context.SaveChangesAsync(cancellationToken));
}
