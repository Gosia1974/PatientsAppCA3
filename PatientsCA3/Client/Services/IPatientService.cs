using PatientsCA3.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsCA3.Client.Services
{
    public interface IPatientService
    {
        /// <summary>
        /// patient service interface with two methods
        /// </summary>
       
        Task<List<Patient>> GetPatients();

        Task<Patient> GetSinglePatient(int id);
    }
}
