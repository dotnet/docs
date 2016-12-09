---
title: Compilation and reuse in regular expressions
description: Compilation and reuse in regular expressions
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/28/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 3adea434-e2ed-4023-b4f5-b0608b4cf53f
---

# Compilation and reuse in regular expressions

You can optimize the performance of applications that make extensive use of regular expressions by understanding how the regular expression engine compiles expressions and by understanding how regular expressions are cached. This topic discusses both compilation and caching.

## Compiled Regular Expressions

By default, the regular expression engine compiles a regular expression to a sequence of internal instructions (these are high-level codes that are different from Microsoft intermediate language, or MSIL). When the engine executes a regular expression, it interprets the internal codes.

If a [Regex](xref:System.Text.RegularExpressions.Regex) object is constructed with the [RegexOptions.Compiled](xref:System.Text.RegularExpressions.RegexOptions.Compiled) option, it compiles the regular expression to explicit MSIL code instead of high-level regular expression internal instructions. This allows .NET's just-in-time (JIT) compiler to convert the expression to native machine code for higher performance.

However, generated MSIL cannot be unloaded. The only way to unload code is to unload an entire application domain (that is, to unload all of your application's code.). Effectively, once a regular expression is compiled with the [RegexOptions.Compiled](xref:System.Text.RegularExpressions.RegexOptions.Compiled) option, .NET never releases the resources used by the compiled expression, even if the regular expression was created by a [Regex](xref:System.Text.RegularExpressions.Regex) object that is itself released to garbage collection.

You must be careful to limit the number of different regular expressions you compile with the [RegexOptions.Compiled](xref:System.Text.RegularExpressions.RegexOptions.Compiled) option to avoid consuming too many resources. If an application must use a large or unbounded number of regular expressions, each expression should be interpreted, not compiled. However, if a small number of regular expressions are used repeatedly, they should be compiled with [RegexOptions.Compiled](xref:System.Text.RegularExpressions.RegexOptions.Compiled) for better performance. 

## The Regular Expressions Cache

To improve performance, the regular expression engine maintains an application-wide cache of compiled regular expressions. The cache stores regular expression patterns that are used only in static method calls. (Regular expression patterns supplied to instance methods are not cached.) This avoids the need to reparse an expression into high-level byte code each time it is used.

The maximum number of cached regular expressions is determined by the value of the `static` (`Shared` in Visual Basic) [Regex.CacheSize](xref:System.Text.RegularExpressions.Regex.CacheSize) property. By default, the regular expression engine caches up to 15 compiled regular expressions. If the number of compiled regular expressions exceeds the cache size, the least recently used regular expression is discarded and the new regular expression is cached. 

Your application can take advantage of precompiled regular expressions in one of the following two ways:

* By using a static method of the [Regex](xref:System.Text.RegularExpressions.Regex) object to define the regular expression. If you are using a regular expression pattern that has already been defined in another static method call, the regular expression engine will retrieve it from the cache. If not, the engine will compile the regular expression and add it to the cache.

* By reusing an existing [Regex](xref:System.Text.RegularExpressions.Regex) object as long as its regular expression pattern is needed.


Because of the overhead of object instantiation and regular expression compilation, creating and rapidly destroying numerous [Regex](xref:System.Text.RegularExpressions.Regex) objects is a very expensive process. For applications that use a large number of different regular expressions, you can optimize performance by using calls to static [Regex](xref:System.Text.RegularExpressions.Regex) methods and possibly by increasing the size of the regular expression cache.

## See Also

[.NET regular expressions](regular-expressions.md)

