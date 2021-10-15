using HotChocolate;
using HotChocolate.Types;
using UrbanEnvi.DataLoaders;

namespace UrbanEnvi.GraphQL;

public static class Config
{
    public static IServiceCollection AddGraphQL(this IServiceCollection services)
    {
        _ = services.AddGraphQLServer()
            .BindRuntimeType<ulong, UnsignedLongType>()
            .AddQueryType()
            .AddMutationType()
            .AddFiltering()
            .AddSorting()
            .AddProjections()
            .AddDefaultSpatialTypes()
            .AddSpatialProjections()
            .AddSpatialFiltering()
            .AddNodaTime()
            .AddNodaTimeFiltering()
            .AddGlobalObjectIdentification()
            .AddCoreTypes()
            .AddDataLoader<AssessmentTypeLoader>()
            .AddDataLoader<ProjectCategoryLoader>()
            .AddDataLoader<ProjectLoader>()
            .AddType<ChangeProjectOrganizationInputType>()
            .AddType<CreateProjectInputType>()
            .AddType<UpdateAssessmentTypeInputType>()
            .AddType<UpdateProjectCategoryInputType>()
            .AddType<UpdateProjectInputType>()
            .AddTypeExtension<Queries>()
            .AddTypeExtension<Mutations>()
            .AddTypeExtension<AssessmentTypeNode>()
            .AddTypeExtension<ProjectCategoryNode>()
            .AddTypeExtension<ProjectNode>()
            .InitializeOnStartup()
            .PublishSchemaDefinition(c => c
                .SetName(WellKnownService.Projects.CamelizedName)
            // .AddTypeExtensionsFromFile("./Stitching.graphql")
            // .PublishToRedis(Constants.GraphQLSchema, sp => sp.GetRequiredService<ConnectionMultiplexer>())
            );

        return services;
    }
}