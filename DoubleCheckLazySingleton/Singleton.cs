using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleCheckLazySingleton
{
    public sealed class Singleton
    {
        private static int counter = 0;
        private static readonly object _lock = new object();
        private static Singleton instance = null;
        private Singleton()
        {
            counter++;
            Console.WriteLine("Counter value " + counter.ToString());
        }
        //slow down your application as only one thread can access 
        //the GetInstance property at any given point of time. 
        //We can overcome the above problem by using 
        //the Double-checked locking mechanism.
        //public static Singleton GetInstance
        //{
        //    get
        //    {
        //        lock (_lock)
        //        {
        //            if (instance == null)
        //            {
        //                instance = new Singleton();
        //            }
        //            return instance;
        //        }
        //    }
        //}
        public static Singleton GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }

        public void SayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
