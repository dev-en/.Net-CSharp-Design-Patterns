using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.Concept
{
    /// <summary>
    /// The 'Handler' abstract class
    /// </summary>
    abstract class Handler
    {
        protected Handler handler;
        public void SetHandler(Handler handler)
        {
            this.handler = handler;
        }
        public abstract void HandleRequest(int request);
    }

    /// <summary>
    /// The 'ConcreteHandlerA' class
    /// </summary>
    class HandlerA : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10)
            {
                Console.WriteLine("{0} handled request {1}",
                  this.GetType().Name, request);
            }
            else if (handler != null)
            {
                handler.HandleRequest(request);
            }
        }
    }

    /// <summary>
    /// The 'ConcreteHandlerB' class
    /// </summary>
    class HandlerB : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Console.WriteLine("{0} handled request {1}",
                  this.GetType().Name, request);
            }
            else if (handler != null)
            {
                handler.HandleRequest(request);
            }
        }
    }

    /// <summary>
    /// The 'ConcreteHandlerC' class
    /// </summary>
    class HandlerC : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine("{0} handled request {1}",
                  this.GetType().Name, request);
            }
            else if (handler != null)
            {
                handler.HandleRequest(request);
            }
        }
    }
}
