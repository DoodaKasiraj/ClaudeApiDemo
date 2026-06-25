using Patients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Patients.Models;

namespace Patients.Repositories
{
    public interface IPatientRepository
    {
        Task CreatePatientAsync(Patient patient);

        Task<List<Patient>> GetPatientsAsync();
    }
}
