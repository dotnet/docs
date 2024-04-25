---
title: "Authenticate and Authorize App Service to a Vector Database"
description: "Learn how to authenticate and authorize your App Service .NET application to a vector database solution using Microsoft Entra managed identities, Key Vault, or app settings"
author: haywoodsloan
ms.topic: how-to
ms.date: 04/24/2024
zone_pivot_groups: azure-development-tool-set-two

#customer intent: As a .NET developer, I want authenticate and authorize my App Service to a vector database so that I can securely add memories to the AI in my .NET application.

---

# Authenticate and authorize App Service to a vector database

This article demonstrates how to manage the connection between your App Service .NET application and a [vector database solution](../conceptual/vector-databases.md). It covers using Microsoft Entra managed identities for supported services and securely storing connection strings for others.

By adding a vector database to your application, you can enable [semantic memories](/semantic-kernel/memories/) for your AI. The [Semantic Kernel SDK](/semantic-kernel/overview) for .NET enables you to easily implement memory storage and recall using your preferred vector database solution.

## Prerequisites

* An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/free/?WT.mc_id=A261C142F).
* [.NET SDK](https://dotnet.microsoft.com/download/visual-studio-sdks)
* [`Microsoft.SemanticKernel` NuGet package](https://www.nuget.org/packages/Microsoft.SemanticKernel)
* [`Microsoft.SemanticKernel.Plugins.Memory` NuGet package](https://www.nuget.org/packages/Microsoft.SemanticKernel.Plugins.Memory)
* [Create and deploy a .NET application to App Service](/azure/app-service/quickstart-dotnetcore)
* [Create and deploy a vector database solution](/semantic-kernel/memories/vector-db)

## Use Microsoft Entra managed identity for authentication

If a vector database service supports Microsoft Entra authentication, you can use a managed identity with your App Service to securely access your vector database without having to manually provision or rotate any secrets. For a list of Azure services that support Microsoft Entra authentication, see [Azure services that support Microsoft Entra authentication](/entra/identity/managed-identities-azure-resources/services-id-authentication-support).

### Add a managed identity to App Service

#### Add a system-assigned identity

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

#### Add a user-assigned identity

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

### Assign a Azure role to your managed identity

:::zone target="docs" pivot="azure-portal"

1. In the [Azure Portal](https://aka.ms/azureportal), navigate to the scope you want to grant vector database access to.
    * The scope can be a **Management group**, **Subscription**, or **Resource group**, or a specific Azure resource.
1. Select **Access control (IAM)** on the left navigation pane.
1. Select **Add**, then select **Add role assignment**.
1. On the **Role** tab, select the appropriate role that grants read access to your vector database.
1. On the **Members** tab, select the managed identity.
1. On the **Review + assign** tab, select **Review + assign** to assign the role.

:::zone-end

:::zone target="docs" pivot="azure-cli"

**Resource scope**

```azurecli
az role assignment create --assignee "{managedIdentityObjectID}" \
--role "{myVectorDbReaderRole}" \
--scope "/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceType}/{resourceSubType}/{resourceName}"
```

**Resource group scope**

```azurecli
az role assignment create --assignee "{managedIdentityObjectID}" \
--role "{myVectorDbReaderRole}" \
--scope "/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}"
```

**Subscription scope**

```azurecli
az role assignment create --assignee "{managedIdentityObjectID}" \
--role "{myVectorDbReaderRole}" \
--scope "/subscriptions/{subscriptionId}"
```

**Management group scope**

```azurecli
az role assignment create --assignee "{managedIdentityObjectID}" \
--role "{myVectorDbReaderRole}" \
--scope "/providers/Microsoft.Management/managementGroups/{managementGroupName}"
```

:::zone-end

### Implement token-based authentication with the vector database

The following code samples require these additional libraries:

* [`Azure.Identity` NuGet package](https://www.nuget.org/packages/Azure.Identity)
* [`Microsoft.SemanticKernel.Connectors.AzureAISearch` NuGet package](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.AzureAISearch)

1. Initialize a `DefaultAzureCredential` object to pick up your app's managed identity:

    :::code language="csharp" source="./snippets/semantic-kernel/IdentityExamples.cs" id="tokenCredential":::

1. Initialize an `IMemoryStore` object for your vector database, then use it to build an `ISemanticTextMemory`:

    :::code language="csharp" source="./snippets/semantic-kernel/IdentityExamples.cs" id="aiStore":::

1. Build a `Kernel` object, then import the `ISemanticTextMemory` object using the `TextMemoryPlugin`:

    :::code language="csharp" source="./snippets/semantic-kernel/IdentityExamples.cs" id="addMemory":::

1. Use the `Kernel` object to invoke a prompt that includes memory recall:

    :::code language="csharp" source="./snippets/semantic-kernel/IdentityExamples.cs" id="useMemory":::

## Use Key Vault to store connection secrets

If a vector database doesn't support Microsoft Entra authentication, you can use a Key Vault to store your connection secrets and retrieve them with your App Service application. By using a Key Vault to store your connection secrets you can share them with multiple applications, and control access to individual secrets per application.

Before following these steps, retrieve a connection string for your vector database. For example, see [Use Azure Cache for Redis in .NET Framework](/azure/azure-cache-for-redis/cache-dotnet-how-to-use-azure-redis-cache#retrieve-host-name-ports-and-access-keys-from-the-azure-portal).

### Add a connection string to Key Vault

:::zone target="docs" pivot="azure-portal"

> [!IMPORTANT]
> Before following these steps, ensure you have [created a Key Vault using the Azure Portal](/azure/key-vault/general/quick-create-portal).

1. Navigate to your key vault in the [Azure Portal](https://aka.ms/azureportal).
1. In the Key Vault left navigation, select **Objects** then select **Secrets**.
1. Select **+ Generate/Import**.
1. On the **Create a secret** screen choose the following values:
   * **Upload options**: `Manual`.
   * **Name**: Type a name for the secret. The secret name must be unique within a Key Vault.
   * **Value**: The connection string for your vector database.
   * Leave the other values to their defaults. Select **Create**.
1. When you receive the message that the secret has been successfully created, it's ready to use in your application.

:::zone-end

:::zone target="docs" pivot="azure-cli"

> [!IMPORTANT]
> Before following these steps, ensure you have [created a Key Vault using the Azure CLI](/azure/key-vault/general/quick-create-cli).

1. Grant your user account permissions to your key vault through Role-Based Access Control (RBAC), assign a role using the Azure CLI command [`az role assignment create`](/cli/azure/role/assignment?view=azure-cli-latest#az-role-assignment-create):

    ```azurecli
    az role assignment create \
    --role "Key Vault Secrets User" \
    --assignee "{yourEmailAddress}" \
    --scope "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{keyVaultName}"
    ```

1. Add the connection string to Key Vault using the Azure CLI command [`az keyvault secret set`](/cli/azure/keyvault/secret?view=azure-cli-latest#az-keyvault-secret-set):

    ```azurecli
    az keyvault secret set \
    --vault-name "{keyVaultName}" \
    --name "{secretName}" \
    --value "{connectionString}"
    ```

:::zone-end

### Grant your App Service access to Key Vault

1. [Assign a managed identity to your App Service](#add-a-managed-identity-to-app-service).
1. [Add the `Key Vault Secrets User` and `Key Vault Reader` roles to your managed identity](#assign-a-azure-role-to-your-managed-identity).

### Implement connection string retrieval from Key Vault

To use the following code samples, you need these additional libraries:

* [`Azure.Identity` NuGet package](https://www.nuget.org/packages/Azure.Identity)
* [`Azure.Extensions.AspNetCore.Configuration.Secrets` NuGet package](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.Configuration.Secrets)
* [`Microsoft.Extensions.Configuration` NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Configuration)

These code samples use a Redis database, but you can apply them to any vector database that supports connection strings.

1. Initialize a `DefaultAzureCredential` object to pick up your app's managed identity:

    :::code language="csharp" source="./snippets/semantic-kernel/IdentityExamples.cs" id="tokenCredential":::

1. Add Key Vault when building your configuration, this will map your Key Vault secrets to the `IConfigurationRoot` object:

    :::code language="csharp" source="./snippets/semantic-kernel/IdentityExamples.cs" id="vaultConfig":::

1. Use your vector database connection string from Key Vault to initialize an `IMemoryStore` object, and then use it to build an `ISemanticTextMemory`:

    :::code language="csharp" source="./snippets/semantic-kernel/IdentityExamples.cs" id="redisStore":::

1. Build a `Kernel` object, then import the `ISemanticTextMemory` object using the `TextMemoryPlugin`:

    :::code language="csharp" source="./snippets/semantic-kernel/IdentityExamples.cs" id="addMemory":::

1. Use the `Kernel` object to invoke a prompt that includes memory recall:

    :::code language="csharp" source="./snippets/semantic-kernel/IdentityExamples.cs" id="useMemory":::

## Use application settings to store connection secrets

If a vector database doesn't support Microsoft Entra authentication, you can use the App Service application settings to store your connection secrets. By using application settings you can store your connection secrets without provisioning any additional Azure resources.

Before following these steps, retrieve a connection string for your vector database. For example, see [Use Azure Cache for Redis in .NET Framework](/azure/azure-cache-for-redis/cache-dotnet-how-to-use-azure-redis-cache#retrieve-host-name-ports-and-access-keys-from-the-azure-portal).

### Add a connection string to application settings

:::zone target="docs" pivot="azure-portal"

1. Navigate to your app's page on the [Azure Portal](https://aka.ms/azureportal).
1. In the app's left menu, select **Configuration** > **Application settings**.
    * By default, values for application settings are hidden in the portal for security.
    * To see a hidden value of an application setting, select its Value field.
1. Select **New connection setting**.
1. On the **Add/Edit connection string** screen choose the following values:
   * **Name**: Type a name for the setting. The setting name must be unique.
   * **Value**: The connection string for your vector database.
   * **Type**: The type of connection, `Custom` if no others apply.
   * Leave the other values to their defaults. Select **OK**.
1. Select **Save** back in the Configuration page.

:::zone-end

:::zone target="docs" pivot="azure-cli"

Add or edit an app setting with the Azure CLI command [`az webapp config connection-string set`](/cli/azure/webapp/config/connection-string?view=azure-cli-latest#az-webapp-config-connection-string-set):

```azurecli
az webapp config connection-string set \
--name "{appName}" \
--resource-group "{groupName}" \
--connection-string-type "{connectionType}" \
--settings {connectionName}='{connectionString}'
```

:::zone-end

### Implement connection string retrieval from app settings

To use the following code samples, you need these additional libraries:

* [`Microsoft.Extensions.Configuration` NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Configuration)
* [`Microsoft.Extensions.Configuration.EnvironmentVariables` NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.EnvironmentVariables)

These code samples use a Redis database, but you can apply them to any vector database that supports connection strings.

1. Add environment variables when building your configuration, this will map your connection strings to the `IConfigurationRoot` object:

    :::code language="csharp" source="./snippets/semantic-kernel/IdentityExamples.cs" id="appSettingsConfig":::

1. Use your vector database connection string from app settings to initialize an `IMemoryStore` object, and then use it to build an `ISemanticTextMemory`:

    :::code language="csharp" source="./snippets/semantic-kernel/IdentityExamples.cs" id="redisStore":::

1. Build a `Kernel` object, then import the `ISemanticTextMemory` object using the `TextMemoryPlugin`:

    :::code language="csharp" source="./snippets/semantic-kernel/IdentityExamples.cs" id="addMemory":::

1. Use the `Kernel` object to invoke a prompt that includes memory recall:

    :::code language="csharp" source="./snippets/semantic-kernel/IdentityExamples.cs" id="useMemory":::

## Related content

<!-- Update links once the other docs are done -->

* [Use Redis for memory storage with the Semantic Kernel SDK]<!-- (use-redis-for-memory.md) -->
* [How to use managed identities for App Service and Azure Functions](/azure/app-service/overview-managed-identity)
* [Steps to assign an Azure role](/azure/role-based-access-control/role-assignments-steps)
