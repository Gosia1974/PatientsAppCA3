using System;

namespace PatientsCA3.Shared
{
    internal class ReguiredAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
    }
}