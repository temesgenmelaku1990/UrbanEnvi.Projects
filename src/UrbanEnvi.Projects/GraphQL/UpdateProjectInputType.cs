using HotChocolate.Types;
using UrbanEnvi.Features.ProjectCategories;
using UrbanEnvi.Features.Projects;

namespace UrbanEnvi.GraphQL;

public class UpdateProjectInputType : InputObjectType<UpdateProject>
{
    protected override void Configure(IInputObjectTypeDescriptor<UpdateProject> descriptor)
    {
        base.Configure(descriptor);

        _ = descriptor
            .Field(x => x.Id)
            .ID(nameof(Project));

        _ = descriptor
            .Field(x => x.ProjectCategoryId)
            .ID(nameof(ProjectCategory));
    }
}
