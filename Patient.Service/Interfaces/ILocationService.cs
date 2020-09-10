using Patient.Model.LocationModule;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Service.Interfaces
{
    public interface ILocationService
    {
        Task<List<StateModel>> GetStateListAsync();
        Task<List<CityModel>> GetCityListByStateIdAsync(int stateId);
    }
}
