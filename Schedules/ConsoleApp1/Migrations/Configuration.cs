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

            new DTO.Patient() { Id = 1, Name = "Aurelio Gorgomez" },
            new DTO.Patient() { Id = 2, Name = "Ana Gorgomez" },
            new DTO.Patient() { Id = 3, Name = "Maria Gorgomez" },
            new DTO.Patient() { Id = 4, Name = "Catalina Gorgomez" },
            new DTO.Patient() { Id = 5, Name = "Carolina Gorgomez" },
            new DTO.Patient() { Id = 6, Name = "Angela Gorgomez" },
            new DTO.Patient() { Id = 7, Name = "Andrea Gorgomez" },
            new DTO.Patient() { Id = 8, Name = "Lunar Gorgomez" }
            );

            context.Schedules.AddOrUpdate(x => x.Id,
                new DTO.Schedule() { Id = 1, Datebook = System.DateTime.Now.AddDays(1), Description = "Descripcion Cita 1", IdPatient = 1, IdTypeDates= 1 },
                new DTO.Schedule() { Id = 2, Datebook = System.DateTime.Now.AddDays(2), Description = "Descripcion Cita 2", IdPatient = 1, IdTypeDates = 2 },
                new DTO.Schedule() { Id = 3, Datebook = System.DateTime.Now.AddDays(3), Description = "Descripcion Cita 3", IdPatient = 1, IdTypeDates = 3 },
                new DTO.Schedule() { Id = 4, Datebook = System.DateTime.Now.AddDays(4), Description = "Descripcion Cita 4", IdPatient = 1, IdTypeDates = 4 },
                new DTO.Schedule() { Id = 5, Datebook = System.DateTime.Now.AddDays(5), Description = "Descripcion Cita 5", IdPatient = 2, IdTypeDates = 4 }
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
