---
title: Authenticating Azure-hosted apps to Azure resources with the Azure SDK for .NET
description: This article covers how to configure authentication for apps to Azure services when the app is hosted in an Azure service like Azure App Service, Azure Functions, or Azure Virtual Machines.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-azurecli
ms.date: 2/28/2023
---

# Authenticating Azure-hosted apps to Azure resources with the Azure SDK for .NET

When an app is hosted in Azure using a service like Azure App Service, Azure Virtual Machines, or Azure Container Instances, the recommended approach to authenticating an app to Azure resources is to use a [managed identity](/azure/active-directory/managed-identities-azure-resources/overview).

A managed identity provides an identity for your app such that it can connect to other Azure resources without the need to use a secret key or other application secret.  Internally, Azure knows the identity of your app and what resources it's allowed to connect to.  Azure uses this information to automatically obtain Azure AD tokens for the app to allow it to connect to other Azure resources, all without you having to manage any application secrets.

## Managed identity types

There are two types of managed identities:

- **System-assigned managed identities** - This type of managed identity is provided by and tied directly to an Azure resource.  When you enable managed identity on an Azure resource, you get a system-assigned managed identity for that resource.  A system-assigned managed identity is tied to the lifecycle of the Azure resource it's associated with. When the resource is deleted, Azure automatically deletes the identity for you.  Since all you have to do is enable managed identity for the Azure resource hosting your code, this is the easiest type of managed identity to use.
- **User-assigned managed identities** - You may also create a managed identity as a standalone Azure resource. This is most frequently used when your solution has multiple workloads that run on multiple Azure resources that all need to share the same identity and same permissions.  For example, if your solution had components that ran on multiple App Service and virtual machine instances that all needed access to the same set of Azure resources, creating and using a user-assigned managed identity across those resources would make sense.

This article will cover the steps to enable and use a system-assigned managed identity for an app.  If you need to use a user-assigned managed identity, see the article [Manage user-assigned managed identities](/azure/active-directory/managed-identities-azure-resources/how-manage-user-assigned-managed-identities) to see how to create a user-assigned managed identity.

## 1 - Enable managed identity in the Azure resource hosting the app

The first step is to enable managed identity on Azure resource hosting your app.  For example, if you're hosting a .NET application using Azure App Service, you need to enable managed identity for the App Service web app that is hosting your app.  If you were using a virtual machine to host your app, you would enable your VM to use managed identity.

You can enable managed identity to be used for an Azure resource using either the Azure portal or the Azure CLI.

### [Azure portal](#tab/azure-portal)

| Instructions    | Screenshot |
|:----------------|-----------:|
| [!INCLUDE [Enable managed identity step 1](<../includes/enable-managed-identity-azure-portal-1.md>)] | :::image type="content" source="../media/enable-managed-identity-azure-portal-1-240px.png" alt-text="A screenshot showing how to use the top search bar in the Azure portal to locate and navigate to a resource in Azure." lightbox="../media/enable-managed-identity-azure-portal-1.png"::: |
| [!INCLUDE [Enable managed identity step 2](<../includes/enable-managed-identity-azure-portal-2.md>)] | :::image type="content" source="../media/enable-managed-identity-azure-portal-2-240px.png" alt-text="A screenshot showing the location of the Identity menu item in the left-hand menu for an Azure resource." lightbox="../media/enable-managed-identity-azure-portal-2.png"::: |
| [!INCLUDE [Enable managed identity step 3](<../includes/enable-managed-identity-azure-portal-3.md>)] | :::image type="content" source="../media/enable-managed-identity-azure-portal-3-240px.png" alt-text="A screenshot showing how to enable managed identity for an Azure resource on the resource's Identity page." lightbox="../media/enable-managed-identity-azure-portal-3.png"::: |

### [Azure CLI](#tab/azure-cli)

Azure CLI commands can be run in the [Azure Cloud Shell](https://shell.azure.com) or on a workstation with the [Azure CLI installed](/cli/azure/install-azure-cli).

The Azure CLI commands used to enable managed identity for an Azure resource are of the form `az <command-group> identity --resource-group <resource-group-name> --name <resource-name>`.  Specific commands for popular Azure services are shown below.

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

The `principalId` value is the unique ID of the managed identity. Keep a copy of this output as you'll need these values in the next step.

---

## 2 - Assign roles to the managed identity

Next, you need to determine what roles (permissions) your app needs and assign the managed identity to those roles in Azure.  A managed identity can be assigned  roles at a resource, resource group, or subscription scope.  This example will show how to assign roles at the resource group scope since most applications group all their Azure resources into a single resource group.

### [Azure portal](#tab/azure-portal)

| Instructions    | Screenshot |
|:----------------|-----------:|
| [!INCLUDE [Assign managed identity to role step 1](<../includes/assign-managed-identity-to-role-azure-portal-1.md>)] | :::image type="content" source="../media/assign-managed-identity-to-role-azure-portal-1-240px.png" alt-text="A screenshot showing how to use the top search bar in the Azure portal to locate and navigate to a resource group in Azure. This is the resource group that you'll assign roles (permissions) to." lightbox="../media/assign-managed-identity-to-role-azure-portal-1.png"::: |
| [!INCLUDE [Assign managed identity to role step 2](<../includes/assign-managed-identity-to-role-azure-portal-2.md>)] | :::image type="content" source="../media/assign-managed-identity-to-role-azure-portal-2-240px.png" alt-text="A screenshot showing the location of the Access control (IAM) menu item in the left-hand menu of an Azure resource group." lightbox="../media/assign-managed-identity-to-role-azure-portal-2.png"::: |
| [!INCLUDE [Assign managed identity to role step 3](<../includes/assign-managed-identity-to-role-azure-portal-3.md>)] | :::image type="content" source="../media/assign-managed-identity-to-role-azure-portal-3-240px.png" alt-text="A screenshot showing how to navigate to the role assignments tab and the location of the button used to add role assignments to a resource group." lightbox="../media/assign-managed-identity-to-role-azure-portal-3.png"::: |
| [!INCLUDE [Assign managed identity to role step 4](<../includes/assign-managed-identity-to-role-azure-portal-4.md>)] | :::image type="content" source="../media/assign-managed-identity-to-role-azure-portal-4-240px.png" alt-text="A screenshot showing how to filter and select role assignments to be added to the resource group." lightbox="../media/assign-managed-identity-to-role-azure-portal-4.png"::: |
| [!INCLUDE [Assign managed identity to role step 5](<../includes/assign-managed-identity-to-role-azure-portal-5.md>)] | :::image type="content" source="../media/assign-managed-identity-to-role-azure-portal-5-240px.png" alt-text="A screenshot showing how to select managed identity as the type of user you want to assign the role (permission) on the add role assignments page." lightbox="../media/assign-managed-identity-to-role-azure-portal-5.png"::: |
| [!INCLUDE [Assign managed identity to role step 6](<../includes/assign-managed-identity-to-role-azure-portal-6.md>)] | :::image type="content" source="../media/assign-managed-identity-to-role-azure-portal-6-240px.png" alt-text="A screenshot showing how to use the select managed identities dialog to filter and select the managed identity to assign the role to." lightbox="../media/assign-managed-identity-to-role-azure-portal-6.png"::: |
| [!INCLUDE [Assign managed identity to role step 7](<../includes/assign-managed-identity-to-role-azure-portal-7.md>)] | :::image type="content" source="../media/assign-managed-identity-to-role-azure-portal-7-240px.png" alt-text="A screenshot of the final add role assignment screen where a user needs to select the Review + Assign button to finalize the role assignment." lightbox="../media/assign-managed-identity-to-role-azure-portal-7.png"::: |

### [Azure CLI](#tab/azure-cli)

A managed identity is assigned a role in Azure using the [az role assignment create] command.

```azurecli
az role assignment create --assignee "{managedIdentityId}" \
    --role "{roleName}" \
    --resource-group "{resourceGroupName}"
```

To get the role names that a service principal can be assigned to, use the [az role definition list](/cli/azure/role/definition#az-role-definition-list) command.

```azurecli
az role definition list \
    --query "sort_by([].{roleName:roleName, description:description}, &roleName)" \
    --output table
```

For example, to allow the managed identity with the ID of `99999999-9999-9999-9999-999999999999` read, write, and delete access to Azure Storage blob containers and data to all storage accounts in the *msdocs-dotnet-sdk-auth-example* resource group, you would assign the application service principal to the *Storage Blob Data Contributor* role using the following command.

```azurecli
az role assignment create --assignee 99999999-9999-9999-9999-999999999999 \
    --role "Storage Blob Data Contributor" \
    --resource-group "msdocs-dotnet-sdk-auth-example"
```

For information on assigning permissions at the resource or subscription level using the Azure CLI, see the article [Assign Azure roles using the Azure CLI](/azure/role-based-access-control/role-assignments-cli).

---

## 3 - Implement DefaultAzureCredential in your application

[!INCLUDE [Implement Default Azure Credentials](<../includes/implement-defaultazurecredential.md>)]
