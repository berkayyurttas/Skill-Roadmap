using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SkillRoadmap.Roadmaps;

public class RoadmapAppService : 
    CrudAppService<
        Roadmap, 
        RoadmapDto, 
        Guid, 
        PagedAndSortedResultRequestDto, 
        CreateUpdateRoadmapDto>, 
    IRoadmapAppService 
{
    private readonly IRepository<RoadmapStep, Guid> _roadmapStepRepository;

    public RoadmapAppService(
        IRepository<Roadmap, Guid> repository,
        IRepository<RoadmapStep, Guid> roadmapStepRepository) 
        : base(repository)
    {
        _roadmapStepRepository = roadmapStepRepository;
    }

    // --- ADIM EKLEME ---
    public async Task<RoadmapStepDto> CreateStepAsync(CreateUpdateRoadmapStepDto input)
    {
        var step = new RoadmapStep
        {
            RoadmapId = input.RoadmapId,
            Title = input.Title,
            Description = input.Description,
            Order = input.Order
        };

        await _roadmapStepRepository.InsertAsync(step);
        return ObjectMapper.Map<RoadmapStep, RoadmapStepDto>(step);
    }

    // --- ADIMLARI LİSTELEME ---
    public async Task<List<RoadmapStepDto>> GetStepsByRoadmapIdAsync(Guid roadmapId)
    {
        var steps = await _roadmapStepRepository.GetListAsync(x => x.RoadmapId == roadmapId);
        return ObjectMapper.Map<List<RoadmapStep>, List<RoadmapStepDto>>(
            steps.OrderBy(x => x.Order).ToList()
        );
    }

    // --- ADIM SİLME (DÜZELTİLDİ) ---
    // Önemli: Metot ismi 'Delete' + 'Step' olduğu için 
    // ABP bunu otomatik olarak DELETE /api/app/roadmap/step/{id} yapar.
   // RoadmapAppService.cs içinde silme metodunu bu şekilde güncelle:

public async Task DeleteStepAsync(Guid id)
{
    // Önce ismi 'DeleteStepAsync' olan metodun ismini 'DeleteStep' olarak sadeleştirin
    // veya kalsın ama Angular rotasını buna göre ayarlayalım.
    await _roadmapStepRepository.DeleteAsync(id);
}
}