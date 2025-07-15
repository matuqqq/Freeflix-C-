using System;

namespace Freeflix.Models
{
    /// <summary>
    /// Clase que representa una valoración
    /// Aplica el principio de Encapsulación
    /// </summary>
    public class Rating
    {
        private string _id;
        private string _userId;
        private string _audiovisualId;
        private int _value;
        private DateTime _createdAt;

        public string Id => _id;
        public string UserId => _userId;
        public string AudiovisualId => _audiovisualId;
        public int Value => _value;
        public DateTime CreatedAt => _createdAt;

        public Rating(string userId, string audiovisualId, int value)
        {
            _id = Guid.NewGuid().ToString();
            _userId = userId ?? throw new ArgumentNullException(nameof(userId));
            _audiovisualId = audiovisualId ?? throw new ArgumentNullException(nameof(audiovisualId));
            _createdAt = DateTime.Now;
            
            SetValue(value);
        }

        private void SetValue(int value)
        {
            if (value < 1 || value > 5)
                throw new ArgumentOutOfRangeException(nameof(value), "La valoración debe estar entre 1 y 5");
            
            _value = value;
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(_userId) && 
                   !string.IsNullOrEmpty(_audiovisualId) && 
                   _value >= 1 && _value <= 5;
        }

        public void UpdateValue(int newValue)
        {
            SetValue(newValue);
        }

        public override string ToString()
        {
            return $"Valoración: {_value}/5 - {_createdAt:dd/MM/yyyy}";
        }
    }
}