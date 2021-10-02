namespace UrbanEnvi.Features.ProjectCategories;

public class MappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        _ = config.NewConfig<CreateProjectCategory, ProjectCategory>()
            .GenerateMapper(MapType.Map | MapType.MapToTarget);

        _ = config.NewConfig<UpdateProjectCategory, ProjectCategory>()
            .GenerateMapper(MapType.Map | MapType.MapToTarget);
    }
}
