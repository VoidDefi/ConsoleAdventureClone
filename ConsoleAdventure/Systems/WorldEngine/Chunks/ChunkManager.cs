using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.Systems.WorldEngine.Chunks
{
    public static class ChunkManager
    {
        public static LoadInfo Load(int x, int y)
        {
            World world = ConsoleAdventure.World;

            if (world == null || world?.Chunks == null) 
                return LoadInfo.Nonexistent;

            int width = world.Chunks.GetLength(0);
            int height = world.Chunks.GetLength(1);

            if (x >= 0 && x < width && y > 0 && y < height)
            {
                LoadedChunk chunk = new LoadedChunk();
                world.Chunks[x, y] = chunk;

                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        Transform transform = new Transform();
                        chunk.SetTransform(i, j, 0, 0, transform);
                    }
                }

                return LoadInfo.Generated;
            }

            return LoadInfo.Nonexistent;
        }
    }

    public enum LoadInfo
    {
        Generated,
        Loaded,
        Nonexistent
    }
}
