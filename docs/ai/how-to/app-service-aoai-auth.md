---
title: "Authenticate and Authorize App Service to Azure OpenAI using Microsoft Entra and the Semantic Kernel SDK"
description: "Learn how to authenticate and authorize your app service application to an Azure OpenAI resource using Microsoft Entra managed identities and the Semantic Kernel SDK for .NET."
author: haywoodsloan
ms.topic: how-to
ms.date: 04/19/2024
zone_pivot_groups: azure-development-tool-set-two

#customer intent: As a .NET developer, I want authenticate and authorize my App Service to Azure OpenAI using Microsoft Entra so that I can securely use AI in my .NET application.

---

# Authenticate and authorize App Service to Azure OpenAI using Microsoft Entra and the Semantic Kernel SDK

This article demonstrates how to use [Microsoft Entra managed identities](/azure/app-service/overview-managed-identity) to authenticate and authorize an App Service application to an Azure OpenAI resource.

By using a managed identity from Microsoft Entra, your App Service application can easily access protected Azure OpenAI resources without having to manually provision or rotate any secrets.

The [Semantic Kernel SDK](/semantic-kernel/overview) enables you to easily implement Microsoft Entra authentication in your .NET application.

## Prerequisites

* An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/free/?WT.mc_id=A261C142F).
* [.NET SDK](https://dotnet.microsoft.com/download/visual-studio-sdks)
* [`Microsoft.SemanticKernel` NuGet package](https://www.nuget.org/packages/Microsoft.SemanticKernel)
* [`Azure.Identity` NuGet package](https://www.nuget.org/packages/Azure.Identity)
* [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource)
* [Create and deploy a .NET application to App Service](/azure/app-service/quickstart-dotnetcore)

## Add a managed identity to App Service

Your application can be granted two types of identities:

* A **system-assigned identity** is tied to your application and is deleted if your app is deleted. An app can only have one system-assigned identity.
* A **user-assigned identity** is a standalone Azure resource that can be assigned to your app. An app can have multiple user-assigned identities.

### Add a system-assigned identity

:::zone target="docs" pivot="azure-portal"

1. Navigate to your app's page on the [Azure Portal](https://aka.ms/azureportal), scroll down to the **Settings** group.
1. Select **Identity**.
1. Within the **System assigned** tab, toggle *Status* to **On**. Click **Save**.

:::zone-end

:::zone target="docs" pivot="azure-cli"

Run the `az webapp identity assign` command to create a system-assigned identity:

```azurecli
az webapp identity assign --name <app-name> --resource-group <group-name>
```

:::zone-end

### Add a user-assigned identity

To create an app with a user-assigned identity, first create the identity and then add its resource identifier to your app config.

:::zone target="docs" pivot="azure-portal"

1. Create a user-assigned managed identity resource according to these [instructions](/azure/active-directory/managed-identities-azure-resources/how-to-manage-ua-identity-portal#create-a-user-assigned-managed-identity).
1. In the left navigation for your app's page, scroll down to the **Settings** group.
1. Select **Identity**.
1. Select **User assigned > Add**.
1. Search for the identity you created earlier, select it, and then select **Add**.

    > [!CAUTION]
    > Once you select **Add**, the app restarts.

:::zone-end

:::zone target="docs" pivot="azure-cli"

1. Create a user-assigned identity:

    ```azurecli
    az identity create --resource-group <group-name> --name <identity-name>
    ```

1. Assign the identity to your app:

    ```azurecli
    az webapp identity assign --resource-group <group-name> --name <app-name> --identities <identity-id>
    ```

:::zone-end

## Add an Azure OpenAI user role to your managed identity

:::zone target="docs" pivot="azure-portal"

1. In the [Azure Portal](https://aka.ms/azureportal), navigate to the scope you want to grant **Azure OpenAI** access to.
    * The scope can be a **Management group**, **Subscription**, or **Resource group**, or a specific **Azure OpenAI** resource.
1. Select **Access control (IAM)** on the left navigation pane.
1. Select **Add**, then select **Add role assignment**.
1. On the **Role** tab, select the **Cognitive Services OpenAI User** role.
1. On the **Members** tab, select the managed identity.
1. On the **Review + assign** tab, select **Review + assign** to assign the role.

:::zone-end

:::zone target="docs" pivot="azure-cli"

**Resource scope**

```azurecli
az role assignment create --assignee "{managedIdentityObjectID}" \
--role "Cognitive Services OpenAI User" \
--scope "/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceType}/{resourceSubType}/{resourceName}"
```

**Resource group scope**

```azurecli
az role assignment create --assignee "{managedIdentityObjectID}" \
--role "Cognitive Services OpenAI User" \
--scope "/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}"
```

**Subscription scope**

```azurecli
az role assignment create --assignee "{managedIdentityObjectID}" \
--role "Cognitive Services OpenAI User" \
--scope "/subscriptions/{subscriptionId}"
```

**Management group scope**

```azurecli
az role assignment create --assignee "{managedIdentityObjectID}" \
--role "Cognitive Services OpenAI User" \
--scope "/providers/Microsoft.Management/managementGroups/{managementGroupName}"
```

:::zone-end

## Implement token-based authentication with the Semantic Kernel SDK

1. Initialize a `DefaultAzureCredential` object to pick up your app's managed identity:

    :::code language="csharp" source="./snippets/semantic-kernel/IdentityExamples.cs" id="tokenCredential":::

1. Build a `Kernel` object including the Azure OpenAI Chat Completion Service, and use the previously created credentials:

    :::code language="csharp" source="./snippets/semantic-kernel/IdentityExamples.cs" id="kernelBuild":::

1. Use the `Kernel` object to invoke prompt completion through Azure OpenAI:

    :::code language="csharp" source="./snippets/semantic-kernel/IdentityExamples.cs" id="invokePrompt":::

## Related content

* [Authenticate and authorize App Service to a vector database](app-service-db-auth.md)
* [How to use managed identities for App Service and Azure Functions](/azure/app-service/overview-managed-identity)
* [Role-based access control for Azure OpenAI Service](/azure/ai-services/openai/how-to/role-based-access-control)
