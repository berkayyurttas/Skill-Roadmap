using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillRoadmap.Roadmaps;

/* Bu sınıf öğrencilerin hangi adımı tamamladığını 
    ve senin (mentorun) bıraktığın notları tutacak.
*/
public class UserProgress : AuditedEntity<Guid>
{
    public Guid UserId { get; set; }           // Öğrencinin ID'si
    public Guid RoadmapStepId { get; set; }    // Tamamlanan adımın (görevin) ID'si
    public bool IsCompleted { get; set; }      // Bitti mi? (True/False)
    public string MentorNote { get; set; }     // Senin yazacağın: "Aferin Berkay, LINQ konusunu çok iyi kavramışsın!"
    public DateTime? CompletionDate { get; set; } // Tamamlanma tarihi
}