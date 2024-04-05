---
title: "Chain of thought prompting"
description: "Learn how chain of thought prompting can simplfy prompt engineering."
author: catbutler
ms.author: [your Microsoft alias or a team alias]
ms.service: [the approved service name]
ms.topic: concept-article #Don't change.
ms.date: [mm/dd/yyyy]

#customer intent: As a .NET developer, I want to understand how chain-of-thought prompting can save time and reduce prompt engineering complexity.

---

# Concept - Chain of thought prompting

This article explains the use of chain of thought prompting in instructions for .NET prompt engineering.

GPT model performance benefits from [prompt engineering](prompt-engineering-in-dot-net.md), the practice of providing instructions and examples to a model to prime or refine its output. Models often perform better if the task is broken down into smaller steps, which can cause an instruction to become quite long and introduce unintended complexity. 

Chain of thought prompting is the practice of instructing a GPT model to perform a task step-by-step and to present each step and its result in order in the output. This simplifies prompt engineering by offloading some execution planning to the model, and makes it easier to connect any problem to a specific step so you know where to focus further efforts. 

## When to use chain of thought prompting

Chain of thought prompting combines the ease of offloading execution planning with detailed insights into the actual execution of the plan. Use it to assist in troubleshooting and refining complex instructions by breaking them down into component steps. You could break down instructions into steps yourself, but it's simpler to just append an instruction that tells the model to create the steps and outputs each step's results. 

## Related content

- [Prompt engineering techniques](https://learn.microsoft.com/en-us/azure/ai-services/openai/concepts/advanced-prompt-engineering)
- [Related article title](link.md)
- [Related article title](link.md)
