using HotChocolate.Types;
using UrbanEnvi.Features.Projects;

namespace UrbanEnvi.GraphQL;

public class ChangeProjectOrganizationInputType : InputObjectType<ChangeProjectOrganization>
{
    protected override void Configure(IInputObjectTypeDescriptor<ChangeProjectOrganization> descriptor)
    {
        base.Configure(descriptor);

        _ = descriptor
            .Field(x => x.Id)
            .ID(nameof(Project));

        _ = descriptor
            .Field(x => x.OrganizationId)
            .ID("Organization");
    }
}
