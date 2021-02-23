using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RealTimeSingleton
{
    public class ExternalService
    {
        public static MultitenantDb CallTenantDb(string tenant)
        {
            Thread.Sleep(7000);
            MultitenantDb multitenantDb = new MultitenantDb()
            {
                UserName = $"UserName{tenant}",
                Password = $"Password{tenant}",
                ConnectionString = $"ConnectionString{tenant}"
            };
            return multitenantDb;
        }
    }
}
