using System;

namespace Freeflix.Models
{
    public class Series : BaseAudiovisual
    {
        private int _episodes;
        private int _seasons;
        private int _episodeDuration;
        private bool _isCompleted;

        public int Episodes
        {
            get => _episodes;
            set => _episodes = value > 0 ? value : throw new ArgumentException("El número de episodios debe ser mayor a 0");
        }

        public int Seasons
        {
            get => _seasons;
            set => _seasons = value > 0 ? value : throw new ArgumentException("El número de temporadas debe ser mayor a 0");
        }

        public int EpisodeDuration
        {
            get => _episodeDuration;
            set => _episodeDuration = value > 0 ? value : throw new ArgumentException("La duración del episodio debe ser mayor a 0");
        }

        public bool IsCompleted
        {
            get => _isCompleted;
            set => _isCompleted = value;
        }

        public Series(string title, string genre, string description, int episodes, int seasons, int episodeDuration)
            : base(title, genre, description, ContentType.Series)
        {
            Episodes = episodes;
            Seasons = seasons;
            EpisodeDuration = episodeDuration;
            _isCompleted = false;
        }

        public override bool IsValidForDisplay()
        {
            return base.IsValidForDisplay() && _episodes > 0 && _seasons > 0 && _episodeDuration > 0;
        }

        public int GetTotalDuration()
        {
            return _episodes * _episodeDuration;
        }

        public string GetTotalDurationFormatted()
        {
            int totalMinutes = GetTotalDuration();
            int hours = totalMinutes / 60;
            int minutes = totalMinutes % 60;
            return hours > 0 ? $"{hours}h {minutes}m total" : $"{minutes}m total";
        }
    }
}