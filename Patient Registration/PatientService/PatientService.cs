using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iMedOneDB.Models;

namespace Patient_Registration.PatientService
{
    public class PatientService:IPatient
    {
        public void SavePatient(IEnumerable<TBLPATIENT> objPatient)
        {
            iMedOneDB.DBContext.SaveAll<TBLPATIENT>(objPatient);
        }

        public IEnumerable<TBLPATIENT> GetPatient()
        {
          return iMedOneDB.DBContext.GetData<TBLPATIENT>();
        }
    }
}
