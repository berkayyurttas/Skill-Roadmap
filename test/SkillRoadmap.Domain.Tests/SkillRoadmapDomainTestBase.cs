using Volo.Abp.Modularity;

namespace SkillRoadmap;

/* Inherit from this class for your domain layer tests. */
public abstract class SkillRoadmapDomainTestBase<TStartupModule> : SkillRoadmapTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
