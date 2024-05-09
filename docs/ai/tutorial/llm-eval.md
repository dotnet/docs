---
title: "Tutorial: Evaluate an LLM's Prompt Completions"
description: "Evaluate the coherence, relevance, and groundedness of a LLM's prompt completions using Azure OpenAI and the Semantic Kernel SDK for .NET."
author: haywoodsloan
ms.topic: tutorial 
ms.date: 05/08/2024

#customer intent: As a .NET developer, I want to evaluate an LLM's prompt completions using .NET so that I can choose an LLM for my .NET application that fits my use case.

---

<!-- --------------------------------------

- Use this template with pattern instructions for:

Tutorial

- Before you sign off or merge:

Remove all comments except the customer intent.

- Feedback:

https://aka.ms/patterns-feedback

-->

# Tutorial: Evaluate an LLM's prompt completions

<!-- Required: Article headline - H1

Identify the product or service and the feature area
the tutorial covers.

-->

In this tutorial, you evaluate the coherence, relevance, and groundedness of an LLM's prompt completions using Azure OpenAI and the Semantic Kernel SDK for .NET.

:::image type="content" source="../media/llm-eval/eval-app.png" lightbox="../media/llm-eval/eval-app.png" alt-text="Main UI of the Evaluation Application":::

<!-- Required: Introductory paragraphs (no heading)

Write a brief introduction that can help the user 
decide whether the article is relevant for them and
to describe how reading the article might benefit
them.

-->

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> * Configure the models to test, generate test data, and perform evaluations
> * Generate test data for an evaluation
> * Perform an evaluation of your LLM
> * View the results of an evaluation

<!-- Required: Outline (no heading)

Before your first H2, use the green checkmark format
for a bulleted list that outlines what you'll cover 
in the tutorial.

-->

If you don't have an Azure subscription, create a [free account](https://azure.microsoft.com/free/?WT.mc_id=A261C142F) before you begin.

<!-- Required: Free account links (no heading)

Because quickstarts are intended to help new customers
evaluate a product or service, include a link to a 
free trial before the first H2.

-->

## Prerequisites

* [.NET 8.0 SDK (or newer)](https://dotnet.microsoft.com/download/visual-studio-sdks)
* [Visual Studio 2022 (or newer)](https://visualstudio.microsoft.com/downloads/) or [Visual Studio Code](https://code.visualstudio.com/Download)
* [Create and deploy a GPT-4 model to Azure OpenAI Service](/azure/ai-services/openai/how-to/create-resource)

<!-- Optional: Prerequisites - H2

If included, "Prerequisites" must be the first H2 in the article.

List any items that are needed for the integration,
such as permissions or software.

If you need to sign in to a portal to do the quickstart, 
provide instructions and a link.

-->

## 1 - Build the evaluation application

Get the source for the evaluation application and ensure it can be built successfully.

1. Clone the repository [dotnet/ai-samples](https://github.com/dotnet/ai-samples)
1. From a terminal or command prompt, navigate to the `ai-samples/src/llm-eval/LLMEval.Test` directory.
1. Build the evaluation application:

    ```dotnetcli
    dotnet build LLMEval.Test.csproj
    ```

## 2 - Configure the models to test, generate test data, and perform evaluations

Set the model to be tested, as well as the models for generating test data and performing evaluations.

It's best to use a GPT-4 model for performing evaluation. You can use an Azure OpenAI resource, an OpenAI instance, or any LLM supported by Semantic Kernel SDK. This article shows using an GPT-4 models deployed to an Azure OpenAI resource for evaluations.

The `KernelFactory` class (`src/LLMEval.Test/KernelFactory.cs`) handles creating the kernels for evaluations, generating data, and the LLM being tested.

<!-- Required: Tasks to complete in the process - H2

In one or more numbered H2 sections, describe tasks that 
the user completes in the process the tutorial describes.

-->

### Configure the model to test

The evaluation application is configured to test the model returned by the `KernelFactory.CreateKernelTest` method.

The Semantic Kernel SDK can integrate any model that supports the *OpenAI Chat Completion API*.

Update the `KernelFactory.CreateKernelTest` method to return a `Kernel` that uses the model to be tested. For example, the following creates a `Kernel` that uses a Llama 3 model deployed and hosted locally using Ollama:

:::code language="csharp" source="./snippets/llm-eval/KernelFactoryExamples.cs" id="testKernel":::

### Configure the model to perform evaluations

Use .NET user secrets to store the Azure OpenAI deployment info. From the `ai-samples/src/llm-eval/LLMEval.Test` directory, run the following commands:

```dotnetcli
dotnet user-secrets init
dotnet user-secrets set "AZURE_OPENAI_MODEL" "<deployment-name>"
dotnet user-secrets set "AZURE_OPENAI_ENDPOINT" "<deployment-endpoint>"
dotnet user-secrets set "AZURE_OPENAI_KEY" "<deployment-key>"
```

The evaluation application is configured to use the previously set secrets to connect to an Azure OpenAI model to perform evaluations. This configuration can be updated in the `KernelFactory.CreateKernelEval` method:

:::code language="csharp" source="./snippets/llm-eval/KernelFactoryExamples.cs" id="evalKernel":::

### Configure the model to generate test data

The evaluation application is configured to use [the secrets set in the previous step](#configure-the-model-to-perform-evaluations) to connect to an Azure OpenAI model to generate test data. This configuration can be updated in the `KernelFactory.CreateKernelGenerateData` method:

:::code language="csharp" source="./snippets/llm-eval/KernelFactoryExamples.cs" id="genKernel":::

<!-- Required: Steps to complete the tasks - H2

Use ordered lists to describe how to complete tasks in 
the process. Be consistent when you describe how to
use a method or tool to complete the task.

Code requires specific formatting. Here are a few useful 
examples of commonly used code blocks. Make sure to 
use the interactive functionality when possible.

For the CLI-based or PowerShell-based procedures,
don't use bullets or numbering.

Here is an example of a code block for Java:

```java
cluster = Cluster.build(new File("src/site.yaml")).create();
...
client = cluster.connect();
```

Here's a code block for the Azure CLI:

```azurecli-interactive 
az vm create --resource-group myResourceGroup --name myVM 
--image win2016datacenter --admin-username azureuser 
--admin-password myPassword12
```

This is a code block for Azure PowerShell:

```azurepowershell-interactive
New-AzureRmContainerGroup -ResourceGroupName 
myResourceGroup -Name mycontainer 
-Image mcr.microsoft.com/windows/servercore/iis:nanoserver 
-OsType Windows -IpAddressType Public
```
-->

## 3 - Generate test data

The evaluation application compares an LLM's output to "ground truth" answers, the ideal answer for a particular question. At least 200 question-answer pairs are recommended for an evaluation.

You can use the evaluation application to generate an initial set of question-answer pairs. Then manually curate them, rewriting or removing an subpar answers.

<!-- Required: Tasks to complete in the process - H2

In one or more numbered H2 sections, describe tasks that 
the user completes in the process the tutorial describes.

-->

1. Procedure step
1. Procedure step
1. Procedure step

<!-- Required: Steps to complete the tasks - H2

Use ordered lists to describe how to complete tasks in 
the process. Be consistent when you describe how to
use a method or tool to complete the task.

Code requires specific formatting. Here are a few useful 
examples of commonly used code blocks. Make sure to 
use the interactive functionality when possible.

For the CLI-based or PowerShell-based procedures,
don't use bullets or numbering.

Here is an example of a code block for Java:

```java
cluster = Cluster.build(new File("src/site.yaml")).create();
...
client = cluster.connect();
```

Here's a code block for the Azure CLI:

```azurecli-interactive 
az vm create --resource-group myResourceGroup --name myVM 
--image win2016datacenter --admin-username azureuser 
--admin-password myPassword12
```

This is a code block for Azure PowerShell:

```azurepowershell-interactive
New-AzureRmContainerGroup -ResourceGroupName 
myResourceGroup -Name mycontainer 
-Image mcr.microsoft.com/windows/servercore/iis:nanoserver 
-OsType Windows -IpAddressType Public
```
-->

## 4 - Perform an evaluation

[Introduce a task and its role in completing the process.]

<!-- Required: Tasks to complete in the process - H2

In one or more numbered H2 sections, describe tasks that 
the user completes in the process the tutorial describes.

-->

1. Procedure step
1. Procedure step
1. Procedure step

<!-- Required: Steps to complete the tasks - H2

Use ordered lists to describe how to complete tasks in 
the process. Be consistent when you describe how to
use a method or tool to complete the task.

Code requires specific formatting. Here are a few useful 
examples of commonly used code blocks. Make sure to 
use the interactive functionality when possible.

For the CLI-based or PowerShell-based procedures,
don't use bullets or numbering.

Here is an example of a code block for Java:

```java
cluster = Cluster.build(new File("src/site.yaml")).create();
...
client = cluster.connect();
```

Here's a code block for the Azure CLI:

```azurecli-interactive 
az vm create --resource-group myResourceGroup --name myVM 
--image win2016datacenter --admin-username azureuser 
--admin-password myPassword12
```

This is a code block for Azure PowerShell:

```azurepowershell-interactive
New-AzureRmContainerGroup -ResourceGroupName 
myResourceGroup -Name mycontainer 
-Image mcr.microsoft.com/windows/servercore/iis:nanoserver 
-OsType Windows -IpAddressType Public
```
-->

## 5 - View the evaluation results

[Introduce a task and its role in completing the process.]

<!-- Required: Tasks to complete in the process - H2

In one or more numbered H2 sections, describe tasks that 
the user completes in the process the tutorial describes.

-->

1. Procedure step
1. Procedure step
1. Procedure step

<!-- Required: Steps to complete the tasks - H2

Use ordered lists to describe how to complete tasks in 
the process. Be consistent when you describe how to
use a method or tool to complete the task.

Code requires specific formatting. Here are a few useful 
examples of commonly used code blocks. Make sure to 
use the interactive functionality when possible.

For the CLI-based or PowerShell-based procedures,
don't use bullets or numbering.

Here is an example of a code block for Java:

```java
cluster = Cluster.build(new File("src/site.yaml")).create();
...
client = cluster.connect();
```

Here's a code block for the Azure CLI:

```azurecli-interactive 
az vm create --resource-group myResourceGroup --name myVM 
--image win2016datacenter --admin-username azureuser 
--admin-password myPassword12
```

This is a code block for Azure PowerShell:

```azurepowershell-interactive
New-AzureRmContainerGroup -ResourceGroupName 
myResourceGroup -Name mycontainer 
-Image mcr.microsoft.com/windows/servercore/iis:nanoserver 
-OsType Windows -IpAddressType Public
```
-->

## Clean up resources

If you no longer need them, delete the Azure OpenAI resource and GPT-4 model deployment. To do so, select the Azure OpenAI resource then select **Delete**.

## Related content

* [Use custom and local AI models with the Semantic Kernel SDK](../how-to/work-with-local-models.md)
* [What is Semantic Kernel?](/semantic-kernel/overview/?tabs=Csharp)
* [What is Azure OpenAI Service?](/azure/ai-services/openai/overview)

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
