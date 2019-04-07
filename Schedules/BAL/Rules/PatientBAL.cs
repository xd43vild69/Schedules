using DTO;
using SAL.Context;
using System.Collections.Generic;

namespace BAL
{
    public class PatientBAL
    {
        private PatientRepository<Patient> Repository { get; set; }

        public PatientBAL()
        {
            Repository = new PatientRepository<Patient>();
        }
        public IEnumerable<Patient> GetLists()
        {
            return Repository.GetLists();
        }
    }
}
