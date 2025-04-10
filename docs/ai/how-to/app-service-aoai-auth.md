---
title: "Authenticate an Azure hosted .NET app to Azure OpenAI using Microsoft Entra ID"
description: "Learn how to authenticate your Azure hosted .NET app to an Azure OpenAI resource using Microsoft Entra ID."
author: haywoodsloan
ms.topic: how-to
ms.custom: devx-track-azurecli
ms.date: 01/29/2025
zone_pivot_groups: azure-interface
#customer intent: As a .NET developer, I want authenticate and authorize my App Service to Azure OpenAI by using Microsoft Entra so that I can securely use AI in my .NET application.
---

# Authenticate to Azure OpenAI from an Azure hosted app using Microsoft Entra ID

This article demonstrates how to use [Microsoft Entra ID managed identities](/azure/app-service/overview-managed-identity) and the [Microsoft.Extensions.AI library](../ai-extensions.md) to authenticate an Azure hosted app to an Azure OpenAI resource.

A managed identity from Microsoft Entra ID allows your app to easily access other Microsoft Entra protected resources such as Azure OpenAI. The identity is managed by the Azure platform and doesn't require you to provision, manage, or rotate any secrets.

## Prerequisites

* An Azure account that has an active subscription. [Create an account for free](https://azure.microsoft.com/free/?WT.mc_id=A261C142F).
* [.NET SDK](https://dotnet.microsoft.com/download/visual-studio-sdks)
* [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource)
* [Create and deploy a .NET application to App Service](/azure/app-service/quickstart-dotnetcore)

## Add a managed identity to App Service

Managed identities provide an automatically managed identity in Microsoft Entra ID for applications to use when connecting to resources that support Microsoft Entra authentication. Applications can use managed identities to obtain Microsoft Entra tokens without having to manage any credentials. Your application can be assigned two types of identities:

* A **system-assigned identity** is tied to your application and is deleted if your app is deleted. An app can have only one system-assigned identity.
* A **user-assigned identity** is a standalone Azure resource that can be assigned to your app. An app can have multiple user-assigned identities.

:::zone target="docs" pivot="azure-portal"

# [System-assigned](#tab/system-assigned)

1. Navigate to your app's page in the [Azure portal](https://aka.ms/azureportal), and then scroll down to the **Settings** group.
1. Select **Identity**.
1. On the **System assigned** tab, toggle *Status* to **On**, and then select **Save**.

    :::image type="content" source="../media/azure-hosted-apps/system-assigned-managed-identity-in-azure-portal.png" alt-text="A screenshot showing how to add a system assigned managed identity to an app.":::

    > [!NOTE]
    > The preceding screenshot demonstrates this process on an Azure App Service, but the steps are similar on other hosts such as Azure Container Apps.

## [User-assigned](#tab/user-assigned)

To add a user-assigned identity to your app, create the identity, and then add its resource identifier to your app config.

1. Create a user-assigned managed identity resource by following [these instructions](/azure/active-directory/managed-identities-azure-resources/how-to-manage-ua-identity-portal#create-a-user-assigned-managed-identity).
1. In the left navigation pane of your app's page, scroll down to the **Settings** group.
1. Select **Identity**.
1. Select **User assigned** > **Add**.
1. Locate the identity that you created earlier, select it, and then select **Add**.

    > [!IMPORTANT]
    > After you select **Add**, the app restarts.

    :::image type="content" source="../media/azure-hosted-apps/user-assigned-managed-identity-in-azure-portal.png" alt-text="A screenshot showing how to add a system assigned managed identity to an app.":::

    > [!NOTE]
    > The preceding screenshot demonstrates this process on an Azure App Service, but the steps are similar on other hosts such as Azure Container Apps.

---

:::zone-end

:::zone target="docs" pivot="azure-cli"

## [System-assigned](#tab/system-assigned)

Run the `az webapp identity assign` command to create a system-assigned identity:

```azurecli
az webapp identity assign --name <appName> --resource-group <groupName>
```

## [User-assigned](#tab/user-assigned)

1. Create a user-assigned identity:

    ```azurecli
    az identity create --resource-group <groupName> --name <identityName>
    ```

1. Assign the identity to your app:

    ```azurecli
    az webapp identity assign --resource-group <groupName> --name <appName> --identities <identityId>
    ```

---

:::zone-end

## Add an Azure OpenAI user role to the identity

:::zone target="docs" pivot="azure-portal"

1. In the [Azure Portal](https://aka.ms/azureportal), navigate to the scope that you want to grant **Azure OpenAI** access to. The scope can be a **Management group**, **Subscription**, **Resource group**, or a specific **Azure OpenAI** resource.
1. In the left navigation pane, select **Access control (IAM)**.
1. Select **Add**, then select **Add role assignment**.

    :::image type="content" source="../media/azure-hosted-apps/add-entra-role.png" alt-text="A screenshot showing how to add an RBAC role.":::

1. On the **Role** tab, select the **Cognitive Services OpenAI User** role.
1. On the **Members** tab, select the managed identity.
1. On the **Review + assign** tab, select **Review + assign** to assign the role.

:::zone-end

:::zone target="docs" pivot="azure-cli"

You can use the Azure CLI to assign the Cognitive Services OpenAI User role to your managed identity at varying scopes.

# [Resource](#tab/resource)

```azurecli
az role assignment create --assignee "<managedIdentityObjectID>" \
--role "Cognitive Services OpenAI User" \
--scope "/subscriptions/<subscriptionId>/resourcegroups/<resourceGroupName>/providers/<providerName>/<resourceType>/<resourceSubType>/<resourceName>"
```

# [Resource group](#tab/resource-group)

```azurecli
az role assignment create --assignee "<managedIdentityObjectID>" \
--role "Cognitive Services OpenAI User" \
--scope "/subscriptions/<subscriptionId>/resourcegroups/<resourceGroupName>"
```

# [Subscription](#tab/subscription)

```azurecli
az role assignment create --assignee "<managedIdentityObjectID>" \
--role "Cognitive Services OpenAI User" \
--scope "/subscriptions/<subscriptionId>"
```

# [Management group](#tab/management-group)

```azurecli
az role assignment create --assignee "<managedIdentityObjectID>" \
--role "Cognitive Services OpenAI User" \
--scope "/providers/Microsoft.Management/managementGroups/<managementGroupName>"
```

---

:::zone-end

## Implement identity authentication in your app code

1. Add the following NuGet packages to your app:

    ```dotnetcli
    dotnet add package Azure.Identity
    dotnet add package Azure.AI.OpenAI
    dotnet add package Microsoft.Extensions.Azure
    dotnet add package Microsoft.Extensions.AI
    dotnet add package Microsoft.Extensions.AI.OpenAI
    ```

    The preceding packages each handle the following concerns for this scenario:

    - **[Azure.Identity](https://www.nuget.org/packages/Azure.Identity)**: Provides core functionality to work with Microsoft Entra ID
    - **[Azure.AI.OpenAI](https://www.nuget.org/packages/Azure.AI.OpenAI)**: Enables your app to interface with the Azure OpenAI service
    - **[Microsoft.Extensions.Azure](https://www.nuget.org/packages/Microsoft.Extensions.Azure)**: Provides helper extensions to register services for dependency injection
    - **[Microsoft.Extensions.AI](https://www.nuget.org/packages/Microsoft.Extensions.AI)**: Provides AI abstractions for common AI tasks
    - **[Microsoft.Extensions.AI.OpenAI](https://www.nuget.org/packages/Microsoft.Extensions.AI.OpenAI)**: Enables you to use OpenAI service types as AI abstractions provided by **Microsoft.Extensions.AI**

1. In the `Program.cs` file of your app, create a `DefaultAzureCredential` object to discover and configure available credentials:

    :::code language="csharp" source="./snippets/hosted-app-auth/program.cs" range="13-22":::

1. Create an AI service and register it with the service collection:

    :::code language="csharp" source="./snippets/hosted-app-auth/program.cs" range="24-30":::

1. Inject the registered service for use in your endpoints:

    :::code language="csharp" source="./snippets/hosted-app-auth/program.cs" range="41-46":::

    > [!TIP]
    > Learn more about ASP.NET Core dependency injection and how to register other AI services types in the Azure SDK for .NET [dependency injection](../../azure/sdk/dependency-injection.md) documentation.

## Related content

* [How to use managed identities for App Service and Azure Functions](/azure/app-service/overview-managed-identity)
* [Role-based access control for Azure OpenAI Service](/azure/ai-services/openai/how-to/role-based-access-control)
