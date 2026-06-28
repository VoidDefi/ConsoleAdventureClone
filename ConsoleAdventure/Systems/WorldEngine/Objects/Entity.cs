using ConsoleAdventure.Graphics;
using ConsoleAdventure.ModLoaderAPI.Loaders;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.Systems.WorldEngine.Objects
{
    public abstract class Entity
    {
        protected static World World => ConsoleAdventure.World;

        public Position position = Position.Zero;

        private int w;

        public int W 
        { 
            get => w; 
            set => w = Math.Clamp(w, 0, Chunk.Deep); 
        }

        public virtual Symbol GetSymbol => new Symbol(" ¿");

        public virtual Color GetColor => Color.Yellow;

        public virtual Color? GetBackgroundColor => null;

        public virtual void Update()
        {

        }

        public bool TrySetPosition(Position position, int w) 
        {
            Transform? block = World.GetTransform(position.X, position.Y, 0, w);

            if (block?.hasObject == false)
            {
                if (TransformLoader.GetTransform(block.Value.type).IsObstacle)
                {
                    this.position = position;
                    W = w;

                    return true;
                }
            }

            return false;
        }
    }
}
