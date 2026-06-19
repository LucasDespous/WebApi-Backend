# Ecommerce API

Proyecto backend realizado en **.NET 8** con **ASP.NET Core Web API** para administrar categorias y productos de un ecommerce.

## Como ejecutar

Desde la carpeta raiz del proyecto:

```bash
dotnet restore
dotnet build
dotnet ef database update --project Ecommerce.Infrastructure --startup-project Ecommerce.Presentation
dotnet run --project Ecommerce.Presentation --urls http://localhost:5000
```

Abrir Swagger:

```text
http://localhost:5000/swagger
```

## Usuario administrador

La API crea o actualiza automaticamente este usuario Admin cuando inicia:

```text
Email: lucasdespous@gmail.com
Password: Lucas1234
Rol: Admin
```

Para iniciar sesion en Swagger:

1. Ir a `POST /api/Auth/login`.
2. Enviar:

```json
{
  "email": "lucasdespous@gmail.com",
  "password": "Lucas1234"
}
```

3. Copiar el token devuelto.
4. Presionar `Authorize`.
5. Pegar el token JWT.
6. Probar los endpoints protegidos de Admin.

## Tecnologias y conceptos usados

- .NET 8
- ASP.NET Core Web API
- Controllers
- Clean Architecture
- Entity Framework Core
- SQLite
- DbContext
- Fluent API
- Migraciones
- Repository Pattern
- DTOs
- CQRS con MediatR
- JWT Authentication
- Authorization con roles
- BCrypt
- Swagger

## Arquitectura

El proyecto esta separado en cuatro capas:

```text
Ecommerce.Domain
Ecommerce.Application
Ecommerce.Infrastructure
Ecommerce.Presentation
```

La dependencia principal es:

```text
Domain <- Application <- Infrastructure <- Presentation
```

`Application` no depende de `Infrastructure`. Las dependencias se invierten mediante interfaces.

## CQRS con MediatR

Para cumplir el criterio de CQRS, se agrego MediatR en la capa `Application`.

Se implemento:

- Query: `GetAllProductsQuery`
- Handler: `GetAllProductsQueryHandler`
- Command: `CreateProductCommand`
- Handler: `CreateProductCommandHandler`

Estos se usan desde `ProductsController`:

- `GET /api/Products` usa `GetAllProductsQuery`
- `POST /api/Products` usa `CreateProductCommand`

El resto de endpoints conserva la estructura previa con casos de uso.

## Funcionalidades

- Registro de usuarios
- Login con JWT
- Roles `Admin` y `User`
- Endpoints protegidos con `[Authorize]`
- Endpoints exclusivos de Admin con `[Authorize(Roles = "Admin")]`
- CRUD de categorias
- CRUD de productos
- Busqueda de productos por nombre
- Relacion entre categoria y productos

## Endpoints principales

### Auth

```text
POST /api/Auth/register
POST /api/Auth/login
```

### Categorias

```text
GET    /api/Categories
GET    /api/Categories/{id}
POST   /api/Categories
PUT    /api/Categories/{id}
DELETE /api/Categories/{id}
```

### Productos

```text
GET    /api/Products
GET    /api/Products/{id}
GET    /api/Products/search?name=texto
POST   /api/Products
PUT    /api/Products/{id}
DELETE /api/Products/{id}
```

## Aclaracion

No se puede eliminar una categoria si tiene productos asociados. Primero se deben eliminar o modificar los productos de esa categoria.
