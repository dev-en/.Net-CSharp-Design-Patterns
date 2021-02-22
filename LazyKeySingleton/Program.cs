using System;
using System.Threading.Tasks;

namespace LazyKeySingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(
                () => GetFirstMessage(),
                () => GetSecondMessage()
                );
            Console.ReadLine();
        }
        private static void GetFirstMessage()
        {
            Singleton firstCaller = Singleton.GetInstance;
            firstCaller.SayMessage("Hi! This is first caller");
        }
        private static void GetSecondMessage()
        {
            Singleton secondCaller = Singleton.GetInstance;
            secondCaller.SayMessage("Hi! This is second caller");
        }
    }
}
