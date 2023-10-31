using Microsoft.Extensions.Diagnostics.Probes;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// Commented out as this is experimental...
// builder.Services.AddKubernetesProbes();

var app = builder.Build();

app.Run();
