---
title: What's new in ML.NET
titleSuffix: ""
description: Discover what's new in ML.NET.
ms.date: 04/15/2024
ms.topic: whats-new

#Customer intent: As a developer, I want to know what the new features are in ML.NET.

---

# What's new in ML.NET

> [!NOTE]
> This article is a work in progress.

You can find all of the release notes for the ML.NET API in the [dotnet/machinelearning repo](https://github.com/dotnet/machinelearning/tree/main/docs/release-notes).

## New deep-learning tasks

ML.NET 3.0 added support for the following deep-learning tasks:

- Object detection (backed by TorchSharp)
- Named entity recognition (NER)
- Question answering (QA)

These trainers are included in the [Microsoft.ML.TorchSharp](https://www.nuget.org/packages/Microsoft.ML.TorchSharp) package. For more information, see [Announcing ML.NET 3.0](https://devblogs.microsoft.com/dotnet/announcing-ml-net-3-0/).

## AutoML

In ML.NET 3.0, the AutoML sweeper was updated to support the sentence similarity, question answering, and object detection tasks. For more information about AutoML, see [How to use the ML.NET Automated Machine Learning (AutoML) API](../how-to-guides/how-to-use-the-automl-api.md).

## Additional tokenizer support

[Microsoft.ML.Tokenizers](https://devblogs.microsoft.com/dotnet/announcing-ml-net-2-0/#tokenizer-support) is an open-source, cross-platform tokenization library. When it was introduced, the library was scoped to the [Byte-Pair Encoding (BPE)](https://en.wikipedia.org/wiki/Byte_pair_encoding) tokenization strategy to satisfy the language set of scenarios in ML.NET. Version 4.0 Preview 1 added support for the `Tiktoken` tokenizer.

The following examples show how to use the `Tiktoken` text tokenizer.

:::code language="csharp" source="./snippets/csharp/Tiktoken.cs" id="Tiktoken":::

### About tokenization

Tokenization is a fundamental component in the preprocessing of natural language text for AI models. Tokenizers are responsible for breaking down a string of text into smaller, more manageable parts, often referred to as *tokens*. When using services like Azure OpenAI, you can use tokenizers to get a better understanding of cost and manage context. When working with self-hosted or local models, tokens are the inputs provided to those models.

## Model Builder (Visual Studio extension)

Model Builder has been updated to consume the ML.NET 3.0 release. Model Builder version 17.18.0 added question answering (QA) and named entity recognition (NER) scenarios.

You can find all of the Model Builder release notes in the [dotnet/machinelearning-modelbuilder repo](https://github.com/dotnet/machinelearning-modelbuilder/tree/main/docs/release-notes).

## See also

- [Blog post: Announcing ML.NET 3.0](https://devblogs.microsoft.com/dotnet/announcing-ml-net-3-0/)
