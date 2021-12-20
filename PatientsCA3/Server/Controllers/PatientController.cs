using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientsCA3.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsCA3.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        List<Patient> patients = new List<Patient>
        {
            new Patient {ID = 1, FirstName = "Dara", LastName ="Smith", Gender = Gender.Male, Age = 55, Height = 180, Weight = 88},
            new Patient {ID = 2, FirstName = "Peter", LastName ="Carr", Gender = Gender.Male, Age = 46, Height = 170, Weight = 95},
            new Patient {ID = 3, FirstName = "Maria", LastName ="White", Gender = Gender.Female, Age = 57, Height = 171, Weight = 82},
            new Patient {ID = 4, FirstName = "Erick", LastName ="Galang", Gender = Gender.Male, Age = 49, Height = 162, Weight = 70},
            new Patient {ID = 5, FirstName = "Barbara", LastName ="Rodak", Gender = Gender.Female, Age = 75, Height = 155, Weight = 67},
            new Patient {ID = 6, FirstName = "Magda", LastName ="MacDonnel", Gender = Gender.Female, Age = 35, Height = 160, Weight = 65}
        };

        // controller method returnig all patients from list in mock db

        [HttpGet] // atribute for constructor to know what call to use
        public async Task<IActionResult> GetPatients()
        {
            return Ok(patients);
        }


        //controller method returning single patient from list in mock db basing on id
        [HttpGet("{id}")] // parameter provided for routing
        public async Task<IActionResult> GeSinglePatient(int id)
        {
            Patient patient = patients.FirstOrDefault(p => p.ID == id);
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
