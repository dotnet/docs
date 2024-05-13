---
title: "Tutorial: Evaluate an LLM's Prompt Completions"
description: "Evaluate the coherence, relevance, and groundedness of a LLM's prompt completions using Azure OpenAI and the Semantic Kernel SDK for .NET."
author: haywoodsloan
ms.topic: tutorial 
ms.date: 05/08/2024

#customer intent: As a .NET developer, I want to evaluate an LLM's prompt completions using .NET so that I can choose an LLM for my .NET application that fits my use case.

---

# Tutorial: Evaluate an LLM's prompt completions

In this tutorial, you evaluate the coherence, relevance, and groundedness of an LLM's prompt completions using Azure OpenAI and the Semantic Kernel SDK for .NET.

:::image type="content" source="../media/llm-eval/eval-app.png" lightbox="../media/llm-eval/eval-app.png" alt-text="Main UI of the Evaluation Application":::

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> * Clone and build the evaluation application
> * Configure the models to test, generate test data, and perform evaluations
> * Generate evaluation test data
> * Perform an evaluation of your LLM
> * Review the results of an evaluation

If you don't have an Azure subscription, create a [free account](https://azure.microsoft.com/free/?WT.mc_id=A261C142F) before you begin.

## Prerequisites

* [.NET 8.0 SDK](https://dotnet.microsoft.com/download/visual-studio-sdks)
* [Create and deploy a GPT-4 model to Azure OpenAI Service](/azure/ai-services/openai/how-to/create-resource)

## 1 - Clone the evaluation application

Get the source for the evaluation application and ensure it can be built.

1. Clone the repository [dotnet/ai-samples](https://github.com/dotnet/ai-samples)
1. From a terminal or command prompt, navigate to the `ai-samples/src/llm-eval` directory.
1. Build the evaluation application:

    ```dotnetcli
    dotnet build .
    ```

## 2 - Configure the models to test, perform evaluations, and generate test data

Set the model to be tested and the models to perform evaluations and generate test data.

It's best to use a GPT-4 model for performing evaluation. You can use an Azure OpenAI resource, an OpenAI instance, or any LLM supported by the Semantic Kernel SDK. This article uses a GPT-4 model deployed to an Azure OpenAI resource for evaluations.

The `KernelFactory` class (`src/LLMEval.Test/KernelFactory.cs`) handles creating the kernels for evaluations, generating test data, and the LLM being tested.

### Configure the model to test

The evaluation application is configured to test the model returned by the `KernelFactory.CreateKernelTest` method.

The Semantic Kernel SDK can integrate any model that supports the *OpenAI Chat Completion API*.

Update the `KernelFactory.CreateKernelTest` method to return a `Kernel` object that uses the model to be tested. For example, the following creates a `Kernel` object that uses a Llama 3 model deployed and hosted locally using Ollama:

:::code language="csharp" source="./snippets/llm-eval/KernelFactoryExamples.cs" id="testKernel":::

### Configure the model to perform evaluations

Use .NET user secrets to store the Azure OpenAI deployment info. From the `ai-samples/src/llm-eval/LLMEval.Test` directory, run the following commands:

```dotnetcli
dotnet user-secrets init
dotnet user-secrets set "AZURE_OPENAI_MODEL" "<deployment-name>"
dotnet user-secrets set "AZURE_OPENAI_ENDPOINT" "<deployment-endpoint>"
dotnet user-secrets set "AZURE_OPENAI_KEY" "<deployment-key>"
```

The evaluation application is configured to use these secrets to connect to an Azure OpenAI model to perform evaluations. This configuration can be updated in the `KernelFactory.CreateKernelEval` method:

:::code language="csharp" source="./snippets/llm-eval/KernelFactoryExamples.cs" id="evalKernel":::

### Configure the model to generate test data

The evaluation application is configured to use [the secrets set in the previous step](#configure-the-model-to-perform-evaluations) to connect to an Azure OpenAI model to generate test data. This configuration can be updated in the `KernelFactory.CreateKernelGenerateData` method:

:::code language="csharp" source="./snippets/llm-eval/KernelFactoryExamples.cs" id="genKernel":::

## 3 - Generate test data

The evaluation application compares an LLM's output to "ground truth" answers, which are ideal question-answer pairs. At least 200 question-answer pairs are recommended for an evaluation.

You can use the evaluation application to generate an initial set of question-answer pairs. Then manually curate them, rewriting or removing any subpar answers.

Tips for generating test data:

* Generate more question-answer pairs than you need, then manually prune them based on quality and overlap. Remove low quality answers, and remove questions that are too similar to other questions.
* Be aware of the knowledge distribution so you effectively sample questions across the relevant knowledge space.
* Once your application is live, continually sample real user questions (within accordance to your privacy policy) to make sure you're representing the kinds of questions that users are asking.

1. From the `ai-samples/src/llm-eval/LLMEval.Test` directory, run the following command:

    ```dotnetcli
    dotnet run .
    ```

1. Select **Generate QAs associated to a topic, and export to json**, then press **Enter**.

    :::image type="content" source="../media/llm-eval/eval-app-gen-scenario.png" lightbox="../media/llm-eval/eval-app-gen-scenario.png" alt-text="Scenario selection step of the Evaluation Application":::

1. Enter the number of question-answer pairs to be generated and their topic.

    :::image type="content" source="../media/llm-eval/eval-app-gen-input.png" lightbox="../media/llm-eval/eval-app-gen-input.png" alt-text="Number and topic inputs for question-answer generation with the Evaluation Application":::

1. A preview of the generated question-answer pairs in JSON format is shown; enter the path of the file to save the JSON to.

    :::image type="content" source="../media/llm-eval/eval-app-gen-output.png" lightbox="../media/llm-eval/eval-app-gen-output.png" alt-text="Output file input for question-answer generation with the Evaluation Application":::

1. Review the output JSON, update or remove any incorrect or subpar answers.

## 4 - Perform an evaluation

Once the question-answer pairs have been curated, the evaluation application can use them to evaluate the outputs of the test model.

1. Copy the JSON file containing the question-answer pairs to `ai-samples/src/llm-eval/LLMEval.Test/assets/qa-02.json`.
1. From the `ai-samples/src/llm-eval/LLMEval.Test` directory, run the following command:

    ```dotnetcli
    dotnet run .
    ```

1. Select **List of QAs from a file**, then press **Enter**.

    :::image type="content" source="../media/llm-eval/eval-app-test-scenario.png" lightbox="../media/llm-eval/eval-app-test-scenario.png" alt-text="Scenario selection step of the Evaluation Application":::

1. The evaluation results are printed in a table format.

    :::image type="content" source="../media/llm-eval/eval-app-test-output.png" lightbox="../media/llm-eval/eval-app-test-output.png" alt-text="Scenario selection step of the Evaluation Application":::

## 5 - Review the evaluation results

The evaluation results [generated in the previous step](#4---perform-an-evaluation) include a *coherence*, *relevance*, and *groundedness* metric. These metrics are similar to the built-in metrics provided by the Azure AI Studio.

* *Coherence*: Measures how well the language model can produce outputs that flow smoothly, read naturally, and resemble human-like language.
  * Based on `ai-samples/src/LLMEval.Core/_prompts/coherence/skprompt.txt`
* *Relevance*: Assesses the ability of answers to capture the key points of the context.
  * Based on `ai-samples/src/LLMEval.Core/_prompts/relevance/skprompt.txt`
* *Groundedness*: Assesses the correspondence between claims in an AI-generated answer and the source context, making sure that these claims are substantiated by the context.
  * Based on `ai-samples/src/LLMEval.Core/_prompts/groundedness/skprompt.txt`

## Clean up resources

If you no longer need them, delete the Azure OpenAI resource and GPT-4 model deployment.

1. In the [Azure Portal](https://aka.ms/azureportal), navigate to the Azure OpenAI resource.
1. Select the Azure OpenAI resource then select **Delete**.

## Related content

* [Evaluation of generative AI applications](/azure/ai-studio/concepts/evaluation-approach-gen-ai)
* [What is Semantic Kernel?](/semantic-kernel/overview/?tabs=Csharp)
* [What is Azure OpenAI Service?](/azure/ai-services/openai/overview)
