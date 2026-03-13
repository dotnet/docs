---
title: "Understanding tokens"
description: "Understand how large language models (LLMs) use tokens to analyze semantic relationships and generate natural language outputs"
ms.topic: concept-article
ms.date: 03/04/2026
ai-usage: ai-assisted
#customer intent: As a .NET developer, I want understand how large language models (LLMs) use tokens so I can add semantic analysis and text generation capabilities to my .NET projects.
---
# Understand tokens

When you work with a large language model (LLM), text is first broken into units called *tokens*, which are words, character sets, or combinations of words and punctuation, by a tokenizer. During training, tokenization runs as the first step. The LLM analyzes the semantic relationships between tokens, such as how commonly they're used together or whether they're used in similar contexts. After training, the LLM uses those patterns and relationships to generate a sequence of output tokens based on the input sequence.

## Turn text into tokens

The set of unique tokens that an LLM is trained on is known as its _vocabulary_.

For example, consider the following sentence:

> `I heard a dog bark loudly at a cat`

This text could be tokenized as:

- `I`
- `heard`
- `a`
- `dog`
- `bark`
- `loudly`
- `at`
- `a`
- `cat`

By having a sufficiently large set of training text, tokenization can compile a vocabulary of many thousands of tokens.

## Common tokenization methods

The specific tokenization method varies by LLM. Common tokenization methods include:

- **Word** tokenization (text is split into individual words based on a delimiter)
- **Character** tokenization (text is split into individual characters)
- **Subword** tokenization (text is split into partial words or character sets)

For example, the GPT models, developed by OpenAI, use a type of subword tokenization that's known as _Byte-Pair Encoding_ (BPE). OpenAI provides [a tool to visualize how text will be tokenized](https://platform.openai.com/tokenizer).

Each tokenization method has benefits and disadvantages:

| Token size                                         | Pros | Cons |
|----------------------------------------------------|------|------|
| Smaller tokens (character or subword tokenization) | - Enables the model to handle a wider range of inputs, such as unknown words, typos, or complex syntax.<br>- Might allow the vocabulary size to be reduced, requiring fewer memory resources. | - A given text is broken into more tokens, requiring additional computational resources while processing.<br>- Given a fixed token limit, the maximum size of the model's input and output is smaller. |
| Larger tokens (word tokenization)                  | - A given text is broken into fewer tokens, requiring fewer computational resources while processing.<br>- Given the same token limit, the maximum size of the model's input and output is larger. | - Might cause an increased vocabulary size, requiring more memory resources.<br>- Can limit the model's ability to handle unknown words, typos, or complex syntax. |

## How LLMs use tokens

After the LLM completes tokenization, it assigns an ID to each unique token.

Consider this example sentence:

> `I heard a dog bark loudly at a cat`

After the model uses a word tokenization method, it could assign token IDs as follows:

- `I` (1)
- `heard` (2)
- `a` (3)
- `dog` (4)
- `bark` (5)
- `loudly` (6)
- `at` (7)
- `a` (the "a" token is already assigned an ID of 3)
- `cat` (8)

By assigning IDs, text can be represented as a sequence of token IDs. The example sentence would be represented as [1, 2, 3, 4, 5, 6, 7, 3, 8]. The sentence "`I heard a cat`" would be represented as [1, 2, 3, 8].

As training continues, the model adds any new tokens in the training text to its vocabulary and assigns each one an ID. For example:

- `meow` (9)
- `run` (10)

These token ID sequences reveal the semantic relationships between tokens. Multi-valued numeric vectors, known as [embeddings](embeddings.md), represent these relationships. The model assigns an embedding to each token based on how commonly it's used together with, or in similar contexts to, the other tokens.

After it's trained, a model can calculate an embedding for text that contains multiple tokens. The model tokenizes the text, then calculates an overall embeddings value based on the learned embeddings of the individual tokens. Use this technique for semantic document searches or to add vector stores to an AI.

During output generation, the model predicts a vector value for the next token in the sequence. The model then selects the next token from its vocabulary based on this vector value. In practice, the model calculates multiple vectors by using various elements of the previous tokens' embeddings. The model then evaluates all potential tokens from these vectors and selects the most probable one to continue the sequence.

Output generation is an iterative operation. The model appends the predicted token to the sequence so far and uses that as the input for the next iteration, building the final output one token at a time.

### Token limits

LLMs have a maximum number of tokens for input and output. This limit is often expressed as a combined maximum _context window_ that covers both input and output tokens together. Taken together, a model's token limit and tokenization method determine the maximum length of text that can be provided as input or generated as output.

For example, consider a model that has a maximum context window of 100 tokens. The model processes the example sentences as input text:

> `I heard a dog bark loudly at a cat`

By using a word-based tokenization method, the input is nine tokens. This leaves 91 **word** tokens available for the output.

By using a character-based tokenization method, the input is 34 tokens (including spaces). This leaves only 66 **character** tokens available for the output.

### Token-based pricing and rate limiting

Generative AI services often use token-based pricing. The cost of each request depends on the number of input and output tokens. Pricing might differ between input and output. For example, see [Azure OpenAI Service pricing](https://azure.microsoft.com/pricing/details/cognitive-services/openai-service/).

Generative AI services also enforce a maximum number of tokens per minute (TPM). These rate limits can vary depending on the service region and LLM. For more information about specific regions, see [Azure OpenAI Service quotas and limits](/azure/ai-services/openai/quotas-limits#regional-quota-limits).

## Related content

- [Use Microsoft.ML.Tokenizers for text tokenization](../how-to/use-tokenizers.md)
- [How generative AI and LLMs work](how-genai-and-llms-work.md)
- [Understand embeddings](embeddings.md)
- [Work with vector databases](vector-databases.md)
