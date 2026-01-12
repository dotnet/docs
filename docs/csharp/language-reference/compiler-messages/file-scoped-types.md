---
title: Resolve errors and warnings in file-scoped types
description: Learn how to diagnose and correct C# compiler errors and warnings when you declare file scoped types, or write source generators that create file scoped types.
f1_keywords:
  - "CS9051"
  - "CS9052"
  - "CS9053"
  - "CS9054"
  - "CS9056"
  - "CS9068"
  - "CS9069"
  - "CS9071"
helpviewer_keywords:
  - "CS9051"
  - "CS9052"
  - "CS9053"
  - "CS9054"
  - "CS9056"
  - "CS9068"
  - "CS9069"
  - "CS9071"
ms.date: 01/13/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings for file scoped types

The C# compiler generates errors and warnings when you declare string literals with incorrect syntax or use them in unsupported contexts. These diagnostics help you identify issues with basic string literals, character literals, raw string literals, and UTF-8 string literals.

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- **CS9051**: *File-local type cannot be used in a member signature in a non-file-local type.*
- **CS9052**: *File-local type cannot use accessibility modifiers.*
- **CS9053**: *File-local type cannot be used as a base type of non-file-local type.*
- **CS9054**: *File-local type must be defined in a top level type; it is a nested type.*
- **CS9056**: *Types and aliases cannot be named 'file'.*
- **CS9068**: *File-local type must be declared in a file with a unique path. Path is used in multiple files.*
- **CS9069**: *File-local type cannot be used because the containing file path cannot be converted into the equivalent UTF-8 byte representation.*
- **CS9071**: *The namespace already contains a definition for the type in this file.*
