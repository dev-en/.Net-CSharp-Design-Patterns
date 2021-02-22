using System;
using System.Threading;

namespace RealTimeSimpleFactory
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
                Obstacle obstacle = ObstacleSimpleFactory.GetObstacle(randomInt);
                if (obstacle != null)
                {
                    Console.WriteLine("ObstacleType : " + obstacle.ToString());
                    randomInt = random.Next(1, 50);
                    //few problems with simple factory
                    //any new introduction of property specific to the entity can not be invoked here

                    //We can't control the values passed here to specific class
                    //for that we may have to introduce several if else

                    //
                    //we can do the above thing in factory class 
                    //but it would defeat the purpose of SRP
                    //
                    obstacle.SetHeight(1, randomInt);
                    obstacle.SetLength(1, randomInt);
                    obstacle.SetWidth(1, randomInt);
                }
                else
                {
                    Console.WriteLine("Invalid Obstacle Type");
                }
            }
        }
    }
}
