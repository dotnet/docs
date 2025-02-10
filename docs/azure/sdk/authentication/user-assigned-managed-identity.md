---
title: Authenticate Azure-hosted .NET apps to Azure resources using a user-assigned managed identity
description: Learn how to authenticate Azure-hosted .NET apps to other Azure services using a user-assigned managed identity.
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

The sections ahead describe the steps to enable and use a user-assigned managed identity for an Azure-hosted app. If you need to use a user-assigned managed identity, visit the [system-assigned managed identities](/dotnet/azure/sdk/authentication/system-assigned-managed-identity) article for more information.

## Create a user-assigned managed identity

User-assigned managed identities are created as standalone resources in your Azure subscription using the Azure portal or the Azure CLI. Azure CLI commands can be run in the [Azure Cloud Shell](https://shell.azure.com) or on a workstation with the [Azure CLI installed](/cli/azure/install-azure-cli).

### [Azure portal](#tab/azure-portal)

1. In the Azure portal, enter *Managed identities* in the main search bar and select the matching result under the **Services** section.
1. On the **Managed Identities** page, select **+ Create**.

    :::image type="content" source="../media/user-assigned-identity-create.png" alt-text="A screenshot showing the page to manage user-assigned identities.":::

1. On the **Create User Assigned Managed Identity** page, select a subscription, resource group, and region for the user-assigned managed identity, and then provide a name.
1. Select **Review + create** to review and validate your inputs.

    :::image type="content" source="../media/user-assigned-identity-form.png" alt-text="A screenshot showing the form to create a user-assigned managed identity.":::

1. Select **Create** to create the user-assigned managed identity.
1. After the identity is created, select **Go to resource**.
1. On the new identity's **Overview** page, copy the **Client ID** value to use for later when you configure the application code.

### [Azure CLI](#tab/azure-cli)

Use the Azure CLI command [`az identity create`](/cli/azure/identity?view=azure-cli-latest#az-identity-create) to create a managed identity:

```azurecli
az identity create \
    --resource-group <resource-group-name> \
    --name <identity-name> \
    --query 'clientId' \
    --output json
```

The command output prints the client ID of the created user-assigned managed identity. The client ID is used to configure application code that relies on the identity.

You can always view the managed identity properties again using the [`az identity show`](/cli/azure/identity?view=azure-cli-latest#az-identity-show) command:

```azurecli
az identity show \
    --resource-group <your-resource-group> \
    --name <your-managed-identity-name> \
    --output json
```

---

## Assign the managed identity to your app

A user-assigned managed identity can be associated with one or more Azure resources. All of the resources that use that identity gain the permissions applied through the identity's roles.

### [Azure portal](#tab/azure-portal)

1. In the Azure portal, navigate to the resource that hosts your app code, such as an Azure App Service or Azure Container App instance.
1. From the resource's **Overview** page, expand **Settings** and select **Identity** from the navigation.
1. On the **Identity** page, switch to the **User assigned** tab.
1. Select **+ Add** to open the **Add user assigned managed identity** panel.
1. On the **Add user assigned managed identity** panel, use the **Subscription** dropdown to filter the search results for your identities. Use the **User assigned managed identities** search box to locate the user-assigned managed identity you enabled for the Azure resource hosting your app.
1. Select the identity and choose **Add** at the bottom of the panel to continue.

    :::image type="content" source="../media/add-user-assigned-identity-to-app.png" alt-text="A screenshot showing how to associate a user-assigned identity with an app.":::

### [Azure CLI](#tab/azure-cli)

The Azure CLI provides different commands to assign a user-assigned managed identity to different types of hosting services.

To assign a user-assigned managed identity to a resource such as an Azure App Service web app using the Azure CLI, you'll need the resource ID of the identity. Use the [`az identity show`](/cli/azure/identity?view=azure-cli-latest#az-identity-show) command to retrieve the resource ID:

```azurecli
az identity show \
    --resource-group <your-resource-group> \
    --name <your-managed-identity-name> \
    --output json \
    --query id
```

Once you have the resource ID, use the Azure CLI command `az <resourceType> identity assign` command to associate the user-assigned managed identity with different resources, such as the following:

For Azure App Service, use the Azure CLI command [`az webapp identity assign`](/cli/azure/webapp/identity?view=azure-cli-latest#az-webapp-identity-assign):

```azurecli
az webapp identity assign \
    --resource-group <resource-group-name> \
    --name <webapp-name> \
    --identities <user-assigned-identity-resource-id>
```

For Azure Container Apps, use the Azure CLI command [`az containerapp identity assign`](/cli/azure/containerapp/identity?view=azure-cli-latest#az-containerapp-identity-assign):

```azurecli
az containerapp identity assign \
    --resource-group <resource-group-name> \
    --name <containerapp-name> \
    --identities <user-assigned-identity-resource-id>
```

For Azure Virtual Machines, use the Azure CLI command [`az vm identity assign`](/cli/azure/vm/identity?view=azure-cli-latest#az-vm-identity-assign):

```azurecli
az vm identity assign \
    --resource-group <resource-group-name> \
    --name <vm-name> \
    --identities <user-assigned-identity-resource-id>
```

---

## Assign roles to the managed identity

Next, determine which roles your app needs and assign those roles to the managed identity. You can assign roles to a managed identity at the following scopes:

- **Resource**: The assigned roles only apply to that specific resource.
- **Resource group**: The assigned roles apply to all resources contained in the resource group.
- **Subscription**: The assigned roles apply to all resources contained in the subscription.

The following example shows how to assign roles at the resource group scope, since many apps manage all their related Azure resources using a single resource group.

### [Azure portal](#tab/azure-portal)

1. Navigate to the **Overview** page of the resource group that contains the app with the user-assigned managed identity.
1. Select **Access control (IAM)** on the left navigation.
1. On the **Access control (IAM)** page, select **+ Add** on the top menu and then choose **Add role assignment** to navigate to the **Add role assignment** page.

    :::image type="content" source="../media/add-role-assignment.png" alt-text="A screenshot showing how to access the identity role assignment page.":::

1. The **Add role assignment** page presents a tabbed, multi-step workflow to assign roles to identities. On the initial **Role** tab, use the search box at the top to locate the role you want to assign to the identity.
1. Select the role from the results and then choose **Next** to move to the **Members** tab.
1. For the **Assign access to** option, select **Managed identity**.
1. For the **Members** option, choose **+ Select members** to open the **Select managed identities** panel.
1. On the **Select managed identities** panel, use the **Subscription** and **Managed identity** dropdowns to filter the search results for your identities. Use the **Select** search box to locate the user-assigned managed identity you enabled for the Azure resource hosting your app.

    :::image type="content" source="../media/user-assigned-identity-assign-roles.png" alt-text="A screenshot showing the managed identity assignment process.":::

1. Select the identity and choose **Select** at the bottom of the panel to continue.
1. Select **Review + assign** at the bottom of the page.
1. On the final **Review + assign** tab, select **Review + assign** to complete the workflow.

### [Azure CLI](#tab/azure-cli)

To assign a role to a user-assigned managed identity using the Azure CLI, you'll need the principal ID of the identity. Use the `az identity show` command to retrieve the resource ID:

```azurecli
az identity show \
    --resource-group <your-resource-group> \
    --name <your-managed-identity-name> \
    --output json \
    --query principalId
```

Assign a role to a managed identity using the [az role assignment create](/cli/azure/role/assignment#az-role-assignment-create) command:

```azurecli
az role assignment create \
    --assignee <your-principal-id> \
    --role <role-name> \
    --scope <scope>
```

To explore which roles a managed identity can be assigned, use the [az role definition list](/cli/azure/role/definition#az-role-definition-list) command:

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

[!INCLUDE [Implement DefaultAzureCredential](<../includes/implement-user-assigned-identity.md>)]
