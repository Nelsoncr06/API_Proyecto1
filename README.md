# Listado de endpoints de la API RESTful

La API RESTful `API.UISIL` fue desarrollada en C# con ASP.NET Core sobre .NET 10 y permite administrar usuarios mediante operaciones CRUD, además de validar las credenciales de acceso mediante un servicio de inicio de sesión conectado a la base de datos `UISIL_API_BD`.

Los endpoints utilizan el formato JSON para recibir y devolver información. Las rutas se presentan de acuerdo con los atributos definidos en los controladores del proyecto.

## 1. Insertar un usuario

- **Funcionalidad:** Registra un nuevo usuario en el sistema.
- **Método HTTP:** `POST`
- **Ruta:** `/api/Usuarios`
- **Cuerpo de la solicitud:**

```json
{
  "correo": "usuario.prueba@example.com",
  "contrasena": "ClaveTemporal123!",
  "idRol": 1,
  "nombre": "Carlos",
  "apellido1": "Rodríguez",
  "apellido2": "Mora",
  "fechaNac": "1998-09-05",
  "genero": "Masculino",
  "telefono": "88881111",
  "direccion": "Heredia, Costa Rica"
}
```

**Descripción:** Recibe los datos del usuario mediante un objeto `UsuariosDto` y delega el registro a la capa de lógica de negocio, que se encarga de procesar la operación.

## 2. Consultar todos los usuarios

- **Funcionalidad:** Obtiene la lista de usuarios registrados que devuelve la consulta de la base de datos.
- **Método HTTP:** `GET`
- **Ruta:** `/api/Usuarios`
- **Cuerpo de la solicitud:** No requiere.

**Descripción:** Recupera la lista de usuarios mediante la capa de lógica de negocio y devuelve una respuesta con el resultado de la consulta.

## 3. Consultar un usuario por ID

- **Funcionalidad:** Busca un usuario específico utilizando su identificador.
- **Método HTTP:** `POST`
- **Ruta:** `/api/Usuarios/ObtenerUsuarioPorId`
- **Cuerpo de la solicitud:**

```json
{
  "idUsuario": 3
}
```

**Descripción:** Recibe el identificador dentro de un objeto `UsuariosDto` y consulta la información correspondiente al usuario solicitado.

## 4. Actualizar un usuario

- **Funcionalidad:** Modifica la información de un usuario existente.
- **Método HTTP:** `PUT`
- **Ruta:** `/api/Usuarios`
- **Cuerpo de la solicitud:**

```json
{
  "idUsuario": 3,
  "correo": "carlos.actualizado@example.com",
  "idRol": 1,
  "nombre": "Carlos Actualizado",
  "apellido1": "Rodríguez",
  "apellido2": "Mora",
  "fechaNac": "1998-09-05",
  "genero": "Masculino",
  "telefono": "88881111",
  "direccion": "Heredia, Costa Rica"
}
```

**Descripción:** Identifica el registro mediante `idUsuario` y envía los nuevos datos a la lógica de negocio para procesar la actualización. El ejemplo omite la contraseña para no modificarla durante esta prueba.

## 5. Eliminar un usuario

- **Funcionalidad:** Solicita la eliminación de un usuario mediante su identificador.
- **Método HTTP:** `DELETE`
- **Ruta:** `/api/Usuarios`
- **Cuerpo de la solicitud:**

```json
{
  "idUsuario": 1005
}
```

**Descripción:** Recibe el identificador del usuario y delega la operación a la capa de lógica de negocio. En la implementación actual, la eliminación es lógica: el registro se marca como inactivo en lugar de borrarse físicamente de la base de datos.

## 6. Iniciar sesión

- **Funcionalidad:** Valida las credenciales de un usuario contra la información almacenada en la base de datos.
- **Método HTTP:** `POST`
- **Ruta:** `/api/InicioSesion`
- **Cuerpo de la solicitud:**

```json
{
  "correo": "usuario.prueba@example.com",
  "contrasena": "ClaveTemporal123!"
}
```

**Descripción:** Recibe el correo electrónico y la contraseña mediante un objeto `InicioSesionDto`. La solicitud se procesa a través de la capa de lógica de negocio y la capa de acceso a datos, que invoca el procedimiento almacenado de inicio de sesión. La respuesta informa si la autenticación fue exitosa.

## Resumen de endpoints

| Funcionalidad | Método HTTP | Ruta |
|---|---|---|
| Insertar usuario | `POST` | `/api/Usuarios` |
| Consultar todos los usuarios | `GET` | `/api/Usuarios` |
| Consultar usuario por ID | `POST` | `/api/Usuarios/ObtenerUsuarioPorId` |
| Actualizar usuario | `PUT` | `/api/Usuarios` |
| Eliminar usuario | `DELETE` | `/api/Usuarios` |
| Iniciar sesión | `POST` | `/api/InicioSesion` |

## Consideraciones para las pruebas

1. Los ejemplos utilizan datos ilustrativos. Deben reemplazarse por valores de prueba válidos al ejecutar las solicitudes.
2. Las solicitudes que contienen un cuerpo deben enviarse con el encabezado `Content-Type: application/json`.
3. Para las operaciones de consulta, actualización y eliminación se debe utilizar un identificador existente cuando corresponda.
4. El resultado de cada operación se devuelve mediante la estructura de respuesta definida por la API, que incluye los campos `ok`, `mensaje` y `valorRetorno`.
5. El endpoint de consulta por ID utiliza `POST` y el de eliminación recibe el identificador en el cuerpo de la solicitud, conforme a la implementación actual del proyecto.
