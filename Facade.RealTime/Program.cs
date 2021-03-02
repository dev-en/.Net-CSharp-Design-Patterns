using System;
 
namespace Facade.RealTime
{
    class Program
    {
        static void Main()
        {
            // Facade loan class
            Loan loan = new Loan();

            // check loan eligibility
            Customer customerA = new Customer("CustomerA", 700000);
            bool eligible = loan.IsEligible(customerA, 50000);

            Console.WriteLine("\n" + customerA.Name +
                " has been " + (eligible ? "Approved" : "Rejected"));

            Customer customerB = new Customer("CustomerB", 800000);
            eligible = loan.IsEligible(customerB, 50000);

            Console.WriteLine("\n" + customerB.Name +
                " has been " + (eligible ? "Approved" : "Rejected"));

            // Wait for user

            Console.ReadKey();
        }
    }
    class Bank
    {
        public bool VerifyBankDetails(Customer c)
        {
            Console.WriteLine("Bank details verified for " + c.Name);
            return true;
        }

        public bool CheckBalance(Customer c)
        {
            Console.WriteLine("Your account balance is " + c.Balance);
            return true;
        }
    }

    class Credit
    {
        public bool CheckCreditScore(Customer c)
        {
            Console.WriteLine("credit score verified for " + c.Name);
            return true;
        }

        public bool CheckCreditDetails(Customer c)
        {
            return true;
        }
    }

    class Identity
    {
        public bool VerifyIdentity(Customer c)
        {
            Console.WriteLine("Identity verified for " + c.Name);
            return true;
        }

        public bool VerifyAddress(Customer c)
        {
            Console.WriteLine("Address verified for " + c.Name);
            return true;
        }
    }

    class Customer
    {
        private string _name;
        private int _balance;

        // Constructor
        public Customer(string name, int balance)
        {
            _name = name;
            _balance = balance;
        }

        // Gets the name

        public string Name
        {
            get { return _name; }
        }

        public int Balance
        {
            get { return _balance; }
        }
    }

    /// <summary>
    /// The 'Facade' class
    /// </summary>
    class Loan

    {
        private readonly Bank _bank = new Bank();
        private readonly Identity _identity = new Identity();
        private readonly Credit _credit = new Credit();

        public bool IsEligible(Customer cust, int amount)
        {
            Console.WriteLine("{0} applies for {1} loan\n",
              cust.Name, amount);

            bool loanStatus = true;
            
            if (!_bank.VerifyBankDetails(cust))
            {
                loanStatus = false;
            }
            else if (!_identity.VerifyAddress(cust)
                || ! _identity.VerifyIdentity(cust))
            {
                loanStatus = false;
            }
            else if (!_credit.CheckCreditScore(cust))
            {
                loanStatus = false;
            }

            return loanStatus;
        }
    }
}
