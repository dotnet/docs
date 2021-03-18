---
title: "Tutorial: Author GitHub Actions with .NET"
description: Learn how to create a GitHub action with a containerized .NET app.
author: IEvangelist
ms.author: dapine
ms.date: 03/18/2021
ms.topic: tutorial
---

<!-- https://docs.github.com/en/actions/creating-actions -->

# Tutorial: Author GitHub Actions with .NET

Learn how to create a .NET app that can be used as a GitHub Action. [GitHub Actions](https://github.com/features/actions) enable workflow automation and composition. With GitHub Actions, you can build, test, and deploy source code from GitHub. Additionally, actions expose the ability to programmatically interact with issues, create pull requests, perform code reviews, and manage branches. For more information on continuous integration with GitHub Actions, see [Building and testing .NET](https://docs.github.com/actions/guides/building-and-testing-net).

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Create a .NET app
> - Containerize the .NET app
> - Define action inputs and outputs
> - Compose the workflow

## Prerequisites

- A [GitHub account](https://github.com/join)
- The [.NET 5.0 SDK or later](https://dotnet.microsoft.com/download/dotnet)
- An integrated development environment (IDE)
  - Screen captures depict the [Visual Studio IDE](https://visualstudio.microsoft.com)

The companion sample source code is [available on GitHub](https://github.com/dotnet/samples/tree/main/github-actions/DotNet.GitHubAction).

## Create a .NET app

You need to create a .NET console application. From the .NET CLI in a working directory, run the [dotnet new](../core/tools/dotnet-new.md) command:

```dotnetcli
dotnet new console -n DotNet.GitHubAction
```

This will create a new directory named "DotNet.GitHubAction" that contains a *DotNet.GitHubAction.csproj* project file, and *Program.cs* source file. This is your new .NET console app. From the same command line session, change directories into the *DotNet.GitHubAction* directory, and then [run the app](../core/tools/dotnet-run.md) to verify it works correctly.

```dotnetcli
cd DotNet.GitHubAction && dotnet run
```

At this point, your app should have restored, compiled, ran, and printed `"Hello World!"` to the console.

### Add package references

Add the [`CommandLineParser` NuGet](https://www.nuget.org/packages/CommandLineParser) package to the project using the [dotnet add package](../core/tools/dotnet-add-package.md) command.

```dotnetcli
dotnet add package CommandLineParser
```

The `CommandLineParser` package is used as a convenience for parsing arguments in standard form. For more information, see [Command Line Parser on GitHub](https://github.com/commandlineparser/commandline).

You will also need to add two more package references to your project.

1. Add the hosting extensions package, [`Microsoft.Extensions.Hosting`](https://www.nuget.org/packages/Microsoft.Extensions.Hosting).

    ```dotnetcli
    dotnet add package Microsoft.Extensions.Hosting
    ```

    For more information on hosting, see [.NET Generic Host](../core/extensions/generic-host.md).

1. Add the dependency injection abstractions package, [`Microsoft.Extensions.DependencyInjection.Abstractions`](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Abstractions).

    ```dotnetcli
    dotnet add package Microsoft.Extensions.DependencyInjection.Abstractions
    ```

    For more information on dependency injection, see [Dependency injection in .NET](../core/extensions/dependency-injection.md).

### Create action inputs class

Open the project in your favorite .NET IDE, and create a new class named *ActionInputs.cs*.

- From **Visual Studio**, right-click on the project and select **Add** > **Class**
- From **Visual Studio Code**, in the Explorer, select **New File**

Copy and paste the following C# code into the newly created `ActionInputs` class.

```csharp
using System;
using CommandLine;

namespace DotNet.GitHubAction
{
    public class ActionInputs
    {
        string _repositoryName = null!;
        string _branchName = null!;

        public ActionInputs()
        {
            var greetings = Environment.GetEnvironmentVariable("GREETINGS");
            if (greetings is { Length: > 0 })
            {
                Console.WriteLine(greetings);
            }
        }

        [Option('o', "owner",
            Required = true,
            HelpText =
                "The owner, for example: \"dotnet\"." +
                "Assign from `github.repository_owner`.")]
        public string Owner { get; set; } = null!;

        [Option('n', "name",
            Required = true,
            HelpText =
                "The repository name, for example: \"samples\"." +
                "Assign from `github.repository`.")]
        public string Name
        {
            get => _repositoryName;
            set => ParseAndAssign(value, str => _repositoryName = str);
        }

        [Option('b', "branch",
            Required = true,
            HelpText =
                "The branch name, for example: \"refs/heads/main\"." +
                "Assign from `github.ref`.")]
        public string Branch
        {
            get => _branchName;
            set => ParseAndAssign(value, str => _branchName = str);
        }

        [Option('d', "dir",
            Required = true,
            HelpText = "The root directory to start recursive searching from.")]
        public string Directory { get; set; } = null!;

        [Option('w', "workspace",
            Required = true,
            HelpText = "The workspace directory, or repository root directory.")]
        public string WorkspaceDirectory { get; set; } = null!;

        static void ParseAndAssign(string? value, Action<string> assign)
        {
            if (value is { Length: > 0 } && assign is not null)
            {
                assign(value.Split("/")[^1]);
            }
        }
    }
}
```

The preceding action inputs class defines several inputs that are required in order for your console application to run successfully. The constructor will write the `"GREETINGS"` environment variable value if present. The `Name` and `Branch` properties are parsed and assigned from the segments.

### Update the program file

With the action inputs class defined, copy and paste the following C# source code and replace the *Program.cs* file contents.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommandLine;
using DotNet.CodeAnalysis;
using DotNet.GitHubAction;
using DotNet.GitHubAction.Analyzers;
using DotNet.GitHubAction.Extensions;
using Microsoft.CodeAnalysis.CodeMetrics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using static CommandLine.Parser;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) => services.AddGitHubActionServices())
    .Build();

static TService Get<TService>(IHost host)
    where TService : notnull =>
    host.Services.GetRequiredService<TService>();

static async Task StartAnalysisAsync(ActionInputs inputs, IHost host)
{
    using ProjectWorkspace workspace = Get<ProjectWorkspace>(host);
    using CancellationTokenSource tokenSource = new();

    Console.CancelKeyPress += delegate
    {
        tokenSource.Cancel();
    };

    var projectAnalyzer = Get<ProjectMetricDataAnalyzer>(host);

    Matcher matcher = new();
    matcher.AddIncludePatterns(new[] { "**/*.csproj", "**/*.vbproj" });

    Dictionary<string, CodeAnalysisMetricData> metricData = new(StringComparer.OrdinalIgnoreCase);
    var projects = matcher.GetResultsInFullPath(inputs.Directory);

    foreach (var project in projects)
    {
        var metrics =
            await projectAnalyzer.AnalyzeAsync(
                workspace, project, tokenSource.Token);

        foreach (var (path, metric) in metrics)
        {
            metricData[path] = metric;
        }
    }

    var updatedMetrics = false;
    var title = "";
    StringBuilder summary = new();
    if (metricData is { Count: > 0 })
    {
        var fileName = "CODE_METRICS.md";
        var fullPath = Path.Combine(inputs.Directory, fileName);
        var logger = Get<ILoggerFactory>(host).CreateLogger(nameof(StartAnalysisAsync));
        var fileExists = File.Exists(fullPath);

        logger.LogInformation(
            $"{(fileExists ? "Updating" : "Creating")} {fileName} markdown file with latest code metric data.");

        summary.AppendLine(
            title = $"{(fileExists ? "Updated" : "Created")} {fileName} file, analyzed metrics for {metricData.Count} projects.");

        foreach (var (path, _) in metricData)
        {
            summary.AppendLine($"- *{path}*");
        }

        await File.WriteAllTextAsync(
            fullPath,
            metricData.ToMarkDownBody(inputs),
            tokenSource.Token);

        updatedMetrics = true;
    }
    else
    {
        summary.Append("No metrics were determined.");
    }

    // https://docs.github.com/actions/reference/workflow-commands-for-github-actions#setting-an-output-parameter
    Console.WriteLine($"::set-output name=updated-metrics::{updatedMetrics}");
    Console.WriteLine($"::set-output name=summary-title::{title}");
    Console.WriteLine($"::set-output name=summary-details::{summary}");

    Environment.Exit(0);
}

var parser = Default.ParseArguments<ActionInputs>(() => new(), args);
parser.WithNotParsed(
    errors =>
    {
        Get<ILoggerFactory>(host)
            .CreateLogger("DotNet.GitHubAction.Program")
            .LogError(
                string.Join(Environment.NewLine, errors.Select(error => error.ToString())));
        
        Environment.Exit(2);
    });

await parser.WithParsedAsync(options => StartAnalysisAsync(options, host));
await host.RunAsync();
```

## Containerize a .NET app

GitHub Actions support two variations of app development, either JavaScript or Docker container. Since .NET is not natively supported, you'll need to containerize your .NET app. For more information, see [Creating a Docker container action](https://docs.github.com/actions/creating-actions/creating-a-docker-container-action).



  The idea for the app is to create / update a CODE_METRICS.md at the root of the repo's dir
  The CODE_METRICS.md file would contain data from: Code metrics output

### Create the Dockerfile

:::code language="dockerfile" source="snippets/Dockerfile":::

The preceding *Dockerfile* steps include:

- Setting the base image from `mcr.microsoft.com/dotnet/sdk:5.0` as the alias `build-env`.
- Copying the contents and publishes the .NET app:
  - This is done using the [`dotnet publish`](../core/tools/dotnet-publish.md) command.
- Applying labels to the container.
- Re-layering the .NET SDK image from `mcr.microsoft.com/dotnet/sdk:5.0`
- Copying the published build output from the `build-env`.
- Defining the entry point, which delegates to [`dotnet /DotNet.GitHubAction.dll`](../core/tools/dotnet.md).

> [!TIP]
> You may be asking yourself, "what is the `mcr.microsoft.com` url". The MCR stands for "Microsoft Container Registry", and is Microsoft's syndicated container catalog from the official Docker hub. For more information, see [Microsoft syndicates container catalog](https://azure.microsoft.com/blog/microsoft-syndicates-container-catalog/).

## Define action inputs and outputs

  Differentiate between writing an action, and consuming one
  Touch on Jobs / Steps / Marketplace

### Create the action.yml

:::code language="yml" source="snippets/action.yml":::

The preceding *action.yml* file

## Compose a consuming workflow

Show what can be done from an action
Show passing of parameters / ENV VAR / Docker / Inputs and Output
Discuss repo Secrets and ${{ secrets.GITHUB_TOKEN }}

### Create the workflow YML file

:::code language="yml" source="snippets/workflow.yml":::

The preceding workflow YAML file

## Explore workflow composition

Show a consuming GitHub action workflow

## Summary

...

## Next steps

> [!div class="nextstepaction"]
> [.NET GitHub Action sample code](contribute-how-to-mvc-tutorial.md)
