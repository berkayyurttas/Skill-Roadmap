using System.Threading.Tasks;

namespace SkillRoadmap.Data;

public interface ISkillRoadmapDbSchemaMigrator
{
    Task MigrateAsync();
}
