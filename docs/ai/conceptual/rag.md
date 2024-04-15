---
title: "Using Your Data in Prompt Engineering with Retrival-Augmented Generation - .NET"
description: "Learn how you can use retreival-augmented generation to pull external text data into examples for prompt engineeing in .NET."
author: catbutler
ms.topic: concept-article #Don't change.
ms.date: 04/10/2024

#customer intent: As a .NET developer, I want to understand how retrieval-augmented generation lets me pull external text data into engineered prompts in .NET so that I can use source text that is much larger than token limits allow.

---

# Using retrieval-augmented generation (RAG) to pull external text into prompts

This article describes how retrieval-augmented generation lets you use extensive texts for prompt engineering in .NET.

LLMs have input limits that prevent you from putting much reference material in an engnieered prompt. You can work around this limitation by using retrieval-augmented generation: using embeddings to match queries with semantically similar text data.
