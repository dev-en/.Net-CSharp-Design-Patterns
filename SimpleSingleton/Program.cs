using System;
using System.Threading.Tasks;

namespace SimpleSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //My singleton class only transfer message
            GetFirstMessage();
            GetSecondMessage();
            Console.ReadLine();
        }

        //static void Main(string[] args)
        //{
        //    Parallel.Invoke(
        //        () => SayFirstCallerMessage(),
        //        () => SaySecondCallerMessage()
        //        );
        //    Console.ReadLine();
        //}
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
