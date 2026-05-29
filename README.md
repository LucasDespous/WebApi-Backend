# Ecommerce API

Proyecto Backend realizado en .NET 8 utilizando Clean Architecture simple para una API de stock estilo Ecommerce

COMO EJECUTAR

1. Abrir terminal en la carpeta del proyecto

2. Restaurar paquetes:
   dotnet restore

3. Ejecutar la API:
   dotnet run --project Ecommerce.Presentation

4. Abrir Swagger:
   http://localhost:5000/swagger

COMO USAR LA API

Para usar la API hay dos opciones: registrar un usuario nuevo o iniciar sesión con el usuario administrador ya creado.

El usuario administrador ya creado es:

Email: lucasdespous@gmail.com
Password: Lucas1234
Rol: Admin

PARA INICIAR SESION:

1. Ir al endpoint:

POST /api/Auth/login

2. Enviar este JSON:

{
  "email": "lucasdespous@gmail.com",
  "password": "Lucas1234"
}

3. La API devuelve un token JWT.

4. Copiar el valor del campo token.

5. En Swagger, presionar el botón Authorize.

6. Pegar el token JWT y confirmar.

PARA REGISTRAR UN USUARIO NUEVO:

POST /api/Auth/register

Con este ejemplo u otro:
{
  "firstName": "Profesor",
  "lastName": "Prueba",
  "email": "profesor@test.com",
  "password": "Profesor123"
}


## Tecnologias y conceptos usados

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- DbContext
- Migraciones
- Repository Pattern
- JWT Authentication
- Authorization con roles
- Swagger

## Arquitectura

El proyecto esta separado en cuatro capas:


Ecommerce.Domain
Ecommerce.Application
Ecommerce.Infrastructure
Ecommerce.Presentation


## Funcionalidades

- Login con JWT
- Roles: `Admin` y `User`
- Endpoints protegidos con `[Authorize]`
- Endpoints exclusivos para Admin con `[Authorize(Roles = "Admin")]`
- CRUD de categorias
- CRUD de productos
- Busqueda de productos por nombre
- Relacion entre categoria y productos




