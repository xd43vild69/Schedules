using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Schedule: Entity 
    {
        public DateTime Datebook { get; set; }
        public string Description { get; set; }
        public int IdPatient { get; set; }
        public int IdTypeDates { get; set; }
    }
}
