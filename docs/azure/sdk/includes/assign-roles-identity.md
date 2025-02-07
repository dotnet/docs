## Assign roles to the managed identity

Next, determine which roles your app needs and assign those roles to the managed identity. You can assign roles to a managed identity at the following scopes:

- **Resource**: The assigned roles only apply to that specific resource.
- **Resource group**: The assigned roles apply to all resources contained in the resource group.
- **Subscription**: The assigned roles apply to all resources contained in the subscription.

The following example shows how to assign roles at the resource group scope, since many apps manage all their related Azure resources using a single resource group.

### [Azure portal](#tab/azure-portal)

1. Navigate to the **Overview** page of the resource group that contains the app with the system-assigned managed identity.
1. Select **Access control (IAM)** on the left navigation.
1. On the **Access control (IAM)** page, select **+ Add** on the top menu and then choose **Add role assignment** to navigate to the **Add role assignment** page.

    :::image type="content" source="../media/system-assigned-identity-access-control.png" alt-text="A screenshot showing how to access the identity role assignment page.":::

1. The **Add role assignment** page presents a tabbed, multi-step workflow to assign roles to identities. On the initial **Role** tab, use the search box at the top to locate the role you want to assign to the identity.
1. Select the role from the results and then choose **Next** to move to the **Members** tab.
1. For the **Assign access to** option, select **Managed identity**.
1. For the **Members** option, choose **+ Select members** to open the **Select managed identities** panel.
1. On the **Select managed identities** panel, use the **Subscription** and **Managed identity** dropdowns to filter the search results for your identities. Use the **Select** search box to locate the system-identity you enabled for the Azure resource hosting your app.

    :::image type="content" source="../media/system-assigned-identity-assign-roles.png" alt-text="A screenshot showing the managed identity assignment process.":::

1. Select the identity and choose **Select** at the bottom of the panel to continue.
1. Select **Review + assign** at the bottom of the page.
1. On the final **Review + assign** tab, select **Review + assign** to complete the workflow.

### [Azure CLI](#tab/azure-cli)

A managed identity is assigned a role in Azure using the [az role assignment create](/cli/azure/role/assignment#az-role-assignment-create) command:

```azurecli
az role assignment create \
    --assignee "{principalId}" \
    --role "{roleName}" \
    --scope "{scope}"
```

To get the role names to which a service principal can be assigned, use the [az role definition list](/cli/azure/role/definition#az-role-definition-list) command:

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
