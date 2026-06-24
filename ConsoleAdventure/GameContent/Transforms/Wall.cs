using ConsoleAdventure.Graphics;
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

        public override Symbol Symbol => new Symbol("##");

        public override Color Color => Color.White;
    }
}
