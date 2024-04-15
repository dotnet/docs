---
title: "Understanding tokens"
description: "Understand how large language models (LLMs) use tokens to analyze semantic relationships and generate natural language outputs"
author: haywoodsloan
ms.topic: concept-article
ms.date: 04/12/2024

#customer intent: As a .NET developer, I want understand how large language models (LLMs) use tokens so I can add semantic analysis and text generation capabilities to my .NET projects.

---

# Understanding tokens

Tokens are the words or character sets that large language models (LLMs) decompose text into. During training, an LLM tokenizes the training text then analyzes the semantic relationships between these tokens, such as how commonly they're used together or if they're used in similar contexts. Once trained, an LLM uses those patterns and relationships to generate a sequence of output tokens based on the input sequence.

## Turning text into tokens

The first step when training an LLM or inputting a prompt is tokenization. The model breaks down the text into a set of strings, known as _tokens_. These tokens can be distinct words, character sets, or combinations of words and punctuation. The set of unique tokens a model has been trained on is referred to as its _vocabulary_.

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

The model will only add the first occurrence of the "a" token to it's vocabulary. All other occurrences can be represented by that first token.

With a sufficiently large set of training text, a vocabulary of many thousands of tokens can be compiled.

## Common tokenization methods

The specific tokenization method varies by LLM. Some common tokenization methods include:

- Word tokenization (text is split into individual words based on a delimiter)
- Character tokenization (text is split into individual characters)
- Subword tokenization (text is split into partial words or character sets)

For example, the GPT models, developed by OpenAI, use _Byte-Pair Encoding_ (BPE) which is a type of subword tokenization. OpenAI provides [a tool to visualize how text will be tokenized](https://platform.openai.com/tokenizer).

There are benefits and disadvantages to each tokenization method:

| Token size                                         | Pros                                                                                                                                                                                            | Cons                                                                                                                                                                                                 |
| -------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Smaller tokens (character or subword tokenization) | - Allows the model to handle a wider range of inputs, such as unknown words, typos, or complex syntax<br>- Might allow the vocabulary size to be reduced, requiring less memory resources       | - A given text is broken into more tokens, requiring additional computational resources while processing<br>- Given a fixed token limit, the maximum size of the model's input and output is smaller |
| Larger tokens (word tokenization)                  | - A given text is broken into fewer tokens, requiring less computational resources while processing<br>- Given the same token limit, the maximum size of the model's input and output is larger | - Might cause an increased vocabulary size, requiring more memory resources<br>- Can limit the models ability to handle unknown words, typos, or complex syntax                                      |

## How LLMs use tokens

After completing tokenization, LLMs assign an ID to each unique token.

Consider the following text:

> I heard a dog bark loudly at a cat

After using a word tokenization method, a model could assign token IDs like this:

- I (1)
- heard (2)
- a (3)
- dog (4)
- bark (5)
- loudly (6)
- at (7)
- a (the "a" token is already assigned an ID of 3)
- cat (8)

By assigning IDs, text can be represented as a sequence of token IDs. The previous sentence would be represented as [1, 2, 3, 4, 5, 6, 7, 3, 8]. The sentence "I heard a cat" would be represented as [1, 2, 3, 8].

As training continues, the model add any new tokens in the training text to it's vocabulary and assigns it an ID. For example:

- meow (9)
- run (10)

The semantic relationships between the tokens can be analyzed using these token ID sequences. Multi-valued numeric vectors, known as [_embeddings_]<!-- (understanding-embeddings.md) -->, are used to represent these relationships. An embedding is assigned to each token based on how commonly it's used together with or in similar contexts to the other tokens.

During output generation, the model predicts a vector value for the next token in the sequence. The model then selects the next token from it's vocabulary based on this vector value. In practice, the models calculates multiple vectors using various elements of the preceding tokens' embeddings. The model then evaluates all potential tokens from these vectors and selects the most probable one to continue the sequence.

Output generation is an iterative operation. The model appends the predicted token to the sequence so far and uses that as the input for the next iteration, building the final output one token at a time.

### Token limits

LLMs have limits on the maximum number of tokens that can be used as input or generated as output. This limit often combines the input and output tokens into a maximum context window.

For example, GPT-4 supports up to 8,192 tokens of context. The combined size of the input and output tokens can't exceed 8,192.

Together a model's token limit and tokenization method determine the maximum length of text that can be provided as input or generated as output.

For example, consider a model with a maximum context window of 100 tokens. For the following input text:

> I heard a dog bark loudly at a cat

With a word-based tokenization method, the input is 9 tokens leaving 91 **word** tokens available for the output.

With a character-based tokenization method, the input is 34 tokens (including spaces) leaving only 66 **character** tokens available for the output.

### Token based pricing and rate limiting

Generative AI services often use token-based pricing. The cost of each request depends on the number of input and output tokens. The pricing might differ between input and output. For example, see [Azure OpenAI Service pricing](https://azure.microsoft.com/pricing/details/cognitive-services/openai-service/).

Generative AI services might also have limits on the maximum number of tokens per minute (TPM). These rate limits can vary depending on the service region and LLM. For more information about specific regions, see [Azure OpenAI Service quotas and limits](/azure/ai-services/openai/quotas-limits#regional-quota-limits).

## Related content

- [How Generative AI and LLMs work]<!-- (how-genai-and-llms-work.md) -->
- [Understanding embeddings]<!-- (understanding-embeddings.md) -->
- [Working with vector databases]<!-- (working-with-vector-dbs.md) -->
