---
title: Quickstart - Evaluate a model's response
description: Learn how to create an MSTest app to evaluate the AI chat response of a language model.
ms.date: 03/18/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
---

# Evaluate a model's response

In this quickstart, you create an MSTest app to evaluate the chat response of an OpenAI model. The test app uses the [Microsoft.Extensions.AI.Evaluation](https://www.nuget.org/packages/Microsoft.Extensions.AI.Evaluation) libraries.

> [!NOTE]
>
> - The `Microsoft.Extensions.AI.Evaluation` library is currently in Preview.
> - This quickstart demonstrates the simplest usage of the evaluation API. Notably, it doesn't demonstrate use of the [response caching](../conceptual/evaluation-libraries.md#cached-responses) and [reporting](../conceptual/evaluation-libraries.md#reporting) functionality, which are important if you're authoring unit tests that run as part of an "offline" evaluation pipeline. The scenario shown in this quickstart is suitable in use cases such as "online" evaluation of AI responses within production code and logging scores to telemetry, where caching and reporting aren't relevant. For a tutorial that demonstrates the caching and reporting functionality, see [Tutorial: Evaluate a model's response with response caching and reporting](../tutorials/evaluate-with-reporting.md)

## Prerequisites

- [.NET 8 or a later version](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/) (optional)

## Configure the AI service

To provision an Azure OpenAI service and model using the Azure portal, complete the steps in the [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource?pivots=web-portal) article. In the "Deploy a model" step, select the `gpt-4o` model.

## Create the test app

Complete the following steps to create an MSTest project that connects to the `gpt-4o` AI model.

1. In a terminal window, navigate to the directory where you want to create your app, and create a new MSTest app with the `dotnet new` command:

    ```dotnetcli
    dotnet new mstest -o TestAI
    ```

1. Navigate to the `TestAI` directory, and add the necessary packages to your app:

    ```dotnetcli
    dotnet add package Azure.AI.OpenAI
    dotnet add package Azure.Identity
    dotnet add package Microsoft.Extensions.AI.Abstractions --prerelease
    dotnet add package Microsoft.Extensions.AI.Evaluation --prerelease
    dotnet add package Microsoft.Extensions.AI.Evaluation.Quality --prerelease
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
    ```

   (Depending on your environment, the tenant ID might not be needed. In that case, remove it from the code that instantiates the <xref:Azure.Identity.DefaultAzureCredential>.)

1. Open the new app in your editor of choice.

## Add the test app code

1. Rename the *Test1.cs* file to *MyTests.cs*, and then open the file and rename the class to `MyTests`.
1. Add the private <xref:Microsoft.Extensions.AI.Evaluation.ChatConfiguration> and chat message and response members to the `MyTests` class. The `s_messages` field is a list that contains two <xref:Microsoft.Extensions.AI.ChatMessage> objects&mdash;one instructs the behavior of the chat bot, and the other is the question from the user.

   :::code language="csharp" source="./snippets/evaluate-ai-responses/MyTests.cs" id="PrivateMembers":::

1. Add the `InitializeAsync` method to the `MyTests` class.

   :::code language="csharp" source="./snippets/evaluate-ai-responses/MyTests.cs" id="Initialize":::

    This method accomplishes the following tasks:

   - Sets up the <xref:Microsoft.Extensions.AI.Evaluation.ChatConfiguration>.
   - Sets the <xref:Microsoft.Extensions.AI.ChatOptions>, including the <xref:Microsoft.Extensions.AI.ChatOptions.Temperature> and the <xref:Microsoft.Extensions.AI.ChatOptions.ResponseFormat>.
   - Fetches the response to be evaluated by calling <xref:Microsoft.Extensions.AI.IChatClient.GetResponseAsync(System.Collections.Generic.IEnumerable{Microsoft.Extensions.AI.ChatMessage},Microsoft.Extensions.AI.ChatOptions,System.Threading.CancellationToken)>, and stores it in a static variable.

1. Add the `GetAzureOpenAIChatConfiguration` method, which creates the <xref:Microsoft.Extensions.AI.IChatClient> that the evaluator uses to communicate with the model.

   :::code language="csharp" source="./snippets/evaluate-ai-responses/MyTests.cs" id="GetChatConfig":::

1. Add a test method to evaluate the model's response.

   :::code language="csharp" source="./snippets/evaluate-ai-responses/MyTests.cs" id="TestCoherence":::

   This method does the following:

   - Invokes the <xref:Microsoft.Extensions.AI.Evaluation.Quality.CoherenceEvaluator> to evaluate the *coherence* of the response. The <xref:Microsoft.Extensions.AI.Evaluation.IEvaluator.EvaluateAsync(System.Collections.Generic.IEnumerable{Microsoft.Extensions.AI.ChatMessage},Microsoft.Extensions.AI.ChatResponse,Microsoft.Extensions.AI.Evaluation.ChatConfiguration,System.Collections.Generic.IEnumerable{Microsoft.Extensions.AI.Evaluation.EvaluationContext},System.Threading.CancellationToken)> method returns an <xref:Microsoft.Extensions.AI.Evaluation.EvaluationResult> that contains a <xref:Microsoft.Extensions.AI.Evaluation.NumericMetric>. A `NumericMetric` contains a numeric value that's typically used to represent numeric scores that fall within a well-defined range.
   - Retrieves the coherence score from the <xref:Microsoft.Extensions.AI.Evaluation.EvaluationResult>.
   - Validates the *default interpretation* for the returned coherence metric. Evaluators can include a default interpretation for the metrics they return. You can also change the default interpretation to suit your specific requirements, if needed.
   - Validates that no diagnostics are present on the returned coherence metric. Evaluators can include diagnostics on the metrics they return to indicate errors, warnings, or other exceptional conditions encountered during evaluation.

## Run the test/evaluation

Run the test using your preferred test workflow, for example, by using the CLI command `dotnet test` or through [Test Explorer](/visualstudio/test/run-unit-tests-with-test-explorer).

## Clean up resources

If you no longer need them, delete the Azure OpenAI resource and GPT-4 model deployment.

1. In the [Azure Portal](https://aka.ms/azureportal), navigate to the Azure OpenAI resource.
1. Select the Azure OpenAI resource, and then select **Delete**.

## Next steps

- Evaluate the responses from different OpenAI models.
- Add response caching and reporting to your evaluation code. For more information, see [Tutorial: Evaluate a model's response with response caching and reporting](../tutorials/evaluate-with-reporting.md).
