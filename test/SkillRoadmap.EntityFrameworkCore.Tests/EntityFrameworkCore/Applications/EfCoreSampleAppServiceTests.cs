using SkillRoadmap.Samples;
using Xunit;

namespace SkillRoadmap.EntityFrameworkCore.Applications;

[Collection(SkillRoadmapTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<SkillRoadmapEntityFrameworkCoreTestModule>
{

}
