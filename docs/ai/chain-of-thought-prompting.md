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

# Chain of thought prompting

This article explains the use of chain of thought prompting for .NET prompt engineering.

GPT model performance benefits from [prompt engineering](prompt-engineering-in-dot-net.md), the practice of providing instructions and examples to a model to prime or refine its output. Models often perform better if the task is broken down into smaller steps, which can cause an instruction to become quite long and introduce unintended complexity. 

Chain of thought prompting is the practice of prompting a GPT model to perform a task step-by-step and to present each step and its result in order in the output. This simplifies prompt engineering by offloading some execution planning to the model, and makes it easier to connect any problem to a specific step so you know where to focus further efforts.

You can use instructions or examples for chain of thought prompting. 

## Use chain of thought prompting in instructions

To use an instruction for chain of thought prompting, include a directive that tells the model to perform the task step-by-step and output the result of each step.

## Use chain of thought prompting in examples

To use an example for chain of thought prompting, include at least one prompt paired with a verbatim completion that includes the step results.

## Related content

- [Prompt engineering techniques](https://learn.microsoft.com/en-us/azure/ai-services/openai/concepts/advanced-prompt-engineering)
- [Related article title](link.md)
- [Related article title](link.md)
