using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.RealTime
{
    /// <summary>
    /// The 'Handler' abstract class
    /// </summary>
    abstract class VehicleManager
    {
        protected VehicleManager manager;
        public void SetManager(VehicleManager manager)
        {
            this.manager = manager;
        }
        public abstract void ManageRequest(int request);
    }

    /// <summary>
    /// The 'ConcreteHandlerA' class
    /// </summary>
    class TwoWheelerManager : VehicleManager
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
    class ThreeWheelerManager : VehicleManager
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
    class FourWheelerManager : VehicleManager
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
