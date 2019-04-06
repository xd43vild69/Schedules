using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Schedules
{
    public class Context : DbContext
    {
        public Context() : base("StringConn")
        {

        }
        public DbSet<Person > Patients { get; set; }
    }
}
