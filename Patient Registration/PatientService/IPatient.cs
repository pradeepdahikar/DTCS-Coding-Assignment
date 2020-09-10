using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iMedOneDB.Models;

namespace Patient_Registration.PatientService
{
    public interface IPatient
    {
        void SavePatient(IEnumerable<TBLPATIENT> objPatient);

        IEnumerable<TBLPATIENT> GetPatient();
    }
}
