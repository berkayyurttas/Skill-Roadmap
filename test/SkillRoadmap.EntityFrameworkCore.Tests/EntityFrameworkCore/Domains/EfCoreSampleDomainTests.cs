using SkillRoadmap.Samples;
using Xunit;

namespace SkillRoadmap.EntityFrameworkCore.Domains;

[Collection(SkillRoadmapTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<SkillRoadmapEntityFrameworkCoreTestModule>
{

}
