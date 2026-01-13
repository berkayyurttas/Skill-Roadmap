using AutoMapper;
using SkillRoadmap.Roadmaps;

namespace SkillRoadmap;

public class SkillRoadmapApplicationMappers : Profile
{
    public SkillRoadmapApplicationMappers()
    {
        // 1. Ana Yol Haritası Eşlemeleri
        CreateMap<Roadmap, RoadmapDto>();
        CreateMap<CreateUpdateRoadmapDto, Roadmap>();
        
        // 2. Yol Haritası Adımları (Görevler) Eşlemeleri
        CreateMap<RoadmapStep, RoadmapStepDto>();
        CreateMap<CreateUpdateRoadmapStepDto, RoadmapStep>();

        // 3. Öğrenci İlerleme ve Mentor Notu Eşlemeleri
        // İleride UserProgressDto oluşturduğunda burası hayat kurtaracak
        // CreateMap<UserProgress, UserProgressDto>(); 
    }
}