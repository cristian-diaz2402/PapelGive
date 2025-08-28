# 🗂️ Sistema de Gestión de Papelería

![Estado](https://img.shields.io/badge/Estado-Finalizado-brightgreen?style=for-the-badge)
![Lenguaje](https://img.shields.io/badge/C%23-.NET%20Framework-512BD4?style=for-the-badge&logo=csharp&logoColor=white)
![Base de Datos](https://img.shields.io/badge/SQL%20Server-Relacional-red?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Tipo](https://img.shields.io/badge/Proyecto-Académico-blue?style=for-the-badge)
![Licencia](https://img.shields.io/badge/Licencia-MIT-yellow?style=for-the-badge)

---

## ✨ Características principales
- Gestión de **productos**, **empleados** y **clientes**.
- Base de datos **SQL Server relacional** con:
  - Diseño normalizado
  - Claves primarias y foráneas
  - Procedimientos almacenados
- Ejecutable (`.exe`) incluido en el repositorio.
- Proyecto **académico** y **100% local** (no requiere internet).

---

## 🗄️ Base de Datos
- El sistema utiliza **SQL Server local**.
- El script completo para crear la base de datos e insertar datos se encuentra en un archivo **.txt** dentro del repositorio.
- Pasos sugeridos:
  1. Crear la base de datos en SQL Server.
  2. Ejecutar todo el contenido del archivo `.txt`.
  3. Si ocurren errores al insertar datos, eliminar las líneas conflictivas y volver a ejecutar.

---

## ⚙️ Configuración
Es necesario modificar las credenciales de conexión en el **código fuente C#** antes de ejecutar el programa:

// Ejemplo de cadena de conexión
string connectionString = "Server=TU_SERVIDOR;Database=PapeleriaDB;User Id=USUARIO;Password=CONTRASEÑA;";


* **Usuario:** `crstiangrupo5`
* **Contraseña:** `grupo5`
* **Base de datos:** `SQL Server`

---

## 🚀 Ejecución

1. Configurar la base de datos como se indica arriba.
2. Modificar las credenciales en el código fuente.
3. Ejecutar el archivo **.exe** incluido en el repositorio.
4. ¡Listo! El sistema estará funcionando sin inconvenientes.

---

## 👤 Roles de acceso

* **Rol:** Administrador
* **Usuario:** `crstiangrupo5`
* **Password:** `grupo5`

---

## 📩 Soporte

Si deseas más información sobre el funcionamiento del sistema, no dudes en comunicarte.
