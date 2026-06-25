using Patients.Models;
using Patients.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patients.Models;
using Patients.Repositories;


namespace Patients.services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task CreatePatientAsync(Patient patient)
        {
            await _repository.CreatePatientAsync(patient);
        }

        public async Task<List<Patient>> GetPatientsAsync()
        {
            return await _repository.GetPatientsAsync();
        }
    }
}
