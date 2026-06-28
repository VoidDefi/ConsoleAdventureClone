using ConsoleAdventure.Graphics;
using ConsoleAdventure.Systems.InputLogic;
using ConsoleAdventure.Systems.WorldEngine;
using ConsoleAdventure.Systems.WorldEngine.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ConsoleAdventure.Systems.PlayerSystem
{
    public sealed class Player : Entity
    {
        public override Symbol GetSymbol => new Symbol(" ^");

        public override Color GetColor => Color.Yellow;

        public int walkSpeed = 3;

        private int walkTimer = 0;

        public override void Update()
        {
            if (walkTimer > walkSpeed)
            {
                Movement();
                walkTimer = 0;
            }

            walkTimer++;
        }

        private void Movement()
        {
            short xDirection = 0;
            short yDirection = 0;

            if (Input.IsKeyDown(Keys.D)) xDirection = 1;
            else if (Input.IsKeyDown(Keys.A)) xDirection = -1;

            if (Input.IsKeyDown(Keys.S)) yDirection = 1;
            else if (Input.IsKeyDown(Keys.W)) yDirection = -1;

            Position newPosition = position;

            newPosition.X += xDirection;
            newPosition.Y += yDirection;

            if (newPosition != position)
                TrySetPosition(newPosition, W);
        }
    }
}
