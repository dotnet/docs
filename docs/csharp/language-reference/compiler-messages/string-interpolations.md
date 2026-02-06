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

The C# compiler generates errors and warnings when you declare string interpolation expressions or string interpolation handlers with incorrect syntax or use them in unsupported contexts. These diagnostics help you identify issues with string interpolations or custom string interpolation handlers.

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- **CS8361**: *A conditional expression cannot be used directly in a string interpolation because the ':' ends the interpolation. Parenthesize the conditional expression.*
- **CS8941**: *Interpolated string handler method '{0}' is malformed. It does not return 'void' or 'bool'.*
- **CS8942**: *Interpolated string handler method '{0}' has inconsistent return type. Expected to return '{1}'.*
- **CS8946**: *'{0}' is not an interpolated string handler type.*
- **CS8947**: *Parameter '{0}' occurs after '{1}' in the parameter list, but is used as an argument for interpolated string handler conversions. This will require the caller to reorder parameters with named arguments at the call site. Consider putting the interpolated string handler parameter after all arguments involved.*
- **CS8953**: *An interpolated string handler construction cannot use dynamic. Manually construct an instance of '{0}'.*
- **CS8976**: *Interpolated string handler conversions that reference the instance being indexed cannot be used in indexer member initializers.*
- **CS9205**: *Expected interpolated string*
- **CS9325**: *Interpolated string handler arguments are not allowed in this context.*

