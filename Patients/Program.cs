using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Azure.Functions.Worker.OpenTelemetry;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry;
using Patients.Data;
using Patients.Repositories;
using Patients.services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Patients.Data;
using Patients.Repositories;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING")))
{
    builder.Services.AddOpenTelemetry()
        .UseFunctionsWorkerDefaults()
        .UseAzureMonitorExporter();
}
// Register CosmosDbContext explicitly with the configuration instance to
// ensure the required IConfiguration is provided when the singleton is created.
builder.Services.AddSingleton(sp => new CosmosDbContext(builder.Configuration));

builder.Services.AddScoped<IPatientRepository,
                           PatientRepository>();

builder.Services.AddScoped<IPatientService,
                           PatientService>();

builder.Build().Run();
