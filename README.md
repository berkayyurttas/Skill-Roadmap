

# 🚀 Skill-Roadmap: Öğrenci Gelişim ve Mentorluk Takip Portalı

Bu proje, öğrencilerin gelişim süreçlerini takip etmek ve mentorluk faaliyetlerini yönetmek amacıyla geliştirilen, modern yazılım mimarilerini barındıran kapsamlı bir web uygulamasıdır.

## 🛠️ Kullanılan Teknolojiler
* **Backend:** .NET 10 (ABP Framework tabanlı)
* **Frontend:** Angular (Production Mode)
* **Database:** PostgreSQL 16 (Dockerize)
* **Cache:** Redis
* **Containerization:** Docker & Docker Compose
* **API Documentation:** Swagger UI

---

## 🏗️ Adım Adım Neler Yaptık? (Geliştirme Günlüğü)

Bu projenin Docker ortamında kusursuz çalışması için aşağıdaki kritik süreçler yönetilmiştir:

### 1. Ortamın Hazırlanması (Dockerize)
* Uygulama; Backend, Frontend, PostgreSQL ve Redis servisleri olarak parçalara bölündü.
* Tüm servislerin birbiriyle izole ve güvenli şekilde konuşabilmesi için bir `docker-compose.yml` ağı kuruldu.

### 2. Veritabanı Migration ve Seed Data
* `DbMigrator` servisi kullanılarak PostgreSQL veritabanı şeması oluşturuldu ve başlangıç (admin) verileri yüklendi.

### 3. SSL ve Kimlik Doğrulama (Auth) Çözümü
* Docker konteynerleri arasında SSL sertifikası karmaşasını önlemek için `http` protokolü üzerinden güvenli bir iletişim köprüsü kuruldu.
* Veritabanındaki `OpenIddictApplications` tabloları SQL ile güncellenerek (Redirect URIs), Angular ve Swagger girişlerindeki "400 Bad Request" hataları giderildi.

### 4. Swagger ve API Entegrasyonu
* Swagger JSON tanımları doğrulanarak backend servisinin API dökümantasyonu erişilebilir hale getirildi.
* OAuth2 akışı (authorization code flow) yapılandırılarak Swagger üzerinden doğrudan API testi yapma imkanı sağlandı.

---

## 🚀 Kurulum ve Çalıştırma

Projeyi yerelinizde çalıştırmak için aşağıdaki adımları izleyin:

1.  **Repoyu Klonlayın:**
    ```bash
    git clone [https://github.com/berkayyurttas/Skill-Roadmap.git](https://github.com/berkayyurttas/Skill-Roadmap.git)
    ```

2.  **Docker Konteynerlerini Kaldırın:**
    ```bash
    docker-compose up -d
    ```

3.  **Uygulamaya Erişin:**
    * **Frontend:** `http://localhost:4200`
    * **Backend / Swagger:** `http://localhost:44334/swagger`

### 🔑 Giriş Bilgileri
* **Kullanıcı Adı:** `admin`
* **Şifre:** `1q2w3E*`

---

## 📈 Gelecek Planları (CI/CD)
* [ ] GitHub Actions ile otomatik derleme (Build) ve test süreçleri.
* [ ] Docker Image'larının otomatik olarak Docker Hub'a pushlanması.
* [ ] Azure/AWS gibi bulut platformlarına otomatik dağıtım (Deployment).
