using System;

namespace ChainOfResponsibility.Concept
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup Chain of Responsibility
            Handler m1 = new HandlerA();
            Handler m2 = new HandlerB();
            Handler m3 = new HandlerC();
            m1.SetHandler(m2);
            m2.SetHandler(m3);

            // Generate and process request
            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };

            foreach (int request in requests)
            {
                m1.HandleRequest(request);
            }

            // Wait for user
            Console.ReadKey();
        }
    }
}
