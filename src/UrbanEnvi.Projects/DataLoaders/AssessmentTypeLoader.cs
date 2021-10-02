using GreenDonut;
using Microsoft.EntityFrameworkCore;
using UrbanEnvi.Features.AssessmentTypes;
using UrbanEnvi.Persistence;

namespace UrbanEnvi.DataLoaders;

public class AssessmentTypeLoader : EntityBatchDataLoader<Guid, AssessmentType, ProjectsContext>
{
    public AssessmentTypeLoader(IDbContextFactory<ProjectsContext> factory, IBatchScheduler batchScheduler, DataLoaderOptions options)
        : base(factory, batchScheduler, options)
    {
    }
}
