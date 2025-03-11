---
ms.topic: include
ms.date: 03/11/2025
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
    az ad group member add \
        --group <group-name> \
        --member-id <object-id>
    ```

---