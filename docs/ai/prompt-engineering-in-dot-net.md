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

This article covers basic GPT prompt engineering for .NET, including Semantic Kernel and Azure OpenAI. 

GPT models from OpenAI are prompt-based: they respond to user input text (a prompt) with the most likely series of words to follow (a completion). The basic completion in earlier GPT models is text generated in response to prompts. Newer GPT models produce completions in chat format. 

Consider this text generation example:
 
```Prompt
"The president who served the shortest term was "
```

```Completion
"Pedro Lascurain." 
```

Looks right, but what if your app is supposed to help US History students? Pedro Lascurain's 45-minute term is the shortest term for any president, but he served Mexico&mdash;the students are probably looking for "William Henry Harrsion." Clearly, the app could be more helpful to its intended users if you gave it some context. 

That's the basic idea of prompt engineering: you add context to the prompt to help the model produce better completions. You can do this by giving the model instructions and examples.

## Instructions

This section explains the use of instructions in prompt engineering. 

An instruction is text that tells the model how to respond. An instruction can be a directive (**You are helping students learn about US history, so talk about the US unless they specifically ask about other countries.**) or an imperative (**Translate to Tagalog:**). 

Directives are more flexible than imperatives. 
- A directive can provide more context, and you can combine several directives in one instruction. 
- It's easier to implement a series of steps using a sequence of directives. You can spell out the steps that you want the model to take, but you can also just tell the model to break it into steps and then follow them, an approach called [chain of thought prompting](chain-of-thought-prompting.md).

Sometimes GPT models don't follow an instruction the way you expect because it doesn't provide enough context. You can add more context to an instruction by including primary content, supporting content, and cues. You can include these when you add an instruction, and can add or adjust them after you test your instruction's effect.

Instructions are typically more effective when used with examples. However, when you use both in a prompt you should make sure that the instructions are either above or below the examples for best model performance.

The Completion API accepts any instructions that you include in a prompt. The Chat Completion API only accepts instructions in a [system message](https://learn.microsoft.com/en-us/azure/ai-services/openai/concepts/advanced-prompt-engineering?pivots=programming-language-chat-completions#system-message) or a user message.
 
### Primary content

Primary content is text you add to an instruction for the model to use as input for the instruction. For example, if you add the instruction **Summarize US Presidential accomplishments.**, you could add a list of accomplishments as primary content. 

Make sure you clearly separate primary content from the instructions that apply to it, such as by labeling it.   

```csharp
prompt= @$"Instructions: Summarize US Presidential accomplishments.
Accomplishments: 'George Washington
First president of the United States.
First president to have been a military veteran.
First president to be elected to a second term in office.
First president to receive votes from every presidential elector in an election.
First president to fill the entire body of the United States federal judges; including the Supreme Court.
First president to be declared an honorary citizen of a foreign country, and an honorary citizen of France.
John Adams ...'" //Text truncated;
```

### Supporting content

Supporting content is text that an instruction uses as input but isn't the subject of the instruction. The instruction must refer to the supporting content. 

Suppose you use the instruction **Summarize US Presidential accomplishments** to produce a list. The model might organized and order it in any number of ways. But what if you want the list to group the accomplishments by a specific set of categories? You could adjust your instruction by appending **&nbsp;grouped by category** to it, but a model is unlikely to correctly determine which specific categories you want. 

To make sure the model uses the categories you want, you could append supporting content to specify your categories and adjust your instruction accordingly. You could add a line of supporting content below the instruction and then change the instruction so it refers to the supporting content: 

```csharp
prompt = @$"Instructions: Summarize US Presidential accomplishments, grouped by category.
Categories: Domestic Policy, US Economy, Foreign Affairs, Space Exploration.
Accomplishments: George Washington
First president of the United States.
First president to have been a military veteran.
First president to be elected to a second term in office.
First president to receive votes from every presidential elector in an election.
First president to fill the entire body of the United States federal judges; including the Supreme Court.
First president to be declared an honorary citizen of a foreign country, and an honorary citizen of France.
John Adams ..."; //Text truncated
```

As with primary content, supporting content should be clearly distinct from the instruction it supports.

### Cues

A cue is a line of text you include after an instruction to convey the desired structure or format of output. Even though you use cues with instructions, like an example a cue shows the model what you want instead of telling it what to do. You can append as many cues as you want to an instruction, so you can iterate to get the result you want. 

Suppose you use an instruction to tell the model to produce a list of presidential accomplishments by category, along with supporting content that tells the model what categories to use. You decide that you want the model to produce a nested list with all caps for categories, with each president's accomplishments in each category listed on one line that begins with their name. After your instruction and supporting content, you could add the following cues to show the model how to structure and format the list:

```csharp
prompt = @$"Instructions: Summarize US Presidential accomplishments, grouped by category.
Categories: Domestic Policy, US Economy, Foreign Affairs, Space Exploration.
Accomplishments: George Washington
First president of the United States.
First president to have been a military veteran.
First president to be elected to a second term in office.
First president to receive votes from every presidential elector in an election.
First president to fill the entire body of the United States federal judges; including the Supreme Court.
First president to be declared an honorary citizen of a foreign country, and an honorary citizen of France.
John Adams ... //Text truncated

DOMESTIC POLICY
- George Washington: 
- Thomas Jefferson:";
```

## Examples 

This section explains the use of examples in .NET prompt engineering.

An example is text that shows the model how to respond. The model uses examples to infer what to include in completions. Examples can come either before or after the instructions in an engineered prompt, but the two shouldn't be interspersed. 

Like a normal GPT interaction, an example starts with a prompt. The example can include a completion but it's not required. A completion in an example doesn't have to include the verbatim response&mdash;it might just include a formatted word, the first bullet in an unordered list, or something similar to indicate how each completion should start.  

Examples are often classified as zero-shot or few-shot based on whether they contain verbatim completions.

- **Zero-shot learning** examples include a prompt with no verbatim completion. Because they don't include verbatim completions, zero-shot prompts test a model's responses without giving it any example output. Zero-shot prompts can have  completions that convey structure or formatting, such as indicating an ordered list structure by including **1.** as the completion. 
- **Few-shot learning** examples include several pairs of prompts with verbatim completions.Few-shot learning can change the model's behavior by adding to its existing knowledge.

## .NET implementations

This section compares two .NET options for prompt engineering: Semantic Kernel and Azure OpenAI. 

### Semantic Kernel

Semantic Kernel allows you to experiment with different prompts and parameters across multiple different models using a common interface. You can quickly compare the outputs of different models and parameters, and iterate on prompts to achieve the desired results.

By deeply integrating with Visual Studio Code, Semantic Kernel also makes it easy for you to integrate prompt engineering into your existing development processes:
- Create prompts directly in your preferred code editor.
- Write tests for your prompts using your existing testing frameworks.
- Deploy your prompts to production using your existing CI/CD pipelines. 

### Azure OpenAI

Azure OpenAI is a managed service that allows developers to deploy, tune, and generate content from OpenAI models on Azure resources. Azure OpenAI's client library for .NET is an adaptation of OpenAI's REST APIs that provides an idiomatic interface and rich integration with the rest of the Azure SDK ecosystem. It can connect to Azure OpenAI resources or to the non-Azure OpenAI inference endpoint, making it suitable for non-Azure OpenAI development.

Use the client library for Azure OpenAI to:
- Provide simple text completions via the Completion API.
- Provide chat-style completions via the Chat Completion API.

The Completion API and the Chat Completion API target different GPT models with different implementations of prompt engineering. The following examples show the same engineered prompt in each API. 

The Completion API targets the GPT-3 and GPT-35 models, which have no specific format rules for prompt engineering. 

```csharp
Prompts = 
    { 
        "Summarize US Presidential accomplishments, grouped by category.",
        "Categories: domestic policy, judicial appointments, trade agreements, space exploration", 
    }
```

The Chat Completion API targets the GPT-35-Turbo and GPT-4 models, which use a specific chat-like format consisting of role-based messages. 

```csharp
Messages =
    {
        // The system message represents instructions or other guidance about how the assistant should behave
        new ChatRequestSystemMessage("You are helping students of US History with their homework. Be cheerful about it."),
        // User messages represent current or historical input from the end user
        new ChatRequestUserMessage("I need help with my homework."),
        // Assistant messages represent historical responses from the assistant
        new ChatRequestAssistantMessage("Of course! That's what I'm here for. How can I help?"),
        new ChatRequestUserMessage("Summarize US Presidential accomplishments, grouped by category.\\n Categories: domestic policy, judicial appointments, trade agreements, space exploration"),
    }
```

## Related content

- [Prompt engineering techniques](https://learn.microsoft.com/en-us/azure/ai-services/openai/concepts/advanced-prompt-engineering)
- [Zero-shot and few-shot learning](zero-shot-learning.md)
- [Configure prompts in Semantic Kernel](https://learn.microsoft.com/en-us/semantic-kernel/prompts/configure-prompts?tabs=Csharp)
