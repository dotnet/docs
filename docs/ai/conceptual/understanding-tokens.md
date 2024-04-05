---
title: "Concept - Understanding tokens"
description: "Understand how large language models (LLMs) use tokens to analyze semantic relationships and generate natural language outputs"
ms.topic: concept-article
ms.date: 04/04/2024

#customer intent: As a .NET developer, I want understand how large language models (LLMs) use tokens to analyze semantic relationships and generate natural language outputs so I may better use LLMs in my .NET projects.

---

<!-- --------------------------------------

- Use this template with pattern instructions for:

Concept

- Before you sign off or merge:

Remove all comments except the customer intent.

- Feedback:

https://aka.ms/patterns-feedback

-->

# Understanding tokens

<!-- Required: Article headline - H1

Identify the product, service, or feature the
article covers.

-->

Tokens are the words or sets of characters that large language models (LLMs) decompose text into. During training a LLM will analyze the semantic relationships between these tokens, such as how commonly they are used together or if they are used in similar contexts. Once trained a LLM will use those relationships and patterns to generate output text based on the sequence of tokens provided as the input.

<!-- Required: Introductory paragraphs (no heading)

Write a brief introduction that can help the user
determine whether the article is relevant for them
and to describe the concept the article covers.

For definitive concepts, it's better to lead with a
sentence in the form, "X is a (type of) Y that does Z."

-->

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

[Describe a main idea.]

<!-- Required: Main ideas - H2

Use one or more H2 sections to describe the main ideas
of the concept.

Follow each H2 heading with a sentence about how
the section contributes to the whole. Then, describe 
the concept's critical features as you define what it is.

-->

## Related content

- [How Generative AI and LLMs work](how-genai-and-llms-work.md)
- [Understanding embeddings](understanding-embeddings.md)
- [Working with vector databases](working-with-vector-dbs.md)

<!-- Optional: Related content - H2

Consider including a "Related content" H2 section that 
lists links to 1 to 3 articles the user might find helpful.

-->

<!--

Remove all comments except the customer intent
before you sign off or merge to the main branch.

-->
