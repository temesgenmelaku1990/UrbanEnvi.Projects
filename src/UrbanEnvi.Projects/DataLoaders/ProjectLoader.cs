using GreenDonut;
using Microsoft.EntityFrameworkCore;
using UrbanEnvi.Features.Projects;
using UrbanEnvi.Persistence;

namespace UrbanEnvi.DataLoaders;

public class ProjectLoader : EntityBatchDataLoader<ulong, Project, ProjectsContext>
{
    public ProjectLoader(IDbContextFactory<ProjectsContext> factory, IBatchScheduler batchScheduler, DataLoaderOptions options)
        : base(factory, batchScheduler, options)
    {
    }
}
