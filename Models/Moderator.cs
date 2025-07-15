using System;
using System.Collections.Generic;

namespace Freeflix.Models
{
    public class Moderator : BaseUser
    {
        private DateTime _createdAt;
        private List<string> _modifiedContentIds;
        private int _contentAdded;

        public DateTime CreatedAt => _createdAt;
        public List<string> ModifiedContentIds => new List<string>(_modifiedContentIds);
        public int ContentAdded => _contentAdded;

        public Moderator(string username, string email, string password)
            : base(username, email, password, UserRole.Moderator)
        {
            _createdAt = DateTime.Now;
            _modifiedContentIds = new List<string>();
            _contentAdded = 0;
        }

        public override UserPermissions GetPermissions()
        {
            return UserPermissions.ModerateContent | UserPermissions.ViewContent;
        }

        public void AddModifiedContent(string contentId)
        {
            if (!_modifiedContentIds.Contains(contentId))
            {
                _modifiedContentIds.Add(contentId);
            }
        }

        public void IncrementContentAdded()
        {
            _contentAdded++;
        }

        public override string GetUserInfo()
        {
            return base.GetUserInfo() + $", Contenido agregado: {_contentAdded}, Modificaciones: {_modifiedContentIds.Count}";
        }
    }
}