using System;
using System.Collections.Generic;
using Freeflix.Models;

namespace Freeflix.Interfaces
{
    /// <summary>
    /// Interfaz para gestión de contenido
    /// Aplica el principio de Abstracción y Segregación de Interfaces
    /// </summary>
    public interface IContentManager
    {
        bool AddContent(BaseAudiovisual content);
        bool UpdateContent(string id, BaseAudiovisual updatedContent);
        bool DeleteContent(string id);
        List<BaseAudiovisual> SearchContent(string query, string genre = null);
        List<BaseAudiovisual> GetAllContent();
        BaseAudiovisual GetContentById(string id);
    }
}