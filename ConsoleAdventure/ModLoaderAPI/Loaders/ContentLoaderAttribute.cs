using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace ConsoleAdventure.ModLoaderAPI.Loaders
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ContentLoaderAttribute : Attribute
    {
        
    }
}
