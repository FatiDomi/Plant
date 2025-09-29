# Gestor de Plantas 🌱

Aplicación web desarrollada con **ASP.NET MVC (C#)** que permite:
- Registrar nuevas plantas con sus características.
- Editar y eliminar registros existentes.
- Consultar la información desde una base de datos SQL Server.

## 🛠️ Tecnologías
- C# .NET (ASP.NET MVC)
- Entity Framework
- SQL Server
- HTML, CSS, Bootstrap

## 🚀 Requisitos
- [.NET 8 o superior](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads)
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms) o [Azure Data Studio](https://learn.microsoft.com/azure-data-studio/download-azure-data-studio)

## 🎥 Demo

Video explicativo sobre el funcionamiento de la página web (1-2 min):https://www.loom.com/share/165ffee75ffe4a289fc5c9889784f857?sid=909952fd-3f8c-4eda-b090-83a0d13a5520


## 📂 Estructura del proyecto
/Controllers → Controladores MVC

/Models → Modelos de datos

/Views → Vistas (UI)

/Repository → Repositorios de acceso a datos

/wwwroot → Archivos estáticos (CSS, JS, imágenes)

/Database → Scripts SQL para crear e inicializar la BD

/Properties → Configuración del proyecto



## 🛠️ Configuración de la base de datos
Los scripts para crear la base de datos se encuentran en la carpeta [`/Plant.WebApp/Database`](./Plant.WebApp/Database)

1. Ejecuta [`/Plant.WebApp/Database/database/01_create_schema.sql`](./Plant.WebApp/Database/database/01_create_schema.sql) para crear las tablas.
2. Ejecuta [`/Plant.WebApp/Database/database/02_seed_data.sql`](./Plant.WebApp/Database/database/02_seed_data.sql) para insertar datos de ejemplo.

👉 Más detalles en [`/Plant.WebApp/Database/database/README.md`](./Plant.WebApp/Database/database/README.md).

## ⚙️ Configuración del proyecto
1. Abre el archivo `appsettings.json`.
2. Configura la cadena de conexión (`ConnectionStrings:DefaultConnection`) para que apunte a tu servidor de SQL Server, por ejemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=PlantasDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
