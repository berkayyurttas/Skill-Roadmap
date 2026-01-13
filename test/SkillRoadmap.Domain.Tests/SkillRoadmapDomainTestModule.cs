using Volo.Abp.Modularity;

namespace SkillRoadmap;

[DependsOn(
    typeof(SkillRoadmapDomainModule),
    typeof(SkillRoadmapTestBaseModule)
)]
public class SkillRoadmapDomainTestModule : AbpModule
{

}
