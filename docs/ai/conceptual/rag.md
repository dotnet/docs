---
title: "Making Your Data Searchable to LLMs with Retrival-Augmented Generation"
description: "Learn how you can use retreival-augmented generation to give LLMs access to your data for prompt engineering in .NET."
author: catbutler
ms.topic: concept-article #Don't change.
ms.date: 04/15/2024

#customer intent: As a .NET developer, I want to understand how retrieval-augmented generation works in .NET so that LLMs can search my data sources to answer user questions.

---

# Using retrieval-augmented generation (RAG) to increase LLM knowledge

This article describes how retrieval-augmented generation lets LLMs query your data sources without first training on the data.

LLMs have token input limits that constrain how much text you can put directly into a prompt. For most use cases that's fine: LLMs have extensive knowledge bases. But, LLMs don't know about your data unless you've customized them through training. Retrieval-augmented generation lets you make your data available to LLMs without training them on it first.

With retrieval-augmented generation, you create indexes for querying your data sources and use them to generate embeddings. When a user asks the LLM a question, it compares the question to your indexed data and finds the most relevant context. This context and the user's question then go to the LLM in a prompt, and the LLM provides a response based on your data.
