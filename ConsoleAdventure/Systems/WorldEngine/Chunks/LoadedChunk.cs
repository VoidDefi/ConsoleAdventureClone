using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.Systems.WorldEngine.Chunks
{
    public class LoadedChunk : Chunk
    {
        public Transform[,,,] Transforms { get; private set; }

        public bool IsUpdated { get; private set; }

        public LoadedChunk()
        {
            Transforms = new Transform[Size, Size, 1, Deep];
        }

        public Transform? GetTransform(int x, int y, int layer, int w)
        {
            if (IsValidPosition(x, y, layer, w))
                return Transforms[x, y, layer, w];

            return null;
        }

        public void SetTransform(int x, int y, int layer, int w, Transform transform)
        {
            if (IsValidPosition(x, y, layer, w))
                Transforms[x, y, layer, w] = transform;
        }

        private bool IsValidPosition(int x, int y, int layer, int w)
        {
            return x >= 0 && x < Size && 
                   y >= 0 && y < Size && 
                   w >= 0 && w < Deep;
        }
    }
}
