---
title: What's new in ML.NET
titleSuffix: ""
description: Discover what's new in ML.NET.
ms.date: 05/15/2025
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

> Tokenization is a fundamental component in the preprocessing of natural language text for AI models. Tokenizers are responsible for breaking down a string of text into smaller, more manageable parts, often referred to as *tokens*. When using services like Azure OpenAI, you can use tokenizers to get a better understanding of cost and manage context. When working with self-hosted or local models, tokens are the inputs provided to those models. For more information about tokenization in the Microsoft.ML.Tokenizers library, see [Announcing ML.NET 2.0](https://devblogs.microsoft.com/dotnet/announcing-ml-net-2-0/#tokenizer-support).

The [Microsoft.ML.Tokenizers](https://www.nuget.org/packages/Microsoft.ML.Tokenizers) package provides an open-source, cross-platform tokenization library. In ML.NET 4.0, the library has been enhanced in the following ways:

- Refined APIs and existing functionality.
- Added `Tiktoken` support.
- Added tokenizer support for the `Llama` model.
- Added the `CodeGen` tokenizer, which is compatible with models such as [codegen-350M-mono](https://huggingface.co/Salesforce/codegen-350M-mono/tree/main) and [phi-2](https://huggingface.co/microsoft/phi-2/tree/main).
- Added `EncodeToIds` overloads that accept `Span<char>` instances and let you customize normalization and pretokenization.
- Worked closely with the DeepDev `TokenizerLib` and `SharpToken` communities to cover scenarios covered by those libraries. If you're using `DeepDev` or `SharpToken`, we recommend migrating to `Microsoft.ML.Tokenizers`. For more details, see the [migration guide](https://github.com/dotnet/machinelearning/blob/main/docs/code/microsoft-ml-tokenizers-migration-guide.md).

The following examples show how to use the `Tiktoken` text tokenizer.

:::code language="csharp" source="./snippets/csharp/Tiktoken.cs" id="Tiktoken":::

The following examples show how to use the `Llama` text tokenizer.

:::code language="csharp" source="./snippets/csharp/Llama.cs" id="Llama":::

The following examples show how to use the `CodeGen` tokenizer.

:::code language="csharp" source="./snippets/csharp/CodeGen.cs" id="CodeGen":::

The following example demonstrates how to use the tokenizer with `Span<char>` and how to disable normalization or pretokenization on the encoding calls.

:::code language="csharp" source="./snippets/csharp/Llama.cs" id="Span":::

## Byte-level support in BPE tokenizer

The <xref:Microsoft.ML.Tokenizers.BpeTokenizer> now supports byte-level encoding, enabling compatibility with models like DeepSeek. This enhancement processes vocabulary as UTF-8 bytes. In addition, the new `BpeOptions` type simplifies tokenizer configuration.

```csharp
BpeOptions bpeOptions = new BpeOptions(vocabs);
BpeTokenizer tokenizer = BpeTokenizer.Create(bpeOptions);
```

## Deterministic option for LightGBM trainer

LightGBM trainers now expose options for deterministic training, ensuring consistent results with the same data and random seed. These options include `deterministic`, `force_row_wise`, and `force_col_wise`.

```csharp
LightGbmBinaryTrainer trainer = ML.BinaryClassification.Trainers.LightGbm(new LightGbmBinaryTrainer.Options
{
    Deterministic = true,
    ForceRowWise = true
});
```

## Model Builder (Visual Studio extension)

Model Builder has been updated to consume the ML.NET 3.0 release. Model Builder version 17.18.0 added question answering (QA) and named entity recognition (NER) scenarios.

You can find all of the Model Builder release notes in the [dotnet/machinelearning-modelbuilder repo](https://github.com/dotnet/machinelearning-modelbuilder/tree/main/docs/release-notes).

## See also

- [Blog post: Announcing ML.NET 3.0](https://devblogs.microsoft.com/dotnet/announcing-ml-net-3-0/)
