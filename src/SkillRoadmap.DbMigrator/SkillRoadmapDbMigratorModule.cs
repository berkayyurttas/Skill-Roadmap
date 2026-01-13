using SkillRoadmap.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SkillRoadmap.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SkillRoadmapEntityFrameworkCoreModule),
    typeof(SkillRoadmapApplicationContractsModule)
)]
public class SkillRoadmapDbMigratorModule : AbpModule
{
}
