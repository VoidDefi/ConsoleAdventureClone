using ConsoleAdventure.ModLoaderAPI.Loaders;
using ConsoleAdventure.Systems.WorldEngine;
using ConsoleAdventure.Systems.WorldEngine.Chunks;
using ConsoleAdventure.Systems.WorldEngine.Objects;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace ConsoleAdventure.Graphics
{
    public static class WorldRenderer
    {
        private static Point symbolSize = new Point(18, 19);

        internal static Stopwatch RenderStopwatch;

        public static void Draw()
        {
            World world = ConsoleAdventure.World;

            if (world == null) return;

            Point screenSize = ConsoleAdventure.ScreenSize;

            int width = screenSize.X / symbolSize.X;
            int height = screenSize.Y / symbolSize.Y;

            int offsetX = (int)((screenSize.X - width * symbolSize.X) / 2f);
            int offsetY = (int)((screenSize.Y - height * symbolSize.Y) / 2f);

            Position startPosition = Position.Zero;
            int w = 0;

            RenderStopwatch = new Stopwatch();
            RenderStopwatch.Start();

            ConsoleAdventure.SpriteBatch.Begin();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Position position = startPosition + new Position(i, j);

                    if (position.X < 0 || position.X > world.Size) continue;
                    if (position.Y < 0 || position.Y > world.Size) continue;

                    Chunk chunk = world.Chunks[position.X / Chunk.Size, position.Y / Chunk.Size];

                    Vector2 drawPosition = new Vector2(i * symbolSize.X + offsetX, j * symbolSize.Y + offsetY);

                    if (chunk is LoadedChunk)
                    {
                        Transform? transform = world.GetTransform(position.X, position.Y, 0, w);

                        if (transform?.hasObject == true)
                        {
                            BaseTransform baseTransform = TransformLoader.GetTransform(transform.Value.type);

                            Symbol symbol = baseTransform.GetSymbol(position, w);
                            Color color = baseTransform.GetColor(position, w);
                            Color? bgColor = baseTransform.GetBackgroundColor(position, w);

                            if (bgColor.HasValue)
                            {
                                ConsoleAdventure.SpriteBatch.DrawString(ConsoleAdventure.Font, "██", drawPosition, bgColor.Value);
                            }

                            ConsoleAdventure.SpriteBatch.DrawString(ConsoleAdventure.Font, symbol.Value, drawPosition, color);
                        }
                    }

                    else
                    {
                        ConsoleAdventure.SpriteBatch.DrawString(ConsoleAdventure.Font, " ?", drawPosition, Color.Gray);
                    }
                }
            }

            ConsoleAdventure.SpriteBatch.End();

            RenderStopwatch.Stop();
        }
    }
}
