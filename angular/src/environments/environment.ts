import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'http://localhost:44334/', // HTTPS yerine HTTP yapıldı
  redirectUri: baseUrl,
  clientId: 'SkillRoadmap_App',
  responseType: 'code',
  scope: 'offline_access SkillRoadmap',
  requireHttps: false, // TRUE yerine FALSE yapıldı (Kritik!)
};

export const environment = {
  production: true, // Docker'da production modunda build ediyoruz
  application: {
    baseUrl,
    name: 'SkillRoadmap',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'http://localhost:44334', // HTTPS yerine HTTP yapıldı
      rootNamespace: 'SkillRoadmap',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;