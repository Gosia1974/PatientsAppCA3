using Microsoft.EntityFrameworkCore;
using PatientsCA3.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientsCA3.Server.Data
{/// <summary>
/// backend db context, represents patient table in db/web api talks to db via dbContext/dbContext is connecting to db and getting data out of it
/// </summary>
    public class PatientContextDB : DbContext
    {
        //collection of patients declered to represent rows in db, using DBSet
        public DbSet<Patient> Patients { get; set; }


        // constructor with options parameter of patientcontextdb type passed into DBContext base class
        //the options is set as UseInMemoryDB, so we can use the memory for our db
        public PatientContextDB(DbContextOptions<PatientContextDB> options)
            : base(options)
        {
        }
    }
}

