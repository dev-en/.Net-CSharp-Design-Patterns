using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ObserverDesignPattern.Bank.Net5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the bank!");
            var accountA = new Account(1000);
            accountA.CustomerId = 100;
            var accountB = new Account(2000);
            accountB.CustomerId = 101;
            var accountC = new Account(3000);
            accountC.CustomerId = 102;
            var accountD = new Account(4000);
            accountD.CustomerId = 103;

            var accounts = new List<Account>()
            {
               accountA, accountB, accountC, accountD
            };

            var schemeProvider = new SchemeProvider();

            var preApprovedPersonnalLoanSchemeReporter
                = new SchemeReporter("Pre-ApprovedPersonnalLoans");
            var preApprovedCarLoansSchemeReporter
                = new SchemeReporter("Pre-ApprovedCarLoans");

            preApprovedPersonnalLoanSchemeReporter.Subscribe(schemeProvider);
            preApprovedCarLoansSchemeReporter.Subscribe(schemeProvider);

            NotifyAccount(accounts, schemeProvider);

            Console.ReadKey();
            preApprovedCarLoansSchemeReporter.Unsubscribe();

            Console.WriteLine("Pre-ApprovedCarLoans unsubscribed");
            NotifyAccount(accounts, schemeProvider);

            Console.ReadKey();
        }

        private static void NotifyAccount(List<Account> accounts, SchemeProvider schemeProvider)
        {
            foreach (var x in accounts)
            {
                schemeProvider.Notify(x, (x, preApprovedPersonnalLoanSchemeReporter) =>
                {
                    if (((SchemeReporter)preApprovedPersonnalLoanSchemeReporter).SchemeName
                    == "Pre-ApprovedPersonnalLoans")
                    {
                        return x.TotalAmount > 1000;
                    }
                    else
                    {
                        return false;
                    }

                });

                schemeProvider.Notify(x, (x, preApprovedPersonnalLoanSchemeReporter) =>
                {
                    if (((SchemeReporter)preApprovedPersonnalLoanSchemeReporter).SchemeName
                    == "Pre-ApprovedCarLoans")
                    {
                        return x.TotalAmount > 500;
                    }
                    else
                    {
                        return false;
                    }

                });
            }
        }
    }

    public class Account
    {
        public int TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public int AmountCredited { get; set; }
        public int AmountDebited { get; set; }

        public Account(int initialAmount)
        {
            TotalAmount = initialAmount;
        }
        public Account Credit(int CreditedAmount)
        {
            return new Account(TotalAmount)
            {
                AmountCredited = CreditedAmount,
                AmountDebited = 0,
                TotalAmount = TotalAmount + CreditedAmount
            };
        }
        public Account Debit(int DebitedAmount)
        {
            return new Account(TotalAmount)
            {
                AmountCredited = 0,
                AmountDebited = DebitedAmount,
                TotalAmount = TotalAmount - DebitedAmount
            };
        }

        public int GetBalance()
        {
            return TotalAmount;
        }
    }

    public class SchemeProvider : IObservable<Account>
    {
        public SchemeProvider()
        {
            observers = new List<IObserver<Account>>();
        }

        private readonly List<IObserver<Account>> observers;
        public IDisposable Subscribe(IObserver<Account> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Account>> _observers;
            private IObserver<Account> _observer;

            public Unsubscriber(List<IObserver<Account>> observers,
                IObserver<Account> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public void Notify(Account account,
            Func<Account, IObserver<Account>, bool> isEligible)
        {
            foreach (var observer in observers)
            {
                if (isEligible(account, observer) )
                {
                    observer.OnNext(account);
                }
            }
        }

        public void EndTransmission()
        {
            foreach (var observer in observers.ToArray())
                if (observers.Contains(observer))
                    observer.OnCompleted();

            observers.Clear();
        }
    }

    public class SchemeReporter : IObserver<Account>
    {
        private IDisposable unsubscriber;
        private readonly string _schemName;

        public SchemeReporter(string schemeName)
        {
            _schemName = schemeName;
        }

        public string SchemeName
        { get { return _schemName; } }

        public virtual void Subscribe(IObservable<Account> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine("Thanks for banking with us, looking " +
                "forward to serve you better in future.");
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine($"Your balance is zero, please refill");
        }

        public virtual void OnNext(Account value)
        {
            Console.WriteLine($"Hello {value.CustomerId}, you account is eligible for " +
                $"{SchemeName}");
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
    }
}
