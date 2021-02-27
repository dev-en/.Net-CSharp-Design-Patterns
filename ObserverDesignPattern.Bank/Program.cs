using System;
using System.Collections.Generic;

namespace ObserverDesignPattern.Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>

            /// Entry point into console application.

            /// </summary>

            static void Main()
            {
                // Create IBM stock and attach investors

                LoanScheme ibm = new LoanScheme("IBM", 120.00);
                ibm.Attach(new Account("Sorros"));
                ibm.Attach(new Account("Berkshire"));

                // Fluctuating prices will notify investors

                ibm.Price = 120.10;
                ibm.Price = 121.00;
                ibm.Price = 120.50;
                ibm.Price = 120.75;

                // Wait for user

                Console.ReadKey();
            }
        }

        /// <summary>

        /// The 'Subject' abstract class

        /// </summary>

        abstract class Scheme

        {
            private string _Name;
            private double _price;
            private List<IAccount> _accounts = new List<IAccount>();

            // Constructor

            public Scheme(string symbol, double price)
            {
                this._Name = symbol;
                this._price = price;
            }

            public void Attach(IAccount investor)
            {
                _accounts.Add(investor);
            }

            public void Detach(IAccount investor)
            {
                _accounts.Remove(investor);
            }

            public void Notify()
            {
                foreach (IAccount account in _accounts)
                {
                    account.Update(this);
                }

                Console.WriteLine("");
            }

            // Gets or sets the price

            public double Price
            {
                get { return _price; }
                set

                {
                    if (_price != value)
                    {
                        _price = value;
                        Notify();
                    }
                }
            }

            // Gets the symbol

            public string Symbol
            {
                get { return _Name; }
            }
        }

        /// <summary>

        /// The 'ConcreteSubject' class

        /// </summary>

        class LoanScheme : Scheme

        {
            // Constructor

            public LoanScheme(string symbol, double price)
              : base(symbol, price)
            {
            }
        }

        /// <summary>

        /// The 'Observer' interface

        /// </summary>

        interface IAccount

        {
            void Update(Scheme stock);
        }

        /// <summary>

        /// The 'ConcreteObserver' class

        /// </summary>

        class Account : IAccount

        {
            private string _name;
            private Scheme _stock;

            // Constructor

            public Account(string name)
            {
                this._name = name;
            }

            public void Update(Scheme stock)
            {
                Console.WriteLine("Notified {0} of {1}'s " +
                  "change to {2:C}", _name, stock.Symbol, stock.Price);
            }

            // Gets or sets the stock

            public Scheme Stock
            {
                get { return _stock; }
                set { _stock = value; }
            }
        }
    }
}