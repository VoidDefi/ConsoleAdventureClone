using ConsoleAdventure.Systems.WorldEngine.Chunks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventure.Systems.WorldEngine
{
    public class World
    {
        public Chunk[,] Chunks { get; private set; }

        public int Size { get; private set; }

        public int Depth { get; private set; } = 1;

        public int Seed { get; private set; }

        public string Name { get; private set; }

        public World(int size, int seed, string name) 
        {
            if (size < 16) throw new ArgumentException("size value cannot be less than 16", nameof(size));

            Size = size / Chunk.Size * Chunk.Size;
            Seed = seed;
            Name = name;

            Chunks = new Chunk[Size, Size];
        }

        public Transform? GetTransform(int x, int y, int layer, int w)
        {
            int chunkX = x / Chunk.Size;
            int chunkY = y / Chunk.Size;

            int chunksSizeX = Chunks.GetLength(0);
            int chunksSizeY = Chunks.GetLength(1);

            if (chunkX < 0 || chunkY < 0 || chunkX >= chunksSizeX || chunkY >= chunksSizeY)
                return null;

            Chunk chunk = Chunks[chunkX, chunkY];

            if (chunk != null)
            {
                if (chunk is LoadedChunk)
                {
                    LoadedChunk loadedChunk = chunk as LoadedChunk;

                    return loadedChunk.GetTransform(x % Chunk.Size, y % Chunk.Size, layer, w);
                }
            }

            return null;
        }
    }
}
