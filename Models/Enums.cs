namespace Freeflix.Models
{
    /// <summary>
    /// Enumeraciones del sistema
    /// </summary>
    public enum UserRole
    {
        User,
        Moderator
    }

    public enum ContentType
    {
        Movie,
        Series
    }

    public enum VideoQuality
    {
        SD,
        HD,
        FullHD,
        UltraHD
    }
}