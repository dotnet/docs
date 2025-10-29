---
title: Use Microsoft.ML.Tokenizers for text tokenization
description: Learn how to use the Microsoft.ML.Tokenizers library to tokenize text for AI models, manage token counts, and work with various tokenization algorithms.
ms.topic: how-to
ms.date: 10/29/2025
ai-usage: ai-assisted
#customer intent: As a .NET developer, I want to use the Microsoft.ML.Tokenizers library to tokenize text so I can work with AI models, manage costs, and handle token limits effectively.
---
# Use Microsoft.ML.Tokenizers for text tokenization

The [Microsoft.ML.Tokenizers](https://www.nuget.org/packages/Microsoft.ML.Tokenizers) library provides a comprehensive set of tools for tokenizing text in .NET applications. Tokenization is essential when working with large language models (LLMs), as it allows you to manage token counts, estimate costs, and preprocess text for AI models.

This article shows you how to use the library's key features and work with different tokenizer models.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later

## Install the package

Install the Microsoft.ML.Tokenizers NuGet package:

```dotnetcli
dotnet add package Microsoft.ML.Tokenizers
```

## Key features

The Microsoft.ML.Tokenizers library provides:

- **Extensible tokenizer architecture**: Allows specialization of Normalizer, PreTokenizer, Model/Encoder, and Decoder components.
- **Multiple tokenization algorithms**: Supports BPE (Byte Pair Encoding), Tiktoken, Llama, CodeGen, and more.
- **Token counting and estimation**: Helps manage costs and context limits when working with AI services.
- **Flexible encoding options**: Provides methods to encode text to token IDs, count tokens, and decode tokens back to text.

## Use Tiktoken tokenizer

The Tiktoken tokenizer is commonly used with OpenAI models like GPT-4. The following example shows how to initialize a Tiktoken tokenizer and perform common operations:

:::code language="csharp" source="./snippets/use-tokenizers/csharp/TokenizersExamples/TiktokenExample.cs" id="TiktokenBasic":::

The tokenizer instance should be cached and reused throughout your application for better performance.

### Manage token limits

When working with LLMs, you often need to manage text within token limits. The following example shows how to trim text to a specific token count:

:::code language="csharp" source="./snippets/use-tokenizers/csharp/TokenizersExamples/TiktokenExample.cs" id="TiktokenTrim":::

## Use Llama tokenizer

The Llama tokenizer is designed for the Llama family of models. It requires a tokenizer model file, which you can download from model repositories like Hugging Face:

:::code language="csharp" source="./snippets/use-tokenizers/csharp/TokenizersExamples/LlamaExample.cs" id="LlamaBasic":::

### Advanced encoding options

The tokenizer supports advanced encoding options, such as controlling normalization and pretokenization:

:::code language="csharp" source="./snippets/use-tokenizers/csharp/TokenizersExamples/LlamaExample.cs" id="LlamaAdvanced":::

## Use BPE tokenizer

Byte Pair Encoding (BPE) is the underlying algorithm used by many tokenizers, including Tiktoken. The following example demonstrates BPE tokenization:

:::code language="csharp" source="./snippets/use-tokenizers/csharp/TokenizersExamples/BpeExample.cs" id="BpeBasic":::

The library also provides specialized tokenizers like `BpeTokenizer` and `EnglishRobertaTokenizer` that you can configure with custom vocabularies for specific models.

## Common tokenizer operations

All tokenizers in the library implement the `Tokenizer` base class, which provides a consistent API:

- **`EncodeToIds`**: Converts text to a list of token IDs
- **`Decode`**: Converts token IDs back to text
- **`CountTokens`**: Returns the number of tokens in a text string
- **`EncodeToTokens`**: Returns detailed token information including values and IDs
- **`GetIndexByTokenCount`**: Finds the character index for a specific token count from the start
- **`GetIndexByTokenCountFromEnd`**: Finds the character index for a specific token count from the end

## Migration from other libraries

If you're currently using `DeepDev.TokenizerLib` or `SharpToken`, consider migrating to Microsoft.ML.Tokenizers. The library has been enhanced to cover scenarios from those libraries and provides better performance and support. For migration guidance, see the [migration guide](https://github.com/dotnet/machinelearning/blob/main/docs/code/microsoft-ml-tokenizers-migration-guide.md).

## Related content

- [Understanding tokens](../conceptual/understanding-tokens.md)
- [Microsoft.ML.Tokenizers API reference](/dotnet/api/microsoft.ml.tokenizers)
- [Microsoft.ML.Tokenizers NuGet package](https://www.nuget.org/packages/Microsoft.ML.Tokenizers)
