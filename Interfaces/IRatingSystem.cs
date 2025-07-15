using System;
using System.Collections.Generic;
using Freeflix.Models;

namespace Freeflix.Interfaces
{
    /// <summary>
    /// Interfaz para sistema de valoraciones
    /// Aplica el principio de Abstracción
    /// </summary>
    public interface IRatingSystem
    {
        bool AddRating(Rating rating);
        double CalculateAverage(string audiovisualId);
        Rating GetUserRating(string userId, string audiovisualId);
        List<Rating> GetRatingsForContent(string audiovisualId);
        bool UpdateRating(string userId, string audiovisualId, int newValue);
    }
}