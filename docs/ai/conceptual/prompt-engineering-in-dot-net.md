---
title: "Prompt Engineering"
description: "Learn basic prompt engineering concepts for .NET."
author: catbutler
ms.topic: concept-article #Don't change.
ms.date: 04/10/2024

#customer intent: As a .NET developer, I want to understand prompt engineering techniques for .NET so that I can build more efficient and targeted AI apps.

---

# Prompt engineering in .NET

This article covers GPT prompt engineering for .NET, including Semantic Kernel and Azure OpenAI.

GPT models from OpenAI are prompt-based: they respond to user input text (a prompt) with the most likely series of words to follow (a completion). The completion format in earlier GPT models is text generated in response to a prompt, producing a more free-form interaction. Newer GPT models produce a chat completion in message form, with messages based on roles (system, user, assistant) and chat history to preserve conversations.

Consider this text generation example where *prompt* is the user input and *completion* is the model output:

Prompt:
**"The president who served the shortest term was "**

Completion:
_"Pedro Lascurain."_

Looks right, but what if your app is supposed to help US History students? Pedro Lascurain's 45-minute term is the shortest term for any president, but he served Mexico&mdash;the students are probably looking for _"William Henry Harrsion."_ Clearly, the app could be more helpful to its intended users if you gave it some context.

That's the basic idea of prompt engineering: you add context to the prompt to help the model produce better completions. You can do this by giving the model [*instructions*](#use-instructions-to-tell-the-model-what-to-do), [*examples*](#examples-show-the-model-what-to-do) and [*cues*](#cues).

GPT models that support text generation don't require any specific format, but you should organize your prompts so it's clear what's an instruction and what's an example. GPT models that support chat-based apps use three roles to organize completions: a system role that controls the chat, a user role to represent user input, and an assistant role for responding to users. You divide your prompts into messages for each role:

- [System messages](/azure/ai-services/openai/concepts/advanced-prompt-engineering?pivots=programming-language-chat-completions#system-message) give the model instructions about the assistant. A prompt can have only one system message, and it must be the first message.
- User messages show example or historical prompts, or contain instructions for the assistant. An example chat completion must have at least one user message.
- Assistant messages show example or historical completions, and must contain a response to the preceding user message. Assistant messages aren't required, but if you include one it must be paired with a user message to form an example.

> [!NOTE]
> In Semantic Kernel, you can help keep your prompts flexible and lean by [using variables for input parameters](/semantic-kernel/prompts/templatizing-prompts?tabs=Csharp#adding-variables-to-the-prompt) and [calling nested functions](/semantic-kernel/prompts/calling-nested-functions?tabs=Csharp#calling-a-nested-function).

## Use Instructions to tell the model what to do

This section explains the use of instructions in prompt engineering.

An instruction is text that tells the model how to respond. An instruction can be a directive or an imperative:

- _Directives_ tell the model how to behave, but aren't simple commands&mdash;think character setup for an improv actor:  **"You are helping students learn about U.S. history, so talk about the U.S. unless they specifically ask about other countries."**
- _Imperatives_ are unambiguous commands for the model to follow. **"Translate to Tagalog:"**

Because they are open-ended, directives are more flexible than imperatives:

- You can combine several directives in one instruction.
- Instructions usually work better when you use them with examples. However, because imperatives are unambiguous commands, models don't need examples to understand them (though you might use an example to show the model how to format responses). Because a directive doesn't tell the model exactly what to do, each example can help the model work better.
- It's usually better to break down a difficult instruction into a series of steps, which you can do with a sequence of directives. You should also tell the model to output the result of each step, so that you can easily make granular adjustments. Although you can break down the instruction into steps yourself, it's easier to just tell the model to do it, and to output the result of each step. This approach is called *chain of thought prompting*.

### Primary content and supporting content add context to instructions

You can add content to add more context to instructions.

*Primary content* is text that you want the model to process with an instruction. Whatever action the instruction entails, the model will perform it on the primary content to produce a completion.

*Supporting content* is text that you refer to in an instruction, but which isn't the target of the instruction. The model uses the supporting content to complete the instruction, which means that supporting content also appears in completions, typically as some kind of structure (such as in headings or column labels).

Use labels with your instructional content to help the model figure out how to use it with the instruction. Don't worry too much about precision&mdash;labels don't have to match instructions exactly because the model will handle things like word form and capitalization.

Suppose you use the instruction **"Summarize US Presidential accomplishments"** to produce a list. The model might organize and order it in any number of ways. But what if you want the list to group the accomplishments by a specific set of categories? You can adjust your instruction by appending **"&nbsp;grouped by category"** to it, but a model won't know which specific categories you want. Use supporting content to add that information to the instruction.

Adjust your instruction so the model will group by category, and append supporting content that specifies those categories:

```csharp
prompt = """
Instructions: Summarize US Presidential accomplishments, grouped by category.
Categories: Domestic Policy, US Economy, Foreign Affairs, Space Exploration.
Accomplishments: 'George Washington
- First president of the United States.
- First president to have been a military veteran.
- First president to be elected to a second term in office.
- Received votes from every presidential elector in an election.
- Filled the entire body of the United States federal judges; including the Supreme Court.
- First president to be declared an honorary citizen of a foreign country, and an honorary citizen of France.
John Adams ...' ///Text truncated
""";
```

## Examples show the model what to do

This section explains the use of examples in .NET prompt engineering.

An example is text that shows the model how to respond by providing sample user input and model output. The model uses examples to infer what to include in completions. Examples can come either before or after the instructions in an engineered prompt, but the two shouldn't be interspersed.

Like a normal GPT interaction, an example starts with a prompt. The example can include a completion but it's not required. A completion in an example doesn't have to include the verbatim response&mdash;it might just contain a formatted word, the first bullet in an unordered list, or something similar to indicate how each completion should start.  

Examples are classified as *zero-shot learning* or *few-shot learning* based on whether they contain verbatim completions.

- **Zero-shot learning** examples include a prompt with no verbatim completion. Because they don't include verbatim completions, zero-shot prompts test a model's responses without giving it example data output. (Zero-shot prompts can have  completions that include cues, such as indicating the model should output an ordered list by including **"1."** as the completion.)
- **Few-shot learning** examples include several pairs of prompts with verbatim completions. Few-shot learning can change the model's behavior by adding to its existing knowledge.

## Cues

A cue is text that conveys the desired structure or format of output. Like an instruction, a cue isn't processed by the model as if it were user input. Like an example, a cue shows the model what you want instead of telling it what to do. You can add as many cues as you want, so you can iterate to get the result you want. Cues are used with an instruction or an example and should be at the end of the prompt.

Suppose you use an instruction to tell the model to produce a list of presidential accomplishments by category, along with supporting content that tells the model what categories to use. You decide that you want the model to produce a nested list with all caps for categories, with each president's accomplishments in each category listed on one line that begins with their name, with presidents listed chronologically. After your instruction and supporting content, you could add three cues to show the model how to structure and format the list:

```csharp
prompt = """
Instructions: Summarize US Presidential accomplishments, grouped by category.
Categories: Domestic Policy, US Economy, Foreign Affairs, Space Exploration.
Accomplishments: George Washington
First president of the United States.
First president to have been a military veteran.
First president to be elected to a second term in office.
First president to receive votes from every presidential elector in an election.
First president to fill the entire body of the United States federal judges; including the Supreme Court.
First president to be declared an honorary citizen of a foreign country, and an honorary citizen of France.
John Adams ...  /// Text truncated

DOMESTIC POLICY
- George Washington: 
- John Adams:
""";
```

- **DOMESTIC POLICY** shows the model that you want it to start each group with the category in all caps.
- **- George Washington:** shows the model to start each section with George Washington's accomplishments listed on one line.
- **- John Adams:** shows the model that it should list remaining presidents in chronological order.

## .NET implementations

This section compares two .NET options for prompt engineering: [Semantic Kernel](/semantic-kernel/overview/) and [Azure OpenAI](/azure/ai-services/openai/overview).

### Semantic Kernel

Semantic Kernel is an SDK that integrates Large Language Models (LLMs) with conventional programming languages such as C#, Python, and Java. Semantic Kernel lets you define plugins and easily chain them together in just a few lines of code. You can use [Semantic Kernel planners](/semantic-kernel/agents/planners/?tabs=Csharp) to automatically orchestrate plugins, which lets you ask an LLM to generate a plan that Semantic Kernel can execute to achieve a user's unique goal.

By deeply integrating with Visual Studio Code, Semantic Kernel also makes it easy for you to integrate [prompt engineering](/semantic-kernel/prompts/your-first-prompt?tabs=Csharp) into your existing development processes:

- Create prompts directly in your preferred code editor.
- Write tests for your prompts using your existing testing frameworks.
- Deploy your prompts to production using your existing CI/CD pipelines.

Semantic Kernel Completions use GPT-3 and GPT-3.5 models, which have no specific format rules for prompts. The preceding sections all contain examples of Semantic Kernel Completions.

Semantic Kernel Chat Completions use GPT-35-Turbo and GPT-4 models, which use a specific chat-like format consisting of role-based messages as shown in the following example.

```csharp
prompt = """
<message role=""system"">
    You are helping students with US History homework. Answers should not be about other countries except in relation to the US. Provide some supporting information for answers. Format any summaries using lists.
</message>
<message role=""user"">
    Which president had the shortest term?
<message/>
<message role=""assistant"">
    William Henry Harrison died just 31 days after his inauguration as president in 1841, making his presidency the shortest in U.S. history.
<message/>
<message role=""user"">
    Instructions: Summarize US Presidential accomplishments, grouped by category. Categories: Domestic Policy, US Economy, Foreign Affairs, Space Exploration, Other.
</message>
""";
```

### Azure OpenAI

Azure OpenAI is a managed service that allows developers to deploy, tune, and generate content from OpenAI models on Azure resources. Azure OpenAI's client library for .NET is an adaptation of OpenAI's REST APIs that provides an idiomatic interface and rich integration with the rest of the Azure SDK ecosystem. It can connect to Azure OpenAI resources or to the non-Azure OpenAI inference endpoint, making it suitable for non-Azure OpenAI development.

Use the client library for Azure OpenAI to:

- Implement text completions via the [Completion API](/azure/ai-services/openai/concepts/advanced-prompt-engineering?pivots=programming-language-completions).
- Implement chat-based completions via the [Chat Completion API](/azure/ai-services/openai/concepts/advanced-prompt-engineering?pivots=programming-language-chat-completions).

Azure OpenAI Completions use GPT-3 and GPT-35 models, which have no specific format rules for prompts.

```csharp
Prompts =
{
    "Summarize US Presidential accomplishments, grouped by category.",
    "Categories: domestic policy, judicial appointments, trade agreements, space exploration", 
}
```

Azure OpenAI Chat Completions use GPT-35-Turbo and GPT-4 models, which use a specific chat-like format consisting of role-based messages.

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

## Extending the reach of your prompt engineering techniques

You can also increase the power of your prompts with two more advanced prompt engineering techniques that are covered in depth in their own articles.

- LLMs have token input limits that constrain the amount of text you can fit in a prompt. You can use *embeddings* and *vector database solutions* to reduce the number of tokens you need to represent a given piece of text.
- LLMs aren't trained on your data unless you train them yourself, which can be costly and time-consuming. You can use *retrieval-augmented generation* to make your data available to an LLM without training it.

## Related content

- [Prompt engineering techniques](/azure/ai-services/openai/concepts/advanced-prompt-engineering)
- [Configure prompts in Semantic Kernel](/semantic-kernel/prompts/configure-prompts?tabs=Csharp)
