using RealTimeFactoryMethod;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealTimeSimpleFactory
{
    internal class ObstacleFactoryMethod
    {
        public static ObstacleCreator GetObstacleCreator(int obstacleType)
        {
            ObstacleCreator obstacleCreator = null;
            if (obstacleType == 1)
            {
                obstacleCreator = new WallObstacleCreator();
            }
            else if (obstacleType == 2)
            {
                obstacleCreator = new TreeObstacleCreator();
            }
            else if (obstacleType == 3)
            {
                obstacleCreator = new BushObstacleCreator();
            }
            else if (obstacleType == 4)
            {
                obstacleCreator = new RiverObstacleCreator();
            }
            return obstacleCreator;
        }
    }
}
