using PatientsCA3.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PatientsCA3.Client.Services
{
    public class PatientService : IPatientService
    {
        private readonly HttpClient httpClient; //private field _httpClient?

        public PatientService(HttpClient httpClient) //constructor with parameter referring to httpclient class
        {
            this.httpClient = httpClient;
        }


        public async Task<List<Patient>> GetPatients()
        {
            try
            {
                var ret = await httpClient.GetFromJsonAsync<List<Patient>>("api/patient");
                return ret;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Patient> GetSinglePatient(int id) // implementtion of method from interface IPatientService
        {
            return await httpClient.GetFromJsonAsync<Patient>($"api/patient/{id}"); // id is going to be injected

        }
    }
}
