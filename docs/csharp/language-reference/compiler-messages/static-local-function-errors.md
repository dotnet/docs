---
title: "Resolve errors related to static local functions"
description: "This article helps you diagnose and correct compiler errors related to static local functions"
f1_keywords:
  - "CS8421"
helpviewer_keywords:
  - "CS8421"
ms.date: 07/16/2026
ai-usage: ai-assisted
---
# Resolve errors related to static local functions

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS8421**](#static-local-functions-cannot-capture-state): *A static local function cannot contain a reference to 'variable'.*

## Static local functions cannot capture state

- **CS8421**: *A static local function cannot contain a reference to 'variable'.*

A [`static` local function](../../programming-guide/classes-and-structs/local-functions.md) can't capture state from the enclosing scope. It can't reference enclosing local variables, parameters, instance members through `this`, or `this` itself. Pass each value the local function needs as a parameter (**CS8421**). If the local function must capture variables from the enclosing scope, remove the `static` modifier.
