---
title: Authenticate .NET apps to Azure services during local development using service principals
description: Learn how to authenticate your app to Azure services during local development using dedicated application service principals.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-azurecli
ms.date: 03/04/2025
---

# Authenticate .NET apps to Azure services during local development using service principals

During local development, applications must authenticate to Azure to consume various Azure services. Two common approaches to local authentication are to use [Developer accounts](local-development-dev-account.md) or a service principal. This article explains how to use a dedicated application service principal.

:::image type="content" source="../media/local-dev-service-principal-overview.png" alt-text="A diagram showing how a local .NET app uses the developer's credentials to connect to Azure by using locally installed development tools.":::

Dedicated application service principals allow you to follow the principle of least privilege when accessing Azure resources. Permissions are scoped to the exact app requirements for development, so app code cannot accidentally access an Azure resource intended for use by other apps or services. This also prevents bugs from occurring when the app is moved to production because the app was over-privileged in the dev environment.

An application service principal is set up for the app when the app is registered in Azure. When registering an app for local development, it's recommended to:

- Create a separate app registration for each developer working on the app. This will create separate application service principals for each developer to use during local development and avoid the need for developers to share credentials for a single application service principal.
- Create a separate app registration per app. This scopes the app's permissions to only what is needed by the app.

During local development, environment variables are set with the application service principal's identity. The Azure Identity library reads these environment variables and uses this information to authenticate the app to the Azure resources it needs.

## 1 - Register the application in Azure

Application service principal objects are created with an app registration in Azure. This can be done using either the Azure portal or Azure CLI.

### [Azure portal](#tab/azure-portal)

1. In the Azure portal, navigate to the **App registrations** page.
1. On the **App registrations** page, select **+ New registration**.
1. On the **Register an application** page:
    - Enter a descriptive name for the app registration. For example, you may want to include the app name and an identifier for the target environment, such as development or production.
    - For the supported account types, select **Accounts in this organizational directory only (Microsoft Customer Led only - Single tenant)**, or whichever option best fits your requirements.
1. Select **Register to register your app** and create the application service principal.

    :::image type="content" source="../../media/app-registration.png" alt-text="A screenshot showing how to create an app registration in the Azure portal.":::

1. On the **App registration page** for your app, review the following values:
    - **Application (client) ID**: The ID the app uses to access Azure during local development.
    - **Directory (tenant) ID**: This value will also be needed by your app when it authenticates to Azure.
    - **Client credentials**: You must set the client credentials for the app before your app can authenticate to Azure and use Azure services.
1. Copy the **Application (client) ID** and **Directory (tenant) ID** and paste them in a temporary location for later use in your app code configurations.
1. Select **Add a certificate or secret** to set up credentials for your app.
1. On the **Certificates & secrets** page, select **+ New client secret**.
1. In the **Add a client secret** flyout panel that opens:
    - For the **Description**, enter a value of Current.
    - For the **Expires** value, leave the default recommended value of 180 days.
    - Select **Add** to add the secret.
1. On the **Certificates & secrets** page, you'll be shown the value of the client secret. Copy this value to a temporary location, as you'll need it in a future step.

    > [!NOTE]
    > This is the only time you will see this value. You may add an additional client secret without invalidating this client secret, but there is no way to display this value again.

### [Azure CLI](#tab/azure-cli)

Azure CLI commands can be run in the [Azure Cloud Shell](https://shell.azure.com) or on a workstation with the [Azure CLI installed](/cli/azure/install-azure-cli).

First, use the [az ad sp create-for-rbac](/cli/azure/ad/sp#az-ad-sp-create-for-rbac) command to create a new service principal for the app. This will also create the app registration for the app at the same time.

```azurecli
az ad sp create-for-rbac \
    --name {service-principal-name}
```

The output of this command resembles the following JSON:

```json
{
  "appId": "00000000-0000-0000-0000-000000000000",
  "displayName": "{service-principal-name}",
  "password": "abcdefghijklmnopqrstuvwxyz",
  "tenant": "11111111-1111-1111-1111-111111111111"
}
```

Copy this output into a temporary file in a text editor, as you'll need these values in a future step.

> [!NOTE]
> This is the only time you will see this value. You may add an additional client secret without invalidating this client secret, but there is no way to display this value again.

---

## 2 - Create Microsoft Entra group for local development

Since there are typically multiple developers who work on an app, it's recommended to create a Microsoft Entra group to encapsulate the roles (permissions) the app needs in local development rather than assigning the roles to individual service principal objects. This approach offers the following advantages:

- Every developer is assured to have the same roles assigned since roles are assigned at the group level.
- If a new role is needed for the app, it only needs to be added to the group for the app.
- If a new developer joins the team, a new application service principal is created for the developer and added to the group, assuring the developer has the right permissions to work on the app.

### [Azure portal](#tab/azure-portal)

1. Navigate to the **Microsoft Entra ID** overview page in the Azure portal.
1. Select **Groups** from the left-hand menu.
1. On the **All groups** page, select **New group**.
1. On the **New group** page, fill out the following form fields:
    - **Group type**: Select **Security**.
    - **Group name**: Enter a name for the security group, which may include a reference to your app or environment name.
    - **Group description**: Enter a description of the purpose of the group.
1. Select the **No members selected** link under **Members** to add members to the group.
1. In the flyout panel that opens, search for the service principal you created earlier and select it from the filtered results. Choose the **Select** button at the bottom of the panel.
1. Select **Create** at the bottom of the **New group** page to create the group and return to the **All groups** page. You may need to wait a moment and refresh the page for the group to appear.

    :::image type="content" source="../../media/create-group.png" alt-text="A screenshot showing how to create a group in the Azure portal.":::

### [Azure CLI](#tab/azure-cli)

The [az ad group create](/cli/azure/ad/group#az-ad-group-create) command is used to create groups in Microsoft Entra ID. The `--display-name` and `--mail-nickname` parameters are required. The name given to the group should be based on the name of the app. It's also useful to include a phrase like 'local-dev' in the group's name to indicate the group's purpose.

```azurecli
az ad group create \
    --display-name MyDisplay \
    --mail-nickname MyDisplay \
    --description {group-description}
```

To add members to the group, you need the object ID of the application service principal, which is different than the application ID. Use the [az ad sp list](/cli/azure/ad/sp#az-ad-sp-list) command to list the available service principals. The `--filter` parameter command accepts OData-style filters and can be used to filter the list as shown. The `--query` parameter limits columns to only those of interest.

```azurecli
az ad sp list \
    --filter "startswith(displayName, 'msdocs')" \
    --query "[].{objectId:objectId, displayName:displayName}" \
    --output table
```

The [az ad group member add](/cli/azure/ad/group/member#az-ad-group-member-add) command can then be used to add members to the group:

```azurecli
az ad group member add \
    --group {group-name} \
    --member-id {object-id}
```

---

## 3 - Assign roles to the application

Next, determine what roles (permissions) your app needs on what resources and assign those roles to your app. In this example, the roles will be assigned to the Microsoft Entra group created in step 2. Groups can be assigned a role at a resource, resource group, or subscription scope. This example shows how to assign roles at the resource group scope, since most apps group all their Azure resources into a single resource group.

### [Azure portal](#tab/azure-portal)

1. In the Azure portal, navigate to the **Overview** page of the resource group that contains your app.
1. Select **Access control (IAM)** from the left navigation.
1. On the Access control (IAM) page, select **+ Add** and then choose **Add role assignment** from the drop-down menu.
1. The **Add role assignment** page provides several tabs to configure and assign roles.
1. On the **Role** tab use the search box to locate the role you want to assign.Select the role, and then choose **Next**.
1. On the **Members** tab:
    - For the **Assign access to** value, select **User, group, or service principal** .
    - For the **Members** value, choose **+ Select members** to open the **Select members** flyout panel.
    - Search for the Microsoft Entra group you created earlier and select it from the filtered results. Choose **Select** to select the group close the flyout panel.
    - Select **Review + assign** at the bottom of the **Members** tab.
1. On the **Review + assign** tab, select **Review + assign** at the bottom of the page.

    :::image type="content" source="../../media/app-role-assignment.png" alt-text="A screenshot showing how to assign a role to the Microsoft Entra group.":::

### [Azure CLI](#tab/azure-cli)

An application service principal is assigned a role in Azure using the [az role assignment create](/cli/azure/role/assignment#az-role-assignment-create) command:

```azurecli
az role assignment create --assignee "{appId}" \
    --role "{roleName}" \
    --resource-group "{resourceGroupName}"
```

To get the role names that a service principal can be assigned to, use the [az role definition list](/cli/azure/role/definition#az-role-definition-list) command:

```azurecli
az role definition list \
    --query "sort_by([].{roleName:roleName, description:description}, &roleName)" \
    --output table
```

For example, to allow the application service principal with the `appId` of `00000000-0000-0000-0000-000000000000` read, write, and delete access to Azure Storage blob containers and data to all storage accounts in the *msdocs-dotnet-sdk-auth-example* resource group, assign the application service principal to the *Storage Blob Data Contributor* role using the following command:

```azurecli
az role assignment create --assignee "00000000-0000-0000-0000-000000000000" \
    --role "Storage Blob Data Contributor" \
    --resource-group "msdocs-dotnet-sdk-auth-example"
```

For information on assigning permissions at the resource or subscription level using the Azure CLI, see [Assign Azure roles using the Azure CLI](/azure/role-based-access-control/role-assignments-cli).

---

## 4 - Set application environment variables

At runtime, `DefaultAzureCredential` looks for the service principal information in a collection of environment variables. There are multiple ways to configure environment variables when working with .NET, depending on your tooling and environment.

Regardless of the approach you choose, configure the following environment variables when working with a service principal:

- `AZURE_CLIENT_ID` &rarr; The app ID value.
- `AZURE_TENANT_ID` &rarr; The tenant ID value.
- `AZURE_CLIENT_SECRET` &rarr; The password/credential generated for the app.

### [Visual Studio](#tab/visual-studio)

When working locally with Visual Studio, environment variables can be set in the `launchsettings.json` file in the `Properties` folder of your project. When the app starts up, these values are pulled in automatically. Keep in mind, these configurations don't travel with your app when it's deployed, so you need to set up environment variables on your target hosting environment.

```json
"profiles": {
    "SampleProject": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "https://localhost:7177;http://localhost:5177",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "AZURE_CLIENT_ID": "<your-client-id>",
        "AZURE_TENANT_ID":"<your-tenant-id>",
        "AZURE_CLIENT_SECRET": "<your-client-secret>"
      }
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "AZURE_CLIENT_ID": "<your-client-id>",
        "AZURE_TENANT_ID":"<your-tenant-id>",
        "AZURE_CLIENT_SECRET": "<your-client-secret>"
      }
    }
  }
```

### [Visual Studio Code](#tab/vs-code)

When working locally with Visual Studio Code, environment variables can be set in the `launch.json` file of your project. When the app starts up, these values will be pulled in automatically. Keep in mind, these configurations don't travel with your app when it's deployed, so you need to set up environment variables on your target hosting environment.

```json
"configurations": [
{
    "env": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "AZURE_CLIENT_ID": "<your-client-id>",
        "AZURE_TENANT_ID":"<your-tenant-id>",
        "AZURE_CLIENT_SECRET": "<your-client-secret>"
    }
}
```

### [Windows](#tab/windows)

You can set environment variables for Windows from the command line. However, when using this approach, the values are accessible to all apps running on that operating system and may cause conflicts if you aren't careful. Environment variables can be set at the user or system level.

```bash
# Set user environment variables
setx ASPNETCORE_ENVIRONMENT "Development"
setx AZURE_CLIENT_ID "<your-client-id>"
setx AZURE_TENANT_ID "<your-tenant-id>"
setx AZURE_CLIENT_SECRET "<your-client-secret>"

# Set system environment variables - requires running as admin
setx ASPNETCORE_ENVIRONMENT "Development"
setx AZURE_CLIENT_ID "<your-client-id>" /m
setx AZURE_TENANT_ID "<your-tenant-id>" /m
setx AZURE_CLIENT_SECRET "<your-client-secret>" /m
```

PowerShell can also be used to set environment variables at the user or machine level:

```powershell
# Set user environment variables
[Environment]::SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development", "User")
[Environment]::SetEnvironmentVariable("AZURE_CLIENT_ID", "<your-client-id>", "User")
[Environment]::SetEnvironmentVariable("AZURE_TENANT_ID", "<your-tenant-id>", "User")
[Environment]::SetEnvironmentVariable("AZURE_CLIENT_SECRET", "<your-client-secret>", "User")

# Set system environment variables - requires running as admin
[Environment]::SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development", "Machine")
[Environment]::SetEnvironmentVariable("AZURE_CLIENT_ID", "<your-client-id>", "Machine")
[Environment]::SetEnvironmentVariable("AZURE_TENANT_ID", "<your-tenant-id>", "Machine")
[Environment]::SetEnvironmentVariable("AZURE_CLIENT_SECRET", "<your-client-secret>", "Machine")
```

---

## 5 - Implement DefaultAzureCredential in your application

[!INCLUDE [Implement Service Principal](<../includes/implement-service-principal.md>)]
