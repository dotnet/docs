---
title: "Authenticate and Authorize App Service to a Vector Database"
description: "Learn how to authenticate and authorize your App Service .NET application to a vector database solution using Microsoft Entra managed identities, Key Vault, or app settings"
author: haywoodsloan
ms.topic: how-to
ms.date: 04/24/2024
zone_pivot_groups: azure-development-tool-set-two

#customer intent: As a .NET developer, I want authenticate and authorize my App Service to a vector database so that I can securely add memories to the AI in my .NET application.

---

<!-- --------------------------------------

- Use this template with pattern instructions for:

How To

- Before you sign off or merge:

Remove all comments except the customer intent.

- Feedback:

https://aka.ms/patterns-feedback

-->

# Authenticate and authorize App Service to a vector database

<!-- Required: Article headline - H1

Identify the product or service and the task the
article describes.

-->

This article demonstrates how to manage the connection between your App Service .NET application and a vector database solution. It will cover using Microsoft Entra managed identities for supported services and securely storing connection strings for others.

By adding a vector database to your application, you can enable [semantic memories](/semantic-kernel/memories/) for your AI. The [Semantic Kernel SDK](/semantic-kernel/overview) for .NET enables you to easily implement memory storage and recall using your preferred vector database solution.

<!-- Required: Introductory paragraphs (no heading)

Write a brief introduction that can help the user
determine whether the article is relevant for them
and to describe the task the article covers.

-->

## Prerequisites

* An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/free/?WT.mc_id=A261C142F).
* [.NET SDK](https://dotnet.microsoft.com/download/visual-studio-sdks)
* [Create and deploy a .NET application to App Service](/azure/app-service/quickstart-dotnetcore)
* [Create and deploy a vector database solution](/semantic-kernel/memories/vector-db)

<!-- Optional: Prerequisites - H2

If included, "Prerequisites" must be the first H2 in the article.

List any items that are needed for the integration,
such as permissions or software.

If you need to sign in to a portal to do the quickstart, 
provide instructions and a link.

-->

## Implement Microsoft Entra managed identity authentication

If a service supports Microsoft Entra authentication, you can use a managed identity with your App Service to securely access your vector database without having to manually provision or rotate any secrets. For a list of Azure services that support Microsoft Entra authentication, see [Azure services that support Microsoft Entra authentication](/entra/identity/managed-identities-azure-resources/services-id-authentication-support)

1. Procedure step
1. Procedure step
1. Procedure step

<!-- Required: Steps to complete the task - H2

In one or more H2 sections, organize procedures. A section
contains a major grouping of steps that help the user complete
a task.

Begin each section with a brief explanation for context, and
provide an ordered list of steps to complete the procedure.

If it applies, provide sections that describe alternative tasks or
procedures.

-->

## Related content

<!-- Update links once the other docs are done -->

* [Authenticate and authorize App Service to Azure OpenAI using Microsoft Entra and the Semantic Kernel SDK]<!-- (app-service-aoai-auth.md) -->
* [How to use managed identities for App Service and Azure Functions](/azure/app-service/overview-managed-identity)
* [Steps to assign an Azure role](/azure/role-based-access-control/role-assignments-steps)

<!-- Optional: Next step or Related content - H2

Consider adding one of these H2 sections (not both):

A "Next step" section that uses 1 link in a blue box 
to point to a next, consecutive article in a sequence.

-or- 

A "Related content" section that lists links to 
1 to 3 articles the user might find helpful.

-->

<!--

Remove all comments except the customer intent
before you sign off or merge to the main branch.

-->
