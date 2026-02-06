---
title: Resolve errors and warnings for string interpolation expressions
description: Learn how to diagnose and correct C# compiler errors and warnings when you use string interpolation expressions, where expressions are substituted for placeholders in a string literal.
f1_keywords:
  - "CS8941"
  - "CS8942"
  - "CS8946"
  - "CS8947"
  - "CS8953"
  - "CS8976"
helpviewer_keywords:
  - "CS8941"
  - "CS8942"
  - "CS8946"
  - "CS8947"
  - "CS8953"
  - "CS8976"
ms.date: 02/06/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings for string interpolation expressions

The C# compiler generates errors and warnings when you declare string literals with incorrect syntax or use them in unsupported contexts. These diagnostics help you identify issues with basic string literals, character literals, raw string literals, and UTF-8 string literals.

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- **CS8941**: *Interpolated string handler method is malformed. It does not return 'void' or 'bool'.*
- **CS8942**: *Interpolated string handler method has inconsistent return type.*
- **CS8946**: *Type is not an interpolated string handler type.*
- **CS8947**: *Parameter occurs after another parameter in the parameter list, but is used as an argument for interpolated string handler conversions.*
- **CS8953**: *An interpolated string handler construction cannot use dynamic.*
- **CS8976**: *Interpolated string handler conversions that reference the instance being indexed cannot be used in indexer member initializers.*

