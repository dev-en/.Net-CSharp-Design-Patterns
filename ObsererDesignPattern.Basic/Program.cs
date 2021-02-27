using System;
using System.Collections.Generic;

namespace ObsererDesignPattern.Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure Observer pattern
            ConcreteSubject subj = new ConcreteSubject();

            ConcreteObserver obsA = new ConcreteObserver(subj, "A");
            ConcreteObserver obsB = new ConcreteObserver(subj, "B");
            ConcreteObserver obsC = new ConcreteObserver(subj, "C");

            subj.Attach(obsA);
            subj.Attach(obsB);
            subj.Attach(obsC);

            // Change subject and notify observers
            subj.Status = "ABC";

            Console.WriteLine("Enter new state");
            var state = Console.ReadLine();
            subj.Status = state;

            Console.WriteLine("Enter new state");
            state = Console.ReadLine();
            subj.Status = state;

            Console.WriteLine("Enter new state");
            state = Console.ReadLine();
            subj.Status = state;

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>
    abstract class Subject
    {
        private readonly List<Observer> _observers 
            = new List<Observer>();

        private string _status;
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
        public string Status
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
    class ConcreteSubject : Subject
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
    class ConcreteObserver : Observer
    {
        private readonly string _name;

        // Gets or sets subject
        public ConcreteSubject Subject { get; set; }

        // Constructor
        public ConcreteObserver(
          ConcreteSubject subject, string name)
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
