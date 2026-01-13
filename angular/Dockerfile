# 1. Build Aşaması
FROM node:20 AS build
WORKDIR /app

# Önbellek için bağımlılıkları kopyala
COPY package*.json ./
RUN npm install --legacy-peer-deps

# Kodları kopyala ve build al
COPY . .
RUN npm run build --configuration=production

# 2. Yayınlama Aşaması (Nginx)
FROM nginx:alpine

# angular.json'daki outputPath ayarına göre doğru yol budur:
# SkillRoadmap projesinin browser çıktılarını kopyalıyoruz.
COPY --from=build /app/dist/SkillRoadmap/browser /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]