using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSingleton
{
    public sealed class Singleton
    {
        private static int counter = 0;
        private static Singleton instance = null;
        private Singleton()
        {
            counter++;
            Console.WriteLine("Counter value " + counter.ToString());
        }
        public static Singleton GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }
        public void SayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
