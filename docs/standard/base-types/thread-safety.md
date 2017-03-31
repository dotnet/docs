---
title: Thread safety in regular expressions
description: Thread safety in regular expressions
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/28/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: dc64b681-b3aa-4911-8e30-0764a8b6a852
---

# Thread safety in regular expressions

The [Regex](xref:System.Text.RegularExpressions.Regex) class itself is thread safe and immutable (read-only). That is, [Regex](xref:System.Text.RegularExpressions.Regex) objects can be created on any thread and shared between threads; matching methods can be called from any thread and never alter any global state.

However, result objects ([Match](xref:System.Text.RegularExpressions.Match) and [MatchCollection)](xref:System.Text.RegularExpressions.MatchCollection) returned by [Regex](xref:System.Text.RegularExpressions.Regex) should be used on a single thread. Although many of these objects are logically immutable, their implementations could delay computation of some results to improve performance, and as a result, callers must serialize access to them.

If there is a need to share [Regex](xref:System.Text.RegularExpressions.Regex) result objects on multiple threads, these objects can be converted to thread-safe instances by calling their synchronized methods. With the exception of enumerators, all regular expression classes are thread safe or can be converted into thread-safe objects by a synchronized method.

Enumerators are the only exception. An application must serialize calls to collection enumerators. The rule is that if a collection can be enumerated on more than one thread simultaneously, you should synchronize enumerator methods on the root object of the collection traversed by the enumerator.

## See Also

[.NET regular expressions](regular-expressions.md)

