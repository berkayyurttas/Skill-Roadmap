using System;
using Volo.Abp.Application.Dtos;

namespace SkillRoadmap.Roadmaps;

public class RoadmapDto : FullAuditedEntityDto<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
}

public class CreateUpdateRoadmapDto
{
    public string Title { get; set; }
    public string Description { get; set; }
}