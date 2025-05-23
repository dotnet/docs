---
title: Errors and warnings for string literal declarations
description: This article helps you diagnose and correct compiler errors and warnings when you declare string literals as constants or variables.
f1_keywords:
  - "CS9274"
helpviewer_keywords:
  - "CS9274"
ms.date: 05/23/2025
---
# Errors and warnings for string literal declarations

There are a few *errors* related to declaring string constants or string literals.

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS9274**](#constant-declarations): *Cannot emit this string literal into the data section because it has XXHash128 collision with another string literal.*

## Constant declarations

- [**CS9274**](#constant-declarations): *Cannot emit this string literal into the data section because it has XXHash128 collision with another string literal.*

These errors indicate that your declaration can't be emitted in the data section. Turn this feature off for your application.