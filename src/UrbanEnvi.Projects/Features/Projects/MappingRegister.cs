namespace UrbanEnvi.Features.Projects;

public class MappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        _ = config.NewConfig<CreateProject, Project>()
            .GenerateMapper(MapType.Map | MapType.MapToTarget);

        _ = config.NewConfig<UpdateProject, Project>()
            .GenerateMapper(MapType.Map | MapType.MapToTarget);

        _ = config.NewConfig<ChangeProjectOrganization, Project>()
            .GenerateMapper(MapType.Map | MapType.MapToTarget);
    }
}
