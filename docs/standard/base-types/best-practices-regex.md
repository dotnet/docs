---
title: Best Practices for Regular Expressions in .NET
description: Learn how to create efficient, effective regular expressions in .NET.
ms.date: 06/11/2024
ms.custom: devdivchpfy22
ms.topic: concept-article
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - ".NET regular expressions, best practices"
  - "regular expressions, best practices"
ms.assetid: 618e5afb-3a97-440d-831a-70e4c526a51c
---
# Best practices for regular expressions in .NET

The regular expression engine in .NET is a powerful, full-featured tool that processes text based on pattern matches rather than on comparing and matching literal text. In most cases, it performs pattern matching rapidly and efficiently. However, in some cases, the regular expression engine can appear to be slow. In extreme cases, it can even appear to stop responding as it processes a relatively small input over the course of hours or even days.

This article outlines some of the best practices that developers can adopt to ensure that their regular expressions achieve optimal performance.

[!INCLUDE [regex](../../../includes/regex.md)]

## Consider the input source

In general, regular expressions can accept two types of input: constrained or unconstrained. Constrained input is a text that originates from a known or reliable source and follows a predefined format. Unconstrained input is a text that originates from an unreliable source, such as a web user, and might not follow a predefined or expected format.

Regular expression patterns are often written to match valid input. That is, developers examine the text that they want to match and then write a regular expression pattern that matches it. Developers then determine whether this pattern requires correction or further elaboration by testing it with multiple valid input items. When the pattern matches all presumed valid inputs, it's declared to be production-ready, and can be included in a released application. This approach makes a regular expression pattern suitable for matching constrained input. However, it doesn't make it suitable for matching unconstrained input.

To match unconstrained input, a regular expression must handle three kinds of text efficiently:

- Text that matches the regular expression pattern.
- Text that doesn't match the regular expression pattern.
- Text that nearly matches the regular expression pattern.

The last text type is especially problematic for a regular expression that has been written to handle constrained input. If that regular expression also relies on extensive [backtracking](backtracking-in-regular-expressions.md), the regular expression engine can spend an inordinate amount of time (in some cases, many hours or days) processing seemingly innocuous text.

> [!WARNING]
> The following example uses a regular expression that's prone to excessive backtracking and that's likely to reject valid email addresses. You shouldn't use it in an email validation routine. If you would like a regular expression that validates email addresses, see [How to: Verify that Strings Are in Valid Email Format](how-to-verify-that-strings-are-in-valid-email-format.md).

For example, consider a commonly used but problematic regular expression for validating the alias of an email address. The regular expression `^[0-9A-Z]([-.\w]*[0-9A-Z])*$` is written to process what is considered to be a valid email address. A valid email address consists of an alphanumeric character, followed by zero or more characters that can be alphanumeric, periods, or hyphens. The regular expression must end with an alphanumeric character. However, as the following example shows, although this regular expression handles valid input easily, its performance is inefficient when it's processing nearly valid input:

[!code-csharp[Conceptual.RegularExpressions.BestPractices#1](./snippets/regex/csharp/design2.cs#1)]
[!code-vb[Conceptual.RegularExpressions.BestPractices#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.bestpractices/vb/design2.vb#1)]

As the output from the preceding example shows, the regular expression engine processes the valid email alias in about the same time interval regardless of its length. On the other hand, when the nearly valid email address has more than five characters, processing time approximately doubles for each extra character in the string. Therefore, a nearly valid 28-character string would take over an hour to process, and a nearly valid 33-character string would take nearly a day to process.

Because this regular expression was developed solely by considering the format of input to be matched, it fails to take account of input that doesn't match the pattern. This oversight, in turn, can allow unconstrained input that nearly matches the regular expression pattern to significantly degrade performance.

To solve this problem, you can do the following:

- When developing a pattern, you should consider how backtracking might affect the performance of the regular expression engine, particularly if your regular expression is designed to process unconstrained input. For more information, see the [Take Charge of Backtracking](#take-charge-of-backtracking) section.

- Thoroughly test your regular expression using invalid, near-valid, and valid input. You can use [Rex](https://www.microsoft.com/research/project/rex-regular-expression-exploration/) to randomly generate input for a particular regular expression. [Rex](https://www.microsoft.com/research/project/rex-regular-expression-exploration/) is a regular expression exploration tool from Microsoft Research.

## Handle object instantiation appropriately

At the heart of .NET's regular expression object model is the <xref:System.Text.RegularExpressions.Regex?displayProperty=nameWithType> class, which represents the regular expression engine. Often, the single greatest factor that affects regular expression performance is the way in which the <xref:System.Text.RegularExpressions.Regex> engine is used. Defining a regular expression involves tightly coupling the regular expression engine with a regular expression pattern. That coupling process is expensive, whether it involves instantiating a <xref:System.Text.RegularExpressions.Regex> object by passing its constructor a regular expression pattern or calling a static method by passing it the regular expression pattern and the string to be analyzed.

> [!NOTE]
> For a detailed discussion of the performance implications of using interpreted and compiled regular expressions, see the blog post [Optimizing Regular Expression Performance, Part II: Taking Charge of Backtracking](/archive/blogs/bclteam/optimizing-regular-expression-performance-part-ii-taking-charge-of-backtracking-ron-petrusha).

You can couple the regular expression engine with a particular regular expression pattern and then use the engine to match the text in several ways:

- You can call a static pattern-matching method, such as <xref:System.Text.RegularExpressions.Regex.Match%28System.String%2CSystem.String%29?displayProperty=nameWithType>. This method doesn't require instantiation of a regular expression object.

- You can instantiate a <xref:System.Text.RegularExpressions.Regex> object and call an instance pattern-matching method of an interpreted regular expression, which is the default method for binding the regular expression engine to a regular expression pattern. It results when a <xref:System.Text.RegularExpressions.Regex> object is instantiated without an `options` argument that includes the <xref:System.Text.RegularExpressions.RegexOptions.Compiled> flag.

- You can instantiate a <xref:System.Text.RegularExpressions.Regex> object and call an instance pattern-matching method of a source-generated regular expression. This technique is recommended in most cases. To do so, place the <xref:System.Text.RegularExpressions.GeneratedRegexAttribute> attribute on a partial method that returns `Regex`.

- You can instantiate a <xref:System.Text.RegularExpressions.Regex> object and call an instance pattern-matching method of a compiled regular expression. Regular expression objects represent compiled patterns when a <xref:System.Text.RegularExpressions.Regex> object is instantiated with an `options` argument that includes the <xref:System.Text.RegularExpressions.RegexOptions.Compiled> flag.

The particular way in which you call regular expression matching methods can affect your application's performance. The following sections discuss when to use static method calls, source-generated regular expressions, interpreted regular expressions, and compiled regular expressions to improve your application's performance.

> [!IMPORTANT]
> The form of the method call (static, interpreted, source-generated, compiled) affects performance if the same regular expression is used repeatedly in method calls, or if an application makes extensive use of regular expression objects.

### Static regular expressions

Static regular expression methods are recommended as an alternative to repeatedly instantiating a regular expression object with the same regular expression. Unlike regular expression patterns used by regular expression objects, either the operation codes (opcodes) or the compiled common intermediate language (CIL) from patterns used in static method calls is cached internally by the regular expression engine.

For example, an event handler frequently calls another method to validate user input. This example is reflected in the following code, in which a <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Click> event is used to call a method named `IsValidCurrency`, which checks whether the user has entered a currency symbol followed by at least one decimal digit.

[!code-csharp[Conceptual.RegularExpressions.BestPractices#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.bestpractices/cs/static1.cs#2)]
[!code-vb[Conceptual.RegularExpressions.BestPractices#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.bestpractices/vb/static1.vb#2)]

An inefficient implementation of the `IsValidCurrency` method is shown in the following example:

> [!NOTE]
> Each method call reinstantiates a <xref:System.Text.RegularExpressions.Regex> object with the same pattern. This, in turn, means that the regular expression pattern must be recompiled each time the method is called.

[!code-csharp[Conceptual.RegularExpressions.BestPractices#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.bestpractices/cs/static1.cs#3)]
[!code-vb[Conceptual.RegularExpressions.BestPractices#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.bestpractices/vb/static1.vb#3)]

You should replace the preceding inefficient code with a call to the static <xref:System.Text.RegularExpressions.Regex.IsMatch%28System.String%2CSystem.String%29?displayProperty=nameWithType> method. This approach eliminates the need to instantiate a <xref:System.Text.RegularExpressions.Regex> object each time you want to call a pattern-matching method, and enables the regular expression engine to retrieve a compiled version of the regular expression from its cache.

[!code-csharp[Conceptual.RegularExpressions.BestPractices#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.bestpractices/cs/static2.cs#4)]
[!code-vb[Conceptual.RegularExpressions.BestPractices#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.bestpractices/vb/static2.vb#4)]

By default, the last 15 most recently used static regular expression patterns are cached. For applications that require a larger number of cached static regular expressions, the size of the cache can be adjusted by setting the <xref:System.Text.RegularExpressions.Regex.CacheSize%2A?displayProperty=nameWithType> property.

The regular expression `\p{Sc}+\s*\d+` that's used in this example verifies that the input string has a currency symbol and at least one decimal digit. The pattern is defined as shown in the following table:

| Pattern   | Description                                                              |
|-----------|--------------------------------------------------------------------------|
| `\p{Sc}+` | Matches one or more characters in the Unicode Symbol, Currency category. |
| `\s*`     | Matches zero or more white-space characters.                             |
| `\d+`     | Matches one or more decimal digits.                                      |

### Interpreted vs. source-generated vs. compiled regular expressions

Regular expression patterns that aren't bound to the regular expression engine through the specification of the <xref:System.Text.RegularExpressions.RegexOptions.Compiled> option are *interpreted*. When a regular expression object is instantiated, the regular expression engine converts the regular expression to a set of operation codes. When an instance method is called, the operation codes are converted to CIL and executed by the JIT compiler. Similarly, when a static regular expression method is called and the regular expression can't be found in the cache, the regular expression engine converts the regular expression to a set of operation codes and stores them in the cache. It then converts these operation codes to CIL so that the JIT compiler can execute them. Interpreted regular expressions reduce startup time at the cost of slower execution time. Because of this process, they're best used when the regular expression is used in a small number of method calls, or if the exact number of calls to regular expression methods is unknown but is expected to be small. As the number of method calls increases, the performance gain from reduced startup time is outstripped by the slower execution speed.

Regular expression patterns that are bound to the regular expression engine through the specification of the <xref:System.Text.RegularExpressions.RegexOptions.Compiled> option are *compiled*. Therefore, when a regular expression object is instantiated, or when a static regular expression method is called and the regular expression can't be found in the cache, the regular expression engine converts the regular expression to an intermediary set of operation codes. These codes are then converted to CIL. When a method is called, the JIT compiler executes the CIL. In contrast to interpreted regular expressions, compiled regular expressions increase startup time but execute individual pattern-matching methods faster. As a result, the performance benefit that results from compiling the regular expression increases in proportion to the number of regular expression methods called.

Regular expression patterns that are bound to the regular expression engine through the adornment of a `Regex`-returning method with the <xref:System.Text.RegularExpressions.GeneratedRegexAttribute> attribute are *source generated*. The source generator, which plugs into the compiler, emits as C# code a custom `Regex`-derived implementation with logic similar to what `RegexOptions.Compiled` emits in CIL. You get all the throughput performance benefits of `RegexOptions.Compiled` (more, in fact) and the start-up benefits of `Regex.CompileToAssembly`, but without the complexity of `CompileToAssembly`. The source that's emitted is part of your project, which means it's also easily viewable and debuggable.

To summarize, we recommend that you:

- Use *interpreted* regular expressions when you call regular expression methods with a specific regular expression relatively infrequently.
- Use *source-generated* regular expressions if you're using `Regex` in C# with arguments known at compile time, and you're using a specific regular expression relatively frequently.
- Use *compiled* regular expressions when you call regular expression methods with a specific regular expression relatively frequently and you're using .NET 6 or an earlier version.

It's difficult to determine the exact threshold at which the slower execution speeds of interpreted regular expressions outweigh gains from their reduced startup time. It's also difficult to determine the threshold at which the slower startup times of source-generated or compiled regular expressions outweigh gains from their faster execution speeds. The thresholds depend on various factors, including the complexity of the regular expression and the specific data that it processes. To determine which regular expressions offer the best performance for your particular application scenario, you can use the <xref:System.Diagnostics.Stopwatch> class to compare their execution times.

The following example compares the performance of compiled, source-generated, and interpreted regular expressions when reading the first 10 sentences and when reading all the sentences in the text of William D. Guthrie's *Magna Carta, and Other Addresses*. As the output from the example shows, when only 10 calls are made to regular expression matching methods, an interpreted or source-generated regular expression offers better performance than a compiled regular expression. However, a compiled regular expression offers better performance when a large number of calls (in this case, over 13,000) are made.

[!code-csharp[Conceptual.RegularExpressions.BestPractices#5](./snippets/regex/csharp/compare1.cs#5)]

The regular expression pattern used in the example, `\b(\w+((\r?\n)|,?\s))*\w+[.?:;!]`, is defined as shown in the following table:

| Pattern | Description                          |
|---------|--------------------------------------|
| `\b`    | Begin the match at a word boundary.  |
| `\w+`   | Matches one or more word characters. |
|<code>(\r?\n)&#124;,?\s)</code>|Matches either zero or one carriage return followed by a newline character, or zero or one comma followed by a white-space character.|
|<code>(\w+((\r?\n)&#124;,?\s))*</code>|Matches zero or more occurrences of one or more word characters that are followed either by zero or one carriage return and a newline character, or by zero or one comma followed by a white-space character.|
|`\w+`|Matches one or more word characters.|
|`[.?:;!]`|Matches a period, question mark, colon, semicolon, or exclamation point.|

## Take charge of backtracking

Ordinarily, the regular expression engine uses linear progression to move through an input string and compare it to a regular expression pattern. However, when indeterminate quantifiers such as `*`, `+`, and `?` are used in a regular expression pattern, the regular expression engine might give up a portion of successful partial matches and return to a previously saved state in order to search for a successful match for the entire pattern. This process is known as backtracking.

> [!TIP]
> For more information on backtracking, see [Details of regular expression behavior](details-of-regular-expression-behavior.md) and [Backtracking](backtracking-in-regular-expressions.md). For detailed discussions of backtracking, see the [Regular Expression Improvements in .NET 7](https://devblogs.microsoft.com/dotnet/regular-expression-improvements-in-dotnet-7/#backtracking-and-regexoptions-nonbacktracking) and [Optimizing Regular Expression Performance](/archive/blogs/bclteam/optimizing-regular-expression-performance-part-ii-taking-charge-of-backtracking-ron-petrusha) blog posts.

Support for backtracking gives regular expressions power and flexibility. It also places the responsibility for controlling the operation of the regular expression engine in the hands of regular expression developers. Because developers are often not aware of this responsibility, their misuse of backtracking or reliance on excessive backtracking often plays the most significant role in degrading regular expression performance. In a worst-case scenario, execution time can double for each additional character in the input string. In fact, by using backtracking excessively, it's easy to create the programmatic equivalent of an endless loop if input nearly matches the regular expression pattern. The regular expression engine might take hours or even days to process a relatively short input string.

Often, applications pay a performance penalty for using backtracking even though backtracking isn't essential for a match. For example, the regular expression `\b\p{Lu}\w*\b` matches all words that begin with an uppercase character, as the following table shows:

| Pattern  | Description                           |
|----------|---------------------------------------|
| `\b`     | Begin the match at a word boundary.   |
| `\p{Lu}` | Matches an uppercase character.       |
| `\w*`    | Matches zero or more word characters. |
| `\b`     | End the match at a word boundary.     |

Because a word boundary isn't the same as, or a subset of, a word character, there's no possibility that the regular expression engine will cross a word boundary when matching word characters. Therefore for this regular expression, backtracking can never contribute to the overall success of any match. It can only degrade performance because the regular expression engine is forced to save its state for each successful preliminary match of a word character.

If you determine that backtracking isn't necessary, you can disable it in a couple of ways:

- By setting the <xref:System.Text.RegularExpressions.RegexOptions.NonBacktracking?displayProperty=nameWithType> option (introduced in .NET 7). For more information, see [Nonbacktracking mode](regular-expression-options.md#nonbacktracking-mode).
- By using the `(?>subexpression)` language element, known as an atomic group. The following example parses an input string by using two regular expressions. The first, `\b\p{Lu}\w*\b`, relies on backtracking. The second, `\b\p{Lu}(?>\w*)\b`, disables backtracking. As the output from the example shows, they both produce the same result:

  [!code-csharp[Conceptual.RegularExpressions.BestPractices#10](./snippets/regex/csharp/backtrack2.cs#10)]
  [!code-vb[Conceptual.RegularExpressions.BestPractices#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.bestpractices/vb/backtrack2.vb#10)]

In many cases, backtracking is essential for matching a regular expression pattern to input text. However, excessive backtracking can severely degrade performance and create the impression that an application has stopped responding. In particular, this problem arises when quantifiers are nested and the text that matches the outer subexpression is a subset of the text that matches the inner subexpression.

> [!WARNING]
> In addition to avoiding excessive backtracking, you should use the timeout feature to ensure that excessive backtracking doesn't severely degrade regular expression performance. For more information, see the [Use time-out values](#use-time-out-values) section.

For example, the regular expression pattern `^[0-9A-Z]([-.\w]*[0-9A-Z])*\$$` is intended to match a part number that consists of at least one alphanumeric character. Any additional characters can consist of an alphanumeric character, a hyphen, an underscore, or a period, though the last character must be alphanumeric. A dollar sign terminates the part number. In some cases, this regular expression pattern can exhibit poor performance because quantifiers are nested, and because the subexpression `[0-9A-Z]` is a subset of the subexpression `[-.\w]*`.

In these cases, you can optimize regular expression performance by removing the nested quantifiers and replacing the outer subexpression with a zero-width lookahead or lookbehind assertion. Lookahead and lookbehind assertions are anchors. They don't move the pointer in the input string but instead look ahead or behind to check whether a specified condition is met. For example, the part number regular expression can be rewritten as `^[0-9A-Z][-.\w]*(?<=[0-9A-Z])\$$`. This regular expression pattern is defined as shown in the following table:

| Pattern         | Description                                                                               |
|-----------------|-------------------------------------------------------------------------------------------|
| `^`             | Begin the match at the beginning of the input string.                                     |
| `[0-9A-Z]`      | Match an alphanumeric character. The part number must consist of at least this character. |
| `[-.\w]*`       | Match zero or more occurrences of any word character, hyphen, or period.                  |
| `\$`            | Match a dollar sign.                                                                      |
| `(?<=[0-9A-Z])` | Look behind the ending dollar sign to ensure that the previous character is alphanumeric. |
| `$`             | End the match at the end of the input string.                                             |

The following example illustrates the use of this regular expression to match an array containing possible part numbers:

[!code-csharp[Conceptual.RegularExpressions.BestPractices#11](./snippets/regex/csharp/backtrack4.cs#11)]
[!code-vb[Conceptual.RegularExpressions.BestPractices#11](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.bestpractices/vb/backtrack4.vb#11)]

The regular expression language in .NET includes the following language elements that you can use to eliminate nested quantifiers. For more information, see [Grouping constructs](grouping-constructs-in-regular-expressions.md).

|Language element|Description|
|----------------------|-----------------|
|`(?=` `subexpression` `)`|Zero-width positive lookahead. Looks ahead of the current position to determine whether `subexpression` matches the input string.|
|`(?!` `subexpression` `)`|Zero-width negative lookahead. Looks ahead of the current position to determine whether `subexpression` doesn't match the input string.|
|`(?<=` `subexpression` `)`|Zero-width positive lookbehind. Looks behind the current position to determine whether `subexpression` matches the input string.|
|`(?<!` `subexpression` `)`|Zero-width negative lookbehind. Looks behind the current position to determine whether `subexpression` doesn't match the input string.|

## Use time-out values

If your regular expressions processes input that nearly matches the regular expression pattern, it can often rely on excessive backtracking, which impacts its performance significantly. In addition to carefully considering your use of backtracking and testing the regular expression against near-matching input, you should always set a time-out value to minimize the effect of excessive backtracking, if it occurs.

The regular expression time-out interval defines the period of time that the regular expression engine will look for a single match before it times out. Depending on the regular expression pattern and the input text, the execution time might exceed the specified time-out interval, but it won't spend more time backtracking than the specified time-out interval. The default time-out interval is <xref:System.Text.RegularExpressions.Regex.InfiniteMatchTimeout?displayProperty=nameWithType>, which means that the regular expression won't time out. You can override this value and define a time-out interval as follows:

- Call the <xref:System.Text.RegularExpressions.Regex.%23ctor%28System.String%2CSystem.Text.RegularExpressions.RegexOptions%2CSystem.TimeSpan%29> constructor to provide a time-out value when you instantiate a <xref:System.Text.RegularExpressions.Regex> object.

- Call a static pattern matching method, such as <xref:System.Text.RegularExpressions.Regex.Match%28System.String%2CSystem.String%2CSystem.Text.RegularExpressions.RegexOptions%2CSystem.TimeSpan%29?displayProperty=nameWithType> or <xref:System.Text.RegularExpressions.Regex.Replace%28System.String%2CSystem.String%2CSystem.String%2CSystem.Text.RegularExpressions.RegexOptions%2CSystem.TimeSpan%29?displayProperty=nameWithType>, that includes a `matchTimeout` parameter.

- Set a process-wide or app domain-wide value with code such as `AppDomain.CurrentDomain.SetData("REGEX_DEFAULT_MATCH_TIMEOUT", TimeSpan.FromMilliseconds(100));`.

If you've defined a time-out interval and a match isn't found at the end of that interval, the regular expression method throws a <xref:System.Text.RegularExpressions.RegexMatchTimeoutException> exception. In your exception handler, you can choose to retry the match with a longer time-out interval, abandon the match attempt and assume that there's no match, or abandon the match attempt and log the exception information for future analysis.

The following example defines a `GetWordData` method that instantiates a regular expression with a time-out interval of 350 milliseconds to calculate the number of words and average number of characters in a word in a text document. If the matching operation times out, the time-out interval is increased by 350 milliseconds and the <xref:System.Text.RegularExpressions.Regex> object is reinstantiated. If the new time-out interval exceeds one second, the method rethrows the exception to the caller.

[!code-csharp[Conceptual.RegularExpressions.BestPractices#12](./snippets/regex/csharp/timeout1.cs#12)]
[!code-vb[Conceptual.RegularExpressions.BestPractices#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.bestpractices/vb/timeout1.vb#12)]

## Capture only when necessary

Regular expressions in .NET support grouping constructs, which let you group a regular expression pattern into one or more subexpressions. The most commonly used grouping constructs in .NET regular expression language are `(`*subexpression*`)`, which defines a numbered capturing group, and `(?<`*name*`>`*subexpression*`)`, which defines a named capturing group. Grouping constructs are essential for creating backreferences and for defining a subexpression to which a quantifier is applied.

However, the use of these language elements has a cost. They cause the <xref:System.Text.RegularExpressions.GroupCollection> object returned by the <xref:System.Text.RegularExpressions.Match.Groups%2A?displayProperty=nameWithType> property to be populated with the most recent unnamed or named captures. If a single grouping construct has captured multiple substrings in the input string, they also populate the <xref:System.Text.RegularExpressions.CaptureCollection> object returned by the <xref:System.Text.RegularExpressions.Group.Captures%2A?displayProperty=nameWithType> property of a particular capturing group with multiple <xref:System.Text.RegularExpressions.Capture> objects.

Often, grouping constructs are used in a regular expression only so that quantifiers can be applied to them. The groups captured by these subexpressions aren't used later. For example, the regular expression `\b(\w+[;,]?\s?)+[.?!]` is designed to capture an entire sentence. The following table describes the language elements in this regular expression pattern and their effect on the <xref:System.Text.RegularExpressions.Match> object's <xref:System.Text.RegularExpressions.Match.Groups%2A?displayProperty=nameWithType> and <xref:System.Text.RegularExpressions.Group.Captures%2A?displayProperty=nameWithType> collections:

| Pattern | Description                                |
|---------|--------------------------------------------|
| `\b`    | Begin the match at a word boundary.        |
| `\w+`   | Matches one or more word characters.       |
| `[;,]?` | Matches zero or one comma or semicolon.    |
| `\s?`   | Matches zero or one white-space character. |
|`(\w+[;,]?\s?)+`|Matches one or more occurrences of one or more word characters followed by an optional comma or semicolon followed by an optional white-space character. This pattern defines the first capturing group, which is necessary so that the combination of multiple word characters (that is, a word) followed by an optional punctuation symbol will be repeated until the regular expression engine reaches the end of a sentence.|
|`[.?!]`|Matches a period, question mark, or exclamation point.|

As the following example shows, when a match is found, both the <xref:System.Text.RegularExpressions.GroupCollection> and <xref:System.Text.RegularExpressions.CaptureCollection> objects are populated with captures from the match. In this case, the capturing group `(\w+[;,]?\s?)` exists so that the `+` quantifier can be applied to it, which enables the regular expression pattern to match each word in a sentence. Otherwise, it would match the last word in a sentence.

[!code-csharp[Conceptual.RegularExpressions.BestPractices#8](./snippets/regex/csharp/group1.cs#8)]
[!code-vb[Conceptual.RegularExpressions.BestPractices#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.bestpractices/vb/group1.vb#8)]

When you use subexpressions only to apply quantifiers to them and you aren't interested in the captured text, you should disable group captures. For example, the `(?:subexpression)` language element prevents the group to which it applies from capturing matched substrings. In the following example, the regular expression pattern from the previous example is changed to `\b(?:\w+[;,]?\s?)+[.?!]`. As the output shows, it prevents the regular expression engine from populating the <xref:System.Text.RegularExpressions.GroupCollection> and <xref:System.Text.RegularExpressions.CaptureCollection> collections:

[!code-csharp[Conceptual.RegularExpressions.BestPractices#9](./snippets/regex/csharp/group2.cs#9)]
[!code-vb[Conceptual.RegularExpressions.BestPractices#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.bestpractices/vb/group2.vb#9)]

You can disable captures in one of the following ways:

- Use the `(?:subexpression)` language element. This element prevents the capture of matched substrings in the group to which it applies. It doesn't disable substring captures in any nested groups.

- Use the <xref:System.Text.RegularExpressions.RegexOptions.ExplicitCapture> option. It disables all unnamed or implicit captures in the regular expression pattern. When you use this option, only substrings that match named groups defined with the `(?<name>subexpression)` language element can be captured. The <xref:System.Text.RegularExpressions.RegexOptions.ExplicitCapture> flag can be passed to the `options` parameter of a <xref:System.Text.RegularExpressions.Regex> class constructor or to the `options` parameter of a <xref:System.Text.RegularExpressions.Regex> static matching method.

- Use the `n` option in the `(?imnsx)` language element. This option disables all unnamed or implicit captures from the point in the regular expression pattern at which the element appears. Captures are disabled either until the end of the pattern or until the `(-n)` option enables unnamed or implicit captures. For more information, see [Miscellaneous Constructs](miscellaneous-constructs-in-regular-expressions.md).

- Use the `n` option in the `(?imnsx:subexpression)` language element. This option disables all unnamed or implicit captures in `subexpression`. Captures by any unnamed or implicit nested capturing groups are disabled as well.

## Thread safety

The <xref:System.Text.RegularExpressions.Regex> class itself is thread safe and immutable (read-only). That is, `Regex` objects can be created on any thread and shared between threads; matching methods can be called from any thread and never alter any global state.

However, result objects (`Match` and `MatchCollection`) returned by `Regex` should be used on a single thread. Although many of these objects are logically immutable, their implementations could delay computation of some results to improve performance, and as a result, callers must serialize access to them.

If you have a need to share `Regex` result objects on multiple threads, these objects can be converted to thread-safe instances by calling their synchronized methods. With the exception of enumerators, all regular expression classes are thread safe or can be converted into thread-safe objects by a synchronized method.

Enumerators are the only exception. You must serialize calls to collection enumerators. The rule is that if a collection can be enumerated on more than one thread simultaneously, you should synchronize enumerator methods on the root object of the collection traversed by the enumerator.

## Related articles

| Title | Description |
|-------|-------------|
|[Details of Regular Expression Behavior](details-of-regular-expression-behavior.md)|Examines the implementation of the regular expression engine in .NET. The article focuses on the flexibility of regular expressions and explains the developer's responsibility for ensuring the efficient and robust operation of the regular expression engine.|
|[Backtracking](backtracking-in-regular-expressions.md)|Explains what backtracking is and how it affects regular expression performance, and examines language elements that provide alternatives to backtracking.|
|[Regular Expression Language - Quick Reference](regular-expression-language-quick-reference.md)|Describes the elements of the regular expression language in .NET and provides links to detailed documentation for each language element.|
