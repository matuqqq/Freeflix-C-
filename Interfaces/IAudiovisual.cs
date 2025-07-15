using System.Collections.Generic;
using Freeflix.Models;

namespace Freeflix.Interfaces
{
    public interface IAudiovisual
    {
        string Id { get; }
        string Title { get; set; }
        string Genre { get; set; }
        string Description { get; set; }
        string ShortDescription { get; set; }
        string ImageUrl { get; set; }
        string VideoUrl { get; set; }
        ContentType Type { get; }
        double Rating { get; }
        List<Rating> Ratings { get; }
        
        void UpdateRating();
        double GetAverageRating();
        bool IsValidForDisplay();
    }
}