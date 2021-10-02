using UrbanEnvi.Persistence;

namespace UrbanEnvi.Features.AssessmentTypes;

public record CreateAssessmentType(
    string Name,
    ISet<CoreAssessmentType> Types
) : IRequest<Result<AssessmentType>>;

public class CreateAssessmentTypeHandler : IRequestHandler<CreateAssessmentType, Result<AssessmentType>>
{
    private readonly ProjectsContext _context;

    public CreateAssessmentTypeHandler(ProjectsContext context) =>
        _context = context;

    public async Task<Result<AssessmentType>> Handle(CreateAssessmentType request, CancellationToken cancellationToken) =>
        await Result
            .Try(() => request.Adapt<AssessmentType>())
            .Tap(async assessmentType => await _context.AssessmentTypes.AddAsync(assessmentType, cancellationToken))
            .Tap(() => _context.SaveChangesAsync(cancellationToken));
}
