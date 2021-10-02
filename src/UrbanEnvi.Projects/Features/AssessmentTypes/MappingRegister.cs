namespace UrbanEnvi.Features.AssessmentTypes;

public class MappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        _ = config.NewConfig<CreateAssessmentType, AssessmentType>()
            .GenerateMapper(MapType.Map | MapType.MapToTarget);

        _ = config.NewConfig<UpdateAssessmentType, AssessmentType>()
            .GenerateMapper(MapType.Map | MapType.MapToTarget);
    }
}
