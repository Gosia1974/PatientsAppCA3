using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientsCA3.Shared
{
    public enum Gender { Male, Female }

    /// <summary>
    /// business model of application data/dll library
    /// </summary>
    public class Patient
    {
        [Reguired(ErrorMessage = "ID must be submitted")]
        public int ID { get; set; }
        

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only.")]
        public string FirstName { get; set; }


        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only.")]
        public string LastName { get; set; }


        private Gender gender;
        public Gender Gender
        {
            get { return gender; }
            set
            {
                if (value == Gender.Female || value == Gender.Male)
                {
                    gender = value;
                }
                else
                {
                    throw new ArgumentException("Not valid gender", "argument");
                }
            }
        }


         [Required(ErrorMessage = "Please enter your age.")]
         public int Age { get; set; }


        [Required(ErrorMessage = "Please enter your height.")]
        public int Height { get; set; }


        [Required(ErrorMessage = "Please enter your weight.")]
        public int Weight { get; set; }

    }
}
