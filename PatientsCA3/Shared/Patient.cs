using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientsCA3.Shared
{
    //business model of application data/dll library
    public enum Gender { Male, Female }
    public class Patient
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

    }
}
