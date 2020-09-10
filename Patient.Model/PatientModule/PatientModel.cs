using System;
using System.Collections.Generic;
using System.Text;

namespace Patient.Model
{
    public class PatientModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public int CityId { get; set; }
    }
}
