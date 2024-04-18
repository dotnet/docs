---
title: "How Embeddings Extend Your AI Model's Reach"
description: "Learn how embeddings extend the limits and capabilities of AI models in .NET."
author: catbutler
ms.topic: concept-article #Don't change.
ms.date: 04/11/2024

#customer intent: As a .NET developer, I want to understand how embeddings extend LLM limits and capabilities in .NET so that I have more semantic context and better outcomes for my AI apps.

---

# Embeddings in .NET

This article explains how embeddings work in .NET.

Embeddings are the way you express semantic meaning to an LLM. Essentially, embeddings are numeric representations of non-numeric data that preserve its semantic meaning. You can use embeddings to help an AI model understand the meaning of inputs so that it can perform comparisons and transformations, such as summarizing text or creating images from text descriptions. LLMs can use embeddings immediately, and you can store embeddings in vector databases to provide semantic memory for LLMs as-needed.

Summarizing text is especially useful for [prompt engineering](), because it gives you a way to use far fewer tokens to repesent a given text. You use instructions in prompt engineering to tell an LLM what to do, and can include text content with the instruction to give the model more context. However, LLMs limit the number of tokens per input, which constrains how much text you can include in prompts. If you try to include more than the limit in one input, the model will ignore some or all of that input. Some LLMs also feature quota systems, another reason to watch your token counts. If you create an embedding for the text content you want to include, the LLM can find a shorter piece of text that has a similar vector, so you can use it instead of the original text to reduce the number of tokens you use to represent the content's meaning.

## Embeddings preserve semantic meaning

Embeddings turn non-numeric data into numeric data that represents semantic meaning. Specifically, an embedding is a vector&mdash;an array of numeric values&mdash; that an LLM uses to compare semantic meanings. Two embeddings with similar vectors also have similar semantic meanings, such as an image and its alt text, or a course syllabus and the textbook for that course.

### Choosing embedding models to generate embeddings

You generate embeddings for your raw data by using an embedding model: an AI model that can encode a piece of non-numeric data into a vector (a long array of numbers). The model can also decode an embedding into non-numeric data that has the same or similar meaning as the original, raw data. The embedding model you choose affects which data types you can generate embeddings for.

In Semantic Kernel, you use connectors to integrate embedding models and databases into your kernel, so you can quickly pull in text data, and generate and store embeddings. This lets you use a vector database solution to store and retrieve semantic memories.

In Azure OpenAI, the service includes access to [embedding models](/azure/ai-services/openai/concepts/models#embeddings).

### Store and process embeddings in a vector database

Vector databases are designed to store and process vectors, so they're a natural home for embeddings. Different vector databases offer different processing capabilities, so you should choose one based on your raw data and your goals. For information about your options, see [available vector database solutions](vector-dbs.md#available-vector-database-solutions).

## Use cases for embeddings

This section lists the main use cases for embeddings. LLMs can process text embeddings, but to use other data types you need to include a suitable embedding model, such as **dall-e-3** for image generation.

In Semantic Kernel, you add connectors to the kernel for each of the embedding models you want to use, and create plugins for the functions you want to use. Semantic Kernel comes with a set of native plugins that allow you to invoke their functions directly, such as 

### Increase the amount of text a model will process

Use embeddings to increase the amount of text a model will process, such as during [prompt engineering]().

For example, suppose you want to include 500 pages of text in a prompt. The number of tokens for that much raw text will exceed the input token limit, making it impossible to directly include in a prompt. You can use embeddings to summarize and break down large amounts of that text into pieces that are small enough to fit in one input, and then assess the similarity of each piece to the entire raw text. Then you can choose a piece that best preserves the semantic meaning of the raw text and use it in your prompt without hitting the token limit.

### More relevant and coherent text generation

Use embeddings to help models generate more relevant and coherent text. For example, embeddings can help the model to generate better stories, poems, jokes, slogans, captions, newsletters, and the like.

### Perform text classification, summarization, or translation

Use embeddings to help a model understand the meaning and context of text, and then classify, summarize, or translate that text. For example, you can use embeddings to help models classify texts as positive or negative, spam or not spam, or news or opinion.

### Turn text into images or images into text

Use an image-embedding model to create vector embeddings for images. Then you can use those embeddings with an LLM to create or modify images using text or vice versa. For example, you can use an embedding model to generate or describe images such as logos, faces, animals, and landscapes.

### Generate or document code

Use embeddings to help a model create code from text or vice versa, by converting different code or text expressions into a common representation. For example, you can use embeddings to help a model generate or document code in C# or Python.

## Related content

- [Retrieval augmented generation]()
