using System;
using System.Collections.Generic;
using System.Text;

namespace RealTimeSimpleFactory
{
    internal class ObstacleSimpleFactory
    {
        public static Obstacle GetObstacle(int obstacleType)
        {
            Obstacle obstacle = null;
            if (obstacleType == 1)
            {
                //obstacle.SetHeight(1, 50);
                //obstacle.SetLength(1, 500);
                //obstacle.SetWidth(1, 35);
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
