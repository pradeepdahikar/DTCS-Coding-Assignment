using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient.Service.Interfaces;

namespace Patient_Registration.Controllers
{
    [Route("api/Location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }


        [HttpGet]
        [Route("State")]
        public async Task<IActionResult> GetStates()
        {
            var result = await _locationService.GetStateListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("City/{Id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var result = await _locationService.GetCityListByStateIdAsync(id);
            return Ok(result);
        }
    }
}
