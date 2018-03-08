using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext() 
                :base("name=SKLEntities")
        {
            var instane = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
