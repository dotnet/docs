---
title: Authenticate .NET apps to Azure services during local development using service principals
description: Learn how to authenticate your app to Azure services during local development using dedicated application service principals.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-azurecli
ms.date: 03/11/2025
---

# Authenticate .NET apps to Azure services during local development using service principals

During local development, applications need to authenticate to Azure to access various Azure services. Two common approaches for local authentication are to [use a developer account](local-development-dev-accounts.md) or a service principal. This article explains how to use an application service principal. In the sections ahead, you learn:

- How to register an application with Microsoft Entra to create a service principal
- How to use Microsoft Entra groups to efficiently manage permissions
- How to assign roles to scope permissions
- How to authenticate using a service principal from your app code

Using dedicated application service principals allows you to adhere to the principle of least privilege when accessing Azure resources. Permissions are limited to the specific requirements of the app during development, preventing accidental access to Azure resources intended for other apps or services. This approach also helps avoid issues when the app is moved to production by ensuring it isn't over-privileged in the development environment.

:::image type="content" source="../media/local-dev-service-principal-overview.png" alt-text="A diagram showing how a local .NET app uses the developer's credentials to connect to Azure by using locally installed development tools.":::

When the app is registered in Azure, an application service principal is created. For local development:

- Create a separate app registration for each developer working on the app to ensure each developer has their own application service principal, avoiding the need to share credentials.
- Create a separate app registration for each app to limit the app's permissions to only what is necessary.

During local development, environment variables are set with the application service principal's identity. The Azure Identity library reads these environment variables to authenticate the app to the required Azure resources.

[!INCLUDE [create-app-registration](../includes/auth-create-app-registration.md)]

[!INCLUDE [create-entra-group](../includes/auth-create-entra-group.md)]

[!INCLUDE [auth-assign-group-roles](../includes/auth-assign-group-roles.md)]

[!INCLUDE [auth-set-environment-variables](../includes/auth-set-environment-variables.md)]

[!INCLUDE [Implement Service Principal](<../includes/implement-service-principal.md>)]
