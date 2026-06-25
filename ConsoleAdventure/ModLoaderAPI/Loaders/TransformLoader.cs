using ConsoleAdventure.Systems.WorldEngine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.ModLoaderAPI.Loaders
{
    [ContentLoader]
    public static class TransformLoader
    {
        private static List<BaseTransform> transforms = new List<BaseTransform>();

        private static int next = 0;

        public static int Count => transforms.Count;

        public static void LoadContent(Mod mod)
        {
            Assembly assembly = mod.Assembly;
            Type baseTransform = typeof(BaseTransform);

            List<Type> types = assembly.GetTypes().Where(t => t.IsSubclassOf(baseTransform)).ToList();

            foreach (Type type in types)
            {
                if (type.IsAbstract) continue;

                BaseTransform transform = Activator.CreateInstance(type) as BaseTransform;

                transform.SetType(next);
                next++;

                transform.Initialize();

                transforms.Add(transform);
            }
        }

        public static BaseTransform GetTransform(int type)
        {
            if (type < 0 || type >= Count) return null;

            return transforms[type];
        }
    }
}
