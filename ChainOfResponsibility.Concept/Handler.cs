using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.Concept
{
    /// <summary>
    /// The 'Handler' abstract class
    /// </summary>
    abstract class Handler<T> where T: class
    {
        protected Handler<T> handler;
        public void SetHandler(Handler<T> handler)
        {
            this.handler = handler;
        }
        public abstract void HandleRequest(T request);
    }

    /// <summary>
    /// The 'ConcreteHandlerA' class
    /// </summary>
    class HandlerA<T> : Handler<T> where T : class
    {
        public override void HandleRequest(T request)
        {
            Console.WriteLine("Started HandlerA");
            //Do some your initial work related to this Handler
            
            if (handler != null)
            {
                handler.HandleRequest(request);
            }
            //Do some your finishing work related to this Handler
            Console.WriteLine("Finished HandlerA");
        }
    }

    /// <summary>
    /// The 'ConcreteHandlerB' class
    /// </summary>
    class HandlerB<T> : Handler<T> where T : class
    {
        public override void HandleRequest(T request)
        {
            Console.WriteLine("Started HandlerB");
            //Do some your initial work related to this Handler
            if (handler != null)
            {
                handler.HandleRequest(request);
            }
            //Do some your finishing work related to this Handler
            Console.WriteLine("Finished HandlerB");
        }
    }

    /// <summary>
    /// The 'ConcreteHandlerC' class
    /// </summary>
    class HandlerC<T> : Handler<T> where T : class
    {
        public override void HandleRequest(T request)
        {
            Console.WriteLine("Started HandlerC");
            //Do some your initial work related to this Handler
            if (handler != null)
            {
                handler.HandleRequest(request);
            }
            //Do some your finishing work related to this Handler
            Console.WriteLine("Finished HandlerC");
        }
    }
}
