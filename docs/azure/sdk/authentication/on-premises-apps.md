---
title: Authenticate to Azure resources from .NET apps hosted on-premises
description: This article describes how to authenticate your application to Azure services when using the Azure SDK for .NET in on-premises hosted applications. 
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23
ms.date: 2/28/2023
---

# Authenticate to Azure resources from .NET apps hosted on-premises

Apps hosted outside of Azure (for example on-premises or at a third-party data center) should use an application service principal to authenticate to Azure when accessing Azure resources.  Application service principal objects are created using the app registration process in Azure.  When an application service principal is created, a client ID and client secret will be generated for your app.  The client ID, client secret, and your tenant ID are then stored in environment variables so they can be used by the Azure SDK for .NET to authenticate your app to Azure at runtime.

A different app registration should be created for each environment the app is hosted in.  This allows environment specific resource permissions to be configured for each service principal and make sure an app deployed to one environment does not talk to Azure resources that are part of another environment.

## 1 - Register the application in Azure

An app can be registered with Azure using either the Azure portal or the Azure CLI.

### [Azure portal](#tab/azure-portal)

Sign in to the [Azure portal](https://portal.azure.com/) and follow these steps.

| Instructions    | Screenshot |
|:----------------|-----------:|
| [!INCLUDE [Create app registration step 1](<../includes/on-premises-app-registration-azure-portal-1.md>)] | :::image type="content" source="./media/on-premises-app-registration-azure-portal-1-240px.png" lightbox="./media/on-premises-app-registration-azure-portal-1.png" alt-text="A screenshot showing how to use the top search bar in the Azure portal to find and navigate to the App registrations page." ::: |
| [!INCLUDE [Create app registration step 2](<../includes/on-premises-app-registration-azure-portal-2.md>)] | :::image type="content" source="./media/on-premises-app-registration-azure-portal-2-240px.png" lightbox="./media/on-premises-app-registration-azure-portal-2.png" alt-text="A screenshot showing the location of the New registration button in the App registrations page." ::: |
| [!INCLUDE [Create app registration step 3](<../includes/on-premises-app-registration-azure-portal-3.md>)] | :::image type="content" source="./media/on-premises-app-registration-azure-portal-3-240px.png" lightbox="./media/on-premises-app-registration-azure-portal-3.png" alt-text="A screenshot showing how to fill out the Register an application page by giving the app a name and specifying supported account types as accounts in this organizational directory only." ::: |
| [!INCLUDE [Create app registration step 4](<../includes/on-premises-app-registration-azure-portal-4.md>)] | :::image type="content" source="./media/on-premises-app-registration-azure-portal-4-240px.png" lightbox="./media/on-premises-app-registration-azure-portal-4.png" alt-text="A screenshot of the App registration page after the app registration has been completed.  This screenshot shows the location of the application ID and tenant ID which will be needed in a future step.  It also shows the location of the link to use to add an application secret for the app." ::: |
| [!INCLUDE [Create app registration step 5](<../includes/on-premises-app-registration-azure-portal-5.md>)] | :::image type="content" source="./media/on-premises-app-registration-azure-portal-5-240px.png" lightbox="./media/on-premises-app-registration-azure-portal-5.png" alt-text="A screenshot showing the location of the link to use to create a new client secret on the certificates and secrets page." ::: |
| [!INCLUDE [Create app registration step 6](<../includes/on-premises-app-registration-azure-portal-6.md>)] | :::image type="content" source="./media/on-premises-app-registration-azure-portal-6-240px.png" lightbox="./media/on-premises-app-registration-azure-portal-6.png" alt-text="A screenshot showing the page where a new client secret is added for the application service principal created by the app registration process." ::: |
| [!INCLUDE [Create app registration step 7](<../includes/on-premises-app-registration-azure-portal-7.md>)] | :::image type="content" source="./media/on-premises-app-registration-azure-portal-7-240px.png" lightbox="./media/on-premises-app-registration-azure-portal-7.png" alt-text="A screenshot showing the page with the generated client secret." ::: |

### [Azure CLI](#tab/azure-cli)

```azurecli
az ad sp create-for-rbac --name <app-name>
```

The output of the command will be similar to the following.  Make note of these values or keep this window open as you will need these values in the next step and will not be able to view the password (client secret) value again.

```json
{
  "appId": "00000000-1111-2222-3333-444444444444",
  "displayName": "msdocs-dotnet-sdk-auth-prod",
  "password": "abcdefghijklmnopqrstuvwxyz",
  "tenant": "00000000-0000-0000-0000-000000000000"
}
```

---

## 2 - Assign roles to the application service principal

Next, you need to determine what roles (permissions) your app needs on what resources and assign those roles to your app. Roles can be assigned a role at a resource, resource group, or subscription scope.  This example will show how to assign roles for the service principal at the resource group scope since most applications group all their Azure resources into a single resource group.

### [Azure portal](#tab/azure-portal)

| Instructions    | Screenshot |
|:----------------|-----------:|
| [!INCLUDE [Assign service principal to role step 1](<../includes/assign-service-principal-to-role-azure-portal-1.md>)] | :::image type="content" source="./media/assign-service-principal-to-role-azure-portal-1-240px.png" lightbox="./media/assign-service-principal-to-role-azure-portal-1.png" alt-text="A screenshot showing how to use the top search box in the Azure portal to locate and navigate to the resource group you want to assign roles (permissions) to." ::: |
| [!INCLUDE [Assign service principal to role step 2](<../includes/assign-service-principal-to-role-azure-portal-2.md>)] | :::image type="content" source="./media/assign-service-principal-to-role-azure-portal-2-240px.png" lightbox="./media/assign-service-principal-to-role-azure-portal-2.png" alt-text="A screenshot of the resource group page showing the location of the Access control (IAM) menu item." ::: |
| [!INCLUDE [Assign service principal to role step 3](<../includes/assign-service-principal-to-role-azure-portal-3.md>)] | :::image type="content" source="./media/assign-service-principal-to-role-azure-portal-3-240px.png" lightbox="./media/assign-service-principal-to-role-azure-portal-3.png" alt-text="A screenshot showing how to navigate to the role assignments tab and the location of the button used to add role assignments to a resource group." ::: |
| [!INCLUDE [Assign service principal to role step 4](<../includes/assign-service-principal-to-role-azure-portal-4.md>)] | :::image type="content" source="./media/assign-service-principal-to-role-azure-portal-4-240px.png" lightbox="./media/assign-service-principal-to-role-azure-portal-4.png" alt-text="A screenshot showing how to filter and select role assignments to be added to the resource group." ::: |
| [!INCLUDE [Assign service principal to role step 5](<../includes/assign-service-principal-to-role-azure-portal-5.md>)] | :::image type="content" source="./media/assign-service-principal-to-role-azure-portal-5-240px.png" lightbox="./media/assign-service-principal-to-role-azure-portal-5.png" alt-text="A screenshot showing the radio button to select to assign a role to an Azure AD group and the link used to select the group to assign the role to." ::: |
| [!INCLUDE [Assign service principal to role step 6](<../includes/assign-service-principal-to-role-azure-portal-6.md>)] | :::image type="content" source="./media/assign-service-principal-to-role-azure-portal-6-240px.png" lightbox="./media/assign-service-principal-to-role-azure-portal-6.png" alt-text="A screenshot showing how to filter for and select the Azure AD group for the application in the Select members dialog box." ::: |
| [!INCLUDE [Assign service principal to role step 7](<../includes/assign-service-principal-to-role-azure-portal-7.md>)] | :::image type="content" source="./media/assign-service-principal-to-role-azure-portal-7-240px.png" lightbox="./media/assign-service-principal-to-role-azure-portal-7.png" alt-text="A screenshot showing the completed Add role assignment page and the location of the Review + assign button used to complete the process." ::: |

### [Azure CLI](#tab/azure-cli)

A service principal is assigned a role in Azure using the [az role assignment create](/cli/azure/role/assignment#az-role-assignment-create) command.

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

For example, to allow the service principal with the appId of `00000000-0000-0000-0000-000000000000` read, write, and delete access to Azure Storage blob containers and data to all storage accounts in the *msdocs-dotnet-sdk-auth-example* resource group, you would assign the application service principal to the *Storage Blob Data Contributor* role using the following command.

```azurecli
az role assignment create --assignee "00000000-0000-0000-0000-000000000000" \
    --role "Storage Blob Data Contributor" \
    --resource-group "msdocs-dotnet-sdk-auth-example"
```

For information on assigning permissions at the resource or subscription level using the Azure CLI, see the article [Assign Azure roles using the Azure CLI](/azure/role-based-access-control/role-assignments-cli).

---

## 3 - Configure environment variables for application

The `DefaultAzureCredential` object will look for service principal credentials in a set of environment variables at runtime. There are multiple ways to configure environment variables when working with .NET depending on your tooling and environment.

Regardless of which approach you choose, you will need to configure the following environment variables when working with a service principal.

- `AZURE_CLIENT_ID` &rarr; The app ID value.
- `AZURE_TENANT_ID` &rarr; The tenant ID value.
- `AZURE_CLIENT_SECRET` &rarr; The password/credential generated for the app.

### [IIS](#tab/iis-app-pool)

If your app is hosted in IIS it is recommended that you set environment variables per app pool to isolate settings between applications.

```bash
appcmd.exe set config -section:system.applicationHost/applicationPools /+"[name='Contoso'].environmentVariables.[name='ASPNETCORE_ENVIRONMENT',value='Production']" /commit:apphost
appcmd.exe set config -section:system.applicationHost/applicationPools /+"[name='Contoso'].environmentVariables.[name='AZURE_CLIENT_ID',value='00000000-0000-0000-0000-000000000000']" /commit:apphost
appcmd.exe set config -section:system.applicationHost/applicationPools /+"[name='Contoso'].environmentVariables.[name='AZURE_TENANT_ID',value='11111111-1111-1111-1111-111111111111']" /commit:apphost
appcmd.exe set config -section:system.applicationHost/applicationPools /+"[name='Contoso'].environmentVariables.[name='AZURE_CLIENT_SECRET',value='=abcdefghijklmnopqrstuvwxyz']" /commit:apphost
```

You can also configure these settings directly using the `applicationPools` element inside of the `applicationHost.config` file.

```xml
<applicationPools>
   <add name="CorePool" managedRuntimeVersion="v4.0" managedPipelineMode="Classic">
      <environmentVariables>
         <add name="ASPNETCORE_ENVIRONMENT" value="Development" />
         <add name="AZURE_CLIENT_ID" value="00000000-0000-0000-0000-000000000000" />
         <add name="AZURE_TENANT_ID" value="11111111-1111-1111-1111-111111111111" />
         <add name="AZURE_CLIENT_SECRET" value="=abcdefghijklmnopqrstuvwxyz" />
      </environmentVariables>
   </add>
</applicationPools>
```

### [Windows](#tab/windows)

You can set environment variables for Windows from the command line. However, when using this approach the values are accessible to all applications running on that operating system and may cause conflicts if you are not careful. Environment variables can be set at either user or system level.

```bash
# Set user environment variables
setx ASPNETCORE_ENVIRONMENT "Development"
setx AZURE_CLIENT_ID "00000000-0000-0000-0000-000000000000"
setx AZURE_TENANT_ID "11111111-1111-1111-1111-111111111111"
setx AZURE_CLIENT_SECRET "=abcdefghijklmnopqrstuvwxyz"

# Set system environment variables - requires running as admin
setx ASPNETCORE_ENVIRONMENT "Development"
setx AZURE_CLIENT_ID "00000000-0000-0000-0000-000000000000" /m
setx AZURE_TENANT_ID "11111111-1111-1111-1111-111111111111" /m
setx AZURE_CLIENT_SECRET "=abcdefghijklmnopqrstuvwxyz" /m
```

You can also use PowerShell to set environment variables at either the user or machine level.

```powershell
# Set user environment variables
[Environment]::SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development", "User")
[Environment]::SetEnvironmentVariable("AZURE_CLIENT_ID", "00000000-0000-0000-0000-000000000000", "User")
[Environment]::SetEnvironmentVariable("AZURE_TENANT_ID", "11111111-1111-1111-1111-111111111111", "User")
[Environment]::SetEnvironmentVariable("AZURE_CLIENT_SECRET", "=abcdefghijklmnopqrstuvwxyz", "User")

# Set system environment variables - requires running as admin
[Environment]::SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development", "Machine")
[Environment]::SetEnvironmentVariable("AZURE_CLIENT_ID", "00000000-0000-0000-0000-000000000000", "Machine")
[Environment]::SetEnvironmentVariable("AZURE_TENANT_ID", "11111111-1111-1111-1111-111111111111", "Machine")
[Environment]::SetEnvironmentVariable("AZURE_CLIENT_SECRET", "=abcdefghijklmnopqrstuvwxyz", "Machine")
```

---

## 4 - Implement DefaultAzureCredential in application

[!INCLUDE [Implement Default Azure Credentials](<../includes/implement-defaultazurecredential.md>)]
