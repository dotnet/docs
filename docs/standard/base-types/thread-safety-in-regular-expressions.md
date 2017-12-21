---
title: "Thread Safety in Regular Expressions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - ".NET Framework regular expressions, threads"
  - "regular expressions, threads"
  - "searching with regular expressions, threads"
  - "parsing text with regular expressions, threads"
  - "pattern-matching with regular expressions, threads"
ms.assetid: 7c4a167b-5236-4cde-a2ca-58646230730f
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Thread Safety in Regular Expressions
The <xref:System.Text.RegularExpressions.Regex> class itself is thread safe and immutable (read-only). That is, **Regex** objects can be created on any thread and shared between threads; matching methods can be called from any thread and never alter any global state.  
  
 However, result objects (**Match** and **MatchCollection**) returned by **Regex** should be used on a single thread. Although many of these objects are logically immutable, their implementations could delay computation of some results to improve performance, and as a result, callers must serialize access to them.  
  
 If there is a need to share **Regex** result objects on multiple threads, these objects can be converted to thread-safe instances by calling their synchronized methods. With the exception of enumerators, all regular expression classes are thread safe or can be converted into thread-safe objects by a synchronized method.  
  
 Enumerators are the only exception. An application must serialize calls to collection enumerators. The rule is that if a collection can be enumerated on more than one thread simultaneously, you should synchronize enumerator methods on the root object of the collection traversed by the enumerator.  
  
## See Also  
 [.NET Regular Expressions](../../../docs/standard/base-types/regular-expressions.md)
