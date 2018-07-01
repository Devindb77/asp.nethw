using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ConnectionsTest.Model
{
    public class AppplicationDbContext : DbContext
    {
        public AppplicationDbContext(DbContextOptions<AppplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Connection>ConnectionsItems { get; set; }

    }

}
