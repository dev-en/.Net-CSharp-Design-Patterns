using System;

namespace ChainOfResponsibility.Concept
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler<string> h1 = new HandlerA<string>();
            Handler<string> h2 = new HandlerB<string>();
            Handler<string> h3 = new HandlerC<string>();
            h1.SetHandler(h2);
            h2.SetHandler(h3);

            string str = "ChainOfResponsinility";
            h1.HandleRequest(str);

            Console.ReadKey();
        }
    }
}
