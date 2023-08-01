---
title: Authenticate .NET apps to Azure services during local development using developer accounts
description: This article describes how to authenticate your application to Azure services when using the Azure SDK for .NET during local development using developer accounts.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-azurecli
ms.date: 2/28/2023
---

# Authenticate .NET apps to Azure services during local development using developer accounts

When creating cloud applications, developers need to debug and test applications on their local workstation. When an application is run on a developer's workstation during local development, it still must authenticate to any Azure services used by the app. This article covers how to use a developer's Azure credentials to authenticate the app to Azure during local development.

:::image type="content" source="media/local-dev-dev-accounts-overview.png" alt-text="A diagram showing how an app running in local developer will obtain the application service principal from a .env file and then use that identity to connect to Azure resources.":::

For an app to authenticate to Azure during local development using the developer's Azure credentials, the developer must be signed-in to Azure from the VS Code Azure Tools extension, the Azure CLI, or Azure PowerShell.  The Azure SDK for .NET is able to detect that the developer is signed-in from one of these tools and then obtain the necessary credentials from the credentials cache to authenticate the app to Azure as the signed-in user.

This approach is easiest to set up for a development team since it takes advantage of the developers' existing Azure accounts. However, a developer's account will likely have more permissions than required by the application, therefore exceeding the permissions the app will run with in production. As an alternative, you can [create application service principals to use during local development](./authentication-local-development-service-principal.md) which can be scoped to have only the access needed by the app.

## 1 - Create Azure AD group for local development

Since there are almost always multiple developers who work on an application, it's recommended to first create an Azure AD group to encapsulate the roles (permissions) the app needs in local development.  This offers the following advantages.

- Every developer is assured to have the same roles assigned since roles are assigned at the group level.
- If a new role is needed for the app, it only needs to be added to the Azure AD group for the app.
- If a new developer joins the team, they simply must be added to the correct Azure AD group to get the correct permissions to work on the app.

If you have an existing Azure AD group for your development team, you can use that group.  Otherwise, complete the following steps to create an Azure AD group.

### [Azure portal](#tab/azure-portal)

| Instructions    | Screenshot |
|:----------------|-----------:|
| [!INCLUDE [Create app AD group step 1](<../includes/local-dev-accounts-app-ad-group-azure-portal-1.md>)] | :::image type="content" source="./media/local-dev-accounts-app-ad-group-azure-portal-1-240px.png" alt-text="A screenshot showing how to use the top search bar in the Azure portal to search for and navigate to the Azure Active Directory page." lightbox="./media/local-dev-accounts-app-ad-group-azure-portal-1.png"::: |
| [!INCLUDE [Create app AD group step 2](<../includes/local-dev-accounts-app-ad-group-azure-portal-2.md>)] | :::image type="content" source="./media/local-dev-accounts-app-ad-group-azure-portal-2-240px.png" alt-text="A screenshot showing the location of the Groups menu item in the left-hand menu of the Azure Active Directory Default Directory page." lightbox="./media/local-dev-accounts-app-ad-group-azure-portal-2.png"::: |
| [!INCLUDE [Create app AD group step 3](<../includes/local-dev-accounts-app-ad-group-azure-portal-3.md>)] | :::image type="content" source="./media/local-dev-accounts-app-ad-group-azure-portal-3-240px.png" alt-text="A screenshot showing the location of the New Group button in the All groups page." lightbox="./media/local-dev-accounts-app-ad-group-azure-portal-3.png"::: |
| [!INCLUDE [Create app AD group step 4](<../includes/local-dev-accounts-app-ad-group-azure-portal-4.md>)] | :::image type="content" source="./media/local-dev-accounts-app-ad-group-azure-portal-4-240px.png" alt-text="A screenshot showing how to fill out the form to create a new Azure Active Directory group for the application.  This screenshot also shows the location of the link to select to add members to this group" lightbox="./media/local-dev-accounts-app-ad-group-azure-portal-4.png"::: |
| [!INCLUDE [Create app AD group step 5](<../includes/local-dev-accounts-app-ad-group-azure-portal-5.md>)] | :::image type="content" source="./media/local-dev-accounts-app-ad-group-azure-portal-5-240px.png" alt-text="A screenshot of the Add members dialog box showing how to select developer accounts to be included in the group." lightbox="./media/local-dev-accounts-app-ad-group-azure-portal-5.png"::: |
| [!INCLUDE [Create app AD group step 6](<../includes/local-dev-accounts-app-ad-group-azure-portal-6.md>)] | :::image type="content" source="./media/local-dev-accounts-app-ad-group-azure-portal-6-240px.png" alt-text="A screenshot of the New Group page showing how to complete the process by selecting the Create button." lightbox="./media/local-dev-accounts-app-ad-group-azure-portal-6.png"::: |

### [Azure CLI](#tab/azure-cli)

The [az ad group create](/cli/azure/ad/group#az-ad-group-create) command is used to create groups in Azure Active Directory.  The `--display-name` and `--main-nickname` parameters are required.  The name given to the group should be based on the name of the application.  It's also useful to include a phrase like 'local-dev' in the name of the group to indicate the purpose of the group.

```azurecli
az ad group create \
    --display-name MyDisplay \
    --mail-nickname MyDisplay  \
    --description <group-description>
```

To add members to the group, you'll need the object ID of Azure user.  Use the [az ad user list](/cli/azure/ad/sp#az-ad-user-list) to list the available service principals.  The `--filter` parameter command accepts OData style filters and can be used to filter the list on the display name of the user as shown.  The `--query` parameter limits to columns to only those of interest.

```azurecli
az ad user list \
    --filter "startswith(displayName, 'Bob')" \
    --query "[].{objectId:objectId, displayName:displayName}" \
    --output table
```

The [az ad group member add](/cli/azure/ad/group/member#az-ad-group-member-add) command can then be used to add members to groups.  

```azurecli
az ad group member add \
    --group <group-name> \
    --member-id <object-id>
```

---

## 2 - Assign roles to the Azure AD group

Next, you need to determine what roles (permissions) your app needs on what resources and assign those roles to your app.  In this example, the roles will be assigned to the Azure Active Directory group created in step 1.  Roles can be assigned a role at a resource, resource group, or subscription scope.  This example will show how to assign roles at the resource group scope since most applications group all their Azure resources into a single resource group.

### [Azure portal](#tab/azure-portal)

| Instructions    | Screenshot |
|:----------------|-----------:|
| [!INCLUDE [Assign dev service principal to role step 1](<../includes/assign-local-dev-group-to-role-azure-portal-1.md>)] | :::image type="content" source="./media/assign-local-dev-group-to-role-azure-portal-1-240px.png" alt-text="A screenshot showing how to use the top search box in the Azure portal to locate and navigate to the resource group you want to assign roles (permissions) to." lightbox="./media/assign-local-dev-group-to-role-azure-portal-1.png"::: |
| [!INCLUDE [Assign dev service principal to role step 1](<../includes/assign-local-dev-group-to-role-azure-portal-2.md>)] | :::image type="content" source="./media/assign-local-dev-group-to-role-azure-portal-2-240px.png" alt-text="A screenshot of the resource group page showing the location of the Access control (IAM) menu item." lightbox="./media/assign-local-dev-group-to-role-azure-portal-2.png"::: |
| [!INCLUDE [Assign dev service principal to role step 1](<../includes/assign-local-dev-group-to-role-azure-portal-3.md>)] | :::image type="content" source="./media/assign-local-dev-group-to-role-azure-portal-3-240px.png" alt-text="A screenshot showing how to navigate to the role assignments tab and the location of the button used to add role assignments to a resource group." lightbox="./media/assign-local-dev-group-to-role-azure-portal-3.png"::: |
| [!INCLUDE [Assign dev service principal to role step 1](<../includes/assign-local-dev-group-to-role-azure-portal-4.md>)] | :::image type="content" source="./media/assign-local-dev-group-to-role-azure-portal-4-240px.png" alt-text="A screenshot showing how to filter and select role assignments to be added to the resource group." lightbox="./media/assign-local-dev-group-to-role-azure-portal-4.png"::: |
| [!INCLUDE [Assign dev service principal to role step 1](<../includes/assign-local-dev-group-to-role-azure-portal-5.md>)] | :::image type="content" source="./media/assign-local-dev-group-to-role-azure-portal-5-240px.png" alt-text="A screenshot showing the radio button to select to assign a role to an Azure AD group and the link used to select the group to assign the role to." lightbox="./media/assign-local-dev-group-to-role-azure-portal-5.png"::: |
| [!INCLUDE [Assign dev service principal to role step 1](<../includes/assign-local-dev-group-to-role-azure-portal-6.md>)] | :::image type="content" source="./media/assign-local-dev-group-to-role-azure-portal-6-240px.png" alt-text="A screenshot showing how to filter for and select the Azure AD group for the application in the Select members dialog box." lightbox="./media/assign-local-dev-group-to-role-azure-portal-6.png"::: |
| [!INCLUDE [Assign dev service principal to role step 1](<../includes/assign-local-dev-group-to-role-azure-portal-7.md>)] | :::image type="content" source="./media/assign-local-dev-group-to-role-azure-portal-7-240px.png" alt-text="A screenshot showing the completed Add role assignment page and the location of the Review + assign button used to complete the process." lightbox="./media/assign-local-dev-group-to-role-azure-portal-7.png"::: |

### [Azure CLI](#tab/azure-cli)

An application service principal is assigned a role in Azure using the [az role assignment create](/cli/azure/role/assignment) command.

```azurecli
az role assignment create --assignee "{appId}" \
    --role "{roleName}" \
    --resource-group "{resourceGroupName}"
```

To get the role names that a service principal can be assigned to, use the [az role definition list](/cli/azure/role/definition#az-role-definition-list) command.

```azurecli
az role definition list --query "sort_by([].{roleName:roleName, description:description}, &roleName)" --output table

```

For example, to allow the application service principal with the appId of `00000000-0000-0000-0000-000000000000` read, write, and delete access to Azure Storage blob containers and data to all storage accounts in the *msdocs-dotnet-sdk-auth-example* resource group, you would assign the application service principal to the *Storage Blob Data Contributor* role using the following command.

```azurecli
az role assignment create --assignee "00000000-0000-0000-0000-000000000000" \
    --role "Storage Blob Data Contributor" \
    --resource-group "msdocs-dotnet-sdk-auth-example"
```

For information on assigning permissions at the resource or subscription level using the Azure CLI, see the article [Assign Azure roles using the Azure CLI](/azure/role-based-access-control/role-assignments-cli).

---

## 3 - Sign-in to Azure using .NET Tooling

Next you need to sign in to Azure using one of several .NET tooling options. The account you sign into should also exist in the Azure Active Directory group you created and configured earlier.

### [Visual Studio](#tab/sign-in-visual-studio)

On the top menu of Visual Studio, navigate to **Tools** > **Options** to open the options dialog. In the search bar in the upper left, type *Azure* to filter the options. Under the **Azure Service Authentication**, choose **Account Selection**.

Select the drop-down menu under **Choose an account** and choose to add a Microsoft Account.  A window will open prompting you to pick an account.  Enter the credentials for your desired Azure account, and then select the confirmation.

:::image type="content" source="./media/visual-studio-sign-in.png" alt-text="A screenshot showing how to sign in to Azure using Visual Studio.":::

### [VS Code Azure Tools extension](#tab/sign-in-vscode)

For an app to use the developer credentials from VS Code, the [VS Code Azure Tools extension must be installed](https://marketplace.visualstudio.com/items?itemName=ms-vscode.vscode-node-azure-pack) in VS Code.

> [!div class="nextstepaction"]
> [Install the Azure Tools extensions for VS Code](https://marketplace.visualstudio.com/items?itemName=ms-vscode.vscode-node-azure-pack)

On the left-hand panel, you'll see an Azure icon. Select this icon, and a control panel for Azure services will appear. Choose **Sign in to Azure...** under any service to complete the authentication process for the Azure tools in Visual Studio Code.

:::image type="content" source="./media/vs-code-azure-login-small.png" alt-text="Screenshot of the Visual Studio Code showing how to sign-in the Azure tools to Azure." lightbox="./media/vs-code-azure-login.png":::

### [Azure CLI](#tab/sign-in-azure-cli)

Open a terminal on your developer workstation and sign-in to Azure from the [Azure CLI](/cli/azure/what-is-azure-cli).

```azurecli
az login
```

### [Azure PowerShell](#tab/sign-in-azure-powershell)

Open a terminal on your developer workstation and sign-in to Azure from [Azure PowerShell](/powershell/azure/what-is-azure-powershell).

```azurepowershell
Connect-AzAccount
```

---

## 4 - Implement DefaultAzureCredential in your application

[!INCLUDE [Implement Default Azure Credentials](<../includes/implement-defaultazurecredential.md>)]
