---
title: Authenticate Azure-hosted .NET apps to Azure resources
description: Learn how to authenticate apps to Azure services when hosted in an Azure compute service like Azure App Service, Azure Functions, or Azure Virtual Machines.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-azurecli
ms.date: 02/06/2025
---

# Authenticate Azure-hosted apps to Azure resources with the Azure SDK for .NET

The recommended approach to authenticate an Azure-hosted app to other Azure resources is to use a [managed identity](/entra/identity/managed-identities-azure-resources/overview). This approach is [supported for most Azure services](/entra/identity/managed-identities-azure-resources/managed-identities-status), including apps hosted on Azure App Service, Azure Container Apps, and Azure Virtual machines. In the sections ahead, you'll learn:

- Essential managed identity concepts
- How to create a managed identity for your app
- How to assign roles to the managed identity
- How to authenticate using the managed identity from your app code

## Managed identity concepts and types

A managed identity enables your app to securely connect to other Azure resources without the use of secret keys or other application secrets. Internally, Azure knows the identity of your app and which resources it's allowed to connect to. Azure uses this information to automatically obtain Microsoft Entra tokens for the app to allow it to connect to other Azure resources, all without you having to manage any application secrets.

There are two types of managed identities to consider when configuring your hosted app:

- **System-assigned** identities are provided by and tied directly to the life cycle of an Azure resource. When the resource is deleted, Azure automatically deletes the identity for you. All you have to do is enable managed identity for the Azure resource hosting your code, which makes this a minimal approach to using managed identities.
- **User-assigned** identities are created as standalone Azure resources. These identities are ideal for solutions that run across multiple Azure resources that all need to share the same identity and permissions. For example, if your solution has multiple virtual machine instances that all need access to the same set of Azure resources, a user-assigned managed identity provides reusability and optimized management.

The sections ahead describe the steps to enable and use a system-assigned managed identity for an Azure-hosted app. If you need to use a user-assigned managed identity, visit the [Manage user-assigned managed identities](/entra/identity/managed-identities-azure-resources/how-manage-user-assigned-managed-identities?pivots=identity-mi-methods-azp) article for more information.

### Enable managed identity on the Azure resource hosting the app

To get started using a system-assigned identity with your app, enable the identity on the Azure resource hosting your app, such as an Azure App Service, Azure Container App, or Azure Virtual Machine.

You can enable a system-assigned managed identity for an Azure resource using either the Azure portal or the Azure CLI.

### [Azure portal](#tab/azure-portal)

1. In the Azure portal, navigate to the resource that hosts your application code, such as an Azure App Service or Azure Container App instance.
1. On the **Overview** page for your resource, select **Identity** from the navigation.
1. On the **Identity** page, toggle the **Status** slider to **On**.
1. Select **Save** to apply your changes.

    :::image type="content" source="../media/system-assigned-identity-enable.png" alt-text="A screenshot showing how to enable a system-assigned identity on a container app.":::

### [Azure CLI](#tab/azure-cli)

Azure CLI commands can be run in the [Azure Cloud Shell](https://shell.azure.com) or on a workstation with the [Azure CLI installed](/cli/azure/install-azure-cli).

The Azure CLI commands used to enable managed identity for an Azure resource are of the form `az <command-group> identity --resource-group <resource-group-name> --name <resource-name>`. Specific commands for popular Azure services are shown below.

[!INCLUDE [Enable managed identity Azure CLI](<../includes/enable-managed-identity-azure-cli.md>)]

The output resembles the following:

```json
{
  "principalId": "99999999-9999-9999-9999-999999999999",
  "tenantId": "33333333-3333-3333-3333-333333333333",
  "type": "SystemAssigned",
  "userAssignedIdentities": null
}
```

The `principalId` value is the unique ID of the managed identity. Keep a copy of this output, as you'll need these values in the next step.

---

### Assign roles to the managed identity

Next, determine which roles your app needs and assign those roles to the managed identity. You can assign roles to a managed identity at the following scopes:

- **Resource**: The assigned roles only apply to that specific resource.
- **Resource group**: The assigned roles apply to all resources contained in the resource group.
- **Subscription**: The assigned roles apply to all resources contained in the subscription.

The following example shows how to assign roles at the resource group scope since many apps manage all their related Azure resources using a single resource group.

### [Azure portal](#tab/azure-portal)

1. Navigate to the **Overview** page of the resource group that contains the app with the system-assigned identity.
1. Select **Access control (IAM)** from the left navigation.
1. On the **Access control (IAM)** page, select **+ Add** from the top menu and then choose **Add role assignment** to navigate to the **Add role assignment** page. This page presents a tabbed, multi-step workflow to assign roles to identities.

    :::image type="content" source="../media/system-assigned-identity-access-control.png" alt-text="A screenshot showing how to access the identity role assignment page.":::

1. On the **Role** tab, use the search box at the top to locate the role you want to assign to the identity. Select the role and then choose **Next** to move to the **Members** tab.
1. For the **Assign access to** option, select **Managed identity**.
1. For the **Members** option, choose **+ Select members** to open the **Select managed identities** flyout panel.
1. On the flyout panel, use the **Subscription** and **Managed identity** dropdowns to filter the search results for your identities. Use the **Select** search box to locate the system-identity you enabled for the Azure resource hosting your app.

    :::image type="content" source="../media/system-assigned-identity-assign-roles.png" alt-text="A screenshot showing the managed identity assignment process.":::

1. Select the identity and choose **Select** at the bottom of the panel to continue.
1. Select **Review + assign** at the bottom of the page.
1. On the final **Review + assign** tab, select **Review + assign** to complete the workflow.

### [Azure CLI](#tab/azure-cli)

A managed identity is assigned a role in Azure using the [az role assignment create](/cli/azure/role/assignment#az-role-assignment-create) command:

```azurecli
az role assignment create \
    --assignee "{managedIdentityId}" \
    --role "{roleName}" \
    --scope "{scope}"
```

To get the role names to which a service principal can be assigned, use the [az role definition list](/cli/azure/role/definition#az-role-definition-list) command:

```azurecli
az role definition list \
    --query "sort_by([].{roleName:roleName, description:description}, &roleName)" \
    --output table
```

For example, to allow the managed identity with the ID of `99999999-9999-9999-9999-999999999999` read, write, and delete access to Azure Storage blob containers and data to all storage accounts in the *msdocs-dotnet-sdk-auth-example* resource group, assign the application service principal to the *Storage Blob Data Contributor* role using the following command:

```azurecli
az role assignment create \
    --assignee 99999999-9999-9999-9999-999999999999 \
    --role "Storage Blob Data Contributor" \
    --scope "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/msdocs-dotnet-sdk-auth-example"
```

For information on assigning permissions at the resource or subscription level using the Azure CLI, see the article [Assign Azure roles using the Azure CLI](/azure/role-based-access-control/role-assignments-cli).

---

## Implement DefaultAzureCredential in your application

[!INCLUDE [Implement DefaultAzureCredential](<../includes/implement-defaultazurecredential.md>)]
