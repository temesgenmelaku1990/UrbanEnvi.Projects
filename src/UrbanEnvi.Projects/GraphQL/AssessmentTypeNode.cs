using HotChocolate.Types;
using HotChocolate.Types.Relay;
using UrbanEnvi.DataLoaders;
using UrbanEnvi.Features.AssessmentTypes;

namespace UrbanEnvi.GraphQL;

[Node]
[ExtendObjectType(typeof(AssessmentType))]
public class AssessmentTypeNode
{
    [NodeResolver]
    public static async Task<AssessmentType> GetAssessmentTypeByIdAsync(
        Guid id,
        AssessmentTypeLoader loader,
        CancellationToken cancellationToken) =>
        await loader.LoadAsync(id, cancellationToken);
}
