using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.ModLoaderAPI
{
    public abstract class Mod : IMod
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Version { get; set; }

        public string Author { get; set; }

        public Assembly Assembly { get; internal set; }

        public void Load()
        {

        }
    }
}
