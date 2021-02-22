using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory
{
    internal class SimpleProductFactory
    {
        public static IProduct GetProduct(string productType)
        {
            IProduct product = null;
            if (productType == "A")
            {
                product = new ProductA();
            }
            else if (productType == "B")
            {
                product = new ProductB();
            }
            else if (productType == "C")
            {
                product = new ProductC();
            }
            return product;
        }
    }
}
