using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using iMedOneDB.Models;
using Microsoft.AspNetCore.Authorization;
using Patient_Registration.PatientService;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;

namespace Patient_Registration.Controllers
{
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService.IPatient _patient;

        public PatientController(PatientService.IPatient patient)
        {
            _patient = patient;
        }

        [Route("api/SavePatient")]
        public void Save(TBLPATIENT body)
        {
            var patient = new[] { body };
            _patient.SavePatient(patient);
        }

        [Route("api/GetPatient")]
        public IEnumerable<TBLPATIENT> Get()
        {
            return _patient.GetPatient();
        }
    }
}