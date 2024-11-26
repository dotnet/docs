---
title: "Zero-shot and few-shot learning"
description: "Learn the use cases for zero-shot and few-shot learning in prompt engineering."
author: catbutler
ms.topic: concept-article #Don't change.
ms.date: 11/25/2024

#customer intent: As a .NET developer, I want to understand how zero-shot and few-shot learning techniques can help me improve my prompt engineering.

---

# Zero-shot and few-shot learning

This article explains zero-shot learning and few-shot learning for prompt engineering in .NET, including their primary use cases.

GPT model performance benefits from *prompt engineering*, the practice of providing instructions and examples to a model to refine its output. Zero-shot learning and few-shot learning are techniques you can use when providing examples.

## Zero-shot learning

Zero-shot learning is the practice of passing prompts that aren't paired with verbatim completions, although you can include completions that consist of cues. Zero-shot learning relies entirely on the model's existing knowledge to generate responses, which reduces the number of tokens created and can help you control costs. However, zero-shot learning doesn't add to the model's knowledge or context.

Here's an example zero-shot prompt that tells the model to evaluate user input to determine which of four possible intents the input represents, and then to preface the response with **"Intent: "**.

```csharp
prompt = $"""
Instructions: What is the intent of this request?
If you don't know the intent, don't guess; instead respond with "Unknown".
Choices: SendEmail, SendMessage, CompleteTask, CreateDocument, Unknown.
User Input: {request}
Intent: 
""";
```

There are two primary use cases for zero-shot learning:

- **Work with fined-tuned LLMs** - Because it relies on the model's existing knowledge, zero-shot learning is not as resource-intensive as few-shot learning, and it works well with LLMs that have already been fined-tuned on instruction datasets. You might be able to rely solely on zero-shot learning and keep costs relatively low.
- **Establish performance baselines** - Zero-shot learning can help you simulate how your app would perform for actual users. This lets you evaluate various aspects of your model's current performance, such as accuracy or precision. In this case, you typically use zero-shot learning to establish a performance baseline and then experiment with few-shot learning to improve performance.

## Few-shot learning

Few-shot learning is the practice of passing prompts paired with verbatim completions (few-shot prompts) to show your model how to respond.  Compared to zero-shot learning, this means few-shot learning produces more tokens and causes the model to update its knowledge, which can make few-shot learning more resource-intensive. However, few-shot learning also helps the model produce more relevant responses.

```csharp
prompt = $"""
Instructions: What is the intent of this request?
If you don't know the intent, don't guess; instead respond with "Unknown".
Choices: SendEmail, SendMessage, CompleteTask, CreateDocument, Unknown.

User Input: Can you send a very quick approval to the marketing team?
Intent: SendMessage

User Input: Can you send the full update to the marketing team?
Intent: SendEmail

User Input: {request}
Intent:
""";
```

Few-shot learning has two primary use cases:

- **Tuning an LLM** - Because it can add to the model's knowledge, few-shot learning can improve a model's performance. It also causes the model to create more tokens than zero-shot learning does, which can eventually become prohibitively expensive or even infeasible. However, if your LLM isn't fined-tuned yet, you won't always get good performance with zero-shot prompts, and few-shot learning is warranted.
- **Fixing performance issues** - You can use few-shot learning as a follow-up to zero-shot learning. In this case, you use zero-shot learning to establish a performance baseline, and then experiment with few-shot learning based on the zero-shot prompts you used. This lets you add to the model's knowledge after seeing how it currently responds, so you can iterate and improve performance while minimizing the number of tokens you introduce.  

### Caveats

- Example-based learning doesn't work well for complex reasoning tasks. However, adding instructions can help address this.
- Few-shot learning requires creating lengthy prompts. Prompts with large number of tokens can increase computation and latency. This typically means increased costs. There's also a limit to the length of the prompts.
- When you use several examples the model can learn false patterns, such as "Sentiments are twice as likely to be positive than negative."

## Related content

- [Prompt engineering techniques](/azure/ai-services/openai/concepts/advanced-prompt-engineering)
- [How GenAI and LLMs work](how-genai-and-llms-work.md)
