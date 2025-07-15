# Sistema Freeflix - Windows Forms C#

## Descripción del Proyecto

Sistema de gestión de películas y series tipo Netflix desarrollado en Windows Forms C# aplicando los cuatro principios fundamentales de la Programación Orientada a Objetos.

## Principios POO Aplicados

### 1. **Abstracción**
- **Interfaces**: `IUser`, `IAudiovisual`, `IContentManager`, `IRatingSystem`
- **Clases Abstractas**: `BaseUser`, `BaseAudiovisual`
- Definen contratos y comportamientos comunes sin implementación específica

### 2. **Encapsulación**
- Propiedades privadas con accesores públicos
- Métodos privados para lógica interna
- Validación de datos en setters
- Ejemplo: `BaseUser` encapsula datos de usuario con validaciones

### 3. **Herencia**
- `User` y `Moderator` heredan de `BaseUser`
- `Movie` y `Series` heredan de `BaseAudiovisual`
- Reutilización de código y jerarquía clara

### 4. **Polimorfismo**
- Métodos abstractos implementados de forma diferente en clases derivadas
- `GetSpecificInfo()` se comporta diferente en `Movie` vs `Series`
- `GetPermissions()` varía entre `User` y `Moderator`

## Patrones de Diseño Implementados

### Singleton
- `AuthService`, `ContentService`, `RatingService`
- Garantiza una única instancia de servicios críticos
- Thread-safe con double-checked locking

### Factory Method
- Creación de usuarios y contenido audiovisual
- Abstrae la lógica de creación de objetos

## Arquitectura del Sistema

```
Freeflix/
├── Models/
│   ├── BaseUser.cs (Clase abstracta)
│   ├── User.cs (Herencia)
│   ├── Moderator.cs (Herencia)
│   ├── BaseAudiovisual.cs (Clase abstracta)
│   ├── Movie.cs (Herencia)
│   ├── Series.cs (Herencia)
│   ├── Rating.cs
│   ├── UserPermissions.cs
│   └── Enums.cs
├── Interfaces/
│   ├── IUser.cs
│   ├── IAudiovisual.cs
│   ├── IContentManager.cs
│   └── IRatingSystem.cs
├── Services/
│   ├── AuthService.cs (Singleton)
│   ├── ContentService.cs (Singleton)
│   └── RatingService.cs (Singleton)
└── Forms/
    ├── FRM_Login.cs
    ├── FRM_Main.cs
    ├── FRM_Movies.cs
    ├── FRM_Series.cs
    ├── FRM_Admin.cs
    └── FRM_VideoPlayer.cs
```

## Funcionalidades Principales

### Sistema de Autenticación
- Login diferenciado por roles (Usuario/Moderador)
- Validación de credenciales
- Gestión de sesiones

### Gestión de Contenido
- **Usuarios**: Visualización, búsqueda y valoración
- **Moderadores**: CRUD completo de películas y series
- Búsqueda por nombre y género
- Sistema de valoraciones con promedio automático

### Reproductor de Video
- Interfaz de reproductor básico
- Controles de play/pause/stop
- Barra de progreso
- Soporte para atajos de teclado

## Diseño Visual

### Paleta de Colores Netflix
- **Fondo Principal**: `Color.FromArgb(20, 20, 20)`
- **Paneles**: `Color.FromArgb(35, 35, 35)`
- **Rojo Netflix**: `Color.FromArgb(229, 9, 20)`
- **Texto**: `Color.White`

### Nomenclatura de Controles
- `BTN_` para botones (BTN_Login, BTN_Search)
- `PNL_` para paneles (PNL_Navigation, PNL_Content)
- `DGV_` para DataGridViews (DGV_Movies, DGV_Series)
- `TXT_` para TextBoxes (TXT_Username, TXT_Search)
- `CMB_` para ComboBoxes (CMB_Genre, CMB_Type)

## Instalación y Configuración

### Requisitos
- Visual Studio 2019 o superior
- .NET Framework 4.7.2 o superior
- Windows 10/11

### Pasos de Instalación
1. Crear nuevo proyecto Windows Forms App (.NET Framework)
2. Copiar todos los archivos .cs en las carpetas correspondientes
3. Agregar referencias necesarias:
   ```xml
   <PackageReference Include="System.Windows.Forms" Version="4.0.0" />
   ```
4. Compilar y ejecutar

### Usuarios de Prueba
- **Moderador**: usuario: `admin`, contraseña: `admin123`
- **Usuario**: usuario: `usuario1`, contraseña: `user123`

## Extensiones Futuras

### Reproductor de Video Real
Para implementar un reproductor real, agregar:
```csharp
// Instalar NuGet: AxInterop.WMPLib
private AxWindowsMediaPlayer axWindowsMediaPlayer1;

// En InitializeComponent():
axWindowsMediaPlayer1 = new AxWindowsMediaPlayer();
axWindowsMediaPlayer1.URL = videoPath;
```

### Base de Datos
Reemplazar listas en memoria con Entity Framework:
```csharp
public class FreelixContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Series> Series { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Rating> Ratings { get; set; }
}
```

### Características Adicionales
- Sistema de favoritos
- Recomendaciones personalizadas
- Historial de visualización
- Comentarios y reseñas
- Notificaciones push
- Modo offline

## Principios SOLID Aplicados

### Single Responsibility Principle (SRP)
- Cada clase tiene una responsabilidad específica
- `AuthService` solo maneja autenticación
- `ContentService` solo gestiona contenido

### Open/Closed Principle (OCP)
- Clases abiertas para extensión, cerradas para modificación
- Nuevos tipos de contenido se pueden agregar heredando de `BaseAudiovisual`

### Liskov Substitution Principle (LSP)
- `Movie` y `Series` pueden usarse intercambiablemente como `BaseAudiovisual`
- `User` y `Moderator` son sustituibles como `BaseUser`

### Interface Segregation Principle (ISP)
- Interfaces específicas y cohesivas
- `IContentManager` e `IRatingSystem` separados

### Dependency Inversion Principle (DIP)
- Dependencias hacia abstracciones, no implementaciones concretas
- Forms dependen de interfaces, no de clases concretas

## Conclusión

Este sistema demuestra una implementación completa de los principios POO en un contexto real, con un diseño escalable, mantenible y extensible. La arquitectura permite fácil adición de nuevas funcionalidades y tipos de contenido sin modificar el código existente.