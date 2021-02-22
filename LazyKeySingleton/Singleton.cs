using System;
using System.Collections.Generic;
using System.Text;

namespace LazyKeySingleton
{
    public sealed class Singleton
    {
        private static int counter = 0;

        //lazy keyword which creates only one singleton instance 
        //and also they are by default thread-safe 
        //that’s why we do not get any error while invoking the methods parallelly.
        //Lazy<T> objects are by default thread-safe

        //A Static Readonly type variable's value can be assigned at runtime 
        //or assigned at compile time and changed at runtime. 
        //But this variable's value can only be changed in the static constructor.
        //And cannot be changed further. It can change only once at runtime.
        private static readonly Lazy<Singleton> _instance =
                    new Lazy<Singleton>(() => new Singleton());
        private Singleton()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }
        public static Singleton GetInstance
        {
            get
            {
                return _instance.Value;
            }
        }
        public void SayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
