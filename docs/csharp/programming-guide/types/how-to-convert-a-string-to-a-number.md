---
title: "How to convert a string to a number"
description: Learn how to convert a string to a number in C# by calling the Parse, TryParse, or Convert class methods.
ms.date: 10/31/2024
helpviewer_keywords: 
  - "conversions [C#]"
  - "conversions [C#], string to int"
  - "converting strings to int [C#]"
  - "strings [C#], converting to int"
ms.topic: how-to
ms.custom: copilot-scenario-highlight
ms.assetid: 467b9979-86ee-4afd-b734-30299cda91e3
adobe-target: true
---
# How to convert a string to a number (C# Programming Guide)

You convert a `string` to a number by calling the `Parse` or `TryParse` method found on numeric types (`int`, `long`, `double`, and so on), or by using methods in the <xref:System.Convert?displayProperty=nameWithType> class.
  
It's slightly more efficient and straightforward to call a `TryParse` method (for example, [`int.TryParse("11", out number)`](xref:System.Int32.TryParse%2A)) or `Parse` method (for example, [`var number = int.Parse("11")`](xref:System.Int32.Parse%2A)). Using a <xref:System.Convert> method is more useful for general objects that implement <xref:System.IConvertible>.
  
You use `Parse` or `TryParse` methods on the numeric type you expect the string contains, such as the <xref:System.Int32?displayProperty=nameWithType> type. The <xref:System.Convert.ToInt32%2A?displayProperty=nameWithType> method uses <xref:System.Int32.Parse%2A> internally. The `Parse` method returns the converted number; the `TryParse` method returns a boolean value that indicates whether the conversion succeeded, and returns the converted number in an `out` parameter. If the string isn't in a valid format, `Parse` throws an exception, but `TryParse` returns `false`. When calling a `Parse` method, you should always use exception handling to catch a <xref:System.FormatException> when the parse operation fails.

> [!TIP]
> You can use AI assistance to [convert a string to a number](#use-AI-to-convert-a-string-to-a-number).

## Call Parse or TryParse methods

The `Parse` and `TryParse` methods ignore white space at the beginning and at the end of the string, but all other characters must be characters that form the appropriate numeric type (`int`, `long`, `ulong`, `float`, `decimal`, and so on). Any white space within the string that forms the number causes an error. For example, you can use `decimal.TryParse` to parse "10", "10.3", or "  10  ", but you can't use this method to parse 10 from "10X", "1 0" (note the embedded space), "10 .3" (note the embedded space), "10e1" (`float.TryParse` works here), and so on. A string whose value is `null` or <xref:System.String.Empty?displayProperty=nameWithType> fails to parse successfully. You can check for a null or empty string before attempting to parse it by calling the <xref:System.String.IsNullOrEmpty%2A?displayProperty=nameWithType> method.

The following example demonstrates both successful and unsuccessful calls to `Parse` and `TryParse`.

[!code-csharp[Parse and TryParse](~/samples/snippets/csharp/programming-guide/string-to-number/parse-tryparse/program.cs)]

The following example illustrates one approach to parsing a string expected to include leading numeric characters (including hexadecimal characters) and trailing non-numeric characters. It assigns valid characters from the beginning of a string to a new string before calling the <xref:System.Int32.TryParse%2A> method. Because the strings to be parsed contain a few characters, the example calls the <xref:System.String.Concat%2A?displayProperty=nameWithType> method to assign valid characters to a new string. For a larger string, the <xref:System.Text.StringBuilder> class can be used instead.

[!code-csharp[Removing invalid characters](~/samples/snippets/csharp/programming-guide/string-to-number/parse-tryparse2/program.cs)]

## Call Convert methods

The following table lists some of the methods from the <xref:System.Convert> class that you can use to convert a string to a number.

| Numeric type | Method                                             |
|--------------|----------------------------------------------------|
| `decimal`    | <xref:System.Convert.ToDecimal%28System.String%29> |
| `float`      | <xref:System.Convert.ToSingle%28System.String%29>  |
| `double`     | <xref:System.Convert.ToDouble%28System.String%29>  |
| `short`      | <xref:System.Convert.ToInt16%28System.String%29>   |
| `int`        | <xref:System.Convert.ToInt32%28System.String%29>   |
| `long`       | <xref:System.Convert.ToInt64%28System.String%29>   |
| `ushort`     | <xref:System.Convert.ToUInt16%28System.String%29>  |
| `uint`       | <xref:System.Convert.ToUInt32%28System.String%29>  |
| `ulong`      | <xref:System.Convert.ToUInt64%28System.String%29>  |

The following example calls the <xref:System.Convert.ToInt32%28System.String%29?displayProperty=nameWithType> method to convert an input string to an [int](../../language-reference/builtin-types/integral-numeric-types.md). The example catches the two most common exceptions thrown by this method: <xref:System.FormatException> and <xref:System.OverflowException>. If the resulting number can be incremented without exceeding <xref:System.Int32.MaxValue?displayProperty=nameWithType>, the example adds 1 to the result and displays the output.

[!code-csharp[Parsing with Convert methods](~/samples/snippets/csharp/programming-guide/string-to-number/convert/program.cs)]

## Use AI to convert a string to a number

You can use AI tools, such as GitHub Copilot to generate C# code to convert a string to a number. You can customize the prompt to use a string per your requirements.

The following text shows an example prompt for Copilot Chat:

```copilot-prompt
Show me how to parse a string as a number, but don't throw an exception if the input string doesn't represent a number.
```

GitHub Copilot is powered by AI, so surprises and mistakes are possible. For more information, see [Copilot FAQs](https://aka.ms/copilot-general-use-faqs).

## See also

- [GitHub Copilot in Visual Studio](/visualstudio/ide/visual-studio-github-copilot-install-and-states)
- [GitHub Copilot in VS Code](https://code.visualstudio.com/docs/copilot/overview)
