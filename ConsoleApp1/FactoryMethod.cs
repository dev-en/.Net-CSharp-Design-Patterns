using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    internal class FactoryMethod
    {
        public static ICreator GetCreator(string creatorType)
        {
            ICreator creator = null;
            if (creatorType == "A")
            {
                creator = new CreatorA();
            }
            else if (creatorType == "B")
            {
                creator = new CreatorB();
            }
            return creator;
        }
    }
}
