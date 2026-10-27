---
title: Resolve errors and warnings for string interpolation expressions
description: Learn how to diagnose and correct C# compiler errors and warnings when you use string interpolation expressions, where expressions are substituted for placeholders in a string literal.
f1_keywords:
  - "CS8076"
  - "CS8086"
  - "CS8087"
  - "CS8088"
  - "CS8089"
  - "CS8094"
  - "CS8361"
  - "CS8941"
  - "CS8942"
  - "CS8946"
  - "CS8947"
  - "CS8953"
  - "CS8976"
  - "CS9205"
  - "CS9325"
helpviewer_keywords:
  - "CS8076"
  - "CS8086"
  - "CS8087"
  - "CS8088"
  - "CS8089"
  - "CS8094"
  - "CS8361"
  - "CS8941"
  - "CS8942"
  - "CS8946"
  - "CS8947"
  - "CS8953"
  - "CS8976"
  - "CS9205"
  - "CS9325"
ms.date: 10/27/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings for string interpolation expressions

The C# compiler generates errors and warnings when you declare string interpolation expressions or string interpolation handlers with incorrect syntax or use them in unsupported contexts. These diagnostics help you identify problems with string interpolations or custom string interpolation handlers.

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error or warning for SEO purposes.
 -->
- [**CS8076**](#interpolation-expression-syntax): *Missing close delimiter '}' for interpolated expression started with '{'.*
- [**CS8086**](#interpolation-expression-syntax): *A 'character' character must be escaped (by doubling) in an interpolated string.*
- [**CS8087**](#interpolation-expression-syntax): *A 'character' character may only be escaped by doubling 'charactercharacter' in an interpolated string.*
- [**CS8088**](#interpolation-format-and-alignment-clauses): *A format specifier may not contain trailing whitespace.*
- [**CS8089**](#interpolation-format-and-alignment-clauses): *Empty format specifier.*
- [**CS8094**](#interpolation-format-and-alignment-clauses): *Alignment value alignment has a magnitude greater than limit and may result in a large formatted string.*
- [**CS8361**](#interpolation-expression-syntax): *A conditional expression cannot be used directly in a string interpolation because the ':' ends the interpolation. Parenthesize the conditional expression.*
- [**CS8941**](#interpolated-string-handler-type-implementation): *Interpolated string handler method 'method' is malformed. It does not return 'void' or 'bool'.*
- [**CS8942**](#interpolated-string-handler-type-implementation): *Interpolated string handler method 'method' has inconsistent return type. Expected to return 'different type'.*
- [**CS8946**](#interpolated-string-handler-type-implementation): *'Type' is not an interpolated string handler type.*
- [**CS8947**](#interpolated-string-handler-usage-restrictions): *Parameter 'parameter' occurs after 'interpolated string handler parameter' in the parameter list, but is used as an argument for interpolated string handler conversions. This will require the caller to reorder parameters with named arguments at the call site. Consider putting the interpolated string handler parameter after all arguments involved.*
- [**CS8953**](#interpolated-string-handler-usage-restrictions): *An interpolated string handler construction cannot use dynamic. Manually construct an instance of 'type'.*
- [**CS8976**](#interpolated-string-handler-usage-restrictions): *Interpolated string handler conversions that reference the instance being indexed cannot be used in indexer member initializers.*
- [**CS9205**](#interpolation-expression-syntax): *Expected interpolated string*
- [**CS9325**](#interpolated-string-handler-usage-restrictions): *Interpolated string handler arguments are not allowed in this context.*

## Interpolation expression syntax

- **CS8076**: *Missing close delimiter '}' for interpolated expression started with '{'.*
- **CS8086**: *A 'character' character must be escaped (by doubling) in an interpolated string.*
- **CS8087**: *A 'character' character may only be escaped by doubling 'charactercharacter' in an interpolated string.*
- **CS8361** - *A conditional expression cannot be used directly in a string interpolation because the ':' ends the interpolation. Parenthesize the conditional expression.*
- **CS9205** - *Expected interpolated string*

To correct these errors, apply the following techniques:

- Close each interpolation expression with `}` (**CS8076**). In an interpolated raw string, use a closing brace sequence with the same number of braces as `$` characters in the opening delimiter.
- Double literal braces in the text of regular or verbatim interpolated strings (**CS8086**). In a regular interpolated string, replace escape sequences that decode to braces with doubled braces (**CS8087**). Backslashes are literal characters in verbatim and raw string text; they don't introduce escape sequences.
- For [interpolated raw strings](../tokens/interpolated.md#interpolated-raw-string-literals), don't apply the brace-doubling rule: use the number of `$` characters to distinguish literal braces from interpolation delimiters.
- Wrap conditional expressions (ternary `?:` operator) in parentheses when you use them inside an interpolation hole (**CS8361**). The colon character has special meaning in [interpolated strings](../tokens/interpolated.md) as it introduces a format string, so the compiler interprets the `:` in `condition ? true : false` as a format specifier rather than part of the conditional expression. For example, use `$"{(x > 0 ? "positive" : "negative")}"` instead of `$"{x > 0 ? "positive" : "negative"}"`.
- Ensure you provide an interpolated string literal where one is expected (**CS9205**). This error occurs when the compiler expects an interpolated string (beginning with `$"` or `$@"`) but encounters a different expression type.

For the language rules, see [Interpolated string expressions](~/_csharpstandard/standard/expressions.md#1283-interpolated-string-expressions).

## Interpolation format and alignment clauses

- **CS8088**: *A format specifier may not contain trailing whitespace.*
- **CS8089**: *Empty format specifier.*
- **CS8094**: *Alignment value alignment has a magnitude greater than limit and may result in a large formatted string.*

To correct format and alignment clauses in regular, verbatim, or raw interpolated strings:

- Remove whitespace, including newlines, from the end of the format specifier (**CS8088**).
- Supply a nonempty format specifier after the colon, or remove the colon if you don't need a format specifier (**CS8089**).
- Use an alignment value between -32767 and 32767 (**CS8094**). Larger magnitudes produce a warning because the requested padding can create very large formatted strings.

For the syntax of these clauses, see [Structure of an interpolated string](../tokens/interpolated.md#structure-of-an-interpolated-string).

## Interpolated string handler type implementation

- **CS8941** - *Interpolated string handler method 'method' is malformed. It does not return 'void' or 'bool'.*
- **CS8942** - *Interpolated string handler method 'method' has inconsistent return type. Expected to return 'different type'.*
- **CS8946** - *'Type' is not an interpolated string handler type.*

When you implement a custom [interpolated string handler](../../advanced-topics/performance/interpolated-string-handler.md), use the following techniques:

- Ensure all `AppendLiteral` and `AppendFormatted` methods return either `void` or `bool` (**CS8941**). The handler pattern requires these methods to have one of these return types so the compiler can properly generate the interpolation code. Methods returning `bool` enable short-circuiting when the handler determines that further processing isn't needed.
- Ensure all append methods in your handler type use the same return type (**CS8942**). If one method returns `void`, all append methods must return `void`. If one returns `bool`, all must return `bool`. Mixing return types prevents the compiler from generating consistent interpolation code.
- Apply the <xref:System.Runtime.CompilerServices.InterpolatedStringHandlerAttribute> to your handler type and ensure it has a valid constructor (**CS8946**). An interpolated string handler type must be marked with this attribute and follow the [handler pattern](~/_csharpstandard/standard/attributes.md#235101-custom-interpolated-string-expression-handlers) to be recognized by the compiler.

## Interpolated string handler usage restrictions

- **CS8947** - *Parameter 'parameter' occurs after 'interpolated string handler parameter' in the parameter list, but is used as an argument for interpolated string handler conversions. This will require the caller to reorder parameters with named arguments at the call site. Consider putting the interpolated string handler parameter after all arguments involved.*
- **CS8953** - *An interpolated string handler construction cannot use dynamic. Manually construct an instance of 'type'.*
- **CS8976** - *Interpolated string handler conversions that reference the instance being indexed cannot be used in indexer member initializers.*
- **CS9325** - *Interpolated string handler arguments are not allowed in this context.*

When you use interpolated string handlers, apply the following techniques:

- Reorder method parameters so that any parameters used by the <xref:System.Runtime.CompilerServices.InterpolatedStringHandlerArgumentAttribute> appear before the interpolated string handler parameter (**CS8947**). This warning indicates that callers need to use named arguments to properly invoke the method, which reduces usability. Place the handler parameter after all arguments it depends on.
- Don't use `dynamic` typed values as arguments to interpolated string handler conversions (**CS8953**). The compiler can't determine the handler's construction requirements at compile time when dynamic values are involved. Instead, manually construct the handler instance and call its methods directly.
- Don't use interpolated strings that reference the instance being initialized in indexer member initializers (**CS8976**). During object initialization, the instance isn't fully constructed, so handler conversions that reference it through `this` aren't allowed. Use a separate statement after initialization to set the indexer value.
- Check the context where you're using interpolated string handler arguments (**CS9325**). Some contexts don't support handler argument attributes. In these cases, use a regular interpolated string or manually construct the handler.
