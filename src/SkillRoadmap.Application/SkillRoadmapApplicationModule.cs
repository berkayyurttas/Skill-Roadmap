using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.AutoMapper; // 1. BU SATIRI EKLE
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.TenantManagement;

namespace SkillRoadmap;

[DependsOn(
    typeof(SkillRoadmapDomainModule),
    typeof(SkillRoadmapApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpAutoMapperModule) // 2. BU SATIRI EKLE
    )]
public class SkillRoadmapApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // 3. MAPPER'I SİSTEME TANITAN BLOĞU EKLE
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<SkillRoadmapApplicationModule>();
        });
    }
}