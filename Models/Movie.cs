using System;

namespace Freeflix.Models
{
    public class Movie : BaseAudiovisual
    {
        private int _duration;
        private string _director;
        private DateTime _releaseDate;

        public int Duration 
        { 
            get => _duration;
            set => _duration = value > 0 ? value : throw new ArgumentException("La duración debe ser mayor a 0");
        }

        public string Director
        {
            get => _director;
            set => _director = value ?? throw new ArgumentNullException(nameof(value));
        }

        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set => _releaseDate = value;
        }

        public Movie(string title, string genre, string description, int duration, string director, DateTime releaseDate)
            : base(title, genre, description, ContentType.Movie)
        {
            Duration = duration;
            Director = director;
            ReleaseDate = releaseDate;
        }

        public string GetDurationFormatted()
        {
            int hours = _duration / 60;
            int minutes = _duration % 60;
            return hours > 0 ? $"{hours}h {minutes}m" : $"{minutes}m";
        }

        public override bool IsValidForDisplay()
        {
            return base.IsValidForDisplay() && _duration > 0 && !string.IsNullOrWhiteSpace(_director);
        }
    }
}