---
title: "Resolve errors related to parsing C# code"
description: "This article helps you diagnose and correct compiler errors related to parsing C# code"
f1_keywords:
  - "CS8635"
  - "CS8641"
helpviewer_keywords:
  - "CS8635"
  - "CS8641"
ms.date: 07/16/2026
ai-usage: ai-assisted
---
# Resolve errors related to parsing C# code

This article covers lexer and parser-stage diagnostics for unexpected character sequences, unexpected tokens, and malformed statement structure. It isn't a general syntax-error catalog.

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS8635**](#unexpected-parser-stage-tokens-and-statements): *Unexpected character sequence '...'*
- [**CS8641**](#unexpected-parser-stage-tokens-and-statements): *'else' cannot start a statement.*

## Unexpected parser-stage tokens and statements

- **CS8635**: *Unexpected character sequence '...'*
- **CS8641**: *'else' cannot start a statement.*

The lexer and parser require token sequences that form valid C# statements. Remove a stray `...` sequence (**CS8635**). If you intended a range expression, use two dots (`..`). If the dots are part of other text, put that text in a string literal or comment.

An `else` clause must immediately follow the matching [`if` statement](../statements/selection-statements.md#the-if-statement) (**CS8641**). Restructure the code so `else` doesn't begin a statement. Add the missing `if`, remove the unmatched `else`, or move intervening statements inside the intended `if` or `else` block.
