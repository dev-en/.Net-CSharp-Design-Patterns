using System;
using System.Collections.Generic;
using System.Text;

namespace RealTimeFactoryMethod
{
    public abstract class Obstacle
    {
        protected Random random = new Random();
        public virtual void SetWidth(int min, int max)
        {
            int width = random.Next(min, max);
            Console.WriteLine($"width is {width}");
        }
        public virtual void SetHeight(int min, int max)
        {
            int height = random.Next(min, max);
            Console.WriteLine($"height is {height}");
        }
        public virtual void SetLength(int min, int max)
        {
            int length = random.Next(min, max);
            Console.WriteLine($"length is {length}");
        }
    }
    /// <summary>
    /// A 'Concrete Obstacle' class
    /// </summary>
    class Wall : Obstacle
    {
    }

    /// <summary>
    /// A 'Concrete Obstacle' class
    /// </summary>
    class Tree : Obstacle
    {
        public virtual void SetLeaves(int min, int max)
        {
            int count = random.Next(min, max);
            Console.WriteLine($"tree leaves are {count}");
        }
    }

    /// <summary>
    /// A 'Concrete Obstacle' class
    /// </summary>
    class Bush : Obstacle
    {
        public virtual void SetLeaves(int min, int max)
        {
            int count = random.Next(min, max);
            Console.WriteLine($"bush leaves are {count}");
        }
    }

    /// <summary>
    /// A 'Concrete Obstacle' class
    /// </summary>
    class River : Obstacle
    {
        public virtual void SetSpeed(int min, int max)
        {
            int speed = random.Next(min, max);
            Console.WriteLine($"river speed is {speed}");
        }

        public virtual void SetDepth(int min, int max)
        {
            int depth = random.Next(min, max);
            Console.WriteLine($"river depth is {depth}");
        }
    }
}
