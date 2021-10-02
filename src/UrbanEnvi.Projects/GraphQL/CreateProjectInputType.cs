using HotChocolate.Types;
using UrbanEnvi.Features.ProjectCategories;
using UrbanEnvi.Features.Projects;

namespace UrbanEnvi.GraphQL;

public class CreateProjectInputType : InputObjectType<CreateProject>
{
    protected override void Configure(IInputObjectTypeDescriptor<CreateProject> descriptor)
    {
        base.Configure(descriptor);

        _ = descriptor
            .Field(x => x.OrganizationId)
            .ID("Organization");

        _ = descriptor
            .Field(x => x.ProjectCategoryId)
            .ID(nameof(ProjectCategory));
    }
}
