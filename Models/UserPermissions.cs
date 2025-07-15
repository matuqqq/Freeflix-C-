using System;

namespace Freeflix.Models
{
    [Flags]
    public enum UserPermissions
    {
        None = 0,
        ViewContent = 1,
        ModerateContent = 2,
        All = ViewContent | ModerateContent
    }
}