using ConsoleAdventure.ModLoaderAPI.Exceptions;
using ConsoleAdventure.ModLoaderAPI.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConsoleAdventure.ModLoaderAPI
{
    public static class ModLoader
    {
        public static void LoadMods()
        {
            ConsoleAdventureMod baseMod = new ConsoleAdventureMod();
            baseMod.Assembly = Assembly.GetAssembly(typeof(ConsoleAdventureMod));

            Type loaderAttribute = typeof(ContentLoaderAttribute);

            List<Type> types = baseMod.Assembly.GetTypes().Where(t => t.IsDefined(loaderAttribute)).ToList();

            foreach (Type type in types)
            {
                //Is Static
                if (type.IsAbstract && type.IsSealed)
                {
                    BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

                    MethodInfo loadMethod = type.GetMethod("LoadContent", bindingFlags, [typeof(Mod)]);

                    if (loadMethod == null )
                        throw new LoaderSignatureException($"Content loader \"{nameof(type)}\" mast contain \"void LoadContent({typeof(Mod).FullName} mod)\" method.");

                    loadMethod.Invoke(null, [baseMod]);
                }

                else
                {
                    throw new LoaderSignatureException($"Content loader \"{nameof(type)}\" mast be static.");
                }
            }
        }
    }
}
