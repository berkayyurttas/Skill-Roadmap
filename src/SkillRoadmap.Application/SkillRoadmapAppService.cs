using SkillRoadmap.Localization;
using Volo.Abp.Application.Services;

namespace SkillRoadmap;

/* Inherit your application services from this class.
 */
public abstract class SkillRoadmapAppService : ApplicationService
{
    protected SkillRoadmapAppService()
    {
        LocalizationResource = typeof(SkillRoadmapResource);
    }
}
