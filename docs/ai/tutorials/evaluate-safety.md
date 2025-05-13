---
title: Tutorial - Evaluate the safety of a model's response
description: Create an MSTest app that evaluates the safety of a model's response using the evaluators in the Microsoft.Extensions.AI.Evaluation.Safety package.
ms.date: 05/12/2025
ms.topic: tutorial
ms.custom: devx-track-dotnet-ai
---

# Tutorial: Evaluate the safety of a model's response

In this tutorial, you create an MSTest app to evaluate the safety of a response from an OpenAI model. The test app uses the evaluators from the [Microsoft.Extensions.AI.Evaluation.Safety](https://www.nuget.org/packages/Microsoft.Extensions.AI.Evaluation.Safety) package to perform the evaluations.

## Prerequisites

[!INCLUDE [prerequisites-azure-openai](../quickstarts/includes/prerequisites-azure-openai.md)]

In addition, to use

## Configure the AI service

To provision an Azure OpenAI service and model using the Azure portal, complete the steps in the [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource?pivots=web-portal) article. In the "Deploy a model" step, select the `gpt-4o` model.

The evaluators in this tutorial use the Azure AI Foundry Evaluation Service, which requires some additional setup:

- [Create a resource group](/azure/azure-resource-manager/management/manage-resource-groups-portal#create-resource-groups) within one of the Azure [regions that support Azure AI Foundry Evaluation Service](/azure/ai-foundry/how-to/develop/evaluate-sdk#region-support).
- [Create an Azure AI Foundry hub](/azure/ai-foundry/how-to/create-azure-ai-resource?tabs=portal#create-a-hub-in-azure-ai-foundry-portal) in the resource group you just created.
- Finally, [create an Azure AI Foundry project](/azure/ai-foundry/how-to/create-projects?tabs=ai-studio#create-a-project) in the hub you just created.

## Create the test app

Complete the following steps to create an MSTest project that connects to the `gpt-4o` AI model.

1. In a terminal window, navigate to the directory where you want to create your app, and create a new MSTest app with the `dotnet new` command:

   ```dotnetcli
   dotnet new mstest -o EvaluateResponseSafety
   ```

1. Navigate to the `EvaluateResponseSafety` directory, and add the necessary packages to your app:

   ```dotnetcli
   dotnet add package Azure.AI.OpenAI
   dotnet add package Azure.Identity
   dotnet add package Microsoft.Extensions.AI.Abstractions --prerelease
   dotnet add package Microsoft.Extensions.AI.Evaluation --prerelease
   dotnet add package Microsoft.Extensions.AI.Evaluation.Reporting --prerelease
   dotnet add package Microsoft.Extensions.AI.Evaluation.Safety --prerelease
   dotnet add package Microsoft.Extensions.AI.OpenAI --prerelease
   dotnet add package Microsoft.Extensions.Configuration
   dotnet add package Microsoft.Extensions.Configuration.UserSecrets
   ```

1. Run the following commands to add [app secrets](/aspnet/core/security/app-secrets) for your Azure OpenAI endpoint, model name, and tenant ID:

   ```bash
   dotnet user-secrets init
   dotnet user-secrets set AZURE_OPENAI_ENDPOINT <your-Azure-OpenAI-endpoint>
   dotnet user-secrets set AZURE_OPENAI_GPT_NAME gpt-4o
   dotnet user-secrets set AZURE_TENANT_ID <your-tenant-ID>
   dotnet user-secrets set AZURE_SUBSCRIPTION_ID <your-subscription-ID>
   dotnet user-secrets set AZURE_RESOURCE_GROUP <your-resource-group>
   dotnet user-secrets set AZURE_AI_PROJECT <your-Azure-AI-project>
   ```

   (Depending on your environment, the tenant ID might not be needed. In that case, remove it from the code that instantiates the <xref:Azure.Identity.DefaultAzureCredential>.)

1. Open the new app in your editor of choice.

## Add the test app code

1. Rename the `Test1.cs` file to `MyTests.cs`, and then open the file and rename the class to `MyTests`.
1. Add the necessary `using` directives to the top of the file.

   :::code language="csharp" source="./snippets/evaluate-safety/MyTests.cs" id="UsingDirectives":::

## Run the test/evaluation

Run the test using your preferred test workflow, for example, by using the CLI command `dotnet test` or through [Test Explorer](/visualstudio/test/run-unit-tests-with-test-explorer).

## Generate a report

??

## Next steps

