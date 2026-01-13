using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillRoadmap.Roadmaps;

public class Roadmap : FullAuditedAggregateRoot<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    
    // Virtual eklemek, Entity Framework'ün bu listeyi daha rahat yönetmesini sağlar
    public virtual ICollection<RoadmapStep> Steps { get; set; } 
}