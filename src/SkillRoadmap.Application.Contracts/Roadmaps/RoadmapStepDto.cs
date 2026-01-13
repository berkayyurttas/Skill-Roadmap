using System;
using Volo.Abp.Application.Dtos;

namespace SkillRoadmap.Roadmaps;

public class RoadmapStepDto : AuditedEntityDto<Guid>
{
    public Guid RoadmapId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}

public class CreateUpdateRoadmapStepDto
{
    public Guid RoadmapId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
}