using System;
using Freeflix.Interfaces;

namespace Freeflix.Models
{
    public abstract class BaseUser : IUser
    {
        private string _id;
        private string _username;
        private string _password;
        private string _email;
        private UserRole _role;
        private bool _isActive;

        public string Id => _id;
        public string Username 
        { 
            get => _username;
            set => _username = value ?? throw new ArgumentNullException(nameof(value));
        }
        public string Password
        {
            get => _password;
            set => _password = value ?? throw new ArgumentNullException(nameof(value));
        }
        public string Email
        {
            get => _email;
            set => _email = value ?? throw new ArgumentNullException(nameof(value));
        }
        public UserRole Role
        {
            get => _role;
            set => _role = value;
        }
        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        protected BaseUser(string username, string email, string password, UserRole role)
        {
            _id = Guid.NewGuid().ToString();
            Username = username;
            Email = email;
            Password = password;
            Role = role;
            IsActive = true;
        }

        public virtual bool ValidateCredentials(string username, string password)
        {
            return _username.Equals(username, StringComparison.OrdinalIgnoreCase) && 
                   _password.Equals(password);
        }

        public virtual string GetUserInfo()
        {
            return $"Usuario: {_username}, Email: {_email}, Rol: {_role}";
        }

        public abstract UserPermissions GetPermissions();
    }
}