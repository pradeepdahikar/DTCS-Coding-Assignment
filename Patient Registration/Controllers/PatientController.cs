using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using iMedOneDB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;
using Patient.Service.Interfaces;
using Patient.Model;

namespace Patient_Registration.Controllers
{
    [Route("api/Patient")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;


        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PatientModel patientModel)
        {
            await _patientService.CreatePatientAsync(patientModel);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _patientService.GetPatientListAsync();
            return Ok(result);
        }
    }
}