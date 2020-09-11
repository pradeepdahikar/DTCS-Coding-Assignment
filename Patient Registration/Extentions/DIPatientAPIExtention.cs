using Microsoft.Extensions.DependencyInjection;
using Patient.Service.Interfaces;
using Patient.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Registration.Extentions
{
    public static class DIPatientAPIExtention
    {
        public static void WiringPatientAPIDependancies(IServiceCollection services)
        {
            services.AddSingleton<IPatientService,PatientService>();
            services.AddSingleton<ILocationService,LocationService>();
        }
    }
}
