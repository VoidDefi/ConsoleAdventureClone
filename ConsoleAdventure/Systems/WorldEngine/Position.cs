using Microsoft.Xna.Framework;
using System;
using System.CodeDom;

namespace ConsoleAdventure.Systems.WorldEngine
{
    public struct Position
    {
        public short X { get; set; }

        public short Y { get; set; }

        public Position(int x, int y)
        {
            X = (short)x;
            Y = (short)y;
        }

        public Position()
        {
            X = 0;
            Y = 0;
        }

        public static Position Zero => new Position(0, 0);

        public Vector2 ToVector2()
        {
            return new(X, Y);
        }

        public Point ToPoint()
        {
            return new(X, Y);
        }

        public override bool Equals(object obj)
        {
            if (obj is Position)
                return this == (Position)obj;

            return false;
        }

        #region Operators

        public static Position operator +(Position left, Position right)
        {
            return new(left.X + right.X, left.Y + right.Y);
        }

        public static Position operator -(Position left, Position right)
        {
            return new(left.X - right.X, left.Y - right.Y);
        }

        public static Position operator *(Position left, Position right)
        {
            return new(left.X * right.X, left.Y * right.Y);
        }

        public static Position operator /(Position left, Position right)
        {
            return new(left.X / right.X, left.Y / right.Y);
        }

        public static Position operator *(Position left, int right)
        {
            return new(left.X * right, left.Y * right);
        }

        public static Position operator /(Position left, int right)
        {
            return new(left.X / right, left.Y / right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return left.X != right.X || left.Y != right.Y;
        }

        public static bool operator ==(Position left, Position right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        public static bool operator >(Position left, Position right)
        {
            return left.X > right.X && left.Y > right.Y;
        }

        public static bool operator <(Position left, Position right)
        {
            return left.X < right.X && left.Y < right.Y;
        }

        public static bool operator >=(Position left, Position right)
        {
            return left.X >= right.X && left.Y >= right.Y;
        }

        public static bool operator <=(Position left, Position right)
        {
            return left.X <= right.X && left.Y <= right.Y;
        }

        #endregion
    }
}