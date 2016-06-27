---
title: Thread Safety in Regular Expressions
description: Thread Safety in Regular Expressions
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 33eaf2c6-d1c7-4c10-9b14-fe55b3550013
---

# Thread Safety in Regular Expressions

The [Regex](https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.Regex) class itself is thread safe and immutable (read-only). That is, [Regex](https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.Regex) objects can be created on any thread and shared between threads; matching methods can be called from any thread and never alter any global state.

However, result objects ([Match](https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.Match) and [MatchCollection)](https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.MatchCollection) returned by [Regex](https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.Regex) should be used on a single thread. Although many of these objects are logically immutable, their implementations could delay computation of some results to improve performance, and as a result, callers must serialize access to them.

If there is a need to share [Regex](https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.Regex) result objects on multiple threads, these objects can be converted to thread-safe instances by calling their synchronized methods. With the exception of enumerators, all regular expression classes are thread safe or can be converted into thread-safe objects by a synchronized method.

Enumerators are the only exception. An application must serialize calls to collection enumerators. The rule is that if a collection can be enumerated on more than one thread simultaneously, you should synchronize enumerator methods on the root object of the collection traversed by the enumerator.

