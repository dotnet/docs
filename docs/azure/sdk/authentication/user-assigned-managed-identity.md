---
title: Authenticate Azure-hosted .NET apps to Azure resources using a user-assigned managed identity
description: Learn how to authenticate Azure-hosted .NET apps to other Azure services using a user-assigned identity
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-azurecli
ms.date: 02/06/2025
---

# Authenticate Azure-hosted .NET apps to Azure resources using a user-assigned managed identity

The recommended approach to authenticate an Azure-hosted app to other Azure resources is to use a [managed identity](/entra/identity/managed-identities-azure-resources/overview). This approach is [supported for most Azure services](/entra/identity/managed-identities-azure-resources/managed-identities-status), including apps hosted on Azure App Service, Azure Container Apps, and Azure Virtual Machines. Discover more about different authentication techniques and approaches on the [authentication overview](/dotnet/azure/sdk/authentication) page. In the sections ahead, you'll learn:

- Essential managed identity concepts
- How to create a user-assigned managed identity for your app
- How to assign roles to the user-assigned managed identity
- How to authenticate using the user-assigned managed identity from your app code

[!INCLUDE [managed-identity-concepts](../includes/managed-identity-concepts.md)]

## Create a user-assigned managed identity

User-assigned identities are created as standalone resources in your Azure subscription. You can create them using the Azure portal or the Azure CLI.

### [Azure portal](#tab/azure-portal)

1. In the Azure portal, enter *Managed identities* in the main search bar and select the matching result under the **Services** section.
1. On the **Managed Identities** page, select **+ Create**.

    :::image type="content" source="../media/user-assigned-identity-create.png" alt-text="A screenshot showing the page to manage user-assigned identities.":::

1. On the **Create User Assigned Managed Identity** page, select a subscription, resource group, and region for the user-assigned identity, and then provide a name.
1. Select **Review + create** to review and validate your inputs.
1. Select **Create** to create the user-assigned identity.

    :::image type="content" source="../media/user-assigned-identity-form.png" alt-text="A screenshot showing the form to create a user-assigned identity.":::

1. After the identity is created, select **Go to resource**.
1. On the new identity's **Overview** page, copy the `Client ID` value to use for later when you configure the application code.

### [Azure CLI](#tab/azure-cli)

Azure CLI commands can be run in the [Azure Cloud Shell](https://shell.azure.com) or on a workstation with the [Azure CLI installed](/cli/azure/install-azure-cli).

Use the Azure CLI command `az identity create` to create a managed identity for an Azure resource:

```azurecli
az identity create --resource-group <resource-group-name> --name <identity-name>
```

The command output prints the following values:
    - **ClientID**: Used to configure application code that uses the identity.
    - **Location**: The Azure region that contains the identity.
    - **Name**: The name of the identity.
    - **PrincipalId**: Used for access control and role assignments in Azure.
    - **ResourceGroup**: The resource group that contains the identity.
    - **TenantId**: The Microsoft Entra tenant that contains the identity.

For the steps ahead, you'll use the `principalId` to assign roles to the managed identity.

---

[!INCLUDE [assign-roles-identity](../includes/assign-roles-identity.md)]

## Implement DefaultAzureCredential in your application

[!INCLUDE [Implement DefaultAzureCredential](<../includes/implement-defaultazurecredential.md>)]
