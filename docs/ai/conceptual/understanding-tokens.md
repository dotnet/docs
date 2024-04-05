---
title: "Concept - Understanding tokens"
description: "Understand how large language models (LLMs) use tokens to analyze semantic relationships and generate natural language outputs"
ms.topic: concept-article
ms.date: 04/04/2024

#customer intent: As a .NET developer, I want understand how large language models (LLMs) use tokens to analyze semantic relationships and generate natural language outputs so I may better use LLMs in my .NET projects.

---

# Understanding tokens

Tokens are the words or sets of characters that large language models (LLMs) decompose text into. During training a LLM will analyze the semantic relationships between these tokens, such as how commonly they are used together or if they are used in similar contexts. Once trained a LLM will use those relationships and patterns to generate output text based on the sequence of tokens provided as the input.

## What are tokens?

The first step when training an LLM or processing an input prompt is tokenization. The text is broken down into a set of strings, known as _tokens_. These tokens can be distinct words, character sets, or combinations of words and punctuation. The set of unique tokens a models has been trained on is refereed to as its _vocabulary_.

For example, consider the following sentence:

> I heard a dog bark loudly at a cat

This text could be tokenized as:

- I
- heard
- a
- dog
- bark
- loudly
- at
- a
- cat

Only the first occurrence of the "a" token will be added to the model's vocabulary. All other occurrences can be represented with that first token.

With a sufficiently large set of training text, a vocabulary of many thousands of tokens could be compiled.

## How are tokens determined?

The exact tokenization method used varies by LLM. Some common tokenization methods include:

- Word tokenization (text is split into individual words based on a delimiter)
- Character tokenization (text is split into individual characters)
- Subword tokenization (text is split into partial words or character sets)

For example, the GPT models, developed by OpenAI, use _Byte-Pair Encoding_ (BPE) which is a type of subword tokenization. OpenAI provides [a tool to visualize how a text will be tokenized](https://platform.openai.com/tokenizer).

There are benefits and disadvantages to each tokenization method:

**Smaller tokens**

- _Pros_:
  - Allows the model to handle a wider range of inputs, such as unknown words, typos, or complex syntax
  - May allow the vocabulary size to be reduced, requiring less memory resources
- _Cons_:
  - A given text will be broken into more tokens requiring additional computational resources while processing
  - Given a fixed token limit the maximum size of the model's input or output will be smaller

**Larger tokens**

- _Pros_:
  - A given text will be broken into fewer token requiring less computational resources while processing
  - Given the same token limit the maximum size of the model's input or output will be larger
- _Cons_:
  - May cause an increased vocabulary size, requiring more memory resources
  - Can limit the models ability to handle unknown words, typos, or complex syntax

## How are tokens used?

During training, after a text has been tokenized, each unique token is assigned an ID.

For example, in the sentence:

> I heard a dog bark loudly at a cat

After tokenization the following IDs could be assigned:

- I (1)
- heard (2)
- a (3)
- dog (4)
- bark (5)
- loudly (6)
- at (7)
- a (the "a" token is already assigned an ID of 3)
- cat (8)

This allows text to be represented as a sequence of token ID. The previous sentence would be represented as [1, 2, 3, 4, 5, 6, 7, 3, 8]. The sentence "I heard a cat" would be represented as [1, 2, 3, 8].

As training continues, any distinct tokens from the training text will be added to the vocabulary and assigned an ID. For example:

- meow (9)
- run (10)

Using these token ID sequences, the semantic relationships between the tokens can be analyzed. These relationships are represented as multi-valued numeric vectors, known as [_embeddings_](understanding-embeddings.md). Each token will be assigned an embedding based on how commonly they are used together or in similar contexts.

During output generation, the model predicts a vector value for the next token in the sequence. This vector value is then used to select the next token from the model's vocabulary. In practice, multiple vectors will be calculated using different elemets of the preceding tokens' embeddings. The model will then evaluate all potential tokens from these vectors and select the most probable one to continue the sequence.

Output generation is an iterative operation. The predicted token is appended to the sequence so far and used as the input for the next iteration, building the final output one token at a time.

### Token limits

LLM's will have limits on the maximum number of tokens that can be used as input context or generated as output. Additionally, the limits for input context and output generation may differ.

For example, GPT-4 supports up to 128,000 tokens of input context but only 4,096 tokens of output.

Together a model's token limit and tokenization method will determine the maximum length of text that can be provided as input or generated as output.

### Token based pricing and rate limiting

Generative AI services will often use token based pricing. The cost of each request will depend on the number of input and output tokens. The pricing may differ between input and output tokens. For example, see [Azure OpenAI Service pricing](https://azure.microsoft.com/en-us/pricing/details/cognitive-services/openai-service/)

Generative AI services may also have limits on the maximum number of Tokens-Per-Minute (TPM). These rate limits can vary depending on the service region and model. For example, see [Azure OpenAI Service quotas and limits](https://learn.microsoft.com/en-us/azure/ai-services/openai/quotas-limits#regional-quota-limits).

## Related content

- [How Generative AI and LLMs work](how-genai-and-llms-work.md)
- [Understanding embeddings](understanding-embeddings.md)
- [Working with vector databases](working-with-vector-dbs.md)
