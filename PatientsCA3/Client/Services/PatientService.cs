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
        private readonly HttpClient httpClient;


        //constructor with parameter referring to httpclient class
        public PatientService(HttpClient httpClient) 
        {
            this.httpClient = httpClient;
        }


        public async Task<List<Patient>> GetPatients()
        {
            try
            {
                
                //var ret = await httpClient.GetFromJsonAsync<List<Patient>>("https://patientsca3server20220106134348.azurewebsites.net/api/patient");
                var ret = await httpClient.GetFromJsonAsync<List<Patient>>("api/patient");
                return ret;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<Patient> GetSinglePatient(int id) // implementtion of method from interface IPatientService
        {
            //return await httpClient.GetFromJsonAsync<Patient>($"https://patientsca3server20220106134348.azurewebsites.net/api/patient/{id}"); // id is going to be injected
            return await httpClient.GetFromJsonAsync<Patient>($"api/patient/{id}"); // id is going to be injected

        }
    }
}
