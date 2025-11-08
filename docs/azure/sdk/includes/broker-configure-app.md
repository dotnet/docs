---
ms.topic: include
ms.date: 03/19/2025
---

## Configure the app for brokered authentication

To enable brokered authentication in your application, follow these steps:

1. In the [Azure portal](https://portal.azure.com), navigate to **Microsoft Entra ID** and select **App registrations** on the left-hand menu.
1. Select the registration for your app, then select **Authentication**.
1. Add the appropriate redirect URI to your app registration via a platform configuration:
    1. Under **Platform configurations**, select **+ Add a platform**.
    1. Under **Configure platforms**, select the tile for your application type (platform) to configure its settings, such as **mobile and desktop applications**.
    1. In **Custom redirect URIs**, enter the following redirect URI for your platform:

        | Platform    | Redirect URI                                                                                                          |
        |-------------|-----------------------------------------------------------------------------------------------------------------------|
        | Windows 10+ or WSL | `ms-appx-web://Microsoft.AAD.BrokerPlugin/{your_client_id}`                                                             |
        | macOS       | `msauth.com.msauth.unsignedapp://auth` for unsigned apps<br>`msauth.{bundle_id}://auth` for signed apps                    |
        | Linux       | `https://login.microsoftonline.com/common/oauth2/nativeclient`                                                        |

        Replace `{your_client_id}` or `{bundle_id}` with the **Application (client) ID** from the app registration's **Overview** pane.

    1. Select **Configure**.

    To learn more, see [Add a redirect URI to an app registration](/entra/identity-platform/quickstart-register-app#add-a-redirect-uri).

1. Back on the **Authentication** pane, under **Advanced settings**, select **Yes** for **Allow public client flows**.
1. Select **Save** to apply the changes.
1. To authorize the application for specific resources, navigate to the resource in question, select **API Permissions**, and enable **Microsoft Graph** and other resources you want to access.

    > [!IMPORTANT]
    > You must also be the admin of your tenant to grant consent to your application when you sign in for the first time.
