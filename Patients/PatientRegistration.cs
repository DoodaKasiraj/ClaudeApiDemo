using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Patients.Models;
using Patients.services;
using System;
using System.Net;

namespace Patients;

public class PatientRegistration
{
    private readonly IPatientService _service;

    public PatientRegistration(IPatientService service)
    {
        _service = service;
    }

    [Function("CreatePatient")]
    public async Task<HttpResponseData> CreatePatient(
    [HttpTrigger(AuthorizationLevel.Anonymous, "post")]
    HttpRequestData req)
    {
        var patient = await req.ReadFromJsonAsync<Patient>();

        Console.WriteLine($"Id={patient?.id}");
        Console.WriteLine($"Name={patient?.name}");
        Console.WriteLine($"Phone={patient?.phoneNumber}");

        await _service.CreatePatientAsync(patient);

        var response = req.CreateResponse(HttpStatusCode.OK);

        return response;
    }

    [Function("GetPatients")]
    public async Task<HttpResponseData> GetPatients(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")]
        HttpRequestData req)
    {
        var patients =
            await _service.GetPatientsAsync();

        var response =
            req.CreateResponse(HttpStatusCode.OK);

        await response.WriteAsJsonAsync(patients);

        return response;
    }
}