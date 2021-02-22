using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.Concept
{
    /// <summary>
    /// The 'Handler' abstract class
    /// </summary>
    abstract class Manager
    {
        protected Manager manager;
        public void SetManager(Manager manager)
        {
            this.manager = manager;
        }
        public abstract void ManageRequest(int request);
    }

    /// <summary>
    /// The 'ConcreteHandlerA' class
    /// </summary>
    class ManagerA : Manager
    {
        public override void ManageRequest(int request)
        {
            if (request >= 0 && request < 10)
            {
                Console.WriteLine("{0} handled request {1}",
                  this.GetType().Name, request);
            }
            else if (manager != null)
            {
                manager.ManageRequest(request);
            }
        }
    }

    /// <summary>
    /// The 'ConcreteHandlerB' class
    /// </summary>
    class ManagerB : Manager
    {
        public override void ManageRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Console.WriteLine("{0} handled request {1}",
                  this.GetType().Name, request);
            }
            else if (manager != null)
            {
                manager.ManageRequest(request);
            }
        }
    }

    /// <summary>
    /// The 'ConcreteHandlerC' class
    /// </summary>
    class ManagerC : Manager
    {
        public override void ManageRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine("{0} handled request {1}",
                  this.GetType().Name, request);
            }
            else if (manager != null)
            {
                manager.ManageRequest(request);
            }
        }
    }
}
