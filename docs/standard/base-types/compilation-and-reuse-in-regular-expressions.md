---
title: "Compilation and Reuse in Regular Expressions | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "parsing text with regular expressions, compilation"
  - "searching with regular expressions, compilation"
  - ".NET Framework regular expressions, engines"
  - ".NET Framework regular expressions, compilation"
  - "regular expressions, compilation"
  - "compilation, regular expressions"
  - "pattern-matching with regular expressions, compilation"
  - "regular expressions, engines"
ms.assetid: 182ec76d-5a01-4d73-996c-0b0d14fcea18
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Compilation and Reuse in Regular Expressions
You can optimize the performance of applications that make extensive use of regular expressions by understanding how the regular expression engine compiles expressions and by understanding how regular expressions are cached. This topic discusses both compilation and caching.  
  
## Compiled Regular Expressions  
 By default, the regular expression engine compiles a regular expression to a sequence of internal instructions (these are high-level codes that are different from Microsoft intermediate language, or MSIL). When the engine executes a regular expression, it interprets the internal codes.  
  
 If a <xref:System.Text.RegularExpressions.Regex> object is constructed with the <xref:System.Text.RegularExpressions.RegexOptions?displayProperty=fullName> option, it compiles the regular expression to explicit MSIL code instead of high-level regular expression internal instructions. This allows the.NET Framework's just-in-time (JIT) compiler to convert the expression to native machine code for higher performance.  
  
 However, generated MSIL cannot be unloaded. The only way to unload code is to unload an entire application domain (that is, to unload all of your application's code.). Effectively, once a regular expression is compiled with the <xref:System.Text.RegularExpressions.RegexOptions?displayProperty=fullName> option, the .NET Framework never releases the resources used by the compiled expression, even if the regular expression was created by a <xref:System.Text.RegularExpressions.Regex> object that is itself released to garbage collection.  
  
 You must be careful to limit the number of different regular expressions you compile with the <xref:System.Text.RegularExpressions.RegexOptions?displayProperty=fullName> option to avoid consuming too many resources. If an application must use a large or unbounded number of regular expressions, each expression should be interpreted, not compiled. However, if a small number of regular expressions are used repeatedly, they should be compiled with <xref:System.Text.RegularExpressions.RegexOptions?displayProperty=fullName> for better performance. An alternative is to use precompiled regular expressions. You can compile all of your expressions into a reusable DLL by using the <xref:System.Text.RegularExpressions.Regex.CompileToAssembly%2A> method. This avoids the need to compile at runtime while still benefiting from the speed of compiled regular expressions.  
  
## The Regular Expressions Cache  
 To improve performance, the regular expression engine maintains an application-wide cache of compiled regular expressions. The cache stores regular expression patterns that are used only in static method calls. (Regular expression patterns supplied to instance methods are not cached.) This avoids the need to reparse an expression into high-level byte code each time it is used.  
  
 The maximum number of cached regular expressions is determined by the value of the `static` (`Shared` in Visual Basic) <xref:System.Text.RegularExpressions.Regex.CacheSize%2A?displayProperty=fullName> property. By default, the regular expression engine caches up to 15 compiled regular expressions. If the number of compiled regular expressions exceeds the cache size, the least recently used regular expression is discarded and the new regular expression is cached.  
  
> [!IMPORTANT]
>  The way that regular expressions are cached in the .NET Framework version 2.0 differs significantly from the .NET Framework versions 1.0 and 1.1. In the .NET Framework 1.0 and 1.1, all regular expressions, both those used in static method calls and those used in instance method calls, are cached. The cache is automatically expanded to store new regular expressions. In the .NET Framework 2.0, only regular expressions used in static method calls are cached. By default, the last 15 regular expressions are cached, although the size of the cache can be adjusted by setting the value of the <xref:System.Text.RegularExpressions.Regex.CacheSize%2A> property.  
  
 Your application can take advantage of precompiled regular expressions in one of the following two ways:  
  
-   By using a static method of the <xref:System.Text.RegularExpressions.Regex> object to define the regular expression. If you are using a regular expression pattern that has already been defined in another static method call, the regular expression engine will retrieve it from the cache. If not, the engine will compile the regular expression and add it to the cache.  
  
-   By reusing an existing <xref:System.Text.RegularExpressions.Regex> object as long as its regular expression pattern is needed.  
  
 Because of the overhead of object instantiation and regular expression compilation, creating and rapidly destroying numerous <xref:System.Text.RegularExpressions.Regex> objects is a very expensive process. For applications that use a large number of different regular expressions, you can optimize performance by using calls to static `Regex` methods and possibly by increasing the size of the regular expression cache.  
  
## See Also  
 [.NET Framework Regular Expressions](../../../docs/standard/base-types/regular-expressions.md)