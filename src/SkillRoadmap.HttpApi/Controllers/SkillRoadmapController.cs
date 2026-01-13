using SkillRoadmap.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SkillRoadmap.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SkillRoadmapController : AbpControllerBase
{
    protected SkillRoadmapController()
    {
        LocalizationResource = typeof(SkillRoadmapResource);
    }
}
