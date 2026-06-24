using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.ModLoaderAPI
{
    public interface IMod
    {
        public abstract string Name { get; set; }

        public abstract string Description { get; set; }

        public abstract string Version { get; set; }

        public abstract string Author { get; set; }
    }
}
