using PatientsCA3.Shared;
using System.Collections.Generic;

namespace PatientsCA3.Server.Repository
{
    ///<summary>
    ///PatientDB interface with two methods
    ///</summary>
    public interface IPatientDBRepository
    {
        IEnumerable<Patient> GetPatients();

        public void Add(Patient patientToCreate);
    }
}