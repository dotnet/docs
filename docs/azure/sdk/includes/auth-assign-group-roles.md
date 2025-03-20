---
ms.topic: include
ms.date: 03/13/2025
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

    :::image type="content" source="../../media/group-role-assignment.png" alt-text="A screenshot showing how to assign a role to the Microsoft Entra group.":::

1. On the **Review + assign** tab, select **Review + assign** at the bottom of the page.

### [Azure CLI](#tab/azure-cli)

1. Use the [az role definition list](/cli/azure/role/definition#az-role-definition-list) command to get the names of the roles that a Microsoft Entra group or service principal can be assigned to:

    ```azurecli
    az role definition list \
        --query "sort_by([].{roleName:roleName, description:description}, &roleName)" \
        --output table
    ```

1. Use the [az role assignment create](/cli/azure/role/assignment#az-role-assignment-create) command to assign a role to the Microsoft Entra group you created:

    ```azurecli
    az role assignment create \
        --assignee "<group-object-Id>" \
        --role "<role-name>" \
        --resource-group "<resource-group-name>"
    ```

    For information on assigning permissions at the resource or subscription level using the Azure CLI, see [Assign Azure roles using the Azure CLI](/azure/role-based-access-control/role-assignments-cli).

---
