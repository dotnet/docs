---
title: "Divide strings using String.Split"
description: The Split method returns an array of strings split from a set of delimiters. It's an easy way to extract substrings from a string.
ms.date: 10/31/2024
helpviewer_keywords:
  - "splitting strings [C#]"
  - "Split method [C#]"
  - "strings [C#], splitting"
  - "parse strings"
ms.assetid: 729c2923-4169-41c6-9c90-ef176c1e2953
ms.custom: mvc, vs-copilot-horizontal
ms.collection: ce-skilling-ai-copilot
---
# How to separate strings using String.Split in C\#

The <xref:System.String.Split%2A?displayProperty=nameWithType> method creates an array of substrings by splitting the input string based on one or more delimiters. This method is often the easiest way to separate a string on word boundaries. It's also used to split strings on other specific characters or strings.

[!INCLUDE[interactive-note](~/includes/csharp-interactive-note.md)]

## String.Split examples

The following code splits a common phrase into an array of strings for each word.

:::code language="csharp" interactive="try-dotnet-method" source="../../../samples/snippets/csharp/how-to/strings/ParseStringsUsingSplit.cs" id="Snippet1":::

Every instance of a separator character produces a value in the returned array. Since arrays in C# are zero-indexed, each string in the array is indexed from 0 to the value returned by the <xref:System.Array.Length%2A?displayProperty=nameWithType> property minus 1:

:::code language="csharp" interactive="try-dotnet-method" source="../../../samples/snippets/csharp/how-to/strings/ParseStringsUsingSplit.cs" id="Snippet1.5":::

Consecutive separator characters produce the empty string as a value in the returned array. You can see how an empty string is created in the following example, which uses the space character as a separator.

:::code language="csharp" interactive="try-dotnet-method" source="../../../samples/snippets/csharp/how-to/strings/ParseStringsUsingSplit.cs" id="Snippet2":::

This behavior makes it easier for formats like comma-separated values (CSV) files representing tabular data. Consecutive commas represent a blank column.

You can pass an optional <xref:System.StringSplitOptions.RemoveEmptyEntries?displayProperty=nameWithType> parameter to exclude any empty strings in the returned array. For more complicated processing of the returned collection, you can use [LINQ](/dotnet/csharp/linq/) to manipulate the result sequence.

<xref:System.String.Split%2A?displayProperty=nameWithType> can use multiple separator characters. The following example uses spaces, commas, periods, colons, and tabs as separating characters, which are passed to <xref:System.String.Split%2A> in an array. The loop at the bottom of the code displays each of the words in the returned array.

:::code language="csharp" interactive="try-dotnet-method" source="../../../samples/snippets/csharp/how-to/strings/ParseStringsUsingSplit.cs" id="Snippet3":::

Consecutive instances of any separator produce the empty string in the output array:

:::code language="csharp" interactive="try-dotnet-method" source="../../../samples/snippets/csharp/how-to/strings/ParseStringsUsingSplit.cs" id="Snippet4":::

<xref:System.String.Split%2A?displayProperty=nameWithType> can take an array of strings (character sequences that act as separators for parsing the target string, instead of single characters).

:::code language="csharp" interactive="try-dotnet-method" source="../../../samples/snippets/csharp/how-to/strings/ParseStringsUsingSplit.cs" id="Snippet5":::

## Use GitHub Copilot to split a string

You can use GitHub Copilot in your IDE to generate code to split strings using `String.Split` in C#.

If you're using [Visual Studio 2022 version 17.8 or later](/visualstudio/releases/2022/release-notes), you can try the AI-driven [GitHub Copilot in Visual Studio](/visualstudio/ide/visual-studio-github-copilot-install-and-states) to generate code to split an input string into substrings based on one or more delimiters. Submit your question as a prompt in the Copilot chat window, as in the following example. You can also submit prompts using [inline chat](/visualstudio/ide/visual-studio-github-copilot-chat#ask-questions-in-the-inline-chat-view) in the editor window itself.

> [!NOTE]
> GitHub Copilot is powered by AI, so surprises and mistakes are possible. Make sure to verify any generated code or suggestions. For more information about the general use of GitHub Copilot, product impact, human oversight, and privacy, see [GitHub Copilot FAQs](https://github.com/features/copilot#faq).

The following text shows an example prompt for Copilot Chat:

> Generate C# code to use Split.String split a string into substrings. Input string is "You win some. You lose some." Delimiters are space and period.  Provide example output.

You can customize the prompt to use strings and delimiters per your requirements.

You can use chat features, such as [slash commands, references to files, methods, or classes, and threads](/visualstudio/ide/copilot-chat-context), to set intent and get better answers with scoped context. For an existing file that's open in the IDE, you can prompt GitHub Copilot using inline chat with `/generate code to split string1 in #Filename by delimiter spaces`.

The following output shows an example Copilot Chat response:

```output
Here is an example of how you can use the Split method in C# to split the string "You win some. You lose some." using space and period as delimiters:

using System;

class Program
{
    static void Main()
    {
        string input = "You win some. You lose some.";
        char[] delimiters = new char[] { ' ', '.' };
        string[] substrings = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        foreach (string substring in substrings)
        {
            Console.WriteLine(substring);
        }
    }
}

**Example Output**
You
win
some
You
lose
some
```

When Copilot returns a code block, the response includes options to copy the code, insert the code into a new file, or preview the code output.

> [!NOTE]
> Your results might be different from what's shown in the example responses. AI models are non-deterministic, which means that they can return different responses when asked the same question. This might be due to additional learning and adaption over time, language variation, changes in context, such as your chat history, and more.

:::image type="content" source="./media/parse-strings-using-split/github-copilot-chat-string-split.png" alt-text="Screenshot that shows using GitHub Copilot Chat in Visual Studio to split a string into substrings." lightbox="./media/parse-strings-using-split/github-copilot-chat-string-split.png":::

For more information, see:

* [GitHub Copilot Trust Center](https://resources.github.com/copilot-trust-center/)
* [GitHub Copilot in Visual Studio](/visualstudio/ide/visual-studio-github-copilot-install-and-states)
* [GitHub Copilot in VS Code](https://code.visualstudio.com/docs/copilot/overview)

## See also

- [Extract elements from a string](../../standard/base-types/divide-up-strings.md)
- [Strings](../programming-guide/strings/index.md)
- [.NET regular expressions](../../standard/base-types/regular-expressions.md)
