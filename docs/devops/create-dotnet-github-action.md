---
title: "Tutorial: Create a GitHub Action with .NET"
description: Learn how to create a GitHub Action with a containerized .NET app.
author: IEvangelist
ms.author: dapine
ms.date: 07/11/2022
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
- The [.NET 6 SDK or later](https://dotnet.microsoft.com/download/dotnet)
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

The virtual environment where the GitHub Action is hosted may or may not have .NET installed. For information about what is preinstalled in the target environment, see [GitHub Actions Virtual Environments](https://github.com/actions/virtual-environments). While it's possible to run .NET CLI commands from the GitHub Actions workflows, for a more fully functioning .NET-based GitHub Action, we recommend that you containerize the app. For more information, see [Containerize a .NET app](../core/docker/build-container.md).

### The Dockerfile

A [*Dockerfile*](https://docs.docker.com/engine/reference/builder) is a set of instructions to build an image. For .NET applications, the *Dockerfile* usually sits in the root of the directory next to a solution file.

:::code language="dockerfile" source="snippets/create-dotnet-github-action/Dockerfile" highlight="24":::

> [!NOTE]
> The .NET app in this tutorial relies on the .NET SDK as part of its functionality. The _Dockerfile_ creates a new set of Docker layers, independent from the previous ones. It starts from scratch with the SDK image, and adds the build output from the previous set of layers. For applications that ***do not*** require the .NET SDK as part of their functionality, they should rely on just the .NET Runtime instead. This greatly reduces the size of the image.
>
> ```dockerfile
> FROM mcr.microsoft.com/dotnet/runtime:6.0
> ```

> [!WARNING]
> Pay close attention to every step within the _Dockerfile_, as it does differ from the standard _Dockerfile_ created from the "add docker support" functionality. In particular, the last few steps vary by not specifying a new `WORKDIR` which would change the path to the app's `ENTRYPOINT`.

The preceding *Dockerfile* steps include:

- Setting the base image from `mcr.microsoft.com/dotnet/sdk:6.0` as the alias `build-env`.
- Copying the contents and publishing the .NET app:
  - The app is published using the [`dotnet publish`](../core/tools/dotnet-publish.md) command.
- Applying labels to the container.
- Relayering the .NET SDK image from `mcr.microsoft.com/dotnet/sdk:6.0`
- Copying the published build output from the `build-env`.
- Defining the entry point, which delegates to [`dotnet /DotNet.GitHubAction.dll`](../core/tools/dotnet.md).

> [!TIP]
> The MCR in `mcr.microsoft.com` stands for "Microsoft Container Registry", and is Microsoft's syndicated container catalog from the official Docker hub. For more information, see [Microsoft syndicates container catalog](https://azure.microsoft.com/blog/microsoft-syndicates-container-catalog/).

> [!CAUTION]
> If you use a *global.json* file to pin the SDK version, you should explicitly refer to that version in your *Dockerfile*. For example, if you've used *global.json* to pin SDK version `5.0.300`, your *Dockerfile* should use `mcr.microsoft.com/dotnet/sdk:5.0.300`. This prevents breaking the GitHub Actions when a new minor revision is released.

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

### Pre-defined environment variables

With GitHub Actions, you'll get a lot of [environment variables](https://docs.github.com/actions/learn-github-actions/environment-variables#default-environment-variables) by default. For instance, the variable `GITHUB_REF` will always contain a reference to the branch or tag that triggered the workflow run. `GITHUB_REPOSITORY` has the owner and repository name, for example, `dotnet/docs`.

You should explore the pre-defined environment variables and use them accordingly.

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

:::code language="yml" source="snippets/create-dotnet-github-action/workflow.yml" range="25-50":::

The `jobs.steps` represents the *workflow composition*. Steps are orchestrated such that they're sequential, communicative, and composable. With various GitHub Actions representing steps, each having inputs and outputs, workflows can be composed.

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

The generated [*CODE_METRICS.md*](https://github.com/dotnet/samples/blob/main/github-actions/DotNet.GitHubAction/CODE_METRICS.md) file is navigable. This file represents the hierarchy of the projects it analyzed. Each project has a top-level section, and an emoji that represents the overall status of the highest cyclomatic complexity for nested objects. As you navigate the file, each section exposes drill-down opportunities with a summary of each area. The markdown has collapsible sections as an added convenience.

The hierarchy progresses from:

- Project file to assembly
- Assembly to namespace
- Namespace to named-type
- Each named-type has a table, and each table has:
  - Links to line numbers for fields, methods, and properties
  - Individual ratings for code metrics

### In action

The workflow specifies that `on` a `push` to the `main` branch, the action is triggered to run. When it runs, the **Actions** tab in GitHub will report the live log stream of its execution. Here is an example log from the `.NET code metrics` run:

:::image type="content" source="media/action-log.png" lightbox="media/action-log.png" border="true" alt-text=".NET code metrics - GitHub Actions log":::

## Performance improvements

If you followed along the sample, you might have noticed that every time this action is used, it will do a **docker build** for that image. So, every trigger is faced with some time to build the container before running it. Before releasing your GitHub Actions to the marketplace, you should:

1. (automatically) Build the Docker image
2. Push the docker image to the GitHub Container Registry (or any other public container registry)
3. Change the action to not build the image, but to use an image from a public registry.

```yaml
# Rest of action.yml content removed for readability
# using Dockerfile
runs:
  using: 'docker'
  image: 'Dockerfile' # Change this line
# using container image from public registry
runs:
  using: 'docker'
  image: 'docker://ghcr.io/some-user/some-registry' # Starting with docker:// is important!!
```

For more information, see [GitHub Docs: Working with the Container registry](https://docs.github.com/packages/working-with-a-github-packages-registry/working-with-the-container-registry).

## See also

- [.NET Generic Host](../core/extensions/generic-host.md)
- [Dependency injection in .NET](../core/extensions/dependency-injection.md)
- [DevOps for ASP.NET Core Developers](../architecture/devops-for-aspnet-developers/index.md)
- [Code metrics values](/visualstudio/code-quality/code-metrics-values)
- [Open-source GitHub Action build in .NET](https://github.com/svrooij/dotnet-feeder/) with a [workflow](https://github.com/svrooij/dotnet-feeder/blob/main/.github/workflows/build.yml) for building and pushing the docker image automatically.

## Next steps

> [!div class="nextstepaction"]
> [.NET GitHub Actions sample code](/samples/dotnet/samples/create-dotnet-github-action)
