using iMedOneDB.Models;
using Patient.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Patient.Service.Interfaces
{
    public interface IPatientService
    {
        Task<bool> CreatePatientAsync(PatientModel patient);

        Task<List<PatientModel>> GetPatientListAsync();
    }
}
