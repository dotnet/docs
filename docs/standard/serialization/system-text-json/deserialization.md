---
title: "How to deserialize JSON in C#"
description: "Learn how to use the System.Text.Json namespace to deserialize from JSON in .NET. Includes sample code."
ms.date: 10/19/2023
no-loc: [System.Text.Json, Newtonsoft.Json]
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "JSON deserialization"
  - "deserializing objects"
  - "deserialization"
ms.topic: concept-article
ms.collection: ce-skilling-ai-copilot
ms.custom: vs-copilot-horizontal
#customer intent: As a developer, I want to learn how to use System.Text.Json to deserialize JSON data.
---

# How to read JSON as .NET objects (deserialize)

This article shows how to use the <xref:System.Text.Json?displayProperty=fullName> namespace to deserialize from JavaScript Object Notation (JSON). If you're porting existing code from `Newtonsoft.Json`, see [How to migrate to `System.Text.Json`](migrate-from-newtonsoft.md).

A common way to deserialize JSON is to have (or create) a .NET class with properties and fields that represent one or more of the JSON properties. Then, to deserialize from a string or a file, call the <xref:System.Text.Json.JsonSerializer.Deserialize%2A?displayProperty=nameWithType> method. For the generic overloads, the generic type parameter is the .NET class. For the non-generic overloads, you pass the type of the class as a method parameter. You can deserialize either synchronously or asynchronously.

> [!TIP]
> You can use AI assistance to [deserialize a JSON string with GitHub Copilot](#use-github-copilot-to-deserialize-json).

Any JSON properties that aren't represented in your class are ignored [by default](missing-members.md). Also, if any properties on the type are [required](required-properties.md) but not present in the JSON payload, deserialization will fail.

## Examples

The following example shows how to deserialize a JSON string:

:::code language="csharp" source="snippets/how-to/csharp/DeserializeExtra.cs" highlight="54-55":::
:::code language="vb" source="snippets/how-to/vb/RoundtripToString.vb" id="Deserialize":::

To deserialize from a file by using synchronous code, read the file into a string, as shown in the following example:

:::code language="csharp" source="snippets/how-to/csharp/DeserializeFromFile.cs" highlight="16-18":::
:::code language="vb" source="snippets/how-to/vb/RoundtripToFile.vb" id="Deserialize":::

To deserialize from a file by using asynchronous code, call the <xref:System.Text.Json.JsonSerializer.DeserializeAsync%2A> method:

:::code language="csharp" source="snippets/how-to/csharp/DeserializeFromFileAsync.cs" highlight="17-20":::
:::code language="vb" source="snippets/how-to/vb/RoundtripToFileAsync.vb" id="Deserialize":::

## Deserialization behavior

The following behaviors apply when deserializing JSON:

* By default, property name matching is case-sensitive. You can [specify case-insensitivity](character-casing.md).
* Non-public constructors are ignored by the serializer.
* Deserialization to immutable objects or properties that don't have public `set` accessors is supported but not enabled by default. See [Immutable types and records](immutability.md).
* By default, enums are supported as numbers. You can [deserialize string enum fields](customize-properties.md#enums-as-strings).
* By default, fields are ignored. You can [include fields](fields.md).
* By default, comments or trailing commas in the JSON throw exceptions. You can [allow comments and trailing commas](invalid-json.md).
* The [default maximum depth](xref:System.Text.Json.JsonReaderOptions.MaxDepth) is 64.

When you use System.Text.Json indirectly in an ASP.NET Core app, some default behaviors are different. For more information, see [Web defaults for JsonSerializerOptions](configure-options.md#web-defaults-for-jsonserializeroptions).

You can [implement custom converters](converters-how-to.md) to provide functionality that isn't supported by the built-in converters.

## Deserialize without a .NET class

If you have JSON that you want to deserialize, and you don't have the class to deserialize it into, you have options other than manually creating the class that you need:

* Use the [Utf8JsonReader](use-utf8jsonreader.md) directly.

* Deserialize into a [JSON DOM (document object model)](use-dom.md) and extract what you need from the DOM.

  The DOM lets you navigate to a subsection of a JSON payload and deserialize a single value, a custom type, or an array. For information about the <xref:System.Text.Json.Nodes.JsonNode> DOM, see [Deserialize subsections of a JSON payload](use-dom.md#deserialize-subsections-of-a-json-payload). For information about the <xref:System.Text.Json.JsonDocument> DOM, see [How to search a JsonDocument and JsonElement for sub-elements](migrate-from-newtonsoft.md#how-to-search-a-jsondocument-and-jsonelement-for-sub-elements).

* Use Visual Studio 2022 to automatically generate the class you need:

  * Copy the JSON that you need to deserialize.
  * Create a class file and delete the template code.
  * Choose **Edit** > **Paste Special** > **Paste JSON as Classes**.

  The result is a class that you can use for your deserialization target.

## Deserialize from UTF-8

To deserialize from UTF-8, call a <xref:System.Text.Json.JsonSerializer.Deserialize%2A?displayProperty=nameWithType> overload that takes a `ReadOnlySpan<byte>` or a `Utf8JsonReader`, as shown in the following examples. The examples assume the JSON is in a byte array named jsonUtf8Bytes.

:::code language="csharp" source="snippets/how-to/csharp/RoundtripToUtf8.cs" id="Deserialize1":::
:::code language="vb" source="snippets/how-to/vb/RoundtripToUtf8.vb" id="Deserialize1":::

:::code language="csharp" source="snippets/how-to/csharp/RoundtripToUtf8.cs" id="Deserialize2":::
:::code language="vb" source="snippets/how-to/vb/RoundtripToUtf8.vb" id="Deserialize2":::

## Use GitHub Copilot to deserialize JSON

You can use GitHub Copilot in your IDE to generate code that uses `System.Text.Json` to deserialize from JSON.

If you're using [Visual Studio 2022 version 17.8 or later](/visualstudio/releases/2022/release-notes), you can try the AI-driven [GitHub Copilot in Visual Studio](/visualstudio/ide/visual-studio-github-copilot-install-and-states) to generate code that uses `System.Text.Json` to deserialize JSON. Submit your question as a prompt in the Copilot chat window, as in the following example. You can also submit prompts using [inline chat](/visualstudio/ide/visual-studio-github-copilot-chat#ask-questions-in-the-inline-chat-view) in the editor window itself.

> [!NOTE]
> GitHub Copilot is powered by AI, so surprises and mistakes are possible. Make sure to verify any generated code or suggestions. For more information about the general use of GitHub Copilot, product impact, human oversight, and privacy, see [GitHub Copilot FAQs](https://github.com/features/copilot#faq).

The following text shows an example prompt for Copilot Chat:

> Generate code to use `System.Text.Json` to deserialize a JSON string {"FirstName":"John","LastName":"Doe","Age":30} to an equivalent .NET object. Map property names & values. Provide example output.

You can customize the prompt to use a JSON string with property names and values that suit your requirements.

You can use chat features, such as [slash commands, references to files, methods, or classes, and threads](/visualstudio/ide/copilot-chat-context), to set intent and get better answers with scoped context. For an existing class in a project that's open in the IDE, you can prompt GitHub Copilot with `/generate code to dserialize JSON to equivalent .NET object in #Filename`.

The following output shows an example Copilot Chat response:

```output
Here's an example of how you can use `System.Text.Json` to deserialize a JSON string into a .NET object in C#:

using System;
using System.Text.Json;
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}
public class Program
{
    public static void Main()
    {
        string jsonString = "{\"FirstName\":\"John\",\"LastName\":\"Doe\",\"Age\":30}";
        Person person = JsonSerializer.Deserialize<Person>(jsonString);
        Console.WriteLine($"FirstName: {person.FirstName}");
        Console.WriteLine($"LastName: {person.LastName}");
        Console.WriteLine($"Age: {person.Age}");
    }
}

**Example Output**
FirstName: John
LastName: Doe
Age: 30

This code defines a Person class with properties that match the JSON string. It then uses `JsonSerializer.Deserialize` to convert the JSON string into a `Person` object and prints the properties to the console.
```

When Copilot returns a code block, the response includes options to copy the code, insert the code into a new file, or preview the code output.

> [!NOTE]
> Your results might be different from what's shown in the example responses. AI models are non-deterministic, which means that they can return different responses when asked the same question. This might be due to additional learning and adaption over time, language variation, changes in context, such as your chat history, and more.

:::image type="content" source="./media/deserialize-json-using-github-copilot.gif" alt-text="Animated screenshot that shows using GitHub Copilot Chat in Visual Studio to deserialize a JSON string to a .NET object." lightbox="./media/deserialize-json-using-github-copilot.gif":::

For more information, see:

* [GitHub Copilot Trust Center](https://resources.github.com/copilot-trust-center/)
* [GitHub Copilot in Visual Studio](/visualstudio/ide/visual-studio-github-copilot-install-and-states)
* [GitHub Copilot in VS Code](https://code.visualstudio.com/docs/copilot/overview)
