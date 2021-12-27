using PatientsCA3.Shared;
using System.Collections.Generic;

namespace PatientsCA3.Server.Repository
{
    public interface IPatientDB
    {
        IEnumerable<Patient> GetPatients();
    }
}