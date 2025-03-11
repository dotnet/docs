---
title: Authenticate .NET apps to Azure services during local development using service principals
description: Learn how to authenticate your app to Azure services during local development using dedicated application service principals.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23, devx-track-azurecli
ms.date: 03/04/2025
---

# Authenticate .NET apps to Azure services during local development using service principals

During local development, applications need to authenticate to Azure to access various Azure services. Two common approaches for local authentication are to [use a developer account](local-development-dev-accounts.md) or a service principal. This article explains how to use an application service principal. In the sections ahead, you learn:

- How to register an application with Microsoft Entra to create a service principal
- How to use Microsoft Entra groups to efficiently manage permissions
- How to assign roles to scope permissions
- How to authenticate using a service principal from your app code

Using dedicated application service principals allows you to adhere to the principle of least privilege when accessing Azure resources. Permissions are limited to the specific requirements of the app during development, preventing accidental access to Azure resources intended for other apps or services. This approach also helps avoid issues when the app is moved to production by ensuring it isn't over-privileged in the development environment.

:::image type="content" source="../media/local-dev-service-principal-overview.png" alt-text="A diagram showing how a local .NET app uses the developer's credentials to connect to Azure by using locally installed development tools.":::

When the app is registered in Azure, an application service principal is created. For local development:

- Create a separate app registration for each developer working on the app to ensure each developer has their own application service principal, avoiding the need to share credentials.
- Create a separate app registration for each app to limit the app's permissions to only what is necessary.

During local development, environment variables are set with the application service principal's identity. The Azure Identity library reads these environment variables to authenticate the app to the required Azure resources.

## Register the app in Azure

Application service principal objects are created through an app registration in Azure using either the Azure portal or Azure CLI.

### [Azure portal](#tab/azure-portal)

1. In the Azure portal, use the search bar to navigate to the **App registrations** page.
1. On the **App registrations** page, select **+ New registration**.
1. On the **Register an application** page:
    - For the **Name** field, enter a descriptive value that includes the app name and the target environment.
    - For the **Supported account types**, select **Accounts in this organizational directory only (Microsoft Customer Led only - Single tenant)**, or whichever option best fits your requirements.
1. Select **Register** to register your app and create the service principal.

    :::image type="content" source="../../media/app-registration.png" alt-text="A screenshot showing how to create an app registration in the Azure portal.":::

1. On the **App registration** page for your app, copy the **Application (client) ID** and **Directory (tenant) ID** and paste them in a temporary location for later use in your app code configurations.
1. Select **Add a certificate or secret** to set up credentials for your app.
1. On the **Certificates & secrets** page, select **+ New client secret**.
1. In the **Add a client secret** flyout panel that opens:
    - For the **Description**, enter a value of Current.
    - For the **Expires** value, leave the default recommended value of 180 days.
    - Select **Add** to add the secret.
1. On the **Certificates & secrets** page, copy the **Value** property of the client secret for use in a future step.

    > [!NOTE]
    > The client secret value is only displayed once after the app registration is created. You can add more client secrets without invalidating this client secret, but there's no way to display this value again.

### [Azure CLI](#tab/azure-cli)

Azure CLI commands can be run in the [Azure Cloud Shell](https://shell.azure.com) or on a workstation with the [Azure CLI installed](/cli/azure/install-azure-cli).

1. Use the [az ad sp create-for-rbac](/cli/azure/ad/sp#az-ad-sp-create-for-rbac) command to create a new app registration and service principal for the app.

    ```azurecli
    az ad sp create-for-rbac --name <service-principal-name>
    ```

    The output of this command resembles the following JSON:

    ```json
    {
      "appId": "00000000-0000-0000-0000-000000000000",
      "displayName": "<service-principal-name>",
      "password": "abcdefghijklmnopqrstuvwxyz",
      "tenant": "11111111-1111-1111-1111-111111111111"
    }
    ```

1. Copy this output into a temporary file in a text editor, as you'll need these values in a future step.

    > [!NOTE]
    > The client secret value is only displayed once after the app registration is created. You can add more client secrets without invalidating this client secret, but there's no way to display this value again.

---

## Create a Microsoft Entra group for local development

Create a Microsoft Entra group to encapsulate the roles (permissions) the app needs in local development rather than assigning the roles to individual service principal objects. This approach offers the following advantages:

- Every developer has the same roles assigned at the group level.
- If a new role is needed for the app, it only needs to be added to the group for the app.
- If a new developer joins the team, a new application service principal is created for the developer and added to the group, ensuring the developer has the right permissions to work on the app.

### [Azure portal](#tab/azure-portal)

1. Navigate to the **Microsoft Entra ID** overview page in the Azure portal.
1. Select **All groups** from the left-hand menu.
1. On the **Groups** page, select **New group**.
1. On the **New group** page, fill out the following form fields:
    - **Group type**: Select **Security**.
    - **Group name**: Enter a name for the group that includes a reference to the app or environment name.
    - **Group description**: Enter a description that explains the purpose of the group.

    :::image type="content" source="../../media/create-group.png" alt-text="A screenshot showing how to create a group in the Azure portal.":::

1. Select the **No members selected** link under **Members** to add members to the group.
1. In the flyout panel that opens, search for the service principal you created earlier and select it from the filtered results. Choose the **Select** button at the bottom of the panel to confirm your selection.
1. Select **Create** at the bottom of the **New group** page to create the group and return to the **All groups** page. If you don't see the new group listed, wait a moment and refresh the page.

### [Azure CLI](#tab/azure-cli)

1. Use the [az ad group create](/cli/azure/ad/group#az-ad-group-create) command to create groups in Microsoft Entra ID.

    ```azurecli
    az ad group create \
        --display-name <group-name> \
        --mail-nickname <group-mail-nickname> \
        --description <group-description>
    ```

    The `--display-name` and `--mail-nickname` parameters are required. The name given to the group should be based on the name and environment of the app to indicate the group's purpose.

1. To add members to the group, you need the object ID of the application service principal, which is different than the application ID. Use the [az ad sp list](/cli/azure/ad/sp#az-ad-sp-list) command to list the available service principals:

    ```azurecli
    az ad sp list \
        --filter "startswith(displayName, '<group-name>')" \
        --query "[].{objectId:id, displayName:displayName}"
    ```

    The `--filter` parameter accepts OData-style filters and can be used to filter the list as shown. The `--query` parameter limits the output to only the columns of interest.

1. Use the [az ad group member add](/cli/azure/ad/group/member#az-ad-group-member-add) command to add members to the group:

    ```azurecli
    az ad group member add --group <group-name> --member-id <object-id>
    ```

---

## Assign roles to the group

Next, determine what roles (permissions) your app needs on what resources and assign those roles to the Microsoft Entra group you created. Groups can be assigned a role at the resource, resource group, or subscription scope. This example shows how to assign roles at the resource group scope, since most apps group all their Azure resources into a single resource group.

### [Azure portal](#tab/azure-portal)

1. In the Azure portal, navigate to the **Overview** page of the resource group that contains your app.
1. Select **Access control (IAM)** from the left navigation.
1. On the **Access control (IAM)** page, select **+ Add** and then choose **Add role assignment** from the drop-down menu. The **Add role assignment** page provides several tabs to configure and assign roles.
1. On the **Role** tab, use the search box to locate the role you want to assign. Select the role, and then choose **Next**.
1. On the **Members** tab:
    - For the **Assign access to** value, select **User, group, or service principal** .
    - For the **Members** value, choose **+ Select members** to open the **Select members** flyout panel.
    - Search for the Microsoft Entra group you created earlier and select it from the filtered results. Choose **Select** to select the group and close the flyout panel.
    - Select **Review + assign** at the bottom of the **Members** tab.

    :::image type="content" source="../../media/app-role-assignment.png" alt-text="A screenshot showing how to assign a role to the Microsoft Entra group.":::

1. On the **Review + assign** tab, select **Review + assign** at the bottom of the page.

### [Azure CLI](#tab/azure-cli)

1. Use the [az role definition list](/cli/azure/role/definition#az-role-definition-list) command to get the names of the roles that a service principal can be assigned to:

    ```azurecli
    az role definition list \
        --query "sort_by([].{roleName:roleName, description:description}, &roleName)" \
        --output table
    ```

1. Use the [az role assignment create](/cli/azure/role/assignment#az-role-assignment-create) command to assign a role to an application service principal:

    ```azurecli
    az role assignment create \
        --assignee "<app-Id>" \
        --role "<role-name>" \
        --resource-group "<resource-group-name>"
    ```

    For information on assigning permissions at the resource or subscription level using the Azure CLI, see [Assign Azure roles using the Azure CLI](/azure/role-based-access-control/role-assignments-cli).

---

## Set the app environment variables

At runtime, certain credentials from the [Azure Identity library](/dotnet/api/azure.identity?view=azure-dotnet&preserve-view=true), such as `DefaultAzureCredential` and `ClientSecretCredential`, search for service principal information by convention in the environment variables. There are multiple ways to configure environment variables when working with .NET, depending on your tooling and environment.

Regardless of the approach you choose, configure the following environment variables for a service principal:

- `AZURE_CLIENT_ID`: Used to identify the registered app in Azure.
- `AZURE_TENANT_ID`: The ID of the Microsoft Entra tenant.
- `AZURE_CLIENT_SECRET`: The secret credential that was generated for the app.

### [Visual Studio](#tab/visual-studio)

In Visual Studio, environment variables can be set in the `launchsettings.json` file in the `Properties` folder of your project. These values are pulled in automatically when the app starts. However, these configurations don't travel with your app during deployment, so you need to set up environment variables on your target hosting environment.

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

In Visual Studio Code, environment variables can be set in the `launch.json` file of your project. These values are pulled in automatically when the app starts. However, these configurations don't travel with your app during deployment, so you need to set up environment variables on your target hosting environment.

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

You can set environment variables for Windows from the command line. However, the values are accessible to all apps running on that operating system and could cause conflicts, so use caution with this approach. Environment variables can be set at the user or system level.

```bash
# Set user environment variables
setx ASPNETCORE_ENVIRONMENT "Development"
setx AZURE_CLIENT_ID "<your-client-id>"
setx AZURE_TENANT_ID "<your-tenant-id>"
setx AZURE_CLIENT_SECRET "<your-client-secret>"

# Set system environment variables - requires running as admin
setx ASPNETCORE_ENVIRONMENT "Development" /m
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

[!INCLUDE [Implement Service Principal](<../includes/implement-service-principal.md>)]
