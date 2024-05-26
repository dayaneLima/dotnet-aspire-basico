var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.AspireBasico_ApiService>("apiservice");

builder.AddProject<Projects.AspireBasico_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.AddProject<Projects.AspireBasico_MinimalApiService>("minimalApiService");

builder.Build().Run();
