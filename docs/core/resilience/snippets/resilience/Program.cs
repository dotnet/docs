using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Resilience;
using Microsoft.Extensions.Resilience.FaultInjection;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddResilienceEnrichment();

builder.Services.AddFaultInjection(static options =>
{
    options.Configure(static options =>
    {
        options.ChaosPolicyOptionsGroups[""] = new()
        {
            LatencyPolicyOptions = new LatencyPolicyOptions(),
            ExceptionPolicyOptions = new ExceptionPolicyOptions()
        };
    });

    options.AddException("http", new HttpRequestException());

    // options.AddCustomResult("obj", new HttpResponseMessage());
});
