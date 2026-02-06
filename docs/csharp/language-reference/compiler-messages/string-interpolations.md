---
title: Resolve errors and warnings for string interpolation expressions
description: Learn how to diagnose and correct C# compiler errors and warnings when you use string interpolation expressions, where expressions are substituted for placeholders in a string literal.
f1_keywords:
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
  - "CS8361"
  - "CS8941"
  - "CS8942"
  - "CS8946"
  - "CS8947"
  - "CS8953"
  - "CS8976"
  - "CS9205"
  - "CS9325"
ms.date: 02/06/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings for string interpolation expressions

The C# compiler generates errors and warnings when you declare string interpolation expressions or string interpolation handlers with incorrect syntax or use them in unsupported contexts. These diagnostics help you identify problems with string interpolations or custom string interpolation handlers.

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS8361**](#interpolation-expression-syntax): *A conditional expression cannot be used directly in a string interpolation because the ':' ends the interpolation. Parenthesize the conditional expression.*
- [**CS8941**](#interpolated-string-handler-type-implementation): *Interpolated string handler method is malformed. It does not return 'void' or 'bool'.*
- [**CS8942**](#interpolated-string-handler-type-implementation): *Interpolated string handler method has inconsistent return type. Expected to return a different type.*
- [**CS8946**](#interpolated-string-handler-type-implementation): *Type is not an interpolated string handler type.*
- [**CS8947**](#interpolated-string-handler-usage-restrictions): *Parameter occurs after interpolated string handler parameter in the parameter list, but is used as an argument for interpolated string handler conversions. This will require the caller to reorder parameters with named arguments at the call site. Consider putting the interpolated string handler parameter after all arguments involved.*
- [**CS8953**](#interpolated-string-handler-usage-restrictions): *An interpolated string handler construction cannot use dynamic. Manually construct an instance instead.*
- [**CS8976**](#interpolated-string-handler-usage-restrictions): *Interpolated string handler conversions that reference the instance being indexed cannot be used in indexer member initializers.*
- [**CS9205**](#interpolation-expression-syntax): *Expected interpolated string.*
- [**CS9325**](#interpolated-string-handler-usage-restrictions): *Interpolated string handler arguments are not allowed in this context.*

## Interpolation expression syntax

- **CS8361** - *A conditional expression cannot be used directly in a string interpolation because the ':' ends the interpolation. Parenthesize the conditional expression.*
- **CS9205** - *Expected interpolated string.*

To correct these errors, apply the following techniques:

- Wrap conditional expressions (ternary `?:` operator) in parentheses when you use them inside an interpolation hole (**CS8361**). The colon character has special meaning in [interpolated strings](../tokens/interpolated.md) as it introduces a format string, so the compiler interprets the `:` in `condition ? true : false` as a format specifier rather than part of the conditional expression. For example, use `$"{(x > 0 ? "positive" : "negative")}"` instead of `$"{x > 0 ? "positive" : "negative"}"`.
- Ensure you provide an interpolated string literal where one is expected (**CS9205**). This error occurs when the compiler expects an interpolated string (beginning with `$"` or `$@"`) but encounters a different expression type.

## Interpolated string handler type implementation

- **CS8941** - *Interpolated string handler method is malformed. It does not return 'void' or 'bool'.*
- **CS8942** - *Interpolated string handler method has inconsistent return type. Expected to return a different type.*
- **CS8946** - *Type is not an interpolated string handler type.*

When you implement a custom [interpolated string handler](../../advanced-topics/performance/interpolated-string-handler.md), apply the following techniques:

- Make sure all `AppendLiteral` and `AppendFormatted` methods return either `void` or `bool` (**CS8941**). The handler pattern requires these methods to have one of these return types so the compiler can properly generate the interpolation code. Methods returning `bool` enable short-circuiting when the handler determines that further processing isn't needed.
- Make sure all append methods in your handler type use the same return type (**CS8942**). If one method returns `void`, all append methods must return `void`. If one returns `bool`, all must return `bool`. Mixing return types prevents the compiler from generating consistent interpolation code.
- Apply the <xref:System.Runtime.CompilerServices.InterpolatedStringHandlerAttribute> to your handler type and make sure it has a valid constructor (**CS8946**). An interpolated string handler type must be marked with this attribute and follow the [handler pattern](~/_csharplang/proposals/csharp-10.0/improved-interpolated-strings.md#the-handler-pattern) to be recognized by the compiler.

## Interpolated string handler usage restrictions

- **CS8947** - *Parameter occurs after the interpolated string handler parameter in the parameter list, but is used as an argument for interpolated string handler conversions. This will require the caller to reorder parameters with named arguments at the call site. Consider putting the interpolated string handler parameter after all arguments involved.*
- **CS8953** - *An interpolated string handler construction cannot use dynamic. Manually construct an instance of '{0}'.*
- **CS8976** - *Interpolated string handler conversions that reference the instance being indexed cannot be used in indexer member initializers.*
- **CS9325** - *Interpolated string handler arguments are not allowed in this context.*

When you use interpolated string handlers, apply the following techniques:

- Reorder method parameters so that any parameters used by the <xref:System.Runtime.CompilerServices.InterpolatedStringHandlerArgumentAttribute> appear before the interpolated string handler parameter (**CS8947**). This warning indicates that callers would need to use named arguments to properly invoke the method, which reduces usability. Place the handler parameter after all arguments it depends on.
- Don't use `dynamic` typed values as arguments to interpolated string handler conversions (**CS8953**). The compiler can't determine the handler's construction requirements at compile time when dynamic values are involved. Instead, manually construct the handler instance and call its methods directly.
- Don't use interpolated strings that reference the instance being initialized in indexer member initializers (**CS8976**). During object initialization, the instance isn't fully constructed, so handler conversions that reference it through `this` aren't allowed. Use a separate statement after initialization to set the indexer value.
- Check the context where you're using interpolated string handler arguments (**CS9325**). Some contexts don't support handler argument attributes. In these cases, use a regular interpolated string or manually construct the handler.

