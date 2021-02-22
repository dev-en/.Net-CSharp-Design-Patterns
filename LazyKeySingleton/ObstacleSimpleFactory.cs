using RealTimeFactoryMethod;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealTimeSimpleFactory
{
    internal class RealTimeFactoryMethod
    {
        public static IObstacle GetObstacle(int obstacleType)
        {
            IObstacle obstacle = null;
            if (obstacleType == 1)
            {
                obstacle = new Wall();
            }
            else if (obstacleType == 2)
            {
                obstacle = new Tree();
            }
            else if (obstacleType == 3)
            {
                obstacle = new Bush();
            }
            else if (obstacleType == 4)
            {
                obstacle = new River();
            }
            return obstacle;
        }
    }
}
