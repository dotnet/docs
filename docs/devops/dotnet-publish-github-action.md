---
title: Create a GitHub Action to publish your .NET app
description: In this quickstart, you will learn how to create a GitHub Action to publish your .NET source code.
author: IEvangelist
ms.author: dapine
ms.date: 07/01/2021
ms.topic: quickstart
recommendations: false
---

# Quickstart: Create a GitHub Action to publish your .NET app

In this quickstart, you will learn how to create a GitHub Action to publish your .NET app from source code. Automatically publishing your .NET app from GitHub to a destination is referred to as continuous deployment (CD). There are many possible destinations to publish an application, in this quickstart you'll publish to Azure.

## Prerequisites

- A [GitHub account](https://github.com/join).
- An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/free/dotnet).
- An ASP.NET Core web app.
- An Azure App Service resource.
- The [.NET 5.0 SDK or later](https://dotnet.microsoft.com/download/dotnet).
- A .NET integrated development environment (IDE).
  - *Feel free to use the [Visual Studio IDE](https://visualstudio.microsoft.com)*.

[!INCLUDE [add-github-workflow](includes/add-github-workflow.md)]

Create a new file named *publish-app.yml*, copy and paste the following YML contents into it:

:::code language="yml" source="snippets/publish-action/publish-app.yml":::

In the preceding workflow composition:

- The `name: publish` defines the name, "publish" will appear in workflow status badges.

  :::code language="yml" source="snippets/publish-action/publish-app.yml" range="1":::

- The `on` node signifies the events that trigger the workflow:

  :::code language="yml" source="snippets/publish-action/publish-app.yml" range="3-5":::

  - Triggered when a `push` occurs on the `production` branch.

- The `env` node defines named environment variables (env var).

  :::code language="yml" source="snippets/publish-action/publish-app.yml" range="7-10":::

  - The environment variable `AZURE_WEBAPP_NAME` is assigned the value `DotNetWeb`.
  - The environment variable `AZURE_WEBAPP_PACKAGE_PATH` is assigned the value `'.'`.
  - The environment variable `DOTNET_VERSION` is assigned the value `'5.0.301'`. The environment variable is later referenced to specify the `dotnet-version` of the `actions/setup-dotnet@v1` GitHub Action.

- The `jobs` node builds out the steps for the workflow to take.

  :::code language="yml" source="snippets/publish-action/publish-app.yml" range="12-42" highlight="2,4,9-11,14,19-20,24,26-31":::

  - There is a single job, named `publish` that will run on the latest version of Ubuntu.
  - The `actions/setup-dotnet@v1` GitHub Action is used to setup the .NET SDK with the specified version from the `DOTNET_VERSION` environment variable.
  - The [`dotnet restore`](../core/tools/dotnet-restore.md) command is called.
  - The [`dotnet build`](../core/tools/dotnet-build.md) command is called.
  - The [`dotnet publish`](../core/tools/dotnet-publish.md) command is called.
  - The [`dotnet test`](../core/tools/dotnet-test.md) command is called.
  - The `azure/webapps-deploy@v2` GitHub Action deploys the app with the given `publish-profile` and `package`.

[!INCLUDE [add-status-badge](includes/add-status-badge.md)]

### Example publish workflow status badge

| Passing | Failing | No status |
|--|--|--|
| :::image type="content" source="../media/publish-badge-passing.svg" alt-text="GitHub: publish passing badge"::: | :::image type="content" source="../media/publish-badge-failing.svg" alt-text="GitHub: publish failing badge"::: | :::image type="content" source="../media/publish-badge-no-status.svg" alt-text="GitHub: publish no-status badge"::: |

## See also

- [dotnet restore](../core/tools/dotnet-restore.md)
- [dotnet build](../core/tools/dotnet-build.md)
- [dotnet test](../core/tools/dotnet-test.md)
- [dotnet publish](../core/tools/dotnet-publish.md)

## Next steps

> [!div class="nextstepaction"]
> [Quickstart: Create a CodeQL GitHub Action](dotnet-secure-github-action.md)
