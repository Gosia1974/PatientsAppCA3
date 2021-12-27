using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientsCA3.Server.Repository;
using PatientsCA3.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsCA3.Server.Controllers
{
    //[Produces("aplication/json")] // produce JSON response only //that is my API, which will talk to DB(physical or inmemory)
    [Route("api/[controller]")] // route to the app, controller is placeholder,which will be replaced with name(stock) of the controler in URL
    [ApiController]
    public class PatientController : ControllerBase
    {
        IPatientDB patientdb;
        public PatientController()
        {
            patientdb = new MockPatientDB();
        }

        // API/<PatientController>controller method returnig all patients from list in mock db, swagger is looking through controllers and its methods(endpoints of api)

        [HttpGet] // atribute for constructor to know what call to use / trigger by Get/allowing only read data
        public async Task<IActionResult> GetPatients()
        {
            return Ok(patientdb.GetPatients());
        }


        //controller method returning single patient from list in mock db basing on id
        [HttpGet("{id}")] // parameter provided for routing
        public async Task<IActionResult> GeSinglePatient(int id)
        {
            Patient patient = patientdb.GetPatients().FirstOrDefault(p => p.ID == id);
            if (patient == null)
            {
                return NotFound("Patient matching this id not found.");
            }
            else 
            { 
                return Ok(patient);
            }
        }
    }
}
