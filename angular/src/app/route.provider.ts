import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/roadmaps',
        name: 'Yol Haritaları',
        iconClass: 'fas fa-map-signs', // Şık bir yol tabelası ikonu
        order: 2,
        layout: eLayoutType.application,
        // requiredPolicy: 'SkillRoadmap.Roadmaps', // İleride yetkilendirme eklediğinde burayı açabilirsin
      },
    ]);
  };
}