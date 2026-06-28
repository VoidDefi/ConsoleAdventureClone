using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace ConsoleAdventure.ModLoaderAPI
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ContentLoaderAttribute : Attribute
    {

    }
}
