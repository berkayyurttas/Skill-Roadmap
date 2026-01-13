using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SkillRoadmap.Data;
using Volo.Abp.DependencyInjection;

namespace SkillRoadmap.EntityFrameworkCore;

public class EntityFrameworkCoreSkillRoadmapDbSchemaMigrator
    : ISkillRoadmapDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSkillRoadmapDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the SkillRoadmapDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SkillRoadmapDbContext>()
            .Database
            .MigrateAsync();
    }
}
