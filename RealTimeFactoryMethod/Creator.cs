using System;
using System.Collections.Generic;
using System.Text;

namespace RealTimeFactoryMethod
{
    public abstract class ObstacleCreator
    {
        public abstract Obstacle Create();
    }

    public class TreeObstacleCreator : ObstacleCreator
    {
        public override Obstacle Create()
        {
            Console.WriteLine("This is tree");
            Tree tree = new Tree();
            tree.SetHeight(1, 100);
            tree.SetLength(1, 5);
            tree.SetWidth(1, 10);
            tree.SetLeaves(1, 1000);
            return tree;
        }
    }
    public class BushObstacleCreator : ObstacleCreator
    {
        public override Obstacle Create()
        {
            Console.WriteLine("This is bush");
            Bush bush = new Bush();
            bush.SetHeight(1, 30);
            bush.SetLength(1, 5);
            bush.SetWidth(1, 10);
            bush.SetLeaves(1, 500);
            return bush;
        }
    }
    public class WallObstacleCreator : ObstacleCreator
    {
        public override Obstacle Create()
        {
            Console.WriteLine("This is wall");
            Wall wall = new Wall();
            wall.SetHeight(1, 50);
            wall.SetLength(1, 500);
            wall.SetWidth(1, 130);
            return wall;
        }
    }
    public class RiverObstacleCreator : ObstacleCreator
    {
        public override Obstacle Create()
        {
            Console.WriteLine("This is river");
            River river = new River();
            river.SetHeight(0, 0);
            river.SetDepth(1, 50);
            river.SetLength(1, 5000);
            river.SetWidth(1, 130);
            river.SetSpeed(1, 50);
            return river;
        }
    }
}
