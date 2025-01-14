# BarberShopSoftware

BarberShopSoftware es una aplicación web diseñada para la gestión de una barbería. Incluye funcionalidades como la administración de clientes, inventario, ventas, y un sistema de autenticación seguro.

## **Tecnologías Utilizadas**

- **Frontend**: React 18 con Vite.
- **Backend**: ASP.NET Core 8.0.0 con soporte para Swagger.
- **Base de datos**: PostgreSQL.
- **Autenticación**: JSON Web Tokens (JWT).
- **Contenedores**: Docker para la fácil implementación.

---

## **Documentación**

### **Problema y Contexto**

El problema principal era la falta de un sistema centralizado para gestionar operaciones en una barbería, como:
- Registro de clientes y barberos.
- Gestión de inventario de productos.
- Registro de ventas.
- Autenticación segura.

Esta solución busca optimizar la gestión diaria de las barberías.

---

### **Detalles Técnicos de la Solución**

1. **Backend**: Construido con ASP.NET Core 8.0.0 y sigue los principios SOLID para escalabilidad.
   - Controladores RESTful para gestionar clientes, productos y ventas.
   - Uso de Entity Framework Core con PostgreSQL.

2. **Frontend**: Diseñado con React y utiliza Axios para consumir APIs.
   - Componentes reutilizables para listas de clientes, inventario y ventas.

3. **Seguridad**:
   - Uso de JWT para autenticar usuarios.
   - Implementación de validaciones en entradas basadas en OWASP.

4. **Swagger API**:
![image](https://github.com/user-attachments/assets/fe697d9e-0bbf-4bf5-aaf3-0d84aeab4304)

---

### **Instrucciones para Ejecutar con Docker**

1. **Clonar el repositorio**:
   ```bash
   git clone https://github.com/vsqbustamante/BarberShopSoftware.git
   cd BarberShopSoftware

2. **Construir y levantar los contenedores**:

    docker-compose up --build

    Acceder a la aplicación:
        Frontend: http://localhost:3000
        Backend: http://localhost:5000
        Swagger API: http://localhost:5000/swagger

Patrones de Diseño y Justificación

    CQRS: Separación de consultas y comandos para simplificar la lógica y optimizar el rendimiento.
    Repository Pattern: Facilita el acceso a los datos mediante repositorios.
    Component-Based Design: Frontend basado en componentes reutilizables.

Principios SOLID Aplicados

    S: Responsabilidad única para controladores, servicios y modelos.
    O: Código abierto para extensión al agregar nuevas funcionalidades.
    L: Sustitución de Liskov asegurada en servicios genéricos.
    I: Interfaces específicas para clientes y productos.
    D: Inversión de dependencias mediante inyección en Startup.cs.

Prácticas OWASP Implementadas

    Validación de Entradas:
        Sanitización de datos recibidos en el backend.
    CORS:
        Configuración de políticas de acceso para evitar ataques de origen cruzado.
    Protección de JWT:
        Tokens firmados con claves seguras y tiempos de expiración definidos.
   
