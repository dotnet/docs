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

An instruction is text that tells the model how to respond. An instruction can be a directive (**You are helping students learn about US history, so talk about the US unless they specifically ask about other countries.**) or an imperative (**Translate to Tagalog:**). Note that directives are often more efficient and flexible than imperatives. A directive can provide more context, and you can combine several directives in one instruction. It's also easier to implement a series of steps using a sequence of directives. Although it's fine to spell out the steps you want the model to take, you can also just tell the model to break the overall task into steps and follow them, an approach called chain-of-thought prompting.

The Completion API accepts any instructions that you include in an engineered prompt. The Chat Completion API only accepts instructions that you include in a [system message](https://learn.microsoft.com/en-us/azure/ai-services/openai/concepts/advanced-prompt-engineering?pivots=programming-language-chat-completions#system-message).

Sometimes GPT models don't follow an instruction the way you expect because it needs more context. You can add more context an instruction by including primary content, supporting content, and cues. You can include these clarifications when you add an instruction, and can add or adjust them after you test your instruction's effect. Note that instructions and any clarifications you add must be clearly distinct from each other.

 
 
### Primary content

Primary content is text you prepend to an instruction to indicate that the model should use the text as input for the instruction. For example, if you add the instruction **Produce a list of US Presidents' executive accomplishments.**, you could prepend a wiki page as primary content and get a list of accomplishments that are present in that page.   
 
--- Need more about how this works with the Chat Completion API

### Supporting content

Supporting content is text that an instruction uses as input but isn't the subject of the instruction. The instruction must refer to the supporting content. 

Suppose you use the instruction **Produce a list of US Presidents' executive accomplishments** to produce a list. The model might organized and order it in any number of ways. But what if you want the list to group the accomplishments by a specific set of categories? You could adjust your instruction by appending **, grouped in categories** to it, but a model is unlikely to correctly determine which specific categories you want. 

To make sure the model uses the categories you want, you could append supporting content to specify your categories and adjust your instruction accordingly. You could append this line of supporting content below the instruction: **My favorite categories: domestic policy, judicial appointments, trade agreements, space exploration**, and then change the instruction so it refers to the supporting content: **Produce a list of US Presidents' executive accomplishments, grouped by my favorite category**. 

### Cues

A cue is a line of text you include after an instruction to convey the desired structure or format of output. Even though you use cues with instructions, like an example a cue shows the model what you want instead of telling it what to do. You can append as many cues as you want to an instruction, so you can iterate to get the result you want. 

Suppose you use an instruction to tell the model to produce a list of presidential accomplishments by category, along with supporting content that tells the model what categories to use. You decide that you want the model to produce a nested list with all caps for categories, with each president's accomplishments in each category listed on one line that begins with their name. After your instruction and supporting content, you could add the following cues to show the model how to structure and format the list:

**DOMESTIC POLICY**
**- George Washington:** 
**- Thomas Jefferson:**

## Examples 

This section explains the use of examples in .NET prompt engineering.

An example is text that shows the model how to respond. The model uses examples to infer what to include in completions. Like a normal GPT interaction, an example starts with a prompt and ends with a completion. However, an example doesn't have to include a full completion&mdash;sometimes you might just want to include a formatted word, the first bullet in an unordered list, or something similar to indicate how each completion should start.  Examples are often classified by the number of prompt/full completion pairs they contain.

- **Zero-shot learning** examples include a prompt paired with a partial completion. 
- **One-shot learning** examples include a prompt paired with a full completion. 
- **Few-shot learning** examples include several prompt/full completion pairs. 

## Chain-of-thought prompts

--- Add cumulative Zero-shot/one=shot/few-shot prompt example 

## Related content

- [Prompt engineering techniques](https://learn.microsoft.com/en-us/azure/ai-services/openai/concepts/advanced-prompt-engineering)
- [Related article title](link.md)
- [Related article title](link.md)
