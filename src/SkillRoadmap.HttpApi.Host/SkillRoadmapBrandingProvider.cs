using Microsoft.Extensions.Localization;
using SkillRoadmap.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SkillRoadmap;

[Dependency(ReplaceServices = true)]
public class SkillRoadmapBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<SkillRoadmapResource> _localizer;

    public SkillRoadmapBrandingProvider(IStringLocalizer<SkillRoadmapResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
