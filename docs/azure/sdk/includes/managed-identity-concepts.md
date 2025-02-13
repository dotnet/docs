## Essential managed identity concepts

A managed identity enables your app to securely connect to other Azure resources without the use of secret keys or other application secrets. Internally, Azure tracks the identity and which resources it's allowed to connect to. Azure uses this information to automatically obtain Microsoft Entra tokens for the app to allow it to connect to other Azure resources.

There are two types of managed identities to consider when configuring your hosted app:

- **System-assigned** managed identities are enabled directly on an Azure resource and are tied to its life cycle. When the resource is deleted, Azure automatically deletes the identity for you. System-assigned identities provide a minimalistic approach to using managed identities.
- **User-assigned** managed identities are created as standalone Azure resources and offer greater flexibility and capabilities. They're ideal for solutions involving multiple Azure resources that need to share the same identity and permissions. For example, if multiple virtual machines need to access the same set of Azure resources, a user-assigned managed identity provides reusability and optimized management.

> [!TIP]
> Learn more about selecting and managing system-assigned managed identities and user-assigned managed identities in the [Managed identity best practice recommendations](/entra/identity/managed-identities-azure-resources/managed-identity-best-practice-recommendations) article.
