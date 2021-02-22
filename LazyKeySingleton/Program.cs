using System;
using System.Threading.Tasks;

namespace LazyKeySingleton
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
            firstCaller.SayMessage("Hi! This is first caller");
        }
        private static void SaySecondCallerMessage()
        {
            Singleton secondCaller = Singleton.GetInstance;
            secondCaller.SayMessage("Hi! This is second caller");
        }
    }
}
