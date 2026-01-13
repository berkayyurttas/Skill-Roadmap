using Microsoft.EntityFrameworkCore;
using SkillRoadmap.Roadmaps; 
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace SkillRoadmap.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class SkillRoadmapDbContext :
    AbpDbContext<SkillRoadmapDbContext>,
    ITenantManagementDbContext,
    IIdentityDbContext
{
    /* Kendi Entity'lerin */
    public DbSet<Roadmap> Roadmaps { get; set; }
    public DbSet<RoadmapStep> RoadmapSteps { get; set; }
    public DbSet<UserProgress> UserProgresses { get; set; } // YENİ: Öğrenci Takip Tablosu

    #region Entities from the modules
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }
    #endregion

    public SkillRoadmapDbContext(DbContextOptions<SkillRoadmapDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Modül yapılandırmaları */
        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        builder.ConfigureBlobStoring();
        
        /* Kendi tablolarının yapılandırması */
        builder.Entity<Roadmap>(b =>
        {
            b.ToTable("AppRoadmaps");
            b.ConfigureByConvention();
            b.Property(x => x.Title).IsRequired().HasMaxLength(128);
        });

        builder.Entity<RoadmapStep>(b =>
        {
            b.ToTable("AppRoadmapSteps");
            b.ConfigureByConvention();
            b.Property(x => x.Title).IsRequired().HasMaxLength(128);
        });

        // YENİ: UserProgress Tablo Ayarları
        builder.Entity<UserProgress>(b =>
        {
            b.ToTable("AppUserProgresses");
            b.ConfigureByConvention();
            b.Property(x => x.MentorNote).HasMaxLength(500); // Not alanı sınırı
        });
    }
}