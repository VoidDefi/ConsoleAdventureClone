using ConsoleAdventure.Graphics;
using ConsoleAdventure.Systems.WorldEngine;
using ConsoleAdventure.Systems.WorldEngine.Objects;
using Microsoft.Xna.Framework;

namespace ConsoleAdventure.GameContent.Transforms
{
    public class Wall : BaseTransform
    {
        public override void Initialize()
        {
            IsObstacle = true;
        }

        public override Symbol GetSymbol(Position position, int w) => new Symbol("##");

        public override Color GetColor(Position position, int w) => Color.White;
    }
}
