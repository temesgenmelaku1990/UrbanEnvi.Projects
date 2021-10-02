using UrbanEnvi;
using UrbanEnvi.Persistence;

namespace UrbanEnvi.Features.Projects;

public record ChangeProjectOrganization(
    ulong Id,
    Guid OrganizationId,
    string Reason
) : IRequest<Result<Project>>;

public class ChangeProjectOrganizationHandler : IRequestHandler<ChangeProjectOrganization, Result<Project>>
{
    private readonly ProjectsContext _context;

    public ChangeProjectOrganizationHandler(ProjectsContext context) =>
        _context = context;

    public async Task<Result<Project>> Handle(ChangeProjectOrganization request, CancellationToken cancellationToken) =>
        await Result
            .Try(async () => await _context.Projects.FindAsync(request.Id))
            .EnsureEntity(request.Id)
            .Tap(project => request.Adapt(project))
            .Tap(() => _context.SaveChangesAsync(cancellationToken));
}
