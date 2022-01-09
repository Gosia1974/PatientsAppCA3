using PatientsCA3.Server.Controllers;
using PatientsCA3.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PatientsCA3.Tests
{
    public class PatientTests
    {
        [Fact]
        public void  SetSuccessfulFirstName()
        {
            //Arrange
            var pt = new Patient();
            //Act
            pt.FirstName = "Rodak";
            //Assert
            Assert.Equal("Rodak", pt.FirstName);
        }


        //validation of patient properties should be different?
        [Fact]
        public void SetNotSuccessfulFirstName()
        {
            Patient pt = new Patient();
            pt.FirstName = "123";
            Assert.Equal("123", pt.FirstName);
        }
    }
}
