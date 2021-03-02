using System;

namespace Adapter.RealTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog superDog = new FlyingDog();
            superDog.Run("SuperDog");

            Console.ReadKey();
        }
    }

    public interface IFlyObject
    {
        void fly(string name);
    }

    public class Bird : IFlyObject
    {
        public virtual void fly(string name)
        {
            Console.WriteLine($"{name}, can fly");
        }
    }

    public interface IRunObject
    {
        void Run(string name);
    }
    public class Dog : IRunObject
    {
        public virtual void Run(string name)
        {
            Console.WriteLine($"{name}, can run");
        }
    }

    public class FlyingDog : Dog
    {
        private Bird _bird = new Bird();
        public override void Run(string name)
        {
            _bird.fly(name);
            base.Run(name);
        }
    }
}
