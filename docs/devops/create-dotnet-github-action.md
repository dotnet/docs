---
title: "Tutorial: Create a GitHub Action with .NET"
description: Learn how to create a GitHub Action with a containerized .NET app.
author: IEvangelist
ms.author: dapine
ms.date: 07/06/2021
ms.topic: tutorial
recommendations: false
---

# Tutorial: Create a GitHub Action with .NET

Learn how to create a .NET app that can be used as a GitHub Action. [GitHub Actions](https://github.com/features/actions) enable workflow automation and composition. With GitHub Actions, you can build, test, and deploy source code from GitHub. Additionally, actions expose the ability to programmatically interact with issues, create pull requests, perform code reviews, and manage branches. For more information on continuous integration with GitHub Actions, see [Building and testing .NET](https://docs.github.com/actions/guides/building-and-testing-net).

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Prepare a .NET app for GitHub Actions
> - Define action inputs and outputs
> - Compose a workflow

## Prerequisites

- A [GitHub account](https://github.com/join)
- The [.NET 5 SDK or later](https://dotnet.microsoft.com/download/dotnet)
- A .NET integrated development environment (IDE)
  - Feel free to use the [Visual Studio IDE](https://visualstudio.microsoft.com)

## The intent of the app

The app in this tutorial performs code metric analysis by:

- Scanning and discovering *\*.csproj* and *\*.vbproj* project files.
- Analyzing the discovered source code within these projects for:

  - Cyclomatic complexity
  - Maintainability index
  - Depth of inheritance
  - Class coupling
  - Number of lines of source code
  - Approximated lines of executable code

- Creating (or updating) a *CODE_METRICS.md* file.

The app is *not* responsible for creating a pull request with the changes to the *CODE_METRICS.md* file. These changes are managed as part of the [workflow composition](#workflow-composition).

References to the source code in this tutorial have portions of the app omitted for brevity. The complete app code is [available on GitHub](https://github.com/dotnet/samples/tree/main/github-actions/DotNet.GitHubAction).

### Explore the app

The .NET console app uses the [`CommandLineParser` NuGet](https://www.nuget.org/packages/CommandLineParser/) package to parse arguments into the `ActionInputs` object.

:::code language="csharp" source="snippets/create-dotnet-github-action/DotNet.GitHubAction/ActionInputs.cs":::

The preceding action inputs class defines several required inputs for the app to run successfully. The constructor will write the `"GREETINGS"` environment variable value, if one is available in the current execution environment. The `Name` and `Branch` properties are parsed and assigned from the last segment of a `"/"` delimited string.

With the defined action inputs class, focus on the *Program.cs* file.

:::code language="csharp" source="snippets/create-dotnet-github-action/DotNet.GitHubAction/Program.cs":::

The `Program` file is simplified for brevity, to explore the full sample source, see [*Program.cs*](https://github.com/dotnet/samples/blob/main/github-actions/DotNet.GitHubAction/DotNet.GitHubAction/Program.cs). The mechanics in place demonstrate the boilerplate code required to use:

- [Top-level statements](../csharp/whats-new/tutorials/top-level-statements.md)
- [Generic Host](../core/extensions/generic-host.md)
- [Dependency injection](../core/extensions/dependency-injection.md)

External project or package references can be used, and registered with dependency injection. The `Get<TService>` is a static local function, which requires the `IHost` instance, and is used to resolve required services. With the `CommandLine.Parser.Default` singleton, the app gets a `parser` instance from the `args`. When the arguments are unable to be parsed, the app exits with a non-zero exit code. For more information, see [Setting exit codes for actions](https://docs.github.com/actions/creating-actions/setting-exit-codes-for-actions).

When the args are successfully parsed, the app was called correctly with the required inputs. In this case, a call to the primary functionality `StartAnalysisAsync` is made.

To write output values, you must follow the format recognized by [GitHub Actions: Setting an output parameter](https://docs.github.com/actions/reference/workflow-commands-for-github-actions#setting-an-output-parameter).

## Prepare the .NET app for GitHub Actions

GitHub Actions support two variations of app development, either

- JavaScript (optionally [TypeScript](https://www.typescriptlang.org))
- Docker container (any app that runs on [Docker](https://docs.github.com/actions/creating-actions/creating-a-docker-container-action))

Since .NET is *not* natively supported by GitHub Actions, the .NET app needs to be containerized. For more information, see [Containerize a .NET app](../core/docker/build-container.md).

### The Dockerfile

A [*Dockerfile*](https://docs.docker.com/engine/reference/builder) is a set of instructions to build an image. For .NET applications, the *Dockerfile* usually sits in the root of the directory next to a solution file.

:::code language="dockerfile" source="snippets/create-dotnet-github-action/Dockerfile" highlight="23":::

> [!NOTE]
> The .NET app in this tutorial relies on the .NET SDK as part of its functionality, as such, the highlighted line relayers the .NET SDK anew with the build output. For applications that ***do not*** require the .NET SDK as part of their functionality, they should rely on just the .NET Runtime instead. This greatly reduces the size of the image.
>
> ```dockerfile
> FROM mcr.microsoft.com/dotnet/runtime:5.0
> ```

The preceding *Dockerfile* steps include:

- Setting the base image from `mcr.microsoft.com/dotnet/sdk:5.0` as the alias `build-env`.
- Copying the contents and publishing the .NET app:
  - The app is published using the [`dotnet publish`](../core/tools/dotnet-publish.md) command.
- Applying labels to the container.
- Relayering the .NET SDK image from `mcr.microsoft.com/dotnet/sdk:5.0`
- Copying the published build output from the `build-env`.
- Defining the entry point, which delegates to [`dotnet /DotNet.GitHubAction.dll`](../core/tools/dotnet.md).

> [!TIP]
> The MCR in `mcr.microsoft.com` stands for "Microsoft Container Registry", and is Microsoft's syndicated container catalog from the official Docker hub. For more information, see [Microsoft syndicates container catalog](https://azure.microsoft.com/blog/microsoft-syndicates-container-catalog/).

> [!CAUTION]
> If you use a *global.json* file to pin the SDK version, you should explicitly refer to that version in your *Dockerfile*. For example, if you've used *global.json* to pin SDK version `5.0.300`, your *Dockerfile* should use `mcr.microsoft.com/dotnet/sdk:5.0.300`. This prevents breaking the GitHub Action when a new minor revision is released.

## Define action inputs and outputs

In the [Explore the app](#explore-the-app) section, you learned about the `ActionInputs` class. This object represents the inputs for the GitHub Action. For GitHub to recognize that the repository is a GitHub Action, you need to have an *action.yml* file at the root of the repository.

:::code language="yml" source="snippets/create-dotnet-github-action/action.yml":::

The preceding *action.yml* file defines:

- The `name` and `description` of the GitHub Action
- The `branding`, which is used in the [GitHub Marketplace](https://github.com/marketplace?type=actions) to help more uniquely identify your action
- The `inputs`, which maps one-to-one with the `ActionInputs` class
- The `outputs`, which is written to in the `Program` and used as part of [Workflow composition](#workflow-composition)
- The `runs` node, which tells GitHub that the app is a `docker` application and what arguments to pass to it

For more information, see [Metadata syntax for GitHub Actions](https://docs.github.com/actions/creating-actions/metadata-syntax-for-github-actions).

## Workflow composition

With the [.NET app containerized](#prepare-the-net-app-for-github-actions), and the [action inputs and outputs](#define-action-inputs-and-outputs) defined, you're ready to consume the action. GitHub Actions are *not* required to be published in the GitHub Marketplace to be used. Workflows are defined in the *.github/workflows* directory of a repository as YAML files.

:::code language="yml" source="snippets/create-dotnet-github-action/workflow.yml":::

> [!IMPORTANT]
> For containerized GitHub Actions, you're required to use `runs-on: ubuntu-latest`. For more information, see [Workflow syntax `jobs.<job_id>.runs-on`](https://docs.github.com/actions/reference/workflow-syntax-for-github-actions#jobsjob_idruns-on).

The preceding workflow YAML file defines three primary nodes:

- The `name` of the workflow. This name is also what's used when creating a [workflow status badge](https://docs.github.com/actions/managing-workflow-runs/adding-a-workflow-status-badge).
- The `on` node defines when and how the action is triggered.
- The `jobs` node outlines the various jobs and steps within each job. Individual steps consume GitHub Actions.

For more information, see [Creating your first workflow](https://docs.github.com/actions/quickstart#creating-your-first-workflow).

Focusing on the `steps` node, the composition is more obvious:

:::code language="yml" source="snippets/create-dotnet-github-action/workflow.yml" range="22-47":::

The `jobs/steps` represents the *workflow composition*. Steps are orchestrated such that they're sequential, communicative, and composable. With various GitHub Actions representing steps, each having inputs and outputs, workflows can be composed.

In the preceding steps, you can observe:

1. The repository is [checked out](https://github.com/actions/checkout).
1. A message is printed to the workflow log, when [manually ran](https://github.blog/changelog/2020-07-06-github-actions-manual-triggers-with-workflow_dispatch).
1. A step identified as `dotnet-code-metrics`:

    - `uses: dotnet/samples/github-actions/DotNet.GitHubAction@main` is the location of the containerized .NET app in this tutorial.
    - `env` creates an environment variable `"GREETING"`, which is printed in the execution of the app.
    - `with` specifies each of the required action inputs.

1. A conditional step, named `Create pull request` runs when the `dotnet-code-metrics` step specifies an output parameter of `updated-metrics` with a value of `true`.

> [!IMPORTANT]
> GitHub allows for the creation of [encrypted secrets](https://docs.github.com/actions/reference/encrypted-secrets). Secrets can be used within workflow composition, using the `${{ secrets.SECRET_NAME }}` syntax. In the context of a GitHub Action, there is a GitHub token that is automatically populated by default: `${{ secrets.GITHUB_TOKEN }}`. For more information, see [Context and expression syntax for GitHub Actions](https://docs.github.com/actions/reference/context-and-expression-syntax-for-github-actions).

## Put it all together

The [dotnet/samples](https://github.com/dotnet/samples) GitHub repository is home to many .NET sample source code projects, including [the app in this tutorial](https://github.com/dotnet/samples/tree/main/github-actions/DotNet.GitHubAction).

The generated [*CODE_METRICS.md*](https://github.com/dotnet/samples/blob/main/github-actions/DotNet.GitHubAction/CODE_METRICS.md) file is navigable. This file represents the hierarchy of the projects it analyzed. Each project has a top-level section, and an emoji the represents the overall status of the highest cyclomatic complexity for nested objects. As you navigate the file, each section exposes drill-down opportunities with a summary of each area. The markdown has collapsible sections as an added convenience.

The hierarchy progresses from:

- Project file to assembly
- Assembly to namespace
- Namespace to named-type
- Each named-type has a table, and each table has:
  - Links to line numbers for fields, methods, and properties
  - Individual ratings for code metrics

### In action

The workflow specifies that `on` a `push` to the `main` branch, the action is triggered to run. When it runs, the **Actions** tab in GitHub will report the live log stream of its execution. Here is an example log from the `.NET code metrics` run:

:::image type="content" source="media/action-log.png" lightbox="media/action-log.png" border="true" alt-text=".NET code metrics - GitHub Action log":::

## See also

<!-- TODO: Add DevOps eBook link when published -->

- [.NET Generic Host](../core/extensions/generic-host.md)
- [Dependency injection in .NET](../core/extensions/dependency-injection.md)
- [Code metrics values](/visualstudio/code-quality/code-metrics-values)

## Next steps

> [!div class="nextstepaction"]
> [.NET GitHub Action sample code](/samples/dotnet/samples/create-dotnet-github-action)
