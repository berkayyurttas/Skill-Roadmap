import type { FullAuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateRoadmapDto {
  title?: string;
  description?: string;
}

export interface RoadmapDto extends FullAuditedEntityDto<string> {
  title?: string;
  description?: string;
}
