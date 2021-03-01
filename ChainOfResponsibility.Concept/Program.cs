using System;

namespace ChainOfResponsibility.Concept
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup Chain of Responsibility
            Handler<string> m1 = new HandlerA<string>();
            Handler<string> m2 = new HandlerB<string>();
            Handler<string> m3 = new HandlerC<string>();
            m1.SetHandler(m2);
            m2.SetHandler(m3);

            string str = "ChainOfResponsinility";
            m1.HandleRequest(str);

            // Wait for user
            Console.ReadKey();
        }
    }
}
