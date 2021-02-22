using RealTimeSimpleFactory;
using System;
using System.Threading;

namespace RealTimeFactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Thread.Sleep(500);
                Random random = new Random();
                int randomInt = random.Next(1, 5);
                ObstacleCreator obstacle = ObstacleFactoryMethod.GetObstacleCreator(randomInt);
                if (obstacle != null)
                {
                    Console.WriteLine("ObstacleType : " + obstacle.ToString());
                    obstacle.Create();
                }
                else
                {
                    Console.WriteLine("Invalid Obstacle Type");
                }
            }
        }
    }
}
