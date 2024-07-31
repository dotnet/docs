---
title: Authenticate .NET apps to Azure services during local development using developer accounts
description: This article describes how to authenticate your application to Azure services when using the Azure SDK for .NET during local development using developer accounts.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-azurecli
ms.date: 07/31/2024
---

# Authenticate .NET apps to Azure services during local development using developer accounts

When creating cloud applications, developers need to debug and test applications on their local workstation. When an application is run on a developer's workstation during local development, it still must authenticate to any Azure services used by the app. This article covers how to use a developer's Azure credentials to authenticate the app to Azure during local development.

:::image type="content" source="../media/local-dev-dev-accounts-overview.png" alt-text="A diagram showing how an app running in local developer will obtain the application service principal from a .env file and then use that identity to connect to Azure resources.":::

For an app to authenticate to Azure during local development using the developer's Azure credentials, the developer must be signed-in to Azure from the VS Code Azure Tools extension, the Azure CLI, or Azure PowerShell.  The Azure SDK for .NET is able to detect that the developer is signed-in from one of these tools and then obtain the necessary credentials from the credentials cache to authenticate the app to Azure as the signed-in user.

This approach is easiest to set up for a development team since it takes advantage of the developers' existing Azure accounts. However, a developer's account will likely have more permissions than required by the application, therefore exceeding the permissions the app will run with in production. As an alternative, you can [create application service principals to use during local development](./local-development-service-principal.md) which can be scoped to have only the access needed by the app.

## 1 - Create Microsoft Entra group for local development

Since there are almost always multiple developers who work on an application, it's recommended to first create a Microsoft Entra group to encapsulate the roles (permissions) the app needs in local development. This approach offers the following advantages:

- Every developer is assured to have the same roles assigned since roles are assigned at the group level.
- If a new role is needed for the app, it only needs to be added to the Microsoft Entra group for the app.
- If a new developer joins the team, they simply must be added to the correct Microsoft Entra group to get the correct permissions to work on the app.

If you have an existing Microsoft Entra group for your development team, you can use that group. Otherwise, complete the following steps to create a Microsoft Entra group.

### [Azure CLI](#tab/azure-cli)

The [az ad group create](/cli/azure/ad/group#az-ad-group-create) command is used to create groups in Microsoft Entra ID. The `--display-name` and `--mail-nickname` parameters are required. The name given to the group should be based on the name of the application. It's also useful to include a phrase like 'local-dev' in the name of the group to indicate the purpose of the group.

```azurecli
az ad group create \
    --display-name MyDisplay \
    --mail-nickname MyDisplay \
    --description <group-description>
```

Copy the value of the `id` property in the output of the command. This is the object ID for the group. You need it in later steps. You can also use the [az ad group show](/cli/azure/ad/group#az-ad-group-show) command to retrieve this property.

To add members to the group, you need the object ID of the Azure user. Use the [az ad user list](/cli/azure/ad/sp#az-ad-user-list) to list the available service principals. The `--filter` parameter command accepts OData-style filters and can be used to filter the list on the display name of the user as shown. The `--query` parameter limits the output to columns of interest.

```azurecli
az ad user list \
    --filter "startswith(displayName, 'Bob')" \
    --query "[].{objectId:id, displayName:displayName}" \
    --output table
```

The [az ad group member add](/cli/azure/ad/group/member#az-ad-group-member-add) command can then be used to add members to groups:

```azurecli
az ad group member add \
    --group <group-name> \
    --member-id <object-id>
```

### [Azure portal](#tab/azure-portal)

| Instructions    | Screenshot |
|:----------------|-----------:|
| [!INCLUDE [Create app group step 1](<../includes/local-dev-accounts-app-group-azure-portal-1.md>)] | :::image type="content" source="../media/local-dev-accounts-app-group-azure-portal-1-240px.png" alt-text="A screenshot showing how to use the top search bar in the Azure portal to search for and navigate to the Microsoft Entra ID page." lightbox="../media/local-dev-accounts-app-group-azure-portal-1.png"::: |
| [!INCLUDE [Create app group step 2](<../includes/local-dev-accounts-app-group-azure-portal-2.md>)] | :::image type="content" source="../media/local-dev-accounts-app-group-azure-portal-2-240px.png" alt-text="A screenshot showing the location of the Groups menu item in the left-hand menu of the Microsoft Entra ID Default Directory page." lightbox="../media/local-dev-accounts-app-group-azure-portal-2.png"::: |
| [!INCLUDE [Create app group step 3](<../includes/local-dev-accounts-app-group-azure-portal-3.md>)] | :::image type="content" source="../media/local-dev-accounts-app-group-azure-portal-3-240px.png" alt-text="A screenshot showing the location of the New Group button in the All groups page." lightbox="../media/local-dev-accounts-app-group-azure-portal-3.png"::: |
| [!INCLUDE [Create app group step 4](<../includes/local-dev-accounts-app-group-azure-portal-4.md>)] | :::image type="content" source="../media/local-dev-accounts-app-group-azure-portal-4-240px.png" alt-text="A screenshot showing how to create a new Microsoft Entra group. The location of the link to select to add members to this group is highlighted." lightbox="../media/local-dev-accounts-app-group-azure-portal-4.png"::: |
| [!INCLUDE [Create app group step 5](<../includes/local-dev-accounts-app-group-azure-portal-5.md>)] | :::image type="content" source="../media/local-dev-accounts-app-group-azure-portal-5-240px.png" alt-text="A screenshot of the Add members dialog box showing how to select developer accounts to be included in the group." lightbox="../media/local-dev-accounts-app-group-azure-portal-5.png"::: |
| [!INCLUDE [Create app group step 6](<../includes/local-dev-accounts-app-group-azure-portal-6.md>)] | :::image type="content" source="../media/local-dev-accounts-app-group-azure-portal-6-240px.png" alt-text="A screenshot of the New Group page showing how to complete the process by selecting the Create button." lightbox="../media/local-dev-accounts-app-group-azure-portal-6.png"::: |

---

> [!NOTE]
> By default, the creation of Microsoft Entra groups is limited to certain privileged roles in a directory. If you're unable to create a group, contact an administrator for your directory. If you're unable to add members to an existing group, contact the group owner or a directory administrator. To learn more, see [Manage Microsoft Entra groups and group membership](/entra/fundamentals/how-to-manage-groups).

## 2 - Assign roles to the Microsoft Entra group

Next, you need to determine what roles (permissions) your app needs on what resources and assign those roles to your app. In this example, the roles will be assigned to the Microsoft Entra group created in step 1. Roles can be assigned a role at a resource, resource group, or subscription scope. This example will show how to assign roles at the resource group scope since most applications group all their Azure resources into a single resource group.

### [Azure portal](#tab/azure-portal)

| Instructions    | Screenshot |
|:----------------|-----------:|
| [!INCLUDE [Assign dev service principal to role step 1](<../includes/assign-local-dev-group-to-role-azure-portal-1.md>)] | :::image type="content" source="../media/assign-local-dev-group-to-role-azure-portal-1-240px.png" alt-text="A screenshot showing how to use the top search box in the Azure portal to locate and navigate to the resource group you want to assign roles (permissions) to." lightbox="../media/assign-local-dev-group-to-role-azure-portal-1.png"::: |
| [!INCLUDE [Assign dev service principal to role step 1](<../includes/assign-local-dev-group-to-role-azure-portal-2.md>)] | :::image type="content" source="../media/assign-local-dev-group-to-role-azure-portal-2-240px.png" alt-text="A screenshot of the resource group page showing the location of the Access control (IAM) menu item." lightbox="../media/assign-local-dev-group-to-role-azure-portal-2.png"::: |
| [!INCLUDE [Assign dev service principal to role step 1](<../includes/assign-local-dev-group-to-role-azure-portal-3.md>)] | :::image type="content" source="../media/assign-local-dev-group-to-role-azure-portal-3-240px.png" alt-text="A screenshot showing how to navigate to the role assignments tab and the location of the button used to add role assignments to a resource group." lightbox="../media/assign-local-dev-group-to-role-azure-portal-3.png"::: |
| [!INCLUDE [Assign dev service principal to role step 1](<../includes/assign-local-dev-group-to-role-azure-portal-4.md>)] | :::image type="content" source="../media/assign-local-dev-group-to-role-azure-portal-4-240px.png" alt-text="A screenshot showing how to filter and select role assignments to be added to the resource group." lightbox="../media/assign-local-dev-group-to-role-azure-portal-4.png"::: |
| [!INCLUDE [Assign dev service principal to role step 1](<../includes/assign-local-dev-group-to-role-azure-portal-5.md>)] | :::image type="content" source="../media/assign-local-dev-group-to-role-azure-portal-5-240px.png" alt-text="A screenshot showing the radio button to select to assign a role to a Microsoft Entra group and the link used to select the group to assign the role to." lightbox="../media/assign-local-dev-group-to-role-azure-portal-5.png"::: |
| [!INCLUDE [Assign dev service principal to role step 1](<../includes/assign-local-dev-group-to-role-azure-portal-6.md>)] | :::image type="content" source="../media/assign-local-dev-group-to-role-azure-portal-6-240px.png" alt-text="A screenshot showing how to filter for and select the Microsoft Entra group for the application in the Select members dialog box." lightbox="../media/assign-local-dev-group-to-role-azure-portal-6.png"::: |
| [!INCLUDE [Assign dev service principal to role step 1](<../includes/assign-local-dev-group-to-role-azure-portal-7.md>)] | :::image type="content" source="../media/assign-local-dev-group-to-role-azure-portal-7-240px.png" alt-text="A screenshot showing the completed Add role assignment page and the location of the Review + assign button used to complete the process." lightbox="../media/assign-local-dev-group-to-role-azure-portal-7.png"::: |

### [Azure CLI](#tab/azure-cli)

An application service principal is assigned a role in Azure using the [az role assignment create](/cli/azure/role/assignment) command.

```azurecli
az role assignment create --assignee "{appId}" \
    --role "{roleName}" \
    --resource-group "{resourceGroupName}"
```

To get the role names that a service principal can be assigned to, use the [az role definition list](/cli/azure/role/definition#az-role-definition-list) command.

```azurecli
az role definition list \
    --query "sort_by([].{roleName:roleName, description:description}, &roleName)" \
    --output table
```

For example, to allow the application service principal with the appId of `00000000-0000-0000-0000-000000000000` read, write, and delete access to Azure Storage blob containers and data to all storage accounts in the *msdocs-dotnet-sdk-auth-example* resource group, you would assign the application service principal to the *Storage Blob Data Contributor* role using the following command.

```azurecli
az role assignment create --assignee "00000000-0000-0000-0000-000000000000" \
    --role "Storage Blob Data Contributor" \
    --resource-group "msdocs-dotnet-sdk-auth-example"
```

For information on assigning permissions at the resource or subscription level using the Azure CLI, see [Assign Azure roles using the Azure CLI](/azure/role-based-access-control/role-assignments-cli).

---

## 3 - Sign-in to Azure using .NET tooling

Next you need to sign in to Azure using one of several .NET tooling options. The account you authenticate should also exist in the Microsoft Entra group you created and configured earlier.

### [Visual Studio](#tab/visual-studio)

On the top menu of Visual Studio, navigate to **Tools** > **Options** to open the options dialog. In the search bar in the upper left, type *Azure* to filter the options. Under the **Azure Service Authentication**, choose **Account Selection**.

Select the drop-down menu under **Choose an account** and choose to add a Microsoft Account. A window will open prompting you to pick an account. Enter the credentials for your desired Azure account, and then select the confirmation.

:::image type="content" source="../media/visual-studio-sign-in.png" alt-text="A screenshot showing how to sign in to Azure using Visual Studio.":::

### [Azure CLI](#tab/azure-cli)

Open a terminal on your developer workstation and sign in to Azure from the [Azure CLI](/cli/azure/what-is-azure-cli):

```azurecli
az login
```

### [Azure Developer CLI](#tab/azure-developer-cli)

Open a terminal on your developer workstation and sign in to Azure from the [Azure Developer CLI](/azure/developer/azure-developer-cli/overview):

```azdeveloper
azd auth login
```

### [Azure PowerShell](#tab/azure-powershell)

Open a terminal on your developer workstation and sign in to Azure from [Azure PowerShell](/powershell/azure/what-is-azure-powershell):

```azurepowershell
Connect-AzAccount
```

---

## 4 - Implement DefaultAzureCredential in your application

[!INCLUDE [Implement DefaultAzureCredential](<../includes/implement-defaultazurecredential.md>)]
