---
title: "Resolve errors related to parsing C# code"
description: "This article helps you diagnose and correct compiler errors related to parsing C# code"
f1_keywords:
  - "CS8180"
  - "CS8300"
  - "CS8635"
  - "CS8641"
helpviewer_keywords:
  - "CS8180"
  - "CS8300"
  - "CS8635"
  - "CS8641"
ms.date: 09/23/2026
ai-usage: ai-assisted
---
# Resolve errors related to parsing C# code

This article covers lexer and parser-stage diagnostics for incomplete declarations, unexpected character sequences, unexpected tokens, merge conflict markers, and malformed statement structure. It isn't a general syntax-error catalog.

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS8180**](#incomplete-accessor-declarations): *{ or ; or => expected*
- [**CS8300**](#merge-conflict-markers): *Merge conflict marker encountered*
- [**CS8635**](#unexpected-parser-stage-tokens-and-statements): *Unexpected character sequence '...'*
- [**CS8641**](#unexpected-parser-stage-tokens-and-statements): *'else' cannot start a statement.*

## Incomplete accessor declarations

- **CS8180**: *{ or ; or => expected*

The parser found an incomplete property, indexer, or event accessor declaration. After an accessor such as `get`, `set`, `init`, `add`, or `remove`, provide the form allowed in that declaration: a block body (`{ ... }`), a semicolon (`;`), or an expression body (`=> expression;`). Don't assume that every form is valid in every context; for example, a semicolon-only accessor is used for an automatically implemented or abstract member. Fix this error first because parser recovery can produce additional errors after the incomplete accessor.

```csharp
class Example
{
    int Value { get } // CS8180: add a body, semicolon, or expression body.
}
```

## Merge conflict markers

- **CS8300**: *Merge conflict marker encountered*

The source file contains an unresolved version-control merge conflict marker, such as `<<<<<<<`, `=======`, or `>>>>>>>`. The compiler recognizes the marker, reports **CS8300**, and continues recovery. Content within the unresolved region can still produce additional diagnostics for invalid tokens or syntax. Review both sides of every conflict, choose or combine the intended code, and remove all conflict markers before compiling. Don't merely comment out the markers or blindly keep one side, because either action can leave incorrect or duplicate code.

## Unexpected parser-stage tokens and statements

- **CS8635**: *Unexpected character sequence '...'*
- **CS8641**: *'else' cannot start a statement.*

The lexer and parser require token sequences that form valid C# statements. Remove a stray `...` sequence (**CS8635**). If you intended a range expression, use two dots (`..`). If the dots are part of other text, put that text in a string literal or comment.

An `else` clause must immediately follow the matching [`if` statement](../statements/selection-statements.md#the-if-statement) (**CS8641**). Restructure the code so `else` doesn't begin a statement. Add the missing `if`, remove the unmatched `else`, or move intervening statements inside the intended `if` or `else` block.
