using ConsoleAdventure.Graphics;
using ConsoleAdventure.ModLoaderAPI;
using ConsoleAdventure.Systems.WorldEngine;
using ConsoleAdventure.Systems.WorldEngine.Chunks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Windows.Forms;

namespace ConsoleAdventure
{
    public class ConsoleAdventure : Game
    {
        public static GraphicsDeviceManager Graphics { get; private set; }

        public static SpriteBatch SpriteBatch { get; private set; }

        private static Point BaseScreenSize => new Point(1602, 912);

        public static Point ScreenSize => new Point(ScreenWidth, ScreenHeight);

        public static int ScreenWidth => Graphics.PreferredBackBufferWidth;

        public static int ScreenHeight => Graphics.PreferredBackBufferHeight;

        public static SpriteFont Font { get; private set; }

        public static World World { get; private set; }

        public static int FPS { get; private set; }

        private static int frameCount;

        private static TimeSpan elapsedTime;

        public ConsoleAdventure()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            IsFixedTimeStep = true;

            Window.Title = $"Console Adventure Clone 0.1v. By Defi's";

            Graphics.SynchronizeWithVerticalRetrace = false;
            Graphics.PreferredBackBufferWidth = BaseScreenSize.X;
            Graphics.PreferredBackBufferHeight = BaseScreenSize.Y;
            Graphics.ApplyChanges();
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            ModLoader.LoadMods();

            World = new World(160, 0, "World");
            ChunkManager.Load(0, 0);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            Font = Content.Load<SpriteFont>("Fonts/MainFont");
        }

        protected override void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                FPS = frameCount;
                frameCount = 0;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            frameCount++;

            WorldRenderer.Draw();

            SpriteBatch.Begin();

            string fps = $"FPS: {FPS}";
            Vector2 fpsPosition = new Vector2(5, ScreenHeight - 18);

            SpriteBatch.DrawString(Font, new string('█', fps.Length), fpsPosition, Color.Black);
            SpriteBatch.DrawString(Font, fps, fpsPosition, Color.White);

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
