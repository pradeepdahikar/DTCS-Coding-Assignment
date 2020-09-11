using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Patient.Model
{
    public class PatientModel
    {
        [JsonProperty(Required = Required.Always)]
        [RegularExpression("[a-zA-Z]+")]
        public string Name { get; set; }
        
        [JsonProperty(Required = Required.Always)]
        [RegularExpression("[a-zA-Z]+")]
        public string SurName { get; set; }
        
        [JsonProperty(Required = Required.Always)]
        public DateTime DOB { get; set; }
        
        [JsonProperty(Required = Required.Always)]
        public string Gender { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int CityId { get; set; }
    }
}
