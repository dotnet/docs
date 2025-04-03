---
title: "How to concatenate multiple strings"
description: There are multiple ways to concatenate strings in C#. Learn the options and the reasons behind different choices.
ms.date: 02/18/2025
helpviewer_keywords: 
  - "joining strings [C#]"
  - "concatenating strings [C#]"
  - "strings [C#], concatenation"
ms.custom: copilot-scenario-highlight
---
# How to concatenate multiple strings (C# Guide)

*Concatenation* is the process of appending one string to the end of another string. You concatenate strings by using the `+` operator. For string literals and string constants, concatenation occurs at compile time; no run-time concatenation occurs. For string variables, concatenation occurs only at run time.

[!INCLUDE[interactive-note](~/includes/csharp-interactive-note.md)]

> [!TIP]
> You can use AI assistance to [concatenate strings with GitHub Copilot](#use-github-copilot-to-concatenate-strings).

## String literals

The following example splits a long string literal into smaller strings to improve readability in the source code. The code concatenates the smaller strings to create the long string literal. The parts are concatenated into a single string at compile time. There's no run-time performance cost regardless of the number of strings involved.

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/Concatenate.cs" id="Snippet1":::

## `+` and `+=` operators

To concatenate string variables, you can use the `+` or `+=` operators, [string interpolation](../language-reference/tokens/interpolated.md) or the <xref:System.String.Format%2A?displayProperty=nameWithType>, <xref:System.String.Concat%2A?displayProperty=nameWithType>, <xref:System.String.Join%2A?displayProperty=nameWithType> or <xref:System.Text.StringBuilder.Append%2A?displayProperty=nameWithType> methods. The `+` operator is easy to use and makes for intuitive code. Even if you use several `+` operators in one statement, the string content is copied only once. The following code shows examples of using the `+` and `+=` operators to concatenate strings:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/Concatenate.cs" id="Snippet2":::

## String interpolation

In some expressions, it's easier to concatenate strings using string interpolation, as the following code shows:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/Concatenate.cs" id="Snippet3":::

> [!NOTE]
> In string concatenation operations, the C# compiler treats a null string the same as an empty string.

You can use string interpolation to initialize a constant string when all the expressions used for placeholders are also constant strings.

## `String.Format`

Another method to concatenate strings is <xref:System.String.Format%2A?displayProperty=nameWithType>. This method works well when you're building a string from a few component strings.

## `StringBuilder`

In other cases, you might be combining strings in a loop where the actual number of source strings can be large. The <xref:System.Text.StringBuilder> class was designed for these scenarios. The following code uses the <xref:System.Text.StringBuilder.Append%2A> method of the <xref:System.Text.StringBuilder> class to concatenate strings.

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/Concatenate.cs" id="Snippet4":::

You can read more about the [reasons to choose string concatenation or the `StringBuilder` class](/dotnet/api/system.text.stringbuilder#the-string-and-stringbuilder-types).

## `String.Concat` or `String.Join`

Another option to join strings from a collection is to use <xref:System.String.Concat%2A?displayProperty=nameWithType> method. Use <xref:System.String.Join%2A?displayProperty=nameWithType> method if a delimiter should separate source strings. The following code combines an array of words using both methods:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/Concatenate.cs" id="Snippet5":::

## LINQ and `Enumerable.Aggregate`

At last, you can use [LINQ](../linq/index.md)
and the <xref:System.Linq.Enumerable.Aggregate%2A?displayProperty=nameWithType> method to join strings from a collection. This method combines
the source strings using a lambda expression. The lambda expression does the
work to add each string to the existing accumulation. The following example
combines an array of words, adding a space between each word in the array:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/strings/Concatenate.cs" id="Snippet6":::

This option can cause more allocations than other methods for concatenating collections, as it creates an intermediate string for each iteration. If optimizing performance is critical, consider the [`StringBuilder`](#stringbuilder) class or the [`String.Concat` or `String.Join`](#stringconcat-or-stringjoin) method to concatenate a collection, instead of `Enumerable.Aggregate`.

## Use GitHub Copilot to concatenate strings

You can use GitHub Copilot in your IDE to generate C# code to concatenate multiple strings. You can customize the prompt to specify strings and the method to use per your requirements.

The following text shows an example prompt for Copilot Chat:

```copilot-prompt
Generate C# code to use String.Format to build an output string "Hi x, today's date is y. You are z years old." where x is "John",  y is today's date and z is the birthdate January 1, 2000. The final string should show date in the full format mm/dd/yyyy. Show output.
```

GitHub Copilot is powered by AI, so surprises and mistakes are possible. For more information, see [Copilot FAQs](https://aka.ms/copilot-general-use-faqs).

Learn more about [GitHub Copilot in Visual Studio](/visualstudio/ide/visual-studio-github-copilot-install-and-states) and [GitHub Copilot in VS Code](https://code.visualstudio.com/docs/copilot/overview).

## See also

- <xref:System.String>
- <xref:System.Text.StringBuilder>
- [Strings](../programming-guide/strings/index.md)
