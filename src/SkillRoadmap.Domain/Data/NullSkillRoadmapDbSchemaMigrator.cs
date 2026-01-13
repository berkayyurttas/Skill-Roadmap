using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SkillRoadmap.Data;

/* This is used if database provider does't define
 * ISkillRoadmapDbSchemaMigrator implementation.
 */
public class NullSkillRoadmapDbSchemaMigrator : ISkillRoadmapDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
