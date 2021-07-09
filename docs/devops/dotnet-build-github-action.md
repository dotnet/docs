---
title: Create a build validation GitHub Action
description: In this quickstart, you will learn how to create a GitHub Action to validate .NET app compilation.
author: IEvangelist
ms.author: dapine
ms.date: 07/06/2021
ms.topic: quickstart
recommendations: false
---

# Quickstart: Create a build validation GitHub Action

In this quickstart, you will learn how to create a GitHub Action to validate the compilation of your .NET source code in GitHub. Compiling your .NET code is one of the most basic validation steps that you can take to help ensure the quality of updates to your code. If code doesn't compile (or build), it's an easy deterrent and should be a clear sign that the code needs to be fixed.

[!INCLUDE [prerequisites](includes/prerequisites.md)]

[!INCLUDE [add-github-workflow](includes/add-github-workflow.md)]

Create a new file named *build-validation.yml*, copy and paste the following YML contents into it:

:::code language="yml" source="snippets/dotnet-build-github-action/build-validation.yml":::

In the preceding workflow composition:

- The `name: build` defines the name, "build" will appear in workflow status badges.

  :::code language="yml" source="snippets/dotnet-build-github-action/build-validation.yml" range="1":::

- The `on` node signifies the events that trigger the workflow:

  :::code language="yml" source="snippets/dotnet-build-github-action/build-validation.yml" range="3-9":::

  - Triggered when a `push` or `pull_quest` occurs on the `main` branch where any files changed ending with the *.cs* or *.csproj* file extensions.

- The `env` node defines named environment variables (env var).

  :::code language="yml" source="snippets/dotnet-build-github-action/build-validation.yml" range="11-12":::

  - The environment variable `DOTNET_VERSION` is assigned the value `'5.0.301'`. The environment variable is later referenced to specify the `dotnet-version` of the `actions/setup-dotnet@v1` GitHub Action.

- The `jobs` node builds out the steps for the workflow to take.

  :::code language="yml" source="snippets/dotnet-build-github-action/build-validation.yml" range="14-34" highlight="2,4-8,13-15,18,21":::

  - There is a single job, named `build-<os>` where the `<os>` is the operating system name from the `strategy/matrix`. The `name` and `runs-on` elements are dynamic for each value in the `matrix/os`. This will run on the latest versions of Ubuntu, Windows, and macOS.
  - The `actions/setup-dotnet@v1` GitHub Action is used to setup the .NET SDK with the specified version from the `DOTNET_VERSION` environment variable.
  - The [`dotnet restore`](../core/tools/dotnet-restore.md) command is called.
  - The [`dotnet build`](../core/tools/dotnet-build.md) command is called.

[!INCLUDE [add-status-badge](includes/add-status-badge.md)]

### Example build workflow status badge

| Passing | Failing | No status |
|--|--|--|
| :::image type="content" source="media/build-badge-passing.svg" alt-text="GitHub: build passing badge"::: | :::image type="content" source="media/build-badge-failing.svg" alt-text="GitHub: build failing badge"::: | :::image type="content" source="media/build-badge-no-status.svg" alt-text="GitHub: build no-status badge"::: |

## See also

- [dotnet restore](../core/tools/dotnet-restore.md)
- [dotnet build](../core/tools/dotnet-build.md)
- [actions/checkout](https://github.com/actions/checkout)
- [actions/setup-dotnet](https://github.com/actions/setup-dotnet)

## Next steps

> [!div class="nextstepaction"]
> [Quickstart: Create a .NET test GitHub Action](dotnet-test-github-action.md)
