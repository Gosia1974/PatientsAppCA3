using PatientsCA3.Server.Data;
using PatientsCA3.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsCA3.Server.Repository
{
    /// <summary>
    /// Db repository for patients/ will talk to DB
    /// </summary>
    public class PatientDBRepository : IPatientDBRepository 
    {
        private readonly PatientContextDB _context;

        public PatientDBRepository(PatientContextDB context)
        {
            this._context = context;
        }
        public void Add(Patient patientToCreate)
        {
            _context.Add<Patient>(patientToCreate);
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _context.Patients.ToList<Patient>();
        }

    }
}
