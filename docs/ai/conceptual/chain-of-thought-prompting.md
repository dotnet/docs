---
title: "Chain of thought prompting"
description: "Learn how chain of thought prompting can simplify prompt engineering."
author: catbutler
ms.topic: concept-article
ms.date: 11/24/2024

#customer intent: As a .NET developer, I want to understand what chain-of-thought prompting is and how it can help me save time and get better completions out of prompt engineering.

---

# Chain of thought prompting

GPT model performance and response quality benefits from *prompt engineering*, which is the practice of providing instructions and examples to a model to prime or refine its output. As they process instructions, models make more reasoning errors when they try to answer right away rather than taking time to work out an answer. You can help the model reason its way toward correct answers more reliably by asking for the model to include its chain of thought&mdash;that is, the steps it took to follow an instruction, along with the results of each step.

*Chain of thought prompting* is the practice of prompting a model to perform a task step-by-step and to present each step and its result in order in the output. This simplifies prompt engineering by offloading some execution planning to the model, and makes it easier to connect any problem to a specific step so you know where to focus further efforts.

It's generally simpler to just instruct the model to include its chain of thought, but you can use examples to show the model how to break down tasks. The following sections show both ways.

## Use chain of thought prompting in instructions

To use an instruction for chain of thought prompting, include a directive that tells the model to perform the task step-by-step and to output the result of each step.

```csharp
prompt= """Instructions: Compare the pros and cons of EVs and petroleum-fueled vehicles.
Break the task into steps, and output the result of each step as you perform it.""";
```

## Use chain of thought prompting in examples

You can use examples to indicate the steps for chain of thought prompting, which the model will interpret to mean it should also output step results. Steps can include formatting cues.

```csharp
prompt= """
        Instructions: Compare the pros and cons of EVs and petroleum-fueled vehicles.

        Differences between EVs and petroleum-fueled vehicles:
        -

        Differences ordered according to overall impact, highest-impact first:
        1.

        Summary of vehicle type differences as pros and cons:
        Pros of EVs
        1.
        Pros of petroleum-fueled vehicles
        1.
        """;
```

## Related content

- [Prompt engineering techniques](/azure/ai-services/openai/concepts/advanced-prompt-engineering)
