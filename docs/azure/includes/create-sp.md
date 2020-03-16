---
ms.service: multiple
ms.date: 9/20/2018
ms.topic: include
---
Your .NET application needs permissions to read and create resources in your Azure subscription in order to use the Azure Management Libraries for .NET. Create a service principal and configure your app to run with its credentials to grant this access. Service principals provide a way to create a non-interactive account associated with your identity to which you grant only the privileges your app needs to run.

First, login to [Azure Cloud Shell](https://shell.azure.com/bash). Verify you are currently using the subscription in which you want the service principal created. 

```azurecli-interactive
az account show
```

Your subscription information is displayed.

```json
{
  "environmentName": "AzureCloud",
  "id": "15dbcfa8-4b93-4c9a-881c-6189d39f04d4",
  "isDefault": true,
  "name": "my-subscription",
  "state": "Enabled",
  "tenantId": "43413cc1-5886-4711-9804-8cfea3d1c3ee",
  "user": {
    "cloudShellID": true,
    "name": "jane@contoso.com",
    "type": "user"
  }
}
```

If you're not logged into the correct subscription, select the correct one by typing `az account set -s <name or ID of subscription>`.

Create the service principal with the following command:

```azurecli-interactive
az ad sp create-for-rbac --sdk-auth
```

The service principal information is displayed as JSON.

```json
{
  "clientId": "b52dd125-9272-4b21-9862-0be667bdf6dc",
  "clientSecret": "ebc6e170-72b2-4b6f-9de2-99410964d2d0",
  "subscriptionId": "ffa52f27-be12-4cad-b1ea-c2c241b6cceb",
  "tenantId": "72f988bf-86f1-41af-91ab-2d7cd011db47",
  "activeDirectoryEndpointUrl": "https://login.microsoftonline.com",
  "resourceManagerEndpointUrl": "https://management.azure.com/",
  "activeDirectoryGraphResourceId": "https://graph.windows.net/",
  "sqlManagementEndpointUrl": "https://management.core.windows.net:8443/",
  "galleryEndpointUrl": "https://gallery.azure.com/",
  "managementEndpointUrl": "https://management.core.windows.net/"
}
```

Copy and paste the JSON output to a text editor for use later.
