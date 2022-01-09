using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientsCA3.Server.Repository;
using PatientsCA3.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsCA3.Server.Controllers
{
    //[Produces("aplication/json")] API produces JSON response only, which will talk to DB(physical or in memory)
    // route to the app, controller is a placeholder, which will be replaced with name(stock) of the controler in URL
    [Route("api/[controller]")] 
    [ApiController]
    public class PatientController : ControllerBase
    {
        public IPatientDB patientdb;
        private readonly ILogger _logger;

        public PatientController(ILogger<PatientController> logger)
        {
            patientdb = new MockPatientDB();
            _logger = logger;
        }

        // API/<PatientController>controller method returnig all patients from list in mock db, swagger is looking through controllers and its methods(endpoints of api)
        // atribute for constructor to know what call to use / triggered by Get/allowing only read data
        [HttpGet] 
        public async Task<IActionResult> GetPatients()
        {
            try
            {
                var ret = patientdb.GetPatients();
                _logger.LogInformation($"Called GetPatients. Number of records: {ret.Count()}");
                return Ok(ret);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }


        //controller method returning single patient from list in mock db basing on id
        // parameter provided for routing
        [HttpGet("{id}")] 
        public async Task<IActionResult> GetSinglePatient(int id)
        {
            Patient patient = patientdb.GetPatients().FirstOrDefault(p => p.ID == id);
            if (patient == null)
            {
                _logger.LogWarning($"No patient found with id {id}");
                return NotFound("Patient matching this id not found.");
            }
            else 
            {
                _logger.LogInformation($"Called GetSinglePatient with id {id}");
                return  Ok(patient);
            }
        }

        // adding patient to db method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreatePatient([Bind("ID, FirstName, LastName, Gender, Age, Height, Weight")] Patient patientToCreate)
        {
            if (ModelState.IsValid)
            {
                patientdb.Add(patientToCreate);
                return Ok();
            }
            return BadRequest();
        }
      
    }
}
