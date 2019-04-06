using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DTO;
namespace Schedules
{
    public class Context : DbContext
    {
        public Context() : base("StringConn")
        {

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<TypeSchedule> TypeSchedules { get; set; }
    }
}
