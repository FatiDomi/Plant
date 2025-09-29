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

## 🚀 Ejecución
1. Clonar el repositorio.
2. Restaurar dependencias en Visual Studio.
3. Ejecutar el script `script_bbdd.sql` para crear la base de datos.
4. Configurar la cadena de conexión en `appsettings.json`.
5. Iniciar el proyecto en modo Debug.

## 🛠️ Pasos para preparar la base de datos
1. Abre **SQL Server Management Studio (SSMS)** o **Azure Data Studio**.
2. Conéctate a tu instancia de SQL Server.
3. Ejecuta primero el script [`01_create_schema.sql`](./01_create_schema.sql) para crear la tabla.
4. Después ejecuta el script [`02_seed_data.sql`](./02_seed_data.sql) para insertar datos de ejemplo.

👉 Al terminar tendrás la tabla `Plantas` con registros de prueba listos para usar.
