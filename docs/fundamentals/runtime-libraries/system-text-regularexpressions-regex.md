---
title: System.Text.RegularExpressions.Regex class
description: Learn about the System.Text.RegularExpressions.Regex class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
ms.topic: article
---
# System.Text.RegularExpressions.Regex class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Text.RegularExpressions.Regex> class represents .NET's regular expression engine. You can use this class to:

- Quickly parse large amounts of text to find specific character patterns.
- Extract, edit, replace, or delete text substrings.
- Add the extracted strings to a collection to generate a report.

> [!NOTE]
> If you want to validate a string by determining whether it conforms to a particular regular expression pattern, you can use the <xref:System.Configuration.RegexStringValidator?displayProperty=nameWithType> class.

To use regular expressions, you define the pattern that you want to identify in a text stream by using the syntax documented in [Regular expression language - quick reference](../../standard/base-types/regular-expression-language-quick-reference.md). Next, you can optionally instantiate a <xref:System.Text.RegularExpressions.Regex> object. Finally, you call a method that performs some operation, such as replacing text that matches the regular expression pattern, or identifying a pattern match.

For more information about the regular expression language, see [Regular expression language - quick reference](../../standard/base-types/regular-expression-language-quick-reference.md) or download and print one of these brochures:

[Quick Reference in Word (.docx) format](https://download.microsoft.com/download/D/2/4/D240EBF6-A9BA-4E4F-A63F-AEB6DA0B921C/Regular%20expressions%20quick%20reference.docx)
[Quick Reference in PDF (.pdf) format](https://download.microsoft.com/download/D/2/4/D240EBF6-A9BA-4E4F-A63F-AEB6DA0B921C/Regular%20expressions%20quick%20reference.pdf)

## Regex vs. String methods

The <xref:System.String?displayProperty=nameWithType> class includes several search and comparison methods that you can use to perform pattern matching with text. For example, the <xref:System.String.Contains%2A?displayProperty=nameWithType>, <xref:System.String.EndsWith%2A?displayProperty=nameWithType>, and <xref:System.String.StartsWith%2A?displayProperty=nameWithType> methods determine whether a string instance contains a specified substring; and the <xref:System.String.IndexOf%2A?displayProperty=nameWithType>, <xref:System.String.IndexOfAny%2A?displayProperty=nameWithType>, <xref:System.String.LastIndexOf%2A?displayProperty=nameWithType>, and <xref:System.String.LastIndexOfAny%2A?displayProperty=nameWithType> methods return the starting position of a specified substring in a string. Use the methods of the <xref:System.String?displayProperty=nameWithType> class when you are searching for a specific string. Use the <xref:System.Text.RegularExpressions.Regex> class when you are searching for a specific pattern in a string. For more information and examples, see [.NET Regular Expressions](../../standard/base-types/regular-expressions.md).

## Static vs. instance methods

After you define a regular expression pattern, you can provide it to the regular expression engine in either of two ways:

- By instantiating a <xref:System.Text.RegularExpressions.Regex> object that represents the regular expression. To do this, you pass the regular expression pattern to a <xref:System.Text.RegularExpressions.Regex.%23ctor%2A> constructor. A <xref:System.Text.RegularExpressions.Regex> object is immutable; when you instantiate a <xref:System.Text.RegularExpressions.Regex> object with a regular expression, that object's regular expression cannot be changed.

- By supplying both the regular expression and the text to search to a `static` (`Shared` in Visual Basic) <xref:System.Text.RegularExpressions.Regex> method. This enables you to use a regular expression without explicitly creating a <xref:System.Text.RegularExpressions.Regex> object.

All <xref:System.Text.RegularExpressions.Regex> pattern identification methods include both static and instance overloads.

The regular expression engine must compile a particular pattern before the pattern can be used. Because <xref:System.Text.RegularExpressions.Regex> objects are immutable, this is a one-time procedure that occurs when a <xref:System.Text.RegularExpressions.Regex> class constructor or a static method is called. To eliminate the need to repeatedly compile a single regular expression, the regular expression engine caches the compiled regular expressions used in static method calls. As a result, regular expression pattern-matching methods offer comparable performance for static and instance methods. However, caching can adversely affect performance in the following two cases:

- When you use static method calls with a large number of regular expressions. By default, the regular expression engine caches the 15 most recently used static regular expressions. If your application uses more than 15 static regular expressions, some regular expressions must be recompiled. To prevent this recompilation, you can increase the <xref:System.Text.RegularExpressions.Regex.CacheSize?displayProperty=nameWithType> property.

- When you instantiate new <xref:System.Text.RegularExpressions.Regex> objects with regular expressions that have previously been compiled. For example, the following code defines a regular expression to locate duplicated words in a text stream. Although the example uses a single regular expression, it instantiates a new <xref:System.Text.RegularExpressions.Regex> object to process each line of text. This results in the recompilation of the regular expression with each iteration of the loop.

  :::code language="csharp" source="./snippets/System.Text.RegularExpressions/Regex/Overview/csharp/caching1.cs" id="Snippet1":::
  :::code language="vb" source="./snippets/System.Text/RegularExpressions/Overview/vb/caching1.vb" id="Snippet1":::

  To prevent recompilation, you should instantiate a single <xref:System.Text.RegularExpressions.Regex> object that is accessible to all code that requires it, as shown in the following rewritten example.

  :::code language="csharp" source="./snippets/System.Text.RegularExpressions/Regex/Overview/csharp/caching1.cs" id="Snippet2":::
  :::code language="vb" source="./snippets/System.Text/RegularExpressions/Overview/vb/caching1.vb" id="Snippet2":::

## Perform regular expression operations

Whether you decide to instantiate a <xref:System.Text.RegularExpressions.Regex> object and call its methods or call static methods, the <xref:System.Text.RegularExpressions.Regex> class offers the following pattern-matching functionality:

- Validation of a match. You call the <xref:System.Text.RegularExpressions.Regex.IsMatch%2A> method to determine whether a match is present.

- Retrieval of a single match. You call the <xref:System.Text.RegularExpressions.Regex.Match%2A> method to retrieve a <xref:System.Text.RegularExpressions.Match> object that represents the first match in a string or in part of a string. Subsequent matches can be retrieved by calling the <xref:System.Text.RegularExpressions.Match.NextMatch%2A?displayProperty=nameWithType> method.

- Retrieval of all matches. You call the <xref:System.Text.RegularExpressions.Regex.Matches%2A> method to retrieve a <xref:System.Text.RegularExpressions.MatchCollection?displayProperty=nameWithType> object that represents all the matches found in a string or in part of a string.

- Replacement of matched text. You call the <xref:System.Text.RegularExpressions.Regex.Replace%2A> method to replace matched text. The replacement text can also be defined by a regular expression. In addition, some of the <xref:System.Text.RegularExpressions.Regex.Replace%2A> methods include a <xref:System.Text.RegularExpressions.MatchEvaluator> parameter that enables you to programmatically define the replacement text.

- Creation of a string array that is formed from parts of an input string. You call the <xref:System.Text.RegularExpressions.Regex.Split%2A> method to split an input string at positions that are defined by the regular expression.

In addition to its pattern-matching methods, the <xref:System.Text.RegularExpressions.Regex> class includes several special-purpose methods:

- The <xref:System.Text.RegularExpressions.Regex.Escape%2A> method escapes any characters that may be interpreted as regular expression operators in a regular expression or input string.
- The <xref:System.Text.RegularExpressions.Regex.Unescape%2A> method removes these escape characters.
- The <xref:System.Text.RegularExpressions.Regex.CompileToAssembly%2A> method creates an assembly that contains predefined regular expressions. .NET contains examples of these special-purpose assemblies in the <xref:System.Web.RegularExpressions?displayProperty=nameWithType> namespace.

## Define a time-out value

.NET supports a full-featured regular expression language that provides substantial power and flexibility in pattern matching. However, the power and flexibility come at a cost: the risk of poor performance. Regular expressions that perform poorly are surprisingly easy to create. In some cases, regular expression operations that rely on excessive backtracking can appear to stop responding when they process text that nearly matches the regular expression pattern. For more information about the .NET Regular Expression engine, see [Details of regular expression behavior](../../standard/base-types/details-of-regular-expression-behavior.md). For more information about excessive backtracking, see [Backtracking](../../standard/base-types/backtracking-in-regular-expressions.md).

Starting with .NET Framework 4.5, you can define a time-out interval for regular expression matches to limit excessive backtracking. Depending on the regular expression pattern and the input text, the execution time may exceed the specified time-out interval, but it will not spend more time backtracking than the specified time-out interval. If the regular expression engine times out, it throws a <xref:System.Text.RegularExpressions.RegexMatchTimeoutException> exception. In most cases, this prevents the regular expression engine from wasting processing power by trying to match text that nearly matches the regular expression pattern. It also could indicate, however, that the time-out interval has been set too low, or that the current machine load has caused an overall degradation in performance.

How you handle the exception depends on the cause of the exception. If the exception occurs because the time-out interval is set too low or because of excessive machine load, you can increase the time-out interval and retry the matching operation. If the exception occurs because the regular expression relies on excessive backtracking, you can assume that a match does not exist, and, optionally, you can log information that will help you modify the regular expression pattern.

You can set a time-out interval by calling the <xref:System.Text.RegularExpressions.Regex.%23ctor(System.String,System.Text.RegularExpressions.RegexOptions,System.TimeSpan)> constructor when you instantiate a regular expression object. For static methods, you can set a time-out interval by calling an overload of a matching method that has a `matchTimeout` parameter. If you do not set a time-out value explicitly, the default time-out value is determined as follows:

- By using the application-wide time-out value, if one exists. Set the application-wide time-out value by calling the <xref:System.AppDomain.SetData%2A?displayProperty=nameWithType> method to assign the string representation of a <xref:System.TimeSpan> value to the `REGEX_DEFAULT_MATCH_TIMEOUT` property.
- By using the value <xref:System.Text.RegularExpressions.Regex.InfiniteMatchTimeout>, if no application-wide time-out value has been set.

> [!IMPORTANT]
> We recommend that you set a time-out value in all regular expression pattern-matching operations. For more information, see [Best practices for regular expressions](../../standard/base-types/best-practices-regex.md).

## Examples

The following example uses a regular expression to check for repeated occurrences of words in a string. The regular expression `\b(?<word>\w+)\s+(\k<word>)\b` can be interpreted as shown in the following table.

| Pattern        | Description                                                                               |
|----------------|-------------------------------------------------------------------------------------------|
| `\b`           | Start the match at a word boundary.                                                       |
| `(?<word>\w+)` | Match one or more word characters up to a word boundary. Name this captured group `word`. |
| `\s+`          | Match one or more white-space characters.                                                 |
| `(\k<word>)`   | Match the captured group that's named `word`.                                             |
| `\b`           | Match a word boundary.                                                                    |

:::code language="csharp" source="./snippets/System.Text.RegularExpressions/Regex/Overview/csharp/words.cs" interactive="try-dotnet" id="Snippet0":::
:::code language="vb" source="./snippets/System.Text.RegularExpressions/Regex/Overview/vb/words.vb" id="Snippet0":::

The next example illustrates the use of a regular expression to check whether a string either represents a currency value or has the correct format to represent a currency value. In this case, the regular expression is built dynamically from the <xref:System.Globalization.NumberFormatInfo.CurrencyDecimalSeparator%2A?displayProperty=nameWithType>, <xref:System.Globalization.NumberFormatInfo.CurrencyDecimalDigits%2A>, <xref:System.Globalization.NumberFormatInfo.CurrencySymbol%2A?displayProperty=nameWithType>, <xref:System.Globalization.NumberFormatInfo.NegativeSign%2A?displayProperty=nameWithType>, and <xref:System.Globalization.NumberFormatInfo.PositiveSign%2A?displayProperty=nameWithType> properties for the en-US culture. The resulting regular expression is `^\s*[\+-]?\s?\$?\s?(\d*\.?\d{2}?){1}$`. This regular expression can be interpreted as shown in the following table.

| Pattern    | Description                                                                    |
|------------|--------------------------------------------------------------------------------|
| `^`        | Start at the beginning of the string.                                          |
| `\s*`      | Match zero or more white-space characters.                                     |
| `[\+-]?`   | Match zero or one occurrence of either the positive sign or the negative sign. |
| `\s?`      | Match zero or one white-space character.                                       |
| `\$?`      | Match zero or one occurrence of the dollar sign.                               |
| `\s?`      | Match zero or one white-space character.                                       |
| `\d*`      | Match zero or more decimal digits.                                             |
| `\.?`      | Match zero or one decimal point symbol.                                        |
| `(\d{2})?` | Capturing group 1: Match two decimal digits zero or one time.                  |
| `(\d*\.?(\d{2})?){1}` | Match the pattern of integral and fractional digits separated by a decimal point symbol exactly once. |
| `$`        | Match the end of the string.                                                   |

In this case, the regular expression assumes that a valid currency string does not contain group separator symbols, and that it has either no fractional digits or the number of fractional digits defined by the specified culture's <xref:System.Globalization.NumberFormatInfo.CurrencyDecimalDigits> property.

:::code language="csharp" source="./snippets/System.Text.RegularExpressions/Regex/Overview/csharp/regex_example1.cs" interactive="try-dotnet" id="Snippet1":::
:::code language="vb" source="./snippets/System.Text.RegularExpressions/Regex/Overview/vb/regex_example1.vb" id="Snippet1":::

Because the regular expression in this example is built dynamically, you don't know at design time whether the currency symbol, decimal sign, or positive and negative signs of the specified culture (en-US in this example) might be misinterpreted by the regular expression engine as regular expression language operators. To prevent any misinterpretation, the example passes each dynamically generated string to the <xref:System.Text.RegularExpressions.Regex.Escape%2A> method.
