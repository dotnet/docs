---
title: Authenticate to Azure resources from .NET apps hosted on-premises
description: This article describes how to authenticate your application to Azure services when using the Azure SDK for .NET in on-premises hosted apps. 
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23
ms.date: 08/02/2024
---

# Authenticate to Azure resources from .NET apps hosted on-premises

Apps hosted outside of Azure, such as on-premises or in a third-party data center, should use an application service principal to authenticate to Azure services. Application service principals are created using the app registration process in Azure. When an application service principal is created, a client ID and client secret will be generated for your app. The client ID, client secret, and your tenant ID are then stored in environment variables so they can be used by the Azure Identity library to authenticate your app to Azure at runtime.

In the sections ahead, you learn:

- How to register an application with Microsoft Entra to create a service principal
- How to assign roles to scope permissions
- How to authenticate using a service principal from your app code

Using dedicated application service principals allows you to adhere to the principle of least privilege when accessing Azure resources. Permissions are limited to the specific requirements of the app during development, preventing accidental access to Azure resources intended for other apps or services. This approach also helps avoid issues when the app is moved to production by ensuring it isn't over-privileged in the development environment.

A different app registration should be created for each environment the app is hosted in. This allows environment specific resource permissions to be configured for each service principal and make sure an app deployed to one environment doesn't talk to Azure resources that are part of another environment.

[!INCLUDE [auth-create-app-registration](../includes/auth-create-app-registration.md)]

## 2 - Assign roles to the application service principal

Next, determine what roles (permissions) your app needs on what resources and assign those roles to the service principal you created. Groups can be assigned a role at the resource, resource group, or subscription scope. This example shows how to assign roles at the resource group scope, since most apps group all their Azure resources into a single resource group.

### [Azure portal](#tab/azure-portal)

1. In the Azure portal, navigate to the **Overview** page of the resource group that contains your app.
1. Select **Access control (IAM)** from the left navigation.
1. On the **Access control (IAM)** page, select **+ Add** and then choose **Add role assignment** from the drop-down menu. The **Add role assignment** page provides several tabs to configure and assign roles.
1. On the **Role** tab, use the search box to locate the role you want to assign. Select the role, and then choose **Next**.
1. On the **Members** tab:
    - For the **Assign access to** value, select **User, group, or service principal** .
    - For the **Members** value, choose **+ Select members** to open the **Select members** flyout panel.
    - Search for the service principal you created earlier and select it from the filtered results. Choose **Select** to select the group and close the flyout panel.
    - Select **Review + assign** at the bottom of the **Members** tab.

    :::image type="content" source="../../media/group-role-assignment.png" alt-text="A screenshot showing how to assign a role to the service principal.":::

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

[!INCLUDE [auth-set-environment-variables](../includes/auth-set-environment-variables.md)]

[!INCLUDE [implement-service-principal](../includes/implement-service-principal.md)]
