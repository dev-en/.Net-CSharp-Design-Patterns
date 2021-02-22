using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace RealTimeSingleton
{
    public sealed class Singleton
    {
        private static int counter = 0;

        //The advantage of using Eager Loading in the Singleton design pattern 
        //is that the CLR (Common Language Runtime) will take care of 
        //object initialization and thread-safety. 
        //That means we will not require to write any code 
        //explicitly for handling the thread-safety for a multithreaded environment.

        //A Static Readonly type variable's value can be assigned at runtime 
        //or assigned at compile time and changed at runtime. 
        //But this variable's value can only be changed in the static constructor.
        //And cannot be changed further. It can change only once at runtime.
        private static readonly Singleton _instance = new Singleton();
        private static ConcurrentDictionary<string, MultitenantDb> Dbs = new ConcurrentDictionary<string, MultitenantDb>();
        private Singleton()
        {
            
        }
        public static Singleton GetInstance
        {
            get
            {
                return _instance;
            }
        }

        public MultitenantDb GetConnection(string tenant)
        {
            if (!Dbs.ContainsKey(tenant))
            {
                MultitenantDb multitenantDb = ExternalService.CallTenantDb(tenant);
                Dbs[tenant] = multitenantDb;
            }
            return Dbs[tenant];
        }
    }
}
