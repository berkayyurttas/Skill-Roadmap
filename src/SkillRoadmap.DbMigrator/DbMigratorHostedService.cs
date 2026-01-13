using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SkillRoadmap.Data;
using Serilog;
using Volo.Abp;
using Volo.Abp.Data;

namespace SkillRoadmap.DbMigrator;

public class DbMigratorHostedService : IHostedService
{
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly IConfiguration _configuration;

    public DbMigratorHostedService(IHostApplicationLifetime hostApplicationLifetime, IConfiguration configuration)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _configuration = configuration;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
{
    // 1. ADIM: Bağlantı cümlesini koda zorla (Hard-coded) enjekte ediyoruz.
    // Docker'daki PostgreSQL'e (5435 portu) bağlanmasını sağlıyoruz.
    _configuration["ConnectionStrings:Default"] = "Host=localhost;Port=5435;Database=SkillRoadmapDb;Username=admin;Password=password123";

    using (var application = await AbpApplicationFactory.CreateAsync<SkillRoadmapDbMigratorModule>(options =>
    {
       options.Services.ReplaceConfiguration(_configuration);
       options.UseAutofac();
       options.Services.AddLogging(c => c.AddSerilog());
       options.AddDataMigrationEnvironment();
    }))
    {
        await application.InitializeAsync();

        // 2. ADIM: Migration işlemini başlat
        await application
            .ServiceProvider
            .GetRequiredService<SkillRoadmapDbMigrationService>()
            .MigrateAsync();

        await application.ShutdownAsync();

        _hostApplicationLifetime.StopApplication();
    }
}

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
