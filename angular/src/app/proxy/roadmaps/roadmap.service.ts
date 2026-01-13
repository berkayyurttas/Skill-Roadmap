import { RestService, Rest } from '@abp/ng.core';
import { Injectable, inject } from '@angular/core';
import type { CreateUpdateRoadmapDto, RoadmapDto } from './models';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class RoadmapService {
  private restService = inject(RestService);
  apiName = 'Default';

  // --- Ana Yol Haritası (Roadmap) Metotları ---

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, RoadmapDto>({
      method: 'GET',
      url: `/api/app/roadmap/${id}`,
    }, { apiName: this.apiName, ...config });

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<RoadmapDto>>({
      method: 'GET',
      url: '/api/app/roadmap',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    }, { apiName: this.apiName, ...config });

  create = (input: CreateUpdateRoadmapDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, RoadmapDto>({
      method: 'POST',
      url: '/api/app/roadmap',
      body: input,
    }, { apiName: this.apiName, ...config });

  update = (id: string, input: CreateUpdateRoadmapDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, RoadmapDto>({
      method: 'PUT',
      url: `/api/app/roadmap/${id}`,
      body: input,
    }, { apiName: this.apiName, ...config });

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/roadmap/${id}`,
    }, { apiName: this.apiName, ...config });

  // --- Yol Haritası Adımları (Step) Metotları ---

  createStep = (input: any, config?: Partial<Rest.Config>) =>
    this.restService.request<any, any>({
      method: 'POST',
      url: '/api/app/roadmap/step',
      body: input,
    }, { apiName: this.apiName, ...config });

  getStepsByRoadmapId = (roadmapId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, any[]>({
      method: 'GET',
      url: `/api/app/roadmap/steps-by-roadmap-id/${roadmapId}`, // Backend: GetStepsByRoadmapIdAsync
    }, { apiName: this.apiName, ...config });

  /**
   * 405 HATASINI ÇÖZEN DÜZENLEME:
   * Backend'deki 'DeleteStepAsync' metodu için ABP'nin ürettiği en muhtemel rota
   */
 // roadmap.service.ts dosyasında sadece bu kısmı güncelle:

// roadmap.service.ts içindeki deleteStep fonksiyonu:

// src/app/proxy/roadmaps/roadmap.service.ts

deleteStep = (id: string, config?: Partial<Rest.Config>) =>
  this.restService.request<any, void>({
    method: 'DELETE',
    // Swagger'daki listeye göre doğru rota budur:
    url: `/api/app/roadmap/${id}/step`, 
  }, { apiName: this.apiName, ...config });
}