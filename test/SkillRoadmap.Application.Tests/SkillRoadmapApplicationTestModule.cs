using Volo.Abp.Modularity;

namespace SkillRoadmap;

[DependsOn(
    typeof(SkillRoadmapApplicationModule),
    typeof(SkillRoadmapDomainTestModule)
)]
public class SkillRoadmapApplicationTestModule : AbpModule
{

}
