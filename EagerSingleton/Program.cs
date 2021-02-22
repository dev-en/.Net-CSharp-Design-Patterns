using System;
using System.Threading.Tasks;

namespace EagerSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(
                () => SayFirstCallerMessage(),
                () => SaySecondCallerMessage()
                );
            Console.ReadLine();
        }
        private static void SayFirstCallerMessage()
        {
            Singleton firstCaller = Singleton.GetInstance;
            firstCaller.SayMessage("From Teacher");
        }
        private static void SaySecondCallerMessage()
        {
            Singleton secondCaller = Singleton.GetInstance;
            secondCaller.SayMessage("From Student");
        }
    }
}
