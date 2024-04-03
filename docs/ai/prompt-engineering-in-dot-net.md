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

# Basic prompt engineering in .NET

This article explains basic GPT prompt engineering for .NET, including the Completion API and the Chat Completion API. 

GPT models from OpenAI are prompt-based: they respond to user input text (a prompt) with the most likely series of words to follow (a completion). For example, in response to the prompt "The president who served the shortest term was " these models might output the completion "Pedro Lascurain". 

But what if your app is supposed to help US History students? Pedro Lascurain's 45-minute term is the shortest term for any president, but he served Mexico&mdash;the students are probably looking for "William Henry Harrsion". Clearly, the app could be more helpful if you gave it some context. That's the basic idea of prompt engineering: you provide context to your app to help it produce better completions. You can do this by giving the model instructions and examples.

The Completion API and the Chat Completion API target different GPT models, which affects their support for prompt engineering. The Completion API targets the GPT-3 and GPT-35 models, which have no specific format rules for prompt engineering. The Chat Completion API targets the GPT-35-Turbo and GPT-4 models, which require that prompt engineering uses a specific chat-like format consisting of role-based messages. 

## Instructions

An instruction is text that tells the model how to respond. You can use directives (such as **You are helping students learn about US history, so talk about the US unless they specifically ask about other countries.**) and imperatives (such as **Translate to Tagalog:**). 

The Completion API will follow any instructions that you include in an engineered prompt. The Chat Completion API only follows instructions that are part of a [system message](https://learn.microsoft.com/en-us/azure/ai-services/openai/concepts/advanced-prompt-engineering?pivots=programming-language-chat-completions#system-message). Directives can be more efficient and flexible than imperatives, especially with the Chat Completion API, because a directive lets you provide more context in one instruction.

Sometimes GPT models misunderstand an instruction that you thought was clear. You can clarify an instruction by including primary content (text to process using the instruction), supporting content (text referenced by the instruction), and cues (text to use to format completions). You can include these clarifications when you add an instruction, and can add or adjust them after you test your instruction's effect. 
 
### Primary content

Primary content is text you include to process with an instruction. For example, you could add an English phrase with the instruction **Translate to Tagalog:** to have the model produce a Tagalog version of the phrase. 
 
--- Need better understanding of how this works with the Chat Completion API

### Supporting content

Supporting content is text that an instruction uses as input but isn't the subject of the instruction. For example, you might use the instruction "Summarize content about historical figures and list US Presidents in descending order of term length, you could use a wiki page as primary content

## Examples 

Use an example to show the model how to respond. An example includes a prompt paired with a partial completion (zero-shot) or a full completion (one-shot). You can improve several examples with full completions (few-shot). The model uses examples to generalize what to include in completions. 

[Describe a main idea.]

<!-- Required: Main ideas - H2

Use one or more H2 sections to describe the main ideas
of the concept.

Follow each H2 heading with a sentence about how
the section contributes to the whole. Then, describe 
the concept's critical features as you define what it is.

-->

## Related content

- [Prompt engineering techniques](https://learn.microsoft.com/en-us/azure/ai-services/openai/concepts/advanced-prompt-engineering)
- [Related article title](link.md)
- [Related article title](link.md)

<!-- Optional: Related content - H2

Consider including a "Related content" H2 section that 
lists links to 1 to 3 articles the user might find helpful.

-->

<!--

Remove all comments except the customer intent
before you sign off or merge to the main branch.

-->

