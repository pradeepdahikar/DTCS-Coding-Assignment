using iMedOneDB.Models;
using Patient.Model.LocationModule;
using Patient.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Service.Services
{
    public class LocationService : ILocationService
    {
        public Task<List<CityModel>> GetCityListByStateIdAsync(int stateId)
        {
            var cityList = iMedOneDB.DBContext.GetData<Tblcity>().Where(a=>a.StateId==stateId);
            return Task.Run(() => cityList.Select(city => new CityModel
            {
                Id = city.Id,
                Name = city.Name
            }).ToList()); ;
        }

        public Task<List<StateModel>> GetStateListAsync()
        {
            var stateList = iMedOneDB.DBContext.GetData<Tblstate>();
            return Task.Run(() => stateList.Select(state => new StateModel
            {
                Id = state.Id,
                Name = state.Name
            }).ToList());
        }
    }
}
