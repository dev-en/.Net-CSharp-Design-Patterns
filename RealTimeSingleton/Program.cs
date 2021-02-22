using System;
using System.Threading;
using System.Threading.Tasks;

namespace RealTimeSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //First call for both tenant db
            Console.WriteLine("First request started");
            Parallel.Invoke(
                () => CallFirstTenantDb(),
                () => CallSecondTenantDb()
                );
            Console.WriteLine("First request completed");
            Console.ReadLine();

            //Subseaquent call for both tenant db
            Console.WriteLine("Second request started");
            Parallel.Invoke(
                () => CallFirstTenantDb(),
                () => CallSecondTenantDb()
                );
            Console.WriteLine("Second request completed");
            Console.ReadLine();

        }
        private static void CallFirstTenantDb()
        {            
            Singleton firstCaller = Singleton.GetInstance;
            firstCaller.GetConnection("A");
            Console.WriteLine("Got tenant A connection");
        }
        private static void CallSecondTenantDb()
        {
            Singleton secondCaller = Singleton.GetInstance;
            secondCaller.GetConnection("B");
            Console.WriteLine("Got tenant B connection");
        }
    }
}
