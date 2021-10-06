---
title: Create a publish app GitHub Action
description: In this quickstart, you will learn how to create a GitHub Action to publish your .NET source code.
author: IEvangelist
ms.author: dapine
ms.date: 10/05/2021
ms.topic: quickstart
recommendations: false
---

# Quickstart: Create a publish app GitHub Action

In this quickstart, you will learn how to create a GitHub Action to publish your .NET app from source code. Automatically publishing your .NET app from GitHub to a destination is referred to as a continuous deployment (CD). There are many possible destinations to publish an application, in this quickstart you'll publish to Azure.

## Prerequisites

- A [GitHub account](https://github.com/join).
- A .NET source code repository.
- An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/free/dotnet).
- An ASP.NET Core web app.
- An Azure App Service resource.

## Add publish profile

To publish the app to Azure, open the Azure portal for the App Service instance of the application. In the resource **Overview**, select **Get publish profile** and save the **.PublishSetting* file locally.

:::image type="content" source="media/get-publish-profile.png" alt-text="Azure Portal, App Service resource: Get publish profile":::

> [!WARNING]
> The publish profile contains sensitive information, such as credentials for accessing your Azure App Service resource. This information should always be treated very carefully.

In the GitHub repository, navigate to **Settings** and select **Secrets** from the left navigation menu. Select **New repository secret**, to add a new secret.

:::image type="content" source="media/github-secret-azure-publish-profile.png" alt-text="GitHub / Settings / Secret: Add new repository secret":::

Enter `AZURE_PUBLISH_PROFILE` as the **Name**, and paste the XML content from the publish profile into the **Value** text area. Select **Add secret**. For more information, see [Encrypted secrets](github-actions-overview.md#encrypted-secrets).

[!INCLUDE [add-github-workflow](includes/add-github-workflow.md)]

Create a new file named *publish-app.yml*, copy and paste the following YML contents into it:

:::code language="yml" source="snippets/dotnet-publish-github-action/publish-app.yml":::

In the preceding workflow composition:

- The `name: publish` defines the name, "publish" will appear in workflow status badges.

  :::code language="yml" source="snippets/dotnet-publish-github-action/publish-app.yml" range="1":::

- The `on` node signifies the events that trigger the workflow:

  :::code language="yml" source="snippets/dotnet-publish-github-action/publish-app.yml" range="3-5":::

  - Triggered when a `push` occurs on the `production` branch.

- The `env` node defines named environment variables (env var).

  :::code language="yml" source="snippets/dotnet-publish-github-action/publish-app.yml" range="7-10":::

  - The environment variable `AZURE_WEBAPP_NAME` is assigned the value `DotNetWeb`.
  - The environment variable `AZURE_WEBAPP_PACKAGE_PATH` is assigned the value `'.'`.
  - The environment variable `DOTNET_VERSION` is assigned the value `'5.0.301'`. The environment variable is later referenced to specify the `dotnet-version` of the `actions/setup-dotnet@v1` GitHub Action.

- The `jobs` node builds out the steps for the workflow to take.

  :::code language="yml" source="snippets/dotnet-publish-github-action/publish-app.yml" range="12-42" highlight="2,4,9-11,14,19-20,24,26-31":::

  - There is a single job, named `publish` that will run on the latest version of Ubuntu.
  - The `actions/setup-dotnet@v1` GitHub Action is used to set up the .NET SDK with the specified version from the `DOTNET_VERSION` environment variable.
  - The [`dotnet restore`](../core/tools/dotnet-restore.md) command is called.
  - The [`dotnet build`](../core/tools/dotnet-build.md) command is called.
  - The [`dotnet publish`](../core/tools/dotnet-publish.md) command is called.
  - The [`dotnet test`](../core/tools/dotnet-test.md) command is called.
  - The `azure/webapps-deploy@v2` GitHub Action deploys the app with the given `publish-profile` and `package`.
    - The `publish-profile` is assigned from the `AZURE_PUBLISH_PROFILE` repository secret.

[!INCLUDE [add-status-badge](includes/add-status-badge.md)]

### Example publish workflow status badge

| Passing | Failing | No status |
|--|--|--|
| :::image type="content" source="media/publish-badge-passing.svg" alt-text="GitHub: publish passing badge"::: | :::image type="content" source="media/publish-badge-failing.svg" alt-text="GitHub: publish failing badge"::: | :::image type="content" source="media/publish-badge-no-status.svg" alt-text="GitHub: publish no-status badge"::: |

## See also

- [dotnet restore](../core/tools/dotnet-restore.md)
- [dotnet build](../core/tools/dotnet-build.md)
- [dotnet test](../core/tools/dotnet-test.md)
- [dotnet publish](../core/tools/dotnet-publish.md)

## Next steps

> [!div class="nextstepaction"]
> [Quickstart: Create a CodeQL GitHub Action](dotnet-secure-github-action.md)
