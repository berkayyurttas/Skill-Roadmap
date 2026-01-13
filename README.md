

# 🚀 Skill-Roadmap: Öğrenci Gelişim ve Mentorluk Takip Portalı

Bu proje, öğrencilerin akademik ve kişisel gelişim süreçlerini modernize etmek, mentorluk faaliyetlerini sistemli bir yapıda takip etmek amacıyla geliştirilmiştir. **ABP Framework** üzerine inşa edilen uygulama, mikroservis odaklı bir yaklaşımla tamamen konteynerize (dockerize) edilmiştir.

## 🏗️ Mimari ve Teknik Stack

* **Backend:** .NET 10 (C#) - ABP Framework tabanlı modüler monolit mimari.
* **Frontend:** Angular 18+ (Production Mode).
* **Veritabanı ve ORM:** * **Entity Framework Core (EF Core):** Code-First yaklaşımı ile tüm veritabanı şeması yönetildi.
    * **PostgreSQL 16:** Ana veri depolama katmanı.
* **Cache:** Redis (Dağıtık önbellekleme).
* **Containerization:** Docker & Docker Compose (Çoklu servis orkestrasyonu).
* **Identity & Auth:** OpenIddict (OAuth2 & OpenID Connect).
* **API Documentation:** Swagger UI.

---

## 🛠️ Uygulanan Kritik Geliştirme Süreçleri

### 1. Veritabanı Yönetimi & EF Core Migration
Projede veritabanı bağımsızlığı ve versiyon kontrolü için EF Core Code-First yaklaşımı kullanılmıştır:
* **Auto-Migration:** `SkillRoadmap.DbMigrator` servisi ile uygulama ayağa kalkmadan önce veritabanı şeması otomatik olarak valide edilir.
* **Data Seeding:** Başlangıç verileri (Initial Seed Data), admin yetkileri ve sistem ayarları migration sürecinde otomatik olarak PostgreSQL'e işlenmiştir.

### 2. Profesyonel Dockerization (Konteynerleştirme)
Tüm ekosistem Docker üzerinde izole bir ağda çalışacak şekilde yapılandırıldı:
* **Multi-Stage Builds:** Backend ve Frontend için optimize edilmiş Dockerfile'lar hazırlandı.
* **Orkestrasyon:** `docker-compose.yml` ile Backend, Frontend, DB ve Redis servisleri arasındaki bağımlılıklar (Depends_on) ve network köprüleri kuruldu.
* **Volume Mapping:** Veritabanı verilerinin konteyner silindiğinde kaybolmaması için Docker Volume yapılandırması yapıldı.

### 3. Kimlik Doğrulama ve Yönlendirme Çözümleri
Docker ortamında en sık karşılaşılan Auth (Yetkilendirme) sorunları kökten çözüldü:
* **Protocol Transition:** Docker içi SSL karmaşasını aşmak için iletişim `http` protokolüne normalize edildi.
* **SQL Patching:** Veritabanındaki `OpenIddictApplications` tablolarındaki Redirect URI'lar terminal üzerinden SQL komutlarıyla (REPLACE) güncellenerek Angular ve Swagger giriş süreçleri stabilize edildi.

---

## 🚀 Kurulum ve Yerel Çalıştırma

Projeyi yerel makinenizde tüm servisleriyle çalıştırmak için:

1.  **Repoyu Klonlayın:**
    ```bash
    git clone [https://github.com/berkayyurttas/Skill-Roadmap.git](https://github.com/berkayyurttas/Skill-Roadmap.git)
    cd Skill-Roadmap
    ```

2.  **Docker ile Yayına Alın:**
    ```bash
    docker-compose up -d
    ```
    *(Bu komut PostgreSQL, Redis, Backend ve Frontend servislerini otomatik olarak indirir, derler ve çalıştırır.)*

3.  **Uygulama Portları:**
    * **Angular UI:** `http://localhost:4200`
    * **Swagger API:** `http://localhost:44334/swagger`
    * **Database:** `localhost:5435` (PostgreSQL)

### 🔑 Test Kullanıcı Bilgileri
* **Username:** `admin`
* **Password:** `1q2w3E*`

---

## 📈 Yol Haritası (CI/CD)
- [ ] **GitHub Actions CI:** Her Push sonrası otomatik Build ve EF Core Migration testleri.
- [ ] **Docker Hub CD:** Başarılı build sonrası Image'ların otomatik olarak Docker Hub'a gönderilmesi.
- [ ] **Cloud Deployment:** Azure/AWS üzerinde canlıya alım süreci.
