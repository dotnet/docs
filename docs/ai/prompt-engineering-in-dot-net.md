---
title: "Prompt engineering in .NET"
description: "Learn basic GPT prompt engineering concepts for .NET."
author: catbutler
ms.author: [your Microsoft alias or a team alias]
ms.service: [the approved service name]
ms.topic: concept-article #Don't change.
ms.date: [mm/dd/yyyy]

#customer intent: As a .NET developer, I want to understand GPT prompt engineering so that I can build more efficient and effective AI chat apps.

---

# Concept - Prompt engineering in .NET

This article explains basic GPT prompt engineering for .NET, including the Completion API and the Chat Completion API. 

GPT models from OpenAI are prompt-based: they respond to user input text (a prompt) with the most likely series of words to follow (a completion). For example, in response to the prompt **"The president who served the shortest term was "** these models would probably output the completion _"Pedro Lascurain."_ 

But what if your app is supposed to help US History students? Pedro Lascurain's 45-minute term is the shortest term for any president, but he served Mexico&mdash;the students are probably looking for _"William Henry Harrsion."_ Clearly, the app could be more helpful to its intended users if you gave it some context. That's the basic idea of prompt engineering: you provide context to your app to help it produce better completions. You can do this by giving the model instructions and examples.

The Completion API and the Chat Completion API target different GPT models with different implementations of prompt engineering. The Completion API targets the GPT-3 and GPT-35 models, which have no specific format rules for prompt engineering. The Chat Completion API targets the GPT-35-Turbo and GPT-4 models, which require that prompt engineering uses a specific chat-like format consisting of role-based messages. 

## Instructions

This section explains the use of instructions in prompt engineering. 

An instruction is text that tells the model how to respond. An instruction can be a directive (**You are helping students learn about US history, so talk about the US unless they specifically ask about other countries.**) or an imperative (**Translate to Tagalog:**). Note that directives are often more efficient and flexible than imperatives, because a directive can provide more context in one instruction.

The Completion API accepts any instructions that you include in an engineered prompt. The Chat Completion API only accepts instructions that you include in a [system message](https://learn.microsoft.com/en-us/azure/ai-services/openai/concepts/advanced-prompt-engineering?pivots=programming-language-chat-completions#system-message).

Sometimes GPT models don't follow an instruction that you thought was clear. You can clarify an instruction by including primary content, supporting content, and cues. You can include these clarifications when you add an instruction, and can add or adjust them after you test your instruction's effect. 
 
### Primary content

Primary content is text you include to process with an instruction. For example, you might use the instruction **Produce a list of US Presidents' executive accomplishments.**, you could use a wiki page as primary content and get a list of accomplishments that are present in that page.   
 
--- Need more about how this works with the Chat Completion API

### Supporting content

Supporting content is text that an instruction uses as input but isn't the subject of the instruction. The instruction must refer to the supporting content. Suppose you use the instruction **Produce a list of US Presidents' executive accomplishments** to produce some kind of a list. But what if you want the list to group the accomplishments by a specific set of categories? You could adjust your instruction by appending **, grouped in categories** to the instruction, but it's unlikely that a model will correctly determine which specific categories you want. You could use supporting content to specify the categories and adjust your instruction accordingly. You could change your instruction to **Produce a list of US Presidents' executive accomplishments, grouped by my favorite category** and then add a line of supporting content: **My favorite categories: domestic policy, judicial appointments, trade agreements, space exploration**. 

### Cues

A cue is text you include after an instruction to convey the desired structure or format of output. Even though you use cues with instructions, like an example a cue shows the model what you want instead of telling it exactly what to do. Suppose you use an instruction to tell the model to produce a list of presidential accomplishments by category and add supporting content to tell the model what categories to use. You decide that you want the model to produce a nested list with all caps for categories, with each president's accomplishments in each category listed on one line that begins with their name. After your instruction and supporting content, you could add the following cue to show the model how to structure and format the list:

**DOMESTIC POLICY**
**- George Washington:** 
**- Thomas Jefferson:**

## Examples 

This section explains the use of examples in .NET prompt engineering.

An example is text that shows the model how to respond. At a minimum, an example includes a prompt paired with a partial completion (known as a zero-shot prompt), but you can improve model performance more by using a prompt paired with a full completion (known as a one-shot prompt) or several prompt/completion pairs (known as a few-shot prompt). The model uses examples to infer what to include in completions. 

### Zero-shot prompts

A zero-shot prompt 

--- Add cumulative Zero-shot/one=shot/few-shot prompt example 

## Related content

- [Prompt engineering techniques](https://learn.microsoft.com/en-us/azure/ai-services/openai/concepts/advanced-prompt-engineering)
- [Related article title](link.md)
- [Related article title](link.md)
