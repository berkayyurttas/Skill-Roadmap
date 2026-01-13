using SkillRoadmap.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace SkillRoadmap.Permissions;

public class SkillRoadmapPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SkillRoadmapPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(SkillRoadmapPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SkillRoadmapResource>(name);
    }
}
