using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SkillRoadmap.Roadmaps; // Namespace'in doğruluğundan emin ol

public interface IRoadmapAppService : 
    ICrudAppService<
        RoadmapDto, 
        Guid, 
        PagedAndSortedResultRequestDto, 
        CreateUpdateRoadmapDto>
{
}