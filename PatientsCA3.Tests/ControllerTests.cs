using PatientsCA3.Server.Controllers;
using System;
using Xunit;

namespace PatientsCA3.Tests
{
    public class ControllerTests
    {
        [Fact]
        public void GetSinglePatientTest()
        {
            var pc = new PatientController();
            var result = pc.GetSinglePatient(2);
            Assert.NotNull(result);
        }
    }
}
