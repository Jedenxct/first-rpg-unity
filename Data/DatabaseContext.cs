using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Data.DAO;

namespace Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public DatabaseContext() : base() {}

        public static DatabaseContext Get()
        {
            return new DatabaseContext();
        }
    }
}
