using BoilerPlate.Contract;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace BoilerPlate.DataAccess
{
   public class DatabaseContext : DbContext
    {
            public DatabaseContext() { }
            public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
            public DbSet<AttributionCode> AttributionCode { get; set; }
    }
}
