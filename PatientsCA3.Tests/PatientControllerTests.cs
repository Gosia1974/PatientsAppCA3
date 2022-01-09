using Microsoft.AspNetCore.Mvc;
using PatientsCA3.Server.Controllers;
using PatientsCA3.Shared;
using System.Collections.Generic;
using System.Linq;
using System;
using Xunit;
using Microsoft.Extensions.Logging;
using PatientsCA3.Server.Repository;

namespace PatientsCA3.Tests
{
    public class PatientControllerTests
    {

        private LoggerFactory lf;
        private ILogger<PatientController> log;
        private IPatientDBRepository mockDBRepo;

        public PatientControllerTests()
        {
            lf = new LoggerFactory();
            log = lf.CreateLogger<PatientController>();
            mockDBRepo = new MockPatientDBRepository();
        }

        //get method testing
        [Fact]
        public async void GetSuccessSinglePatientTest()
        {

            var pc = new PatientController(log, mockDBRepo);
            var result = await pc.GetSinglePatient(2);
            Assert.NotNull(result);
            Assert.True(result is OkObjectResult);
        }

        [Fact]
        public async void GetNotFoundSinglePatientTest()
        {
            var pc = new PatientController(log, mockDBRepo);
            var result = await pc.GetSinglePatient(20);
            Assert.NotNull(result);
            Assert.True(result is NotFoundObjectResult);
        }

        [Fact]
        public async void GetSuccessPatientsTest()
        {
            var pc = new PatientController(log, mockDBRepo);
            var result = await pc.GetPatients();
            Assert.NotNull(result);
            Assert.True(result is ObjectResult);
        }

        [Fact]
        public async void GetNotSuccessPatientsTest()
        {
            var pc = new PatientController(log, mockDBRepo);
            var result = await pc.GetPatients();
            Assert.NotNull(result);
            Assert.False(result is NotFoundObjectResult);
        }


        // post method testing
        [Fact]
        public async void CreatePatientSuccessfulTest()
        {
            var cpt = new PatientController(log, mockDBRepo);
            var lst = mockDBRepo.GetPatients();
            var countbefore = lst.Count();
            var pt = new Patient { ID = 7, FirstName = "Patrick", LastName = "Kenny", Gender = Gender.Male, Age = 58, Height = 188, Weight = 99 };
            var result = await cpt.CreatePatient(pt);
            lst = mockDBRepo.GetPatients();
            var countafter = lst.Count();
            Assert.NotNull(result);
            Assert.True(result is OkResult);
            Assert.True(countbefore < countafter);
        }
    }
}
