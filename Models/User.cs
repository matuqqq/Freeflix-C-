using System;
using System.Collections.Generic;

namespace Freeflix.Models
{
    public class User : BaseUser
    {
        private DateTime _lastLogin;
        private int _totalRatings;
        private List<string> _favoriteContent;

        public DateTime LastLogin
        {
            get => _lastLogin;
            private set => _lastLogin = value;
        }

        public int TotalRatings
        {
            get => _totalRatings;
            private set => _totalRatings = value;
        }

        public List<string> FavoriteContent => new List<string>(_favoriteContent);

        public User(string username, string email, string password)
            : base(username, email, password, UserRole.User)
        {
            _lastLogin = DateTime.Now;
            _totalRatings = 0;
            _favoriteContent = new List<string>();
        }

        public override UserPermissions GetPermissions()
        {
            return UserPermissions.ViewContent;
        }

        public void UpdateLastLogin()
        {
            LastLogin = DateTime.Now;
        }

        public void IncrementRatingCount()
        {
            TotalRatings++;
        }

        public void AddToFavorites(string contentId)
        {
            if (!_favoriteContent.Contains(contentId))
            {
                _favoriteContent.Add(contentId);
            }
        }

        public void RemoveFromFavorites(string contentId)
        {
            _favoriteContent.Remove(contentId);
        }

        public override string GetUserInfo()
        {
            return base.GetUserInfo() + $", Último acceso: {LastLogin:dd/MM/yyyy HH:mm}, Valoraciones: {TotalRatings}";
        }
    }
}