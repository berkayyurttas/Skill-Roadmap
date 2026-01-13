import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'http://localhost:44334/', // HTTPS -> HTTP yapıldı
  redirectUri: baseUrl,
  clientId: 'SkillRoadmap_App',
  responseType: 'code',
  scope: 'offline_access SkillRoadmap',
  requireHttps: false, // TRUE -> FALSE yapıldı (Kritik!)
};

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'SkillRoadmap',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'http://localhost:44334', // HTTPS -> HTTP yapıldı
      rootNamespace: 'SkillRoadmap',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
  remoteEnv: {
    url: '/getEnvConfig',
    mergeStrategy: 'deepmerge'
  }
} as Environment;