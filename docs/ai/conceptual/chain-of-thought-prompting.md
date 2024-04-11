---
title: "Chain of thought prompting"
description: "Learn how chain of thought prompting can simplfy prompt engineering."
author: catbutler
ms.topic: concept-article #Don't change.
ms.date: 04/10/2024

#customer intent: As a .NET developer, I want to understand how chain-of-thought prompting can save time and reduce prompt engineering complexity.

---

# Chain of thought prompting

This article explains the use of chain of thought prompting in .NET.

GPT model performance benefits from [prompt engineering](prompt-engineering-in-dot-net.md), the practice of providing instructions and examples to a model to prime or refine its output. Models often perform better if the task is broken down into smaller steps, which can cause an instruction to become quite long and introduce unintended complexity.

Chain of thought prompting is the practice of prompting a GPT model to perform a task step-by-step and to present each step and its result in order in the output. This simplifies prompt engineering by offloading some execution planning to the model, and makes it easier to connect any problem to a specific step so you know where to focus further efforts.

It's generally much simpler to use instructions for chain of thought prompting, but you can use examples to show the model how to break down tasks.

## Use chain of thought prompting in instructions

To use an instruction for chain of thought prompting, include a directive that tells the model to perform the task step-by-step and to output the result of each step.

```csharp
prompt= @$"Instructions: Compare the pros and cons of EVs and petroleum-fueled vehicles. Break the task into steps, and output the result of each step as you perform it."; 
```

## Use chain of thought prompting in examples

You can use examples to indicate the steps for chain of thought prompting, which the model will interpret to mean it should also output step results. Steps can include formatting cues.

```csharp
prompt= @$"Instructions: Compare the pros and cons of EVs and petroleum-fueled vehicles.

        Differences between EVs and petroleum-fueled vehicles:
        - 

        Differences ordered according to overall impact, highest-impact first: 
        1. 
        
        Summary of vehicle type differences as pros and cons:
        Pros of EVs
        1.
        Pros of petroleum-fueled vehicles
        1. ";
```

## Related content

- [Prompt engineering techniques](/azure/ai-services/openai/concepts/advanced-prompt-engineering)
