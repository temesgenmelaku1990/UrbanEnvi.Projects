using UrbanEnvi;
using UrbanEnvi.Persistence;

namespace UrbanEnvi.Features.ProjectCategories;

public record UpdateProjectCategory(
    Guid Id,
    string Name
) : IRequest<Result<ProjectCategory>>;

public class UpdateProjectCategoryHandler : IRequestHandler<UpdateProjectCategory, Result<ProjectCategory>>
{
    private readonly ProjectsContext _context;

    public UpdateProjectCategoryHandler(ProjectsContext context) =>
        _context = context;

    public async Task<Result<ProjectCategory>> Handle(UpdateProjectCategory request, CancellationToken cancellationToken) =>
        await Result
            .Try(async () => await _context.ProjectCategories.FindAsync(request.Id))
            .EnsureEntity(request.Id)
            .Tap(category => request.Adapt(category))
            .Tap(() => _context.SaveChangesAsync(cancellationToken));
}
