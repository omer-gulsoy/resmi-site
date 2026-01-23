# 🏢 TRtek Software Official Website & Admin Panel

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![MS SQL](https://img.shields.io/badge/MS%20SQL-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black)

**TRtek Software Official Website** is a comprehensive web solution designed for a software company. Unlike standard static websites, this project includes a robust **Admin Panel (CMS)** that allows authorized personnel to manage the site content dynamically.

It features a secure authentication system, role-based management, and a professional frontend interface, showcasing a complete **Full-Stack** development approach using **ASP.NET Core MVC**.

## 🇬🇧 English

### 🚀 Key Features

* **Advanced Admin Panel:** A dedicated dashboard to manage services, projects, team members, and blog posts without touching the code.
* **Secure Authentication:** Implements secure login/logout mechanisms and session management for administrators.
* **Dynamic Content:** All content on the public-facing site is fetched dynamically from the MS SQL database.
* **Responsive Frontend:** Professional and corporate design using Bootstrap and custom JavaScript animations.
* **Data Management:** CRUD (Create, Read, Update, Delete) operations for all major entities.

### 🛠️ Tech Stack & Architecture

* **Framework:** ASP.NET Core MVC (Full-Stack)
* **Language:** C#
* **Database:** Microsoft SQL Server
* **ORM:** Entity Framework Core (Code-First / DB-First)
* **Authentication:** ASP.NET Core Identity / Cookie Authentication
* **Frontend:** HTML5, CSS3, JavaScript, jQuery, Bootstrap

### ⚙️ Installation

1.  **Clone the repository**
    ```bash
    git clone [https://github.com/omer-gulsoy/web-officialWebsite.git](https://github.com/omer-gulsoy/web-officialWebsite.git)
    ```
2.  **Database Configuration**
    Update the `appsettings.json` file with your local SQL Server connection string.
3.  **Run Migrations**
    Open Package Manager Console and run:
    ```bash
    Update-Database
    ```
4.  **Run the Application**
    ```bash
    dotnet run
    ```

---

## 🇹🇷 Türkçe

### 🎯 Proje Hakkında

**TRtek Yazılım Resmi Web Sitesi**, bir yazılım firmasının ihtiyaç duyacağı tüm dijital altyapıyı sunan kapsamlı bir projedir. Sadece ziyaretçilerin gördüğü ön yüzden ibaret değildir; arka planda tüm içeriğin yönetilebildiği gelişmiş bir **Yönetici Paneli (Admin Dashboard)** barındırır.

Kullanıcı doğrulama (Authentication), güvenli giriş sistemleri ve dinamik veri yönetimi gibi backend yetkinliklerini **ASP.NET Core MVC** mimarisiyle birleştirir.

### 🚀 Öne Çıkan Özellikler

* **Yönetici Paneli (CMS):** Kod bilgisine ihtiyaç duymadan; projeler, hizmetler, blog yazıları ve referanslar panel üzerinden güncellenebilir, silinebilir veya eklenebilir.
* **Güvenli Giriş Sistemi:** Yöneticiler için şifreli ve güvenli oturum açma (Login) mekanizması.
* **Dinamik Yapı:** Sitedeki görseller ve metinler veritabanından anlık olarak çekilir.
* **Full-Stack Mimarisi:** Frontend (JS/CSS) ve Backend (C#/SQL) katmanlarının entegre çalıştığı bütünleşik yapı.
* **CRUD İşlemleri:** Veri ekleme, okuma, güncelleme ve silme işlemlerinin tamamı panel üzerinden yapılabilir.

### 🛠️ Kullanılan Teknolojiler

* **Çatı (Framework):** ASP.NET Core MVC
* **Yazılım Dili:** C#
* **Veritabanı:** MS SQL Server
* **Veri Erişimi:** Entity Framework Core
* **Güvenlik:** Authentication & Authorization
* **Ön Yüz:** JavaScript, Bootstrap, HTML5

### ⚙️ Kurulum

1.  Projeyi bilgisayarınıza indirin (Clone).
2.  `appsettings.json` dosyasındaki Connection String ayarını kendi yerel sunucunuza göre düzenleyin.
3.  Veritabanını oluşturmak için `Update-Database` komutunu çalıştırın.
4.  Projeyi derleyip ayağa kaldırın.

## 🤝 Contributing

Contributions are welcome! Please submit a pull request or open an issue for bugs and feature requests.

## 📝 License

This project is licensed under the MIT License.
