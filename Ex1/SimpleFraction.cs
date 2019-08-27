using System;
using System.Security.Cryptography.X509Certificates;

namespace Homework
{
    public struct SimpleFraction : IComparable
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public SimpleFraction(int x, int y)
        {
            X = x;
            Y = y;
            MakeSimple();
        }

        private void MakeSimple()
        {
            var min = Math.Min(X, Y);
            if (min == 0)
            {
                Y = 1;
                return;
            }

            for (int i = min; i > 1; i--)
            {
                if (X % i == 0 && Y % i == 0)
                {
                    X /= i;
                    Y /= i;
                }

                if (X == 1 || Y == 1)
                {
                    break;
                }
            }
        }

        public static SimpleFraction operator +(SimpleFraction a, SimpleFraction b)
        {
            var x = a.X * b.Y + b.X * a.Y;
            var y = a.Y * b.Y;
            return new SimpleFraction(x, y);
        }

        public static SimpleFraction operator -(SimpleFraction a, SimpleFraction b)
        {
            var x = a.X * b.Y - b.X * a.Y;
            var y = a.Y * b.Y;
            return new SimpleFraction(x, y);
        }

        public static SimpleFraction operator *(SimpleFraction a, SimpleFraction b)
        {
            var x = a.X * b.X;
            var y = a.Y * b.Y;
            return new SimpleFraction(x, y);
        }

        public static SimpleFraction operator /(SimpleFraction a, SimpleFraction b)
        {
            var x = a.X * b.Y;
            var y = a.Y * b.X;
            return new SimpleFraction(x, y);
        }


        public override string ToString()
        {
            return X == 0 ? $"{X}" : $"{X}/{Y}";
        }

        public int CompareTo(object obj)
        {
            var fraction = (SimpleFraction)obj;
            if (X * fraction.Y > fraction.X * Y)
                return 1;
            if (X * fraction.Y < fraction.X * Y)
                return -1;

            return 0;
        }
    }
}