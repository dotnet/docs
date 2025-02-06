---
title: Authenticate Azure-hosted .NET apps to Azure resources
description: Learn how to authenticate apps to Azure services when hosted in an Azure compute service like Azure App Service, Azure Functions, or Azure Virtual Machines.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-azurecli
ms.date: 07/31/2024
---

# Authenticate Azure-hosted apps to Azure resources with the Azure SDK for .NET

The recommended approach to authenticating an Azure-hosted app to other Azure resources is to use a [managed identity](/entra/identity/managed-identities-azure-resources/overview). This approach is supported for apps hosted on Azure App Service, Azure Container Apps, Azure Virtual machines, and most other Azure services.

A managed identity provides an identity for your app that can connect to other Azure resources without the use of secret keys or other application secrets. Internally, Azure knows the identity of your app and which resources it's allowed to connect to. Azure uses this information to automatically obtain Microsoft Entra tokens for the app to allow it to connect to other Azure resources, all without you having to manage any application secrets.

## Managed identity types

There are two types of managed identities:

- **System-assigned** identities are provided by and tied directly to the life cycle of an Azure resource. When the resource is deleted, Azure automatically deletes the identity for you. Since all you have to do is enable managed identity for the Azure resource hosting your code, this is the most minimal approach to using managed identities.
- **User-assigned** identities are created as standalone Azure resources. These identities are ideal for solutions that require that run across multiple Azure resources that all need to share the same identity and same permissions. For example, if your solution had components that ran on multiple App Service and virtual machine instances that all needed access to the same set of Azure resources, creating and using a user-assigned managed identity across those resources provides reusability and optimized management.

## Authenticate your app using a system-assigned identity

This article covers the steps to enable and use a system-assigned managed identity for an app. If you need to use a user-assigned managed identity, see the article [Manage user-assigned managed identities](/entra/identity/managed-identities-azure-resources/how-manage-user-assigned-managed-identities?pivots=identity-mi-methods-azp) to see how to create a user-assigned managed identity.

### 1 - Enable managed identity in the Azure resource hosting the app

The first step is to enable managed identity on the Azure resource hosting your app, such as an Azure App Service, Azure Container App, or Azure Virtual Machine.

You can enable managed identity to be used for an Azure resource using either the Azure portal or the Azure CLI.

### [Azure portal](#tab/azure-portal)

1. Navigate to the resource that hosts your application code in the Azure portal, such as an Azure App Service or Container App instance.
1. On the page for your resource, select the Identity menu item from the left-hand menu.
1. On the Identity page, toggle the **Status** slider to **On**.
1. Select **Save** to apply your changes.

    :::image type="content" source="../../../ai/media/azure-hosted-apps/enable-system-assigned-identity.png" alt-text="A screenshot showing how to enable a system-assigned identity on a container app.":::

### [Azure CLI](#tab/azure-cli)

Azure CLI commands can be run in the [Azure Cloud Shell](https://shell.azure.com) or on a workstation with the [Azure CLI installed](/cli/azure/install-azure-cli).

The Azure CLI commands used to enable managed identity for an Azure resource are of the form `az <command-group> identity --resource-group <resource-group-name> --name <resource-name>`. Specific commands for popular Azure services are shown below.

[!INCLUDE [Enable managed identity Azure CLI](<../includes/enable-managed-identity-azure-cli.md>)]

The output will look like the following.

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

### 2 - Assign roles to the managed identity

Next, determine which roles (permissions) your app needs and assign the managed identity to those roles in Azure. A managed identity can be assigned roles at the following scopes:
    - **Resource**: The assigned roles only apply to that specific resource.
    - **Resource group**: The assigned roles apply to all resources that live in the resource group.
    - **Subscription**: The assigned roles apply to all resources contained in the subscription.

The following example shows how to assign roles at the resource group scope since many apps group and manage all their related Azure resources into a single resource group.

### [Azure portal](#tab/azure-portal)

1. Navigate to the overview page of the resource group that contains the app for which you enabled a system-assigned identity.
1. Select **Access control (IAM)** from the left-hand menu.
1. On the **Access control (IAM)** page, select **+ Add** from the top menu and then choose **Add role assignment** from the drop-down menu.

    :::image type="content" source="../../../ai/media/azure-hosted-apps/identity-assign-role.png" alt-text="A screenshot showing how to access the identity role assignment page.":::

1. The **Add role assignment** page presents a tabbed, multi-step workflow to assign roles to identities. Complete the following steps:
    1. On the **Role** tab, use the search box at the top to locate and select the role that you want to assign, then select **Next**.
    1. On the members tab:
        1. For the **Assign access to** option, select **Managed identity**.
        1. For the **Members** option, choose **+ Select members** to open the **Select managed identities** panel.

        :::image type="content" source="../media/assign-managed-identity-to-role-azure-portal-5.png" alt-text="A screenshot showing the managed identity assignment process.":::

        1. On the flyout panel, use the **Managed identity** dropdown and **Select** text box to filter the list of managed identities in your subscription. Select the managed identity for the Azure resource hosting your app.
        1. Choose **Select** at the bottom of the panel to continue.
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

## 3 - Implement DefaultAzureCredential in your application

[!INCLUDE [Implement DefaultAzureCredential](<../includes/implement-defaultazurecredential.md>)]
