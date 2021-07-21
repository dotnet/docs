---
title: Create a test validation GitHub Action
description: In this quickstart, you will learn how to create a GitHub Action to test your .NET source code.
author: IEvangelist
ms.author: dapine
ms.date: 07/06/2021
ms.topic: quickstart
recommendations: false
---

# Quickstart: Create a test validation GitHub Action

In this quickstart, you will learn how to create a GitHub Action to test your .NET source code. Automatically testing your .NET code within GitHub is referred to as continuous integration (CI), where pull requests or changes to the source trigger workflows to exercise. Along with [building the source code](dotnet-build-github-action.md), testing ensures that the compiled source code functions as the author intended. More often than not, unit tests serve as immediate feedback-loop to help ensure the validity of changes to source code.

[!INCLUDE [prerequisites](includes/prerequisites.md)]

[!INCLUDE [add-github-workflow](includes/add-github-workflow.md)]

Create a new file named *build-and-test.yml*, copy and paste the following YML contents into it:

:::code language="yml" source="snippets/dotnet-test-github-action/build-and-test.yml":::

In the preceding workflow composition:

- The `name: build and test` defines the name, "build and test" will appear in workflow status badges.

  :::code language="yml" source="snippets/dotnet-test-github-action/build-and-test.yml" range="1":::

- The `on` node signifies the events that trigger the workflow:

  :::code language="yml" source="snippets/dotnet-test-github-action/build-and-test.yml" range="3-9":::

  - Triggered when a `push` or `pull_quest` occurs on the `main` branch where any files changed ending with the *.cs* or *.csproj* file extensions.

- The `env` node defines named environment variables (env var).

  :::code language="yml" source="snippets/dotnet-test-github-action/build-and-test.yml" range="11-12":::

  - The environment variable `DOTNET_VERSION` is assigned the value `'5.0.301'`. The environment variable is later referenced to specify the `dotnet-version` of the `actions/setup-dotnet@v1` GitHub Action.

- The `jobs` node builds out the steps for the workflow to take.

  :::code language="yml" source="snippets/dotnet-test-github-action/build-and-test.yml" range="14-37" highlight="2,4-8,13-15,18,21,24":::

  - There is a single job, named `build-<os>` where the `<os>` is the operating system name from the `strategy/matrix`. The `name` and `runs-on` elements are dynamic for each value in the `matrix/os`. This will run on the latest versions of Ubuntu, Windows, and macOS.
  - The `actions/setup-dotnet@v1` GitHub Action is used to setup the .NET SDK with the specified version from the `DOTNET_VERSION` environment variable.
  - The [`dotnet restore`](../core/tools/dotnet-restore.md) command is called.
  - The [`dotnet build`](../core/tools/dotnet-build.md) command is called.
  - The [`dotnet test`](../core/tools/dotnet-test.md) command is called.

[!INCLUDE [add-status-badge](includes/add-status-badge.md)]

### Example test workflow status badge

| Passing | Failing | No status |
|--|--|--|
| :::image type="content" source="media/test-badge-passing.svg" alt-text="GitHub: test passing badge"::: | :::image type="content" source="media/test-badge-failing.svg" alt-text="GitHub: test failing badge"::: | :::image type="content" source="media/test-badge-no-status.svg" alt-text="GitHub: test no-status badge"::: |

## See also

- [dotnet restore](../core/tools/dotnet-restore.md)
- [dotnet build](../core/tools/dotnet-build.md)
- [dotnet test](../core/tools/dotnet-test.md)
- [Unit testing .NET apps](../core/testing/unit-testing-with-dotnet-test.md)
- [actions/checkout](https://github.com/actions/checkout)
- [actions/setup-dotnet](https://github.com/actions/setup-dotnet)

## Next steps

> [!div class="nextstepaction"]
> [Quickstart: Create a GitHub Action to publish your .NET app](dotnet-publish-github-action.md)
