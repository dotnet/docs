---
title: Authenticate to Azure OpenAI using .NET
description: Learn about the different options to authenticate to Azure OpenAI and other services using .NET
author: alexwolfmsft
ms.topic: concept-article
ms.date: 06/27/2024

---

# Authenticate to Azure AI Services using .NET

Application requests to Azure AI Services must be authenticated. In this article you explore the options available to authenticate to Azure OpenAI and other AI services using .NET. These concepts apply to the Semantic Kernel Sdk, as well SDKs from specific services such as Azure OpenAI. Most AI services offer two primary ways to authenticate apps and users:

- **Key-based authentication** provides access to an Azure service using secret key values. These secrets are also known as API keys or access keys.
- **Microsoft Entra ID** provides a comprehensive identity and access management solution to ensure that the correct identities have the correct level of access to different Azure resources.

The sections ahead provide conceptual overviews for these two approaches, rather than detailed implementation steps. For more detailed information about connecting to Azure services, visit the following resources:

- [Authenticate .NET apps to Azure services](/dotnet/azure/sdk/authentication/)
- [Identity fundamentals](/entra/fundamentals/identity-fundamental-concepts)
- [What is Azure RBAC?](/azure/role-based-access-control/overview)

> [!NOTE]
> The examples in this article focus primarily on connections to Azure OpenAI, but the same concepts and implementation steps directly apply to many other Azure AI Services as well.

## Explore key-based authentication

Access keys allow apps and tools to authenticate to an Azure AI service such as OpenAI using a secret key provided by the service. Retrieve the secret key using tools such as the Azure Portal or Azure CLI and use it to configure your app code to connect to the AI service:

```csharp
builder.Services.AddAzureOpenAIChatCompletion(
    "deployment-model",
    "service-endpoint",
    "service-key");
var kernel = builder.Build();
```

Using keys is a straightforward option, but this approach should be used with caution. Keys are not the recommended authentication option for the following reasons:

- Keys do not follow [the principle of least privilege](/entra/identity-platform/secure-least-privileged-access) - they needlessly provide elevated permissions for a given task.
- Keys can accidentally be checked into source control or stored in unsafe locations.
- Keys can easily be shared or sent to parties who should not have access.
- Keys often require manual administration and rotation.

Instead, consider using [Microsoft Entra ID](/#explore-microsoft-entra-id) for authentication, which is the recommended solution for most scenarios.

## Explore Microsoft Entra ID

Microsoft Entra ID is a cloud-based identity and access management service that provides a vast set of features for different business and app scenarios. Microsoft Entra ID is the recommended solution to connect to Azure OpenAI and other AI services and provides the following benefits:

- Key-less authentication using [identities](/entra/fundamentals/identity-fundamental-concepts).
- Role-based-access-control (RBAC) to assign identities the minimum required permissions.
- Detects [different credentials across environments](/python/api/azure-identity/azure.identity.defaultazurecredential?view=azure-python) without requiring code changes.
- Automatically handles administrative tasks.

The general flow to implement Entra ID authentication in your app generally include the following:

- Local development:
    1. Authenticate to Azure using a local dev tool such as the Azure CLI or Visual Studio.
    1. Configure your code to use the [`Azure.Identity`](/dotnet/api/overview/azure/identity-readme) client library and `DefaultAzureCredential` class.
    1. Assign roles to the account you used to authenticate.

- Azure hosted app:
    1. Deploy the app to Azure after configuring it to use `Azure.Identity`.
    1. Assign a [managed identity](/entra/identity/managed-identities-azure-resources/overview) to the Azure hosted app.
    1. Assign roles to the managed identity.

Key steps of this workflow are explored in the following sections.

### Authenticate to Azure locally

When developing apps locally that connect to Azure AI Services, authenticate to Azure using a tool such as Visual Studio or the Azure CLI. Your local credentials can be discovered by the `Azure.Identity` and used to authenticate your app to Azure services, as described in the [configure the app code](/#configure-your-app-code) section.

For example, to authenticate to Azure locally using the Azure CLI, run the following command:

```azurecli
az login
```

### Configure the app code

Use the [`Azure.Identity`](/dotnet/api/overview/azure/identity-readme) client library from the Azure SDK to implement Entra ID authentication in your code. The `Azure.Identity` libraries include the `DefaultAzureCredential` class, which automatically discovers available Azure credentials based on the current environment and tooling available. You can see the full set of supported environment credentials and the order in which they are searched in the [Azure SDK for .NET](/dotnet/api/azure.identity.defaultazurecredential) documentation.

For example, configure Semantic Kernel to authenticate using `DefaultAzureCredential` using the following code:

```csharp
Kernel kernel = Kernel
.CreateBuilder()
    .AddAzureOpenAITextGeneration(
        "your-model",
        "your-endpoint",
        new DefaultAzureCredential())
    .Build();
```

`DefaultAzureCredential` enables apps to be promoted from local development to test environments to production without code changes. For example, during development `DefaultAzureCredential` uses your local user credentials from Visual Studio or the Azure CLI to authenticate to the AI service. When the app is deployed to Azure, `DefaultAzureCredential` uses the managed identity that is assigned with your app.

### Assign roles to your identity

[Azure role-based access control (Azure RBAC)](/azure/role-based-access-control) is a system that provides fine-grained access management of Azure resources. You'll need to assign a role to the security principal used by `DefaultAzureCredential` to connect to an Azure AI service, whether that's an individual user, group, service principal, or managed identity. Roles are a collection of permissions that allow the identity to perform various tasks, such as generate completions or create and delete resources.

Assign roles such as **Cognitive Services OpenAI User** (role ID: `5e0bd9bd-7b93-4f28-af87-19fc36ad61bd`) to the relevant identity using tools such as the Azure CLI, Bicep, or the Azure Portal. For example, use the `az role assignment create` command to assign a role using the Azure CLI:

```azurecli
az role assignment create \
        --role "5e0bd9bd-7b93-4f28-af87-19fc36ad61bd" \
        --assignee-object-id "$PRINCIPAL_ID" \
        --scope /subscriptions/"$SUBSCRIPTION_ID"/resourceGroups/"$RESOURCE_GROUP" \
        --assignee-principal-type User
```

Learn more about Azure RBAC using the following resources:

- [What is Azure RBAC?](/azure/role-based-access-control/overview)
- [Grant a user access](/azure/role-based-access-control/quickstart-assign-role-user-portal)
- [RBAC best practices](/azure/role-based-access-control/best-practices)

### Assign a managed identity to your app

In most scenarios, Azure hosted applications should use a [managed identity](/entra/identity/managed-identities-azure-resources/overview) to connect to other services such as Azure OpenAI. `DefaultAzureCredential` discovers the identity associated with your app and uses it to authenticate to other Azure services. Managed identities provide an automatically managed identity in Microsoft Entra ID for applications to use when connecting to resources that support Microsoft Entra authentication. Applications use managed identities to obtain Microsoft Entra tokens without having to manage any credentials.

There are two types of managed identities you can assign to your app:

- A **system-assigned identity** is tied to your application and is deleted if your app is deleted. An app can only have one system-assigned identity.
- A **user-assigned identity** is a standalone Azure resource that can be assigned to your app. An app can have multiple user-assigned identities.

Assign roles to a managed identity just like you would an individual user account, such as the **Cognitive Services OpenAI User** role. learn more about working with managed identities using the following resources:

- [Managed identities overview](/entra/identity/managed-identities-azure-resources/overview)
- [How to use managed identities for App Service and Azure Functions](/azure/app-service/overview-managed-identity)
- [Authenticate App Service to Azure OpenAI using Microsoft Entra ID](/dotnet/ai/how-to/app-service-aoai-auth?pivots=azure-portal)
