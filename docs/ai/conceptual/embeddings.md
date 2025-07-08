---
title: "How Embeddings Extend Your AI Model's Reach"
description: "Learn how embeddings extend the limits and capabilities of AI models in .NET."
ms.topic: concept-article #Don't change.
ms.date: 05/29/2025

#customer intent: As a .NET developer, I want to understand how embeddings extend LLM limits and capabilities in .NET so that I have more semantic context and better outcomes for my AI apps.

---
# Embeddings in .NET

Embeddings are the way LLMs capture semantic meaning. They are numeric representations of non-numeric data that an LLM can use to determine relationships between concepts. You can use embeddings to help an AI model understand the meaning of inputs so that it can perform comparisons and transformations, such as summarizing text or creating images from text descriptions. LLMs can use embeddings immediately, and you can store embeddings in vector databases to provide semantic memory for LLMs as-needed.

## Use cases for embeddings

This section lists the main use cases for embeddings.

### Use your own data to improve completion relevance

Use your own databases to generate embeddings for your data and integrate it with an LLM to make it available for completions. This use of embeddings is an important component of [retrieval-augmented generation](rag.md).

### Increase the amount of text you can fit in a prompt

Use embeddings to increase the amount of context you can fit in a prompt without increasing the number of tokens required.

For example, suppose you want to include 500 pages of text in a prompt. The number of tokens for that much raw text will exceed the input token limit, making it impossible to directly include in a prompt. You can use embeddings to summarize and break down large amounts of that text into pieces that are small enough to fit in one input, and then assess the similarity of each piece to the entire raw text. Then you can choose a piece that best preserves the semantic meaning of the raw text and use it in your prompt without hitting the token limit.

### Perform text classification, summarization, or translation

Use embeddings to help a model understand the meaning and context of text, and then classify, summarize, or translate that text. For example, you can use embeddings to help models classify texts as positive or negative, spam or not spam, or news or opinion.

### Generate and transcribe audio

Use audio embeddings to process audio files or inputs in your app.

For example, [Azure AI Speech](/azure/ai-services/speech-service/) supports a range of audio embeddings, including [speech to text](/azure/ai-services/speech-service/speech-to-text) and [text to speech](/azure/ai-services/speech-service/text-to-speech). You can process audio in real-time or in batches.

### Turn text into images or images into text

Semantic image processing requires image embeddings, which most LLMs can't generate. Use an image-embedding model such as [ViT](https://huggingface.co/docs/transformers/main/en/model_doc/vit) to create vector embeddings for images. Then you can use those embeddings with an image generation model to create or modify images using text or vice versa. For example, you can [use the DALL·E model to generate images](/azure/ai-services/openai/dall-e-quickstart?tabs=dalle3%2Ccommand-line&pivots=programming-language-csharp) such as logos, faces, animals, and landscapes.

### Generate or document code

Use embeddings to help a model create code from text or vice versa, by converting different code or text expressions into a common representation. For example, you can use embeddings to help a model generate or document code in C# or Python.

## Choose an embedding model

You generate embeddings for your raw data by using an AI embedding model, which can encode non-numeric data into a vector (a long array of numbers). The model can also decode an embedding into non-numeric data that has the same or similar meaning as the original, raw data. There are many embedding models available for you to use, with OpenAI's `text-embedding-ada-002` model being one of the common models that's used. For more examples, see the list of [Embedding models available on Azure OpenAI](/azure/ai-services/openai/concepts/models#embeddings).

### Store and process embeddings in a vector database

After you generate embeddings, you'll need a way to store them so you can later retrieve them with calls to an LLM. Vector databases are designed to store and process vectors, so they're a natural home for embeddings. Different vector databases offer different processing capabilities, so you should choose one based on your raw data and your goals. For information about your options, see [available vector database solutions](vector-databases.md#available-vector-database-solutions).

### Using embeddings in your LLM solution

When building LLM-based applications, you can use Semantic Kernel to integrate embedding models and vector stores, so you can quickly pull in text data, and generate and store embeddings. This lets you use a vector database solution to store and retrieve semantic memories.

## Related content

- [How GenAI and LLMs work](how-genai-and-llms-work.md)
- [Retrieval-augmented generation](rag.md)
- [Training: Develop AI agents with Azure OpenAI and Semantic Kernel](/training/paths/develop-ai-agents-azure-open-ai-semantic-kernel-sdk/)
