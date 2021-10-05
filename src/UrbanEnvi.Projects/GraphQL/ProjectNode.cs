using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using UrbanEnvi.DataLoaders;
using UrbanEnvi.Features.ProjectCategories;
using UrbanEnvi.Features.Projects;

namespace UrbanEnvi.GraphQL;

[Node]
[ExtendObjectType(typeof(Project))]
public class ProjectNode
{
    [BindMember(nameof(Project.ProjectCategory), Replace = true)]
    public async Task<ProjectCategory?> GetPrimaryContactAsync(
        [Parent] Project project,
        ProjectCategoryLoader loader,
        CancellationToken cancellationToken) =>
        await loader.LoadByProjectId(project.Id, cancellationToken);

    [NodeResolver]
    public static async Task<Project> GetProjectByIdAsync(
        ulong id,
        ProjectLoader loader,
        CancellationToken cancellationToken) =>
        await loader.LoadAsync(id, cancellationToken);
}
