using System;
using System.Collections.Generic;
using System.Linq;
using Freeflix.Interfaces;

namespace Freeflix.Models
{
    public abstract class BaseAudiovisual : IAudiovisual
    {
        private string _id;
        private string _title;
        private string _genre;
        private string _description;
        private string _shortDescription;
        private string _imageUrl;
        private string _videoUrl;
        private readonly ContentType _type;
        private double _rating;
        private readonly List<Rating> _ratings;

        public string Id => _id;
        public string Title 
        { 
            get => _title;
            set => _title = value ?? throw new ArgumentNullException(nameof(value));
        }
        public string Genre
        {
            get => _genre;
            set => _genre = value ?? throw new ArgumentNullException(nameof(value));
        }
        public string Description
        {
            get => _description;
            set => _description = value ?? throw new ArgumentNullException(nameof(value));
        }
        public string ShortDescription
        {
            get => _shortDescription;
            set => _shortDescription = value ?? throw new ArgumentNullException(nameof(value));
        }
        public string ImageUrl
        {
            get => _imageUrl;
            set => _imageUrl = value;
        }
        public string VideoUrl
        {
            get => _videoUrl;
            set => _videoUrl = value;
        }
        public ContentType Type => _type;
        public double Rating => _rating;
        public List<Rating> Ratings => new List<Rating>(_ratings);

        protected BaseAudiovisual(string title, string genre, string description, ContentType type)
        {
            _id = Guid.NewGuid().ToString();
            Title = title;
            Genre = genre;
            Description = description;
            ShortDescription = description.Length > 100 ? description.Substring(0, 97) + "..." : description;
            _type = type;
            _ratings = new List<Rating>();
            _rating = 0.0;
        }

        public void UpdateRating()
        {
            if (!_ratings.Any())
            {
                _rating = 0.0;
                return;
            }
            _rating = GetAverageRating();
        }

        public double GetAverageRating()
        {
            return _ratings.Any() ? _ratings.Average(r => r.Value) : 0.0;
        }

        public virtual bool IsValidForDisplay()
        {
            return !string.IsNullOrWhiteSpace(_title) && 
                   !string.IsNullOrWhiteSpace(_genre) && 
                   !string.IsNullOrWhiteSpace(_description);
        }

        public void AddRating(Rating rating)
        {
            if (rating == null)
                throw new ArgumentNullException(nameof(rating));

            var existingRating = _ratings.FirstOrDefault(r => r.UserId == rating.UserId);
            if (existingRating != null)
            {
                _ratings.Remove(existingRating);
            }

            _ratings.Add(rating);
            UpdateRating();
        }
    }
}