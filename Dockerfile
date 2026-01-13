# 1. Build Aşaması
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Tüm projeyi kopyalıyoruz
COPY . .

RUN dotnet restore

# Projeyi yayınla
RUN dotnet publish "src/SkillRoadmap.HttpApi.Host/SkillRoadmap.HttpApi.Host.csproj" -c Release -o /publish

# 2. Çalıştırma Aşaması
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

# Derlenen dosyaları kopyala
COPY --from=build /publish .

# Sertifikayı çalışma dizinine kopyala
COPY src/SkillRoadmap.HttpApi.Host/openiddict.pfx .

EXPOSE 80
ENTRYPOINT ["dotnet", "SkillRoadmap.HttpApi.Host.dll"]