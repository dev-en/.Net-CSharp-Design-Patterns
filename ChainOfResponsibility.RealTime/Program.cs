using System;

namespace ChainOfResponsibility.RealTime
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup Chain of Responsibility
            VehicleManager m1 = new TwoWheelerManager();
            VehicleManager m2 = new ThreeWheelerManager();
            VehicleManager m3 = new FourWheelerManager();
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
