---
title: "Resolve errors and warnings related to async enumerables, enumerables, and `foreach` statements"
description: "This article helps you diagnose and correct compiler errors and warnings related to async enumerables, enumerables, and foreach statements"
f1_keywords:
  - "CS8412"
  - "CS8413"
  - "CS8414"
  - "CS8415"
  - "CS8419"
  - "CS8420"
  - "CS8424"
  - "CS8425"
  - "CS8426"
helpviewer_keywords:
  - "CS8412"
  - "CS8413"
  - "CS8414"
  - "CS8415"
  - "CS8419"
  - "CS8420"
  - "CS8424"
  - "CS8425"
  - "CS8426"
ms.date: 07/13/2026
ai-usage: ai-assisted
---

# Resolve errors and warnings for `foreach` statements and async enumerables

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

- [**CS8412**](#anchor-tbd): *Asynchronous foreach requires that the return type 'type' of 'method' must have a suitable public 'MoveNextAsync' method and public 'Current' property*
- [**CS8413**](#anchor-tbd): *Asynchronous foreach statement cannot operate on variables of type 'type' because it implements multiple instantiations of 'interface'; try casting to a specific interface instantiation*
- [**CS8414**](#anchor-tbd): *foreach statement cannot operate on variables of type 'type' because 'type' does not contain a public instance or extension definition for 'member'. Did you mean 'await foreach' rather than 'foreach'?*
- [**CS8415**](#anchor-tbd): *Asynchronous foreach statement cannot operate on variables of type 'type' because 'type' does not contain a public instance or extension definition for 'member'. Did you mean 'foreach' rather than 'await foreach'?*
- [**CS8419**](#anchor-tbd): *The body of an async-iterator method must contain a 'yield' statement.*
- [**CS8420**](#anchor-tbd): *The body of an async-iterator method must contain a 'yield' statement. Consider removing 'async' from the method declaration or adding a 'yield' statement.*
- [**CS8424**](#anchor-tbd): *The EnumeratorCancellationAttribute applied to parameter 'name' will have no effect. The attribute is only effective on a parameter of type CancellationToken in an async-iterator method returning IAsyncEnumerable*
- [**CS8425**](#anchor-tbd): *Async-iterator 'method' has one or more parameters of type 'CancellationToken' but none of them is decorated with the 'EnumeratorCancellation' attribute, so the cancellation token parameter from the generated 'IAsyncEnumerable<>.GetAsyncEnumerator' will be unconsumed*
- [**CS8426**](#anchor-tbd): *The attribute [EnumeratorCancellation] cannot be used on multiple parameters*
