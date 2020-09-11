using iMedOneDB.Models;
using Patient.Model;
using Patient.Service.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Patient.Service.Services
{
    public class PatientService : IPatientService
    {
        public Task<bool> CreatePatientAsync(PatientModel patient)
        {
            //Check id Patient is already registered
            var tempPatient = iMedOneDB.DBContext.GetData<TBLPATIENT>();
            tempPatient= tempPatient.Where(p => p.Name == patient.Name && p.SurName == patient.SurName && p.DOB == patient.DOB && p.Gender == patient.Gender);

            if (tempPatient == null || tempPatient.Count() <= 0)
            {
                IEnumerable<TBLPATIENT> patientData = new List<TBLPATIENT>() {
                new TBLPATIENT{
                Name = patient.Name,
                SurName = patient.SurName,
                CityId = patient.CityId,
                DOB = patient.DOB,
                Gender = patient.Gender
                }
            };
                iMedOneDB.DBContext.SaveAll<TBLPATIENT>(patientData);
                return Task.Run(() => true );
            }

            return Task.Run(() => false);
        }

        public Task<List<PatientModel>> GetPatientListAsync()
        {
            var patientList = iMedOneDB.DBContext.GetData<TBLPATIENT>();
            return Task.Run(() => patientList.Select(patient => new PatientModel
            {
                Name = patient.Name,
                SurName = patient.SurName,
                CityId = patient.CityId,
                DOB = patient.DOB,
                Gender = patient.Gender
            }).ToList());
        }
    }
}
