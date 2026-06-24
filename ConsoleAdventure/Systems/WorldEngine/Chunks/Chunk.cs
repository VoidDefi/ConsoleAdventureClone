using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAdventure.Systems.WorldEngine.Chunks;

namespace ConsoleAdventure.Systems.WorldEngine
{
    public abstract class Chunk
    {
        public static int Size => 16;

        public static int Deep => ConsoleAdventure.World.Depth;

        public bool InProcess { get; internal set; }
    }
}
