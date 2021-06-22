using System;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using DotNet.GitHubAction;
using DotNet.GitHubAction.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using static CommandLine.Parser;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) => services.AddGitHubActionServices())
    .Build();

static TService Get<TService>(IHost host)
    where TService : notnull =>
    host.Services.GetRequiredService<TService>();

var parser = Default.ParseArguments<ActionInputs>(() => new(), args);
parser.WithNotParsed(
    errors =>
    {
        Get<ILoggerFactory>(host)
            .CreateLogger("DotNet.GitHubAction.Program")
            .LogError(
                string.Join(
                    Environment.NewLine, errors.Select(error => error.ToString())));
        
        Environment.Exit(2);
    });

await parser.WithParsedAsync(options => StartAnalysisAsync(options, host));
await host.RunAsync();

static async Task StartAnalysisAsync(ActionInputs inputs, IHost host)
{
    // Omitted for brevity, here is the preudo code:
    // - Read projects
    // - Calculate code metric analytics
    // - Write the CODE_METRICS.md file
    // - Set the outputs

    var updatedMetrics = true;
    var title = "Updated 2 projects";
    var summary = "Calculated code metrics on two projects.";

    // Do the work here...

    Console.WriteLine($"::set-output name=updated-metrics::{updatedMetrics}");
    Console.WriteLine($"::set-output name=summary-title::{title}");
    Console.WriteLine($"::set-output name=summary-details::{summary}");

    await Task.CompletedTask;

    Environment.Exit(0);
}
