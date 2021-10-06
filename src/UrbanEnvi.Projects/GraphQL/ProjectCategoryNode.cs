using HotChocolate.Types;
using HotChocolate.Types.Relay;
using UrbanEnvi.DataLoaders;
using UrbanEnvi.Features.ProjectCategories;

namespace UrbanEnvi.GraphQL;

[Node]
[ExtendObjectType(typeof(ProjectCategory))]
public class ProjectCategoryNode
{
    [NodeResolver]
    public static async Task<ProjectCategory> GetProjectCategoryByIdAsync(
        Guid id,
        ProjectCategoryLoader loader,
        CancellationToken cancellationToken) =>
        await loader.LoadAsync(id, cancellationToken);
}
