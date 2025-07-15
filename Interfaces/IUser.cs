using System;
using Freeflix.Models;

namespace Freeflix.Interfaces
{
    /// <summary>
    /// Interfaz que define el contrato para usuarios del sistema
    /// Aplica el principio de Abstracción
    /// </summary>
    public interface IUser
    {
        string Username { get; set; }
        string Password { get; set; }
        UserRole Role { get; set; }
        bool IsActive { get; set; }
        UserPermissions GetPermissions();
    }
}