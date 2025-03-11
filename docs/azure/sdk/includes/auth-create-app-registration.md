---
ms.topic: include
ms.date: 08/15/2024
---

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