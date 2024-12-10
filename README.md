# **.NET 8 Web API con Azure y Clean Architecture**

## Descripción

Esta es una API construida con **.NET 8** utilizando **Clean Architecture**. La aplicación ofrece una serie de funcionalidades que incluyen autenticación basada en **JWT**, integración con **Azure**, **envío de correos**, **monitoreo de API**, **creación de recursos en Azure** y **seguridad con Azure Key Vault**. Además, la aplicación proporciona documentación interactiva de la API a través de **Swagger**.

## Funcionalidades

### 1. **Autenticación con JWT**

La aplicación implementa autenticación basada en **JSON Web Tokens (JWT)**. Los usuarios pueden usar el método **"get-by-username-password"** con las credenciales, y una vez autenticados, recibirán un token JWT para acceder a los recursos protegidos de la API.

- **Flujo de autenticación:**
  - El usuario envía sus credenciales (nombre de usuario y contraseña).
  - Si las credenciales son válidas, se genera un **token JWT**.
  - El token se envía al cliente y debe ser utilizado en las solicitudes subsiguientes en el encabezado `Authorization`.

### 2. **Envío de Correo Electrónico**

La aplicación tiene la capacidad de enviar correos electrónicos. Esta funcionalidad se puede mejorar para ser util con en escenarios como la confirmación de registro, recuperación de contraseñas, y notificaciones a los usuarios.

- Se utiliza un servicio de correo electrónico configurado en Azure o mediante SMTP.
- El sistema envía correos a los usuarios con contenido dinámico.

### 3. **Creación de Recursos en Azure**

La aplicación está integrada con **Azure** para permitir la creación y administración de recursos de manera dinámica:

- **Creación de recursos:** la aplicación puede interactuar con **Azure Resource Manager** para crear recursos como keyValut, bases de datos, etc.
- **Configuración de recursos:** la integración permite manejar configuraciones como el almacenamiento en Azure, instancias de bases de datos, entre otros.

### 4. **Uso de Azure Key Vault**

La seguridad de la aplicación se mejora mediante el uso de **Azure Key Vault**. Todos los secretos, claves y certificados sensibles se almacenan de manera segura en **Key Vault**.

- **Gestión de secretos:** las credenciales y configuraciones sensibles se extraen de **Azure Key Vault** para ser utilizadas por la aplicación de forma segura.
- **Acceso controlado:** la aplicación utiliza **Managed Identity** para acceder a los secretos almacenados en Key Vault sin necesidad de claves de acceso explícitas.

### 5. **Monitoreo de la API**

La aplicación está configurada para ofrecer monitoreo y trazabilidad de las solicitudes a la API, integrándose con herramientas de Azure para monitoreo, como **Azure Application Insights**.

- **Monitoreo de rendimiento y errores**: Información detallada sobre el rendimiento de la API y cualquier error ocurrido.
- **Alertas**: Notificaciones automáticas sobre anomalías en el sistema.
- **Análisis de solicitudes**: Información detallada sobre las solicitudes y respuestas de la API.

### 6. **Documentación con Swagger**

La API proporciona documentación interactiva a través de **Swagger**. Swagger permite a los desarrolladores explorar todos los puntos finales de la API y probar las solicitudes directamente desde el navegador.

- **Documentación interactiva**: Swagger UI proporciona una interfaz fácil de usar para interactuar con la API.
- **Esquema de la API**: Se genera automáticamente un esquema OpenAPI para describir todos los recursos disponibles en la API.

## Arquitectura

La aplicación sigue el patrón de **Clean Architecture** para organizar el código de manera modular y escalable.

- **Capa API**: La API es el punto de entrada para interactuar con la aplicación. Está encargada de recibir solicitudes HTTP y devolver respuestas.
- **Capa Application**: Contiene la lógica de negocio y las interfaces necesarias para interactuar con las capas de infraestructura y presentación.
- **Capa Domain**: Define las entidades y las reglas de negocio de la aplicación. No depende de ninguna otra capa.
- **Capa Infrastructure**: Contiene implementaciones concretas para interactuar con servicios externos como bases de datos, servicios de correo, y Azure.

## Requisitos

- **.NET 6.0 o superior**
- **Azure Subscription** para acceder a servicios como Azure Key Vault y Azure Resource Manager.
- **Cuenta de correo electrónico SMTP** o integración con un servicio de correo como SendGrid.
- **Swagger** habilitado para la documentación de la API.

## OJO
- La cuenta de azure debe ser creado incluyendo la integración de esta a la app, se puede usar una cuenta **Gratuita de 1 mes** o una cuenta **estudiantil**
❤

## Instalación

1. **Clonar el repositorio:**

   ```bash
   git clone https://github.com/ViCode321/API-en-.NET-8.git
   cd API-en-.NET-8

