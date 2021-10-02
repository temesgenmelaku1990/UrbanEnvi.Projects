using GreenDonut;
using Microsoft.EntityFrameworkCore;
using UrbanEnvi.Features.ProjectCategories;
using UrbanEnvi.Features.Projects;
using UrbanEnvi.Persistence;

namespace UrbanEnvi.DataLoaders;

public class ProjectCategoryLoader : EntityBatchDataLoader<Guid, ProjectCategory, ProjectsContext>
{
    public ProjectCategoryLoader(IDbContextFactory<ProjectsContext> factory, IBatchScheduler batchScheduler, DataLoaderOptions options)
        : base(factory, batchScheduler, options)
    {
    }

    public async Task<ProjectCategory> LoadByProjectId(ulong id, CancellationToken cancellationToken = default) =>
        await LoadOneAsync<Project>(
            q => q
                .Include(x => x.ProjectCategory)
                .Where(x => x.Id == id)
                .Select(x => x.ProjectCategory),
            cancellationToken
        );
}
