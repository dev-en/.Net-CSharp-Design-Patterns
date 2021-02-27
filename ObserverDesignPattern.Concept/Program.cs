using System;
using System.Collections.Generic;
using System.Threading;

namespace ObserverDesignPattern.Concept
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure Observer pattern
            StockA stock = new StockA();

            Investor obsA = new Investor(stock, "A");
            Investor obsB = new Investor(stock, "B");
            Investor obsC = new Investor(stock, "C");

            stock.Attach(obsA);
            stock.Attach(obsB);
            stock.Attach(obsC);

            // Change subject and notify observers
            while (true)
            {
                Thread.Sleep(1000);
                Random random = new Random();
                double val = random.NextDouble() * 100;
                stock.Status = val;
            }
        }
    }

    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>
    abstract class Subject
    {
        private readonly List<Observer> _observers
            = new List<Observer>();

        private double _status;
        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer o in _observers)
            {
                o.Update();
            }
        }

        // Gets or sets the price
        public double Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    Notify();
                }
            }
        }
    }

    /// <summary>
    /// The 'ConcreteSubject' class
    /// </summary>
    class StockA : Subject
    {

    }

    /// <summary>
    /// The 'Observer' abstract class
    /// </summary>
    abstract class Observer
    {
        public abstract void Update();
    }

    /// <summary>
    /// The 'ConcreteObserver' class
    /// </summary>
    class Investor : Observer
    {
        private readonly string _name;

        // Gets or sets subject
        public StockA Subject { get; set; }

        // Constructor
        public Investor(
          StockA subject, string name)
        {
            Subject = subject;
            _name = name;
        }

        public override void Update()
        {
            Console.WriteLine("Hi {0}, Subject new state is {1}",
              _name, Subject.Status);
        }
    }
}
