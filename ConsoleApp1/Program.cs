using FactoryMethod;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter creator type");
                string productType = Console.ReadLine();
                ICreator creator = FactoryMethod.FactoryMethod.GetCreator(productType);
                if (creator != null)
                {
                    Console.WriteLine("CreatorType : " + creator.ToString());
                    IProduct product = creator.FactoryMethod();
                    Console.WriteLine("ProductType : " + product.ToString());
                }
                else
                {
                    Console.WriteLine("Invalid Obstacle Type");
                }
            }
        }
    }
}
