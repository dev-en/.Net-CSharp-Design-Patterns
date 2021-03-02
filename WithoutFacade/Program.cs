using System;

namespace WithoutFacade
{
    /// <summary>
    /// Facade Design Pattern.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            var _one = new SubSystemOne();
            var _two = new SubSystemTwo();
            var _three = new SubSystemThree();

            //job ABC
            //This job ABC is called multiple times
            Console.WriteLine("Job ABC");
            _one.MethodA();
            _two.MethodB();
            _three.MethodC();

            Console.WriteLine();

            //job XYZ
            //This job XYZ is called multiple times
            Console.WriteLine("Job XYZ");
            _one.MethodX();
            _two.MethodY();
            _three.MethodZ();

            Console.WriteLine();

            //job ABC
            //This job ABC is called multiple times
            Console.WriteLine("Job ABC");
            _one.MethodA();
            _two.MethodB();
            _three.MethodC();

            Console.WriteLine();

            //job XYZ
            //This job XYZ is called multiple times
            Console.WriteLine("Job XYZ");
            _one.MethodX();
            _two.MethodY();
            _three.MethodZ();

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Subsystem' class
    /// </summary>
    class SubSystemOne
    {
        public void MethodA()
        {
            Console.WriteLine(" Job A completed");
        }

        public void MethodX()
        {
            Console.WriteLine(" Job X completed");
        }
    }

    /// <summary>
    /// The 'Subsystem' class
    /// </summary>
    class SubSystemTwo
    {
        public void MethodB()
        {
            Console.WriteLine(" job B completed");
        }

        public void MethodY()
        {
            Console.WriteLine(" Job Y completed");
        }
    }

    /// <summary>
    /// The 'Subsystem' class
    /// </summary>
    class SubSystemThree
    {
        public void MethodC()
        {
            Console.WriteLine(" job C completed");
        }
        public void MethodZ()
        {
            Console.WriteLine(" Job Z completed");
        }
    }
}
