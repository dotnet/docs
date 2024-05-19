using System.Text;
using CommandLine;
using DotNet.GitHubAction;
using DotNet.GitHubAction.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using static CommandLine.Parser;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddGitHubActionServices();

using IHost host = builder.Build();

ParserResult<ActionInputs> parser = Default.ParseArguments<ActionInputs>(() => new(), args);
parser.WithNotParsed(
    errors =>
    {
        host.Services
            .GetRequiredService<ILoggerFactory>()
            .CreateLogger("DotNet.GitHubAction.Program")
            .LogError("{Errors}", string.Join(
                Environment.NewLine, errors.Select(error => error.ToString())));

        Environment.Exit(2);
    });

await parser.WithParsedAsync(
    async options => await StartAnalysisAsync(options, host));

await host.RunAsync();

static async ValueTask StartAnalysisAsync(ActionInputs inputs, IHost host)
{
    // Omitted for brevity, here is the pseudo code:
    // - Read projects
    // - Calculate code metric analytics
    // - Write the CODE_METRICS.md file
    // - Set the outputs

    var updatedMetrics = true;
    var title = "Updated 2 projects";
    var summary = "Calculated code metrics on two projects.";

    // Do the work here...

    // Write GitHub Action workflow outputs.
    var gitHubOutputFile = Environment.GetEnvironmentVariable("GITHUB_OUTPUT");
    if (!string.IsNullOrWhiteSpace(gitHubOutputFile))
    {
        using StreamWriter textWriter = new(gitHubOutputFile, true, Encoding.UTF8);
        textWriter.WriteLine($"updated-metrics={updatedMetrics}");
        textWriter.WriteLine($"summary-title={title}");
        textWriter.WriteLine($"summary-details={summary}");
    }

    await ValueTask.CompletedTask;

    Environment.Exit(0);
}
