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
> - Containerize the .NET app
> - Define action inputs and outputs
> - Compose the workflow

## Prerequisites

- A [GitHub account](https://github.com/join)
- The [.NET 5.0 SDK or later](https://dotnet.microsoft.com/download/dotnet)
- An integrated development environment (IDE)
  - Screen captures depict the [Visual Studio IDE](https://visualstudio.microsoft.com)

## The intent of the app

The app in this tutorial performs code metric analysis, when ran it will:

- Scan and discover **.csproj* and **.vbproj* project files.
- Analyze the discovered source code for:

  - Cyclomatic complexity
  - Maintainability index
  - Depth of inheritance
  - Class coupling
  - Number of lines of source code
  - Approximated lines of executable code

- Create (or update) a *CODE_METRICS.md* file.

The app is not responsible for creating a pull request with the changes to the *CODE_METRICS.md* file. That is managed as part of the workflow composition. The complete app code is [available on GitHub](https://github.com/dotnet/samples/tree/main/github-actions/DotNet.GitHubAction).


### Create action inputs class

Open the project in your favorite .NET IDE, and create a new class named *ActionInputs.cs*.

- From **Visual Studio**, right-click on the project and select **Add** > **Class**.
- From **Visual Studio Code**, in the Explorer, select **New File**.

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

The preceding action inputs class defines several required inputs for your console application to run successfully. The constructor will write the `"GREETINGS"` environment variable value, if one is available in the current execution environment. The `Name` and `Branch` properties are parsed and assigned from the last segment of a `"/"` delimited string.

### Update the program file

With the action inputs class defined, copy and paste the following C# source code and replace the *Program.cs* file contents.

:::code language="csharp" source="snippets/DotNet.GitHubAction/Program.cs":::

<https://docs.github.com/actions/reference/workflow-commands-for-github-actions#setting-an-output-parameter>

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

## See also

- [.NET Generic Host](../core/extensions/generic-host.md)
- [Dependency injection in .NET](../core/extensions/dependency-injection.md)

## Next steps

> [!div class="nextstepaction"]
> [.NET GitHub Action sample code](contribute-how-to-mvc-tutorial.md)
