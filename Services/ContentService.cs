using System;
using System.Collections.Generic;
using System.Linq;
using Freeflix.Interfaces;
using Freeflix.Models;

namespace Freeflix.Services
{
    /// <summary>
    /// Servicio de gestión de contenido - Patrón Singleton
    /// Aplica el principio de Encapsulación y patrón Singleton
    /// Implementa IContentManager
    /// </summary>
    public sealed class ContentService : IContentManager
    {
        private static ContentService _instance;
        private static readonly object _lock = new object();
        private readonly List<BaseAudiovisual> _content;

        private ContentService()
        {
            _content = new List<BaseAudiovisual>();
            InitializeDefaultContent();
        }

        public static ContentService GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new ContentService();
                }
            }
            return _instance;
        }

        private void InitializeDefaultContent()
        {
            // Películas de ejemplo
            var movie1 = new Movie(
                "Acción Extrema",
                "Acción",
                "Una película llena de adrenalina y aventuras.",
                120,
                "Director Acción",
                DateTime.Now
            );
            movie1.ImageUrl = "https://via.placeholder.com/300x450/FF0000/FFFFFF?text=Acción+Extrema";
            movie1.VideoUrl = @"C:\Videos\sample_movie.mp4"; // Ruta de ejemplo
            _content.Add(movie1);

            var movie2 = new Movie(
                "Comedia Familiar",
                "Comedia",
                "Una divertida comedia para toda la familia.",
                95,
                "Director Comedia",
                DateTime.Now
            );
            movie2.ImageUrl = "https://via.placeholder.com/300x450/00FF00/FFFFFF?text=Comedia+Familiar";
            _content.Add(movie2);

            // Series de ejemplo
            var series1 = new Series(
                "Drama Épico",
                "Drama",
                "Una serie dramática que te mantendrá al borde del asiento.",
                24,
                3,
                45
            );
            series1.ImageUrl = "https://via.placeholder.com/300x450/0000FF/FFFFFF?text=Drama+Épico";
            _content.Add(series1);

            var series2 = new Series(
                "Ciencia Ficción",
                "Sci-Fi",
                "Aventuras en el espacio y tecnología futurista.",
                12,
                2,
                50
            );
            series2.ImageUrl = "https://via.placeholder.com/300x450/FF00FF/FFFFFF?text=Sci-Fi";
            _content.Add(series2);
        }

        public bool AddContent(BaseAudiovisual content)
        {
            if (content == null || !content.IsValidForDisplay())
                return false;

            // Verificar si ya existe contenido con el mismo título
            if (_content.Any(c => c.Title.Equals(content.Title, StringComparison.OrdinalIgnoreCase)))
                return false;

            _content.Add(content);
            return true;
        }

        public bool UpdateContent(string id, BaseAudiovisual updatedContent)
        {
            if (string.IsNullOrEmpty(id) || updatedContent == null)
                return false;

            var existingContent = _content.FirstOrDefault(c => c.Id == id);
            if (existingContent == null)
                return false;

            // Actualizar propiedades
            existingContent.Title = updatedContent.Title;
            existingContent.Genre = updatedContent.Genre;
            existingContent.ShortDescription = updatedContent.ShortDescription;

            // Actualizar propiedades específicas según el tipo
            if (existingContent is Movie existingMovie && updatedContent is Movie updatedMovie)
            {
                existingMovie.Duration = updatedMovie.Duration;
                existingMovie.Director = updatedMovie.Director;
                existingMovie.ReleaseDate = updatedMovie.ReleaseDate;
            }
            else if (existingContent is Series existingSeries && updatedContent is Series updatedSeries)
            {
                existingSeries.Episodes = updatedSeries.Episodes;
                existingSeries.Seasons = updatedSeries.Seasons;
                existingSeries.EpisodeDuration = updatedSeries.EpisodeDuration;
                existingSeries.IsCompleted = updatedSeries.IsCompleted;
            }

            return true;
        }

        public bool DeleteContent(string id)
        {
            if (string.IsNullOrEmpty(id))
                return false;

            var content = _content.FirstOrDefault(c => c.Id == id);
            if (content == null)
                return false;

            _content.Remove(content);
            return true;
        }

        public List<BaseAudiovisual> SearchContent(string query, string genre = null)
        {
            var results = _content.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(query))
            {
                results = results.Where(c => c.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                           c.ShortDescription.Contains(query, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(genre))
            {
                results = results.Where(c => c.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
            }

            return results.ToList();
        }

        public List<BaseAudiovisual> GetAllContent()
        {
            return new List<BaseAudiovisual>(_content); // Copia defensiva
        }

        public BaseAudiovisual GetContentById(string id)
        {
            return _content.FirstOrDefault(c => c.Id == id);
        }

        public List<Movie> GetAllMovies()
        {
            return _content.OfType<Movie>().ToList();
        }

        public List<Series> GetAllSeries()
        {
            return _content.OfType<Series>().ToList();
        }

        public List<string> GetAllGenres()
        {
            return _content.Select(c => c.Genre).Distinct().OrderBy(g => g).ToList();
        }

        public List<BaseAudiovisual> GetTopRatedContent(int count = 10)
        {
            return _content.OrderByDescending(c => c.Rating).Take(count).ToList();
        }

        public List<BaseAudiovisual> GetRecentContent(int count = 10)
        {
            return _content.OrderByDescending(c => c.Id).Take(count).ToList();
        }
    }
}