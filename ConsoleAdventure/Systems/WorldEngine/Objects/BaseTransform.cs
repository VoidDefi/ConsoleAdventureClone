using ConsoleAdventure.Graphics;
using Microsoft.Xna.Framework;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.Systems.WorldEngine.Objects
{
    public class BaseTransform
    {
        public int Type { get; private set; } = -1;

        public bool IsObstacle { get; set; }

        public virtual Symbol Symbol => new Symbol(" ?");

        public virtual Color Color => Color.White;

        public virtual Color? BackgroundColor => Color.White;

        public virtual void Initialize()
        {

        }

        public void SetType(int type)
        {
            if (Type < 0) Type = type;
        }
    }
}
