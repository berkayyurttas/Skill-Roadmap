using Volo.Abp.Modularity;

namespace SkillRoadmap;

public abstract class SkillRoadmapApplicationTestBase<TStartupModule> : SkillRoadmapTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
