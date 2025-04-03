---
title: Authenticate to Azure OpenAI using .NET
description: Learn about the different options to authenticate to Azure OpenAI and other services using .NET
author: alexwolfmsft
ms.topic: conceptual
ms.date: 06/27/2024
---

# Azure AI services authentication and authorization using .NET

Application requests to Azure AI Services must be authenticated. In this article, you explore the options available to authenticate to Azure OpenAI and other AI services using .NET. These concepts apply to the Semantic Kernel SDK, as well as SDKs from specific services such as Azure OpenAI. Most AI services offer two primary ways to authenticate apps and users:

- **Key-based authentication** provides access to an Azure service using secret key values. These secret values are sometimes known as API keys or access keys depending on the service.
- **Microsoft Entra ID** provides a comprehensive identity and access management solution to ensure that the correct identities have the correct level of access to different Azure resources.

The sections ahead provide conceptual overviews for these two approaches, rather than detailed implementation steps. For more detailed information about connecting to Azure services, visit the following resources:

- [Authenticate .NET apps to Azure services](../azure/sdk/authentication/index.md)
- [Identity fundamentals](/entra/fundamentals/identity-fundamental-concepts)
- [What is Azure RBAC?](/azure/role-based-access-control/overview)

> [!NOTE]
> The examples in this article focus primarily on connections to Azure OpenAI, but the same concepts and implementation steps directly apply to many other Azure AI services as well.

## Authentication using keys

Access keys allow apps and tools to authenticate to an Azure AI service, such as Azure OpenAI, using a secret key provided by the service. Retrieve the secret key using tools such as the Azure portal or Azure CLI and use it to configure your app code to connect to the AI service:

```csharp
builder.Services.AddAzureOpenAIChatCompletion(
    "deployment-model",
    "service-endpoint",
    "service-key"); // Secret key
var kernel = builder.Build();
```

Using keys is a straightforward option, but this approach should be used with caution. Keys aren't the recommended authentication option because they:

- Don't follow [the principle of least privilege](/entra/identity-platform/secure-least-privileged-access). They provide elevated permissions regardless of who uses them or for what task.
- Can accidentally be checked into source control or stored in unsafe locations.
- Can easily be shared with or sent to parties who shouldn't have access.
- Often require manual administration and rotation.

Instead, consider using [Microsoft Entra ID](/#explore-microsoft-entra-id) for authentication, which is the recommended solution for most scenarios.

## Authentication using Microsoft Entra ID

Microsoft Entra ID is a cloud-based identity and access management service that provides a vast set of features for different business and app scenarios. Microsoft Entra ID is the recommended solution to connect to Azure OpenAI and other AI services and provides the following benefits:

- Keyless authentication using [identities](/entra/fundamentals/identity-fundamental-concepts).
- Role-based access control (RBAC) to assign identities the minimum required permissions.
- Can use the [`Azure.Identity`](/dotnet/api/overview/azure/identity-readme) client library to detect [different credentials across environments](/dotnet/api/azure.identity.defaultazurecredential) without requiring code changes.
- Automatically handles administrative maintenance tasks such as rotating underlying keys.

The workflow to implement Microsoft Entra authentication in your app generally includes the following steps:

- Local development:

    1. Sign-in to Azure using a local dev tool such as the Azure CLI or Visual Studio.
    1. Configure your code to use the [`Azure.Identity`](/dotnet/api/overview/azure/identity-readme) client library and `DefaultAzureCredential` class.
    1. Assign Azure roles to the account you signed-in with to enable access to the AI service.

- Azure-hosted app:

    1. Deploy the app to Azure after configuring it to authenticate using the `Azure.Identity` client library.
    1. Assign a [managed identity](/entra/identity/managed-identities-azure-resources/overview) to the Azure-hosted app.
    1. Assign Azure roles to the managed identity to enable access to the AI service.

The key concepts of this workflow are explored in the following sections.

### Authenticate to Azure locally

When developing apps locally that connect to Azure AI services, authenticate to Azure using a tool such as Visual Studio or the Azure CLI. Your local credentials can be discovered by the `Azure.Identity` client library and used to authenticate your app to Azure services, as described in the [Configure the app code](/#configure-your-app-code) section.

For example, to authenticate to Azure locally using the Azure CLI, run the following command:

```azurecli
az login
```

### Configure the app code

Use the [`Azure.Identity`](/dotnet/api/overview/azure/identity-readme) client library from the Azure SDK to implement Microsoft Entra authentication in your code. The `Azure.Identity` libraries include the `DefaultAzureCredential` class, which automatically discovers available Azure credentials based on the current environment and tooling available. Visit the [Azure SDK for .NET](/dotnet/api/azure.identity.defaultazurecredential) documentation for the full set of supported environment credentials and the order in which they are searched.

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

`DefaultAzureCredential` enables apps to be promoted from local development to production without code changes. For example, during development `DefaultAzureCredential` uses your local user credentials from Visual Studio or the Azure CLI to authenticate to the AI service. When the app is deployed to Azure, `DefaultAzureCredential` uses the managed identity that is assigned to your app.

### Assign roles to your identity

[Azure role-based access control (Azure RBAC)](/azure/role-based-access-control) is a system that provides fine-grained access management of Azure resources. Assign a role to the security principal used by `DefaultAzureCredential` to connect to an Azure AI service, whether that's an individual user, group, service principal, or managed identity. Azure roles are a collection of permissions that allow the identity to perform various tasks, such as generate completions or create and delete resources.

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

In most scenarios, Azure-hosted apps should use a [managed identity](/entra/identity/managed-identities-azure-resources/overview) to connect to other services such as Azure OpenAI. Managed identities provide a fully managed identity in Microsoft Entra ID for apps to use when connecting to resources that support Microsoft Entra authentication. `DefaultAzureCredential` discovers the identity associated with your app and uses it to authenticate to other Azure services.

There are two types of managed identities you can assign to your app:

- A **system-assigned identity** is tied to your application and is deleted if your app is deleted. An app can only have one system-assigned identity.
- A **user-assigned identity** is a standalone Azure resource that can be assigned to your app. An app can have multiple user-assigned identities.

Assign roles to a managed identity just like you would an individual user account, such as the **Cognitive Services OpenAI User** role. learn more about working with managed identities using the following resources:

- [Managed identities overview](/entra/identity/managed-identities-azure-resources/overview)
- [Authenticate App Service to Azure OpenAI using Microsoft Entra ID](/dotnet/ai/how-to/app-service-aoai-auth?pivots=azure-portal)
- [How to use managed identities for App Service and Azure Functions](/azure/app-service/overview-managed-identity)
