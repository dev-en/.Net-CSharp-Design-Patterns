using System;

namespace ChainOfResponsibility.Concept
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup Chain of Responsibility
            Manager m1 = new ManagerA();
            Manager m2 = new ManagerB();
            Manager m3 = new ManagerC();
            m1.SetManager(m2);
            m2.SetManager(m3);

            // Generate and process request
            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };

            foreach (int request in requests)
            {
                m1.ManageRequest(request);
            }

            // Wait for user
            Console.ReadKey();
        }
    }
}
