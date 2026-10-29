# Sistema de Gestión de Ventas

## Descripción
Sistema de consola desarrollado en C# para la gestión integral de ventas, productos y clientes. Permite realizar operaciones CRUD completas, control de inventario en tiempo real y generación de reportes básicos.

## Características Principales
- **Gestión de Productos**: CRUD completo con control de stock
- **Gestión de Clientes**: Administración de base de clientes
- **Registro de Ventas**: Proceso completo con validación de stock
- **Reportes Automatizados**: Total de ventas y ventas por producto
- **Validaciones Robustas**: Control de datos de entrada y reglas de negocio

## Requisitos del Sistema
- **.NET 6.0** o superior
- **Windows/Linux/macOS** con soporte para .NET
- **Consola/Terminal** estándar

## Instalación y Ejecución

### Paso 1: Clonar o Descargar el Proyecto
# Si usas Git
git clone [url-del-repositorio]

# O descargar el archivo ZIP y extraer

### Paso 2: Compilar el Proyecto
dotnet build


## Guía de Uso Rápido

### Menú Principal
=== SISTEMA DE GESTIÓN DE VENTAS ===
1. Gestión de Productos
2. Gestión de Clientes  
3. Gestión de Ventas
4. Reportes
0. Salir

### Ejemplo: Agregar Producto

=== PRODUCTOS ===
1. Agregar
2. Listar
3. Actualizar
4. Eliminar
0. Volver
Opción: 1

Nombre: Laptop HP
Precio: 1500.00
Stock: 10
Producto agregado.

### Ejemplo: Registrar Venta
=== VENTAS ===
1. Registrar venta
Opción: 1

ID Cliente: 1
ID Producto: 1
Cantidad: 2
Venta registrada exitosamente.

## Validaciones Implementadas
- **Nombres**: No pueden contener números o estar vacíos
- **Precios**: No pueden ser valores negativos
- **Stock**: Debe ser entero no negativo
- **Emails**: No pueden estar vacíos
- **Stock en ventas**: Verificación de disponibilidad

## Casos de Prueba Recomendados

### Prueba 1: Flujo Completo de Venta
1. Agregar cliente: "Maria Garcia", "maria@email.com"
2. Agregar producto: "Tablet Samsung", 300.00, 15
3. Registrar venta: ClienteID 1, ProductoID 1, Cantidad 2
4. Verificar stock actualizado: 13 unidades
5. Generar reporte de ventas

### Prueba 2: Validación de Stock Insuficiente
1. Intentar vender 20 unidades de producto con stock 5
2. Sistema debe mostrar: "Error: Stock insuficiente"

## Solución de Problemas Comunes

### Problema: "La consola se cierra inmediatamente"
- Ejecutar desde Command Prompt o Terminal
- Usar `dotnet run` en la carpeta del proyecto

## Tecnologías Utilizadas
- **C#** (.NET 6.0)
- **Colecciones**: List<T>, Dictionary<TKey, TValue>
- **LINQ** para consultas de datos
- **Programación Orientada a Objetos**

## Licencia
Este proyecto es para fines educativos. Desarrollado como parte de un curso de Programación Orientada a Objetos.

---

**¡Listo para usar!** Ejecuta `dotnet run` y comienza a gestionar tus ventas.
