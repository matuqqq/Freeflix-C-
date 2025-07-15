using System;
using System.Collections.Generic;
using System.Linq;
using Freeflix.Interfaces;
using Freeflix.Models;

namespace Freeflix.Services
{
    /// <summary>
    /// Servicio de gestión de valoraciones - Patrón Singleton
    /// Aplica el principio de Encapsulación y patrón Singleton
    /// Implementa IRatingSystem
    /// </summary>
    public sealed class RatingService : IRatingSystem
    {
        private static RatingService _instance;
        private static readonly object _lock = new object();
        private readonly List<Rating> _ratings;

        private RatingService()
        {
            _ratings = new List<Rating>();
        }

        public static RatingService GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new RatingService();
                }
            }
            return _instance;
        }

        public bool AddRating(Rating rating)
        {
            if (rating == null || !rating.IsValid())
                return false;

            // Verificar si el usuario ya valoró este contenido
            var existingRating = _ratings.FirstOrDefault(r => r.UserId == rating.UserId && 
                                                             r.AudiovisualId == rating.AudiovisualId);

            if (existingRating != null)
            {
                // Actualizar valoración existente
                existingRating.UpdateValue(rating.Value);
            }
            else
            {
                // Agregar nueva valoración
                _ratings.Add(rating);
            }

            // Actualizar la valoración en el contenido
            var contentService = ContentService.GetInstance();
            var content = contentService.GetContentById(rating.AudiovisualId);
            content?.AddRating(rating);

            // Incrementar contador de valoraciones del usuario
            var authService = AuthService.GetInstance();
            if (authService.CurrentUser is User user)
            {
                user.IncrementRatingCount();
            }

            return true;
        }

        public double CalculateAverage(string audiovisualId)
        {
            if (string.IsNullOrEmpty(audiovisualId))
                return 0.0;

            var contentRatings = _ratings.Where(r => r.AudiovisualId == audiovisualId).ToList();
            
            if (contentRatings.Count == 0)
                return 0.0;

            return contentRatings.Average(r => r.Value);
        }

        public Rating GetUserRating(string userId, string audiovisualId)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(audiovisualId))
                return null;

            return _ratings.FirstOrDefault(r => r.UserId == userId && r.AudiovisualId == audiovisualId);
        }

        public List<Rating> GetRatingsForContent(string audiovisualId)
        {
            if (string.IsNullOrEmpty(audiovisualId))
                return new List<Rating>();

            return _ratings.Where(r => r.AudiovisualId == audiovisualId).ToList();
        }

        public bool UpdateRating(string userId, string audiovisualId, int newValue)
        {
            var rating = GetUserRating(userId, audiovisualId);
            if (rating == null)
                return false;

            try
            {
                rating.UpdateValue(newValue);
                
                // Actualizar la valoración en el contenido
                var contentService = ContentService.GetInstance();
                var content = contentService.GetContentById(audiovisualId);
                content?.UpdateRating();

                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }

        public List<Rating> GetUserRatings(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return new List<Rating>();

            return _ratings.Where(r => r.UserId == userId).ToList();
        }

        public Dictionary<int, int> GetRatingDistribution(string audiovisualId)
        {
            var distribution = new Dictionary<int, int>
            {
                {1, 0}, {2, 0}, {3, 0}, {4, 0}, {5, 0}
            };

            var contentRatings = GetRatingsForContent(audiovisualId);
            foreach (var rating in contentRatings)
            {
                distribution[rating.Value]++;
            }

            return distribution;
        }

        public int GetTotalRatingsCount()
        {
            return _ratings.Count;
        }

        public List<Rating> GetRecentRatings(int count = 10)
        {
            return _ratings.OrderByDescending(r => r.CreatedAt).Take(count).ToList();
        }
    }
}