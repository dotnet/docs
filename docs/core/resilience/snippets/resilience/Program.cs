using System.Net;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Resilience;
using Microsoft.Extensions.Resilience.FaultInjection;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddResilienceEnrichment();

builder.Services.AddFaultInjection(static builder =>
{
    _ = builder.Configure(static options =>
    {
        options.ChaosPolicyOptionsGroups[""] = new()
        {
            LatencyPolicyOptions = new LatencyPolicyOptions(),
            ExceptionPolicyOptions = new ExceptionPolicyOptions()
        };
    });

    _ = builder.AddException("http", new HttpRequestException());
});

builder.Services.ConfigureFailureResultContext<HttpResponseMessage>(
    configure: static response => response is not null
        ? FailureResultContext.Create(
            failureSource:
                response.ReasonPhrase = "Fault injection",
            failureReason:
                (response.StatusCode = HttpStatusCode.InternalServerError)
                    .ToString())
        : FailureResultContext.Create());

IHost host = builder.Build();

await host.RunAsync();
