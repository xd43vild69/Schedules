namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DTO;

    internal sealed class Configuration : DbMigrationsConfiguration<Schedules.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Schedules.Context context)
        {
            context.Patients.AddOrUpdate(x => x.Id,

            new DTO.Patient() { Id = 1, Name = "Patient1" },
            new DTO.Patient() { Id = 1, Name = "Patient1" }
            );

            context.Schedules.AddOrUpdate(x => x.Id,
                new DTO.Schedule() { Id = 1, Datebook = System.DateTime.Now, Description = "Desc1", IdPatient = 1 },
                new DTO.Schedule() { Id = 1, Datebook = System.DateTime.Now, Description = "Desc2", IdPatient = 2 }
            );

            context.TypeSchedules.AddOrUpdate(x => x.Id,
            new DTO.TypeSchedule() { Id = 1, Name = "Medicina General" },
            new DTO.TypeSchedule() { Id = 2, Name = "Odontología" },
            new DTO.TypeSchedule() { Id = 3, Name = "Pediatría" },
            new DTO.TypeSchedule() { Id = 4, Name = "Neurología" }
            );
        }
    }
}
