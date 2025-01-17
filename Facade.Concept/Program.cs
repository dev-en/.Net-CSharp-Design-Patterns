﻿using System;

namespace Facade.Concept
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
            Facade facade = new Facade();

            facade.MethodABC();
            facade.MethodXYZ();

            facade.MethodABC();
            facade.MethodXYZ();


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

    /// <summary>
    /// The 'Facade' class
    /// </summary>
    class Facade
    {
        private SubSystemOne _one;
        private SubSystemTwo _two;
        private SubSystemThree _three;

        public Facade()
        {
            _one = new SubSystemOne();
            _two = new SubSystemTwo();
            _three = new SubSystemThree();
        }

        public void MethodABC()
        {
            //job ABC
            //This job ABC is called multiple times
            Console.WriteLine("Job ABC");
            _one.MethodA();
            _two.MethodB();
            _three.MethodC();
        }
        public void MethodXYZ()
        {
            //job XYZ
            //This job XYZ is called multiple times
            Console.WriteLine("Job XYZ");
            _one.MethodX();
            _two.MethodY();
            _three.MethodZ();
        }

       
    }
}