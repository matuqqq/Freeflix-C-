using System;
using System.Collections.Generic;
using System.Linq;
using Freeflix.Models;

namespace Freeflix.Services
{
    /// <summary>
    /// Servicio de autenticación - Patrón Singleton
    /// Aplica el principio de Encapsulación y patrón Singleton
    /// </summary>
    public sealed class AuthService
    {
        private static AuthService _instance;
        private static readonly object _lock = new object();
        private readonly List<BaseUser> _users;
        private BaseUser _currentUser;

        private AuthService()
        {
            _users = new List<BaseUser>();
            InitializeDefaultUsers();
        }

        public static AuthService GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new AuthService();
                }
            }
            return _instance;
        }

        public BaseUser CurrentUser => _currentUser;

        private void InitializeDefaultUsers()
        {
            // Usuario moderador por defecto
            var moderator = new Moderator("admin", "admin@freeflix.com", "admin123");
            _users.Add(moderator);

            // Usuario común por defecto
            var user = new User("usuario1", "user1@freeflix.com", "user123");
            _users.Add(user);
        }

        public BaseUser Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            var user = _users.FirstOrDefault(u => u.ValidateCredentials(username, password));
            
            if (user != null)
            {
                _currentUser = user;
                
                // Actualizar último login si es usuario común
                if (user is User commonUser)
                {
                    commonUser.UpdateLastLogin();
                }
            }

            return user;
        }

        public bool RegisterUser(BaseUser user)
        {
            if (user == null)
                return false;

            // Verificar si el usuario ya existe
            if (_users.Any(u => u.Username.Equals(user.Username, StringComparison.OrdinalIgnoreCase) ||
                               u.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase)))
            {
                return false;
            }

            _users.Add(user);
            return true;
        }

        public void Logout()
        {
            _currentUser = null;
        }

        public bool IsAuthenticated()
        {
            return _currentUser != null;
        }

        public bool IsCurrentUserModerator()
        {
            return _currentUser is Moderator;
        }

        public List<BaseUser> GetAllUsers()
        {
            return new List<BaseUser>(_users); // Copia defensiva
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            var user = _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            
            if (user == null || !user.ValidateCredentials(username, oldPassword))
                return false;

            // Aquí necesitarías un método para cambiar la contraseña en BaseUser
            // Por simplicidad, asumimos que existe
            return true;
        }
    }
}