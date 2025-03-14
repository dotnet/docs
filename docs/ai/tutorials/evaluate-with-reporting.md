---
title: Tutorial - Evaluate a model's response
description: Learn how to create an MSTest app to evaluate the AI chat response of a language model and use the caching and reporting features of Microsoft.Extensions.AI.Evaluation.
ms.date: 03/04/2025
ms.topic: tutorial
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
---

# Tutorial: Evaluate a model's response with response caching and reporting

In this tutorial, you create an MSTest app to evaluate the chat response of a model. The test app uses the [Microsoft.Extensions.AI.Evaluation](https://www.nuget.org/packages/Microsoft.Extensions.AI.Evaluation) libraries.

## Prerequisites

- [Install .NET 8.0](https://dotnet.microsoft.com/download) or a later version
- [Visual Studio Code](https://code.visualstudio.com/) (optional)

## Configure the AI service

1. To provision an Azure OpenAI service and model using the Azure portal, complete the steps in the [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource?pivots=web-portal) article.

1. From a terminal or command prompt, navigate to the root of your project directory.

1. Run the following commands to add your Azure OpenAI endpoint, model name, and tenant ID [app secrets](/aspnet/core/security/app-secrets):

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set AZURE_OPENAI_ENDPOINT <your-azure-openai-endpoint>
    dotnet user-secrets set AZURE_OPENAI_GPT_NAME <your-azure-openai-model-name>
    dotnet user-secrets set AZURE_TENANT_ID <your-tenant-id>
    ```

## Create the test app

Complete the following steps to create an MSTest project that connects to the gpt-4o AI model.

1. In a terminal window, navigate to the directory where you want to create your app, and create a new MSTest app with the `dotnet new` command:

    ```dotnetcli
    dotnet new mstest -o TestAIWithReporting
    ```

1. Navigate to the `TestAI` directory, and add the necessary packages to your app:

    ```dotnetcli
    dotnet add package Azure.AI.OpenAI
    dotnet add package Azure.Identity
    dotnet add package Microsoft.Extensions.AI.Abstractions --prerelease
    dotnet add package Microsoft.Extensions.AI.Evaluation --prerelease
    dotnet add package Microsoft.Extensions.AI.Evaluation.Quality --prerelease
    dotnet add package Microsoft.Extensions.AI.Evaluation.Reporting --prerelease
    dotnet add package Microsoft.Extensions.AI.OpenAI --prerelease
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    ```

1. Open the new app in your editor of choice, such as Visual Studio Code.

    ```dotnetcli
    code .
    ```

## Add the test app code

1. Rename the file *Test1.cs* to *MyTests.cs*, and then open the file and rename the class to `MyTests`.
1. Add the private <xref:Microsoft.Extensions.AI.Evaluation.ChatConfiguration> and chat message and response members to the `MyTests` class. The `s_messages` field is a list that contains two <xref:Microsoft.Extensions.AI.ChatMessage> objects&mdash;one instructs the behavior of the chat bot, and the other is the question from the user.

   :::code language="csharp" source="./snippets/evaluate-ai-responses/MyTests.cs" id="PrivateMembers":::

1. Add the `InitializeAsync` method to the `MyTests` class.

   :::code language="csharp" source="./snippets/evaluate-ai-responses/MyTests.cs" id="Initialize":::

    This method accomplishes the following tasks:

   - Sets up the <xref:Microsoft.Extensions.AI.Evaluation.ChatConfiguration>.
   - Sets the <xref:Microsoft.Extensions.AI.ChatOptions>, including the <xref:Microsoft.Extensions.AI.ChatOptions.Temperature> and the <xref:Microsoft.Extensions.AI.ChatOptions.ResponseFormat>.
   - Fetches the response to be evaluated by calling <xref:Microsoft.Extensions.AI.IChatClient.GetResponseAsync(System.Collections.Generic.IList{Microsoft.Extensions.AI.ChatMessage},Microsoft.Extensions.AI.ChatOptions,System.Threading.CancellationToken)>, and stores it in a static variable.

1. Add the `GetOllamaChatConfiguration` method, which creates the <xref:Microsoft.Extensions.AI.IChatClient> that the evaluator uses to communicate with the model.

   :::code language="csharp" source="./snippets/evaluate-ai-responses/MyTests.cs" id="GetChatConfig":::

1. Add a test method to evaluate the model's response.

   :::code language="csharp" source="./snippets/evaluate-ai-responses/MyTests.cs" id="TestCoherence":::

   This method does the following:

   - Invokes the <xref:Microsoft.Extensions.AI.Evaluation.Quality.CoherenceEvaluator> to evaluate the *coherence* of the response. The <xref:Microsoft.Extensions.AI.Evaluation.IEvaluator.EvaluateAsync(System.Collections.Generic.IEnumerable{Microsoft.Extensions.AI.ChatMessage},Microsoft.Extensions.AI.ChatMessage,Microsoft.Extensions.AI.Evaluation.ChatConfiguration,System.Collections.Generic.IEnumerable{Microsoft.Extensions.AI.Evaluation.EvaluationContext},System.Threading.CancellationToken)> method returns an <xref:Microsoft.Extensions.AI.Evaluation.EvaluationResult> that contains a <xref:Microsoft.Extensions.AI.Evaluation.NumericMetric>. A `NumericMetric` contains a numeric value that's typically used to represent numeric scores that fall within a well-defined range.
   - Retrieves the coherence score from the <xref:Microsoft.Extensions.AI.Evaluation.EvaluationResult>.
   - Validates the *default interpretation* for the returned coherence metric. Evaluators can include a default interpretation for the metrics they return. You can also change the default interpretation to suit your specific requirements, if needed.
   - Validates that no diagnostics are present on the returned coherence metric. Evaluators can include diagnostics on the metrics they return to indicate errors, warnings, or other exceptional conditions encountered during evaluation.

## Run the test/evaluation

Run the test using your preferred test workflow, for example, by using the CLI command `dotnet test` or through [Test Explorer](/visualstudio/test/run-unit-tests-with-test-explorer).

## Next steps

