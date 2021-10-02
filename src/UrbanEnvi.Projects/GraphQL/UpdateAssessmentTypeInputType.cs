using HotChocolate.Types;
using UrbanEnvi.Features.AssessmentTypes;

namespace UrbanEnvi.GraphQL;

public class UpdateAssessmentTypeInputType : InputObjectType<UpdateAssessmentType>
{
    protected override void Configure(IInputObjectTypeDescriptor<UpdateAssessmentType> descriptor)
    {
        base.Configure(descriptor);

        _ = descriptor
            .Field(x => x.Id)
            .ID(nameof(AssessmentType));
    }
}
