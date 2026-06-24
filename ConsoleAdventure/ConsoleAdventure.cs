using ConsoleAdventure.ModLoaderAPI;
using ConsoleAdventure.Systems.WorldEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ConsoleAdventure
{
    public class ConsoleAdventure : Game
    {
        public static GraphicsDeviceManager Graphics { get; private set; }

        public static SpriteBatch SpriteBatch { get; private set; }

        public static Point ScreenSize => new Point(1602, 912);

        public static float Width => Graphics.PreferredBackBufferWidth;

        public static float Height => Graphics.PreferredBackBufferHeight;

        public static SpriteFont Font { get; private set; }

        public static World World { get; private set; }

        public ConsoleAdventure()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            IsFixedTimeStep = true;

            Window.Title = $"Console Adventure Clone 0.1v. By Defi's";

            Graphics.SynchronizeWithVerticalRetrace = false;
            Graphics.PreferredBackBufferWidth = ScreenSize.X;
            Graphics.PreferredBackBufferHeight = ScreenSize.Y;
            Graphics.ApplyChanges();
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            ModLoader.LoadMods();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            Font = Content.Load<SpriteFont>("Fonts/MainFont");
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
