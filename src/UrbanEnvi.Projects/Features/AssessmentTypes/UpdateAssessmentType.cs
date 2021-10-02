using UrbanEnvi;
using UrbanEnvi.Persistence;

namespace UrbanEnvi.Features.AssessmentTypes;

public record UpdateAssessmentType(
    Guid Id,
    string Name
) : IRequest<Result<AssessmentType>>;

public class UpdateAssessmentTypeHandler : IRequestHandler<UpdateAssessmentType, Result<AssessmentType>>
{
    private readonly ProjectsContext _context;

    public UpdateAssessmentTypeHandler(ProjectsContext context) =>
        _context = context;

    public async Task<Result<AssessmentType>> Handle(UpdateAssessmentType request, CancellationToken cancellationToken) =>
        await Result
            .Try(async () => await _context.AssessmentTypes.FindAsync(request.Id))
            .EnsureEntity(request.Id)
            .Tap(project => request.Adapt(project))
            .Tap(() => _context.SaveChangesAsync(cancellationToken));
}
