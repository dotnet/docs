---
title: "Agents and Copilots Bring Automation and Interactive Assistance to Your App"
description: "Learn how agents and copilots intelligently extend the functionality of LLMs to automatically meet user goals in .NET."
author: catbutler
ms.topic: concept-article #Don't change.
ms.date: 04/15/2024

#customer intent: As a .NET developer, I want to understand how agents and copilots extend the functionality of AI apps, so that my app users can handle any type of content and meet more user goals.

---

# How agents and copilots work with LLMs

Agents and copilots both extend an LLM's capabilities by intelligently invoking external functionality, such as sending an email.

- An *agent* is an artificial intelligence that can answer questions and automate processes for users. Agents can determine which functions will meet a user's goal, and then call those functions on the user's behalf.
- A *copilot* is a type of agent that works side-by-side with a user. Unlike an agent, a copilot isn't fully automated&mdash;it relies on user interaction. A copilot can help a user complete a task by providing suggestions and recommendations.

For example, suppose you're building an email chat helper app. Along with the LLM, you'll also need a plugin to perform email-related actions, as well as plugins for searching, summarizing, determining intent, and the like. You can use [native functions](/semantic-kernel/agents/plugins/using-the-kernelfunction-decorator?tabs=Csharp#creating-your-native-functions), [out-of-the-box plugins](/semantic-kernel/agents/plugins/out-of-the-box-plugins?tabs=Csharp), and your own [custom plugins](/semantic-kernel/agents/plugins/?tabs=Csharp#adding-functions-to-plugins).

Creating the plugins is only half the battle: you still need to invoke the right functions at the right time, a process that can be error-prone and inefficient. An agent can handle it better.

An agent automatically decides what sequence of functions an LLM needs to reach a goal. For example, suppose you have a chat app that reviews new inbox items and determines what action each item requires. If you set up an agent, it can orchestrate the necessary plugin functions and perform the steps automatically.

## Components of an agent

Each agent has three core building blocks: a persona, plugins, and planners.

- [Personas](#personas) determine the manner in which agents respond to users or perform actions.
- [Plugins](#plugins) let agents retrieve information from the user or other systems. You can use pre-built plugins and your own custom plugins.
- [Planners](/semantic-kernel/agents/planners/?tabs=Csharp) let agents plan how to use available plugins.

### Personas

An agent's persona is its identity: any plugins and planners that the agent uses are tools, but the persona determines how it uses those tools. You use [instructions](prompt-engineering-dotnet.md#use-instructions-to-tell-the-model-what-to-do) in a prompt to establish an agent's persona.

For example, you can use instructions to tell an agent that it is helping people manage emails, and to explain its decisions as it makes them. Your prompt might look something like this:

```csharp
prompt = $"""
<message role="system">You are a friendly assistant helping people with emails. When you decide to peform an action, explain your decision and then perform the action.</message>
"""
```

### Plugins

You use [plugins](/semantic-kernel/agents/plugins/?tabs=Csharp) to do things an LLM can't do alone, such as retrieving data from external data sources or completing tasks in the real world.

For example, an LLM can't send an email, so to add that function to a chat app, you'd need to create a plugin. To process text from the emails, you could use [core plugins](/semantic-kernel/agents/plugins/out-of-the-box-plugins?tabs=Csharp#core-plugins), such as the [ConversationSummaryPlugin](/dotnet/api/microsoft.semantickernel.plugins.core.conversationsummaryplugin?view=semantic-kernel-dotnet).

Make sure you clearly document the functions in your plugins&mdash;planners use this information to determine what functions are available.

### Planners

A [planner](/semantic-kernel/agents/planners/?tabs=Csharp) can analyze available functions and come up with alternate ways to reach the goal.

Calling plugin functions isn't always efficient. For example, say you want to sum the numbers between 1 and 100. You could call a math plugin, but the LLM would need to make a separate call for each number.

Moreover, the best sequence and combination of functions to reach a goal depends on the details. For example, suppose you're building an email chat helper app, so you include a plugin to enable sending emails. However, some emails might need a different action, such as a meeting request without RSVP&mdash;sending a reply isn't necessary, but adding a calendar item is. A planner looks at all available functions and comes up with efficient ways to reach goals.

## Copilots add user interaction

Process automation has many benefits, but sometimes the user needs to make decisions along the way. An agent can't automate user actions. That's where copilots come in.

An agent in your email chat app might produce the following plan for sending an email:

1. Get the user's email address and name
1. Get the email address of the recipient
1. Get the topic of the email
1. Generate the subject and body of the email
1. Send the email

Very handy, but what if the user doesn't like the email body? A copilot adds a user interaction step to the plan:

1. Get the user's email address and name
1. Get the email address of the recipient
1. Get the topic of the email
1. Generate the subject and body of the email
1. **Review the email with the user and make adjustments**
1. Send the email

### Semantic Kernel Chat Copilot app

To get started with copilots, try the [Semantic Kernel Chat Copilot](/semantic-kernel/chat-copilot/), a reference application for building a chat experience with an AI agent.

## Related content

- [Develop AI agents using Azure OpenAI and the Semantic Kernel SDK](/training/paths/develop-ai-agents-azure-open-ai-semantic-kernel-sdk/)
