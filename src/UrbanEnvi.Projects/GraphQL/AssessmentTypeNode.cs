using HotChocolate.Types;
using HotChocolate.Types.Relay;
using UrbanEnvi.DataLoaders;
using UrbanEnvi.Features.AssessmentTypes;

namespace UrbanEnvi.GraphQL;

[Node]
[ExtendObjectType(typeof(AssessmentType), IgnoreProperties = new[] {
    nameof(Entity.Inbox),
    nameof(Entity.Outbox)
})]
public class AssessmentTypeNode
{
    [NodeResolver]
    public static async Task<AssessmentType> GetAssessmentTypeByIdAsync(
        Guid id,
        AssessmentTypeLoader loader,
        CancellationToken cancellationToken) =>
        await loader.LoadAsync(id, cancellationToken);
}
