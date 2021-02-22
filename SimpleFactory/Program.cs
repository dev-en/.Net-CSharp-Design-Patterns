using System;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter product type");
                string productType = Console.ReadLine();
                IProduct product = SimpleProductFactory.GetProduct(productType);

                if (product != null)
                {
                    Console.WriteLine("ProductType : " + product.ToString());
                }
                else
                {
                    Console.WriteLine("Invalid Product Type");
                }
            }
        }
    }
}
