using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.Systems.WorldEngine
{
    public struct Transform
    { 
        public short type = -1;
        public bool hasObject = false;

        public Transform(short type) 
        { 
            this.type = type;
            hasObject = type >= 0;
        }
    }
}
