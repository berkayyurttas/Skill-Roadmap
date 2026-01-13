using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillRoadmap.Roadmaps;

public class RoadmapStep : AuditedEntity<Guid>
{
    public Guid RoadmapId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }

    // 1. Parametresiz Constructor: Entity Framework ve ABP'nin serileştirme işlemleri için şarttır.
    public RoadmapStep()
    {
    }

    // 2. Parametreli Constructor: Uygulama içinden güvenli nesne oluşturmak için.
    // Bu metodu eklediğinde servis tarafındaki hata (CS1729) düzelecektir.
    public RoadmapStep(Guid id, Guid roadmapId, string title, string description, int order)
        : base(id)
    {
        RoadmapId = roadmapId;
        Title = title;
        Description = description;
        Order = order;
    }
}