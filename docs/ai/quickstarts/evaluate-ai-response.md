---
title: Quickstart - Evaluate a model's response
description: Learn how to create an MSTest app to evaluate the AI chat response of a language model.
ms.date: 02/25/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
---

# Evaluate a model's response

In this quickstart, you create an MSTest app to evaluate the chat response of a model. The test app uses the [Microsoft.Extensions.AI.Evaluation](https://www.nuget.org/packages/Microsoft.Extensions.AI.Evaluation) libraries.

## Prerequisites

- [Install Ollama](https://ollama.com/) locally on your machine
[!INCLUDE [Prerequisites](../../../includes/dotnet-prerequisites.md)]

## Run the local AI model

Complete the following steps to configure and run a local AI model on your device. For this quickstart, you'll use the general purpose `phi3:mini` model, which is a small but capable generative AI created by Microsoft.

1. Open a terminal window and verify that Ollama is available on your device:

    ```bash
    ollama
    ```

    If Ollama is available, it displays a list of available commands.

1. Start Ollama:

    ```bash
    ollama serve
    ```

    If Ollama is running, it displays a list of available commands.

1. Pull the `phi3:mini` model from the Ollama registry and wait for it to download:

    ```bash
    ollama pull phi3:mini
    ```

1. After the download completes, run the model:

    ```bash
    ollama run phi3:mini
    ```

    Ollama starts the `phi3:mini` model and provides a prompt for you to interact with it.

## Create the test app

Complete the following steps to create an MSTest project that connects to your local `phi3:mini` AI model.

1. In a terminal window, navigate to the directory where you want to create your app, and create a new MSTest app with the `dotnet new` command:

    ```dotnetcli
    dotnet new mstest -o TestAI
    ```

1. Navigate to the `TestAI` directory, and add the necessary packages to your app:

    ```dotnetcli
    dotnet add package Microsoft.Extensions.AI.Ollama --prerelease
    dotnet add package Microsoft.Extensions.AI.Abstractions --prerelease
    dotnet add package Microsoft.Extensions.AI.Evaluation --prerelease
    dotnet add package Microsoft.Extensions.AI.Evaluation.Quality --prerelease
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

    This methods accomplishes the following tasks:

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

Next, try evaluating against different models to see if the results change. Then, check out the extensive examples in the [dotnet/ai-samples repo](https://github.com/dotnet/ai-samples/blob/main/src/microsoft-extensions-ai-evaluation/api/) to see how to invoke multiple evaluators, add additional context, invoke a custom evaluator, attach diagnostics, or change the default interpretation of metrics.
