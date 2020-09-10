using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using iMedOneDB.Models;
using Microsoft.AspNetCore.Authorization;

namespace Patient_Registration.Controllers
{
    public class CommonController :ControllerBase
    {
        [HttpGet]
        [Route("api/States")]
        public string GetStates()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(iMedOneDB.DBContext.GetData<Tblstate>());
        }

        [Route("api/Cities")]
        public string GetCities()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(iMedOneDB.DBContext.GetData<Tblcity>());
        }

        [HttpGet]
        [Route("api/Cities/{id}")]
        public string GetCityById(int id)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(iMedOneDB.DBContext.GetData<Tblcity>().Where(a => a.StateId == id));
        }
    }
}