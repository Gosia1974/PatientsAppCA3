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
    public class PatientDB : IPatientDB 
    {
        public void Add(Patient patientToCreate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetPatients()
        {
            return new List<Patient>();
        }

    }
}
