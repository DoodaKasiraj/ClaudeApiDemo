using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Patients.Data;
using Patients.Models;

namespace Patients.Repositories
{
    public class PatientRepository :IPatientRepository
    {
        private readonly Container _container;

        public PatientRepository(CosmosDbContext context)
        {
            _container = context.PatientsContainer;
        }

        public async Task CreatePatientAsync(Patient patient)
        {
            Console.WriteLine(
                System.Text.Json.JsonSerializer.Serialize(patient));

            await _container.CreateItemAsync(
                patient,
                new PartitionKey(patient.id));
        }

        public async Task<List<Patient>> GetPatientsAsync()
        {
            var patients = new List<Patient>();

            var query = _container.GetItemQueryIterator<Patient>(
                "SELECT * FROM c");

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                patients.AddRange(response);
            }

            return patients;
        }
    }
}
