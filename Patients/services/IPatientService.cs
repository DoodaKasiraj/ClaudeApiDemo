using Patients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patients.services
{
    public interface IPatientService
    {
        Task CreatePatientAsync(Patient patient);

        Task<List<Patient>> GetPatientsAsync();
    }
}
