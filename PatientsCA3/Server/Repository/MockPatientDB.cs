using PatientsCA3.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsCA3.Server.Repository
{
    public class MockPatientDB : IPatientDB
    {
        public IEnumerable<Patient> GetPatients()
        {
            //gary has private list and then initialysed in constructor
            return new List<Patient> // in memory collection, store in mock db and initialise the list collection, will be replace by real db
            {
                //hard coded data
                new Patient {ID = 1, FirstName = "Dara", LastName ="Smith", Gender = Gender.Male, Age = 55, Height = 180, Weight = 88},
                new Patient {ID = 2, FirstName = "Peter", LastName ="Carr", Gender = Gender.Male, Age = 46, Height = 170, Weight = 95},
                new Patient {ID = 3, FirstName = "Maria", LastName ="White", Gender = Gender.Female, Age = 57, Height = 171, Weight = 82},
                new Patient {ID = 4, FirstName = "Erick", LastName ="Galang", Gender = Gender.Male, Age = 49, Height = 162, Weight = 70},
                new Patient {ID = 5, FirstName = "Barbara", LastName ="Rodak", Gender = Gender.Female, Age = 75, Height = 155, Weight = 67},
                new Patient {ID = 6, FirstName = "Magda", LastName ="MacDonnel", Gender = Gender.Female, Age = 35, Height = 160, Weight = 65}
            };
        }
    }
}
