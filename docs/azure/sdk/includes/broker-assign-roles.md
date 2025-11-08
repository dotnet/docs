---
ms.topic: include
ms.date: 03/19/2025
---

## Assign roles

To run your app code successfully with brokered authentication, grant your user account permissions using [Azure role-based access control (RBAC)](/azure/role-based-access-control/overview). Assign an appropriate role to your user account for the relevant Azure service. For example:

- **Azure Blob Storage**: Assign the **Storage Account Data Contributor** role.
- **Azure Key Vault**: Assign the **Key Vault Secrets Officer** role.

If an app is specified, it must have API permissions set for **user_impersonation Access Azure Storage** (step 6 in the previous section). This API permission allows the app to access Azure storage on behalf of the signed-in user after consent is granted during sign-in.
