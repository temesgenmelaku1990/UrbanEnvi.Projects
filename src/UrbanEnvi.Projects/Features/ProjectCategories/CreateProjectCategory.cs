using UrbanEnvi.Persistence;

namespace UrbanEnvi.Features.ProjectCategories;

public record CreateProjectCategory(string Name) : IRequest<Result<ProjectCategory>>;

public class CreateProjectCategoryHandler : IRequestHandler<CreateProjectCategory, Result<ProjectCategory>>
{
    private readonly ProjectsContext _context;

    public CreateProjectCategoryHandler(ProjectsContext context) =>
        _context = context;

    public async Task<Result<ProjectCategory>> Handle(CreateProjectCategory request, CancellationToken cancellationToken) =>
        await Result
            .Try(() => request.Adapt<ProjectCategory>())
            .Tap(async category => await _context.ProjectCategories.AddAsync(category, cancellationToken))
            .Tap(() => _context.SaveChangesAsync(cancellationToken));
}
