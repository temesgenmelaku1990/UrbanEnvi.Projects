using HotChocolate.Types;
using UrbanEnvi.Features.ProjectCategories;

namespace UrbanEnvi.GraphQL;

public class UpdateProjectCategoryInputType : InputObjectType<UpdateProjectCategory>
{
    protected override void Configure(IInputObjectTypeDescriptor<UpdateProjectCategory> descriptor)
    {
        base.Configure(descriptor);

        _ = descriptor
            .Field(x => x.Id)
            .ID(nameof(ProjectCategory));
    }
}
