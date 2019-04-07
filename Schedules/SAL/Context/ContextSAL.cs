using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DTO;
namespace SAL
{
    public class ContextSAL : DbContext
    {
        public ContextSAL() : base("StringConn")
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<TypeSchedule> TypeSchedules { get; set; }
    }
}
