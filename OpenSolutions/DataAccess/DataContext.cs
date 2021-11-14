using Microsoft.EntityFrameworkCore;
using OpenSolutions.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSolutions.DataAccess
{
    public class DataContext:DbContext
    {
        public DbSet<RecordEntity> Records { get; set; }
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
    }
}
