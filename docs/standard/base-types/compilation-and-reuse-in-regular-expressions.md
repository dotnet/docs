---
title: "Compilation and Reuse in Regular Expressions"
description: "Learn about compilation and reuse in Regular Expressions."
ms.topic: article
ms.date: 06/11/2024
helpviewer_keywords:
  - "parsing text with regular expressions, compilation"
  - "searching with regular expressions, compilation"
  - ".NET regular expressions, engines"
  - ".NET regular expressions, compilation"
  - "regular expressions, compilation"
  - "compilation, regular expressions"
  - "pattern-matching with regular expressions, compilation"
  - "regular expressions, engines"
---
# Compilation and reuse in regular expressions

You can optimize the performance of applications that make extensive use of regular expressions by understanding how the regular expression engine compiles expressions and how regular expressions are cached. This article discusses compilation, source generation, and caching of compiled regular expressions.

## Interpreted regular expressions

By default, the regular expression engine compiles a regular expression to a sequence of internal instructions (these are high-level codes that are different from common intermediate language, or CIL). When the engine executes a regular expression, it interprets the internal codes.

## Compiled regular expressions

If a <xref:System.Text.RegularExpressions.Regex> object is constructed with the <xref:System.Text.RegularExpressions.RegexOptions.Compiled?displayProperty=nameWithType> option, it compiles the regular expression to explicit CIL code instead of high-level regular expression internal instructions. This allows .NET's just-in-time (JIT) compiler to convert the expression to native machine code for higher performance. The cost of constructing the <xref:System.Text.RegularExpressions.Regex> object may be higher, but the cost of performing matches with it is likely to be much smaller.

## Source-generated regular expressions

Source generation for regular expressions is available in .NET 7 and later versions. The source generator emits, as C# code, a custom `Regex`-derived implementation with logic similar to what `RegexOptions.Compiled` emits in IL. You get all the throughput performance benefits of `RegexOptions.Compiled` and the start-up benefits of `Regex.CompileToAssembly`, but without the complexity of `CompileToAssembly`. The source that's emitted is part of your project, which means it's also easily viewable and debuggable.

Where possible, use source-generated regular expressions instead of compiling regular expressions using the <xref:System.Text.RegularExpressions.RegexOptions.Compiled?displayProperty=nameWithType> option. For more information about source-generated regular expressions, see [.NET regular expression source generators](regular-expression-source-generators.md).

### The regular expressions cache

To improve performance, the regular expression engine maintains an application-wide cache of compiled regular expressions. The cache stores regular expression patterns that are used only in static method calls. (Regular expression patterns supplied to instance methods aren't cached.) Caching avoids the need to reparse an expression into high-level byte code each time it's used.

The maximum number of cached regular expressions is determined by the value of the `static` (`Shared` in Visual Basic) <xref:System.Text.RegularExpressions.Regex.CacheSize%2A?displayProperty=nameWithType> property. By default, the regular expression engine caches up to 15 compiled regular expressions. If the number of compiled regular expressions exceeds the cache size, the least recently used regular expression is discarded and the new regular expression is cached.

Your application can reuse regular expressions in one of the following two ways:

- By using a static method of the <xref:System.Text.RegularExpressions.Regex> object to define the regular expression. If you're using a regular expression pattern that has already been defined by another static method call, the regular expression engine will try to retrieve it from the cache. If it's not available in the cache, the engine will compile the regular expression and add it to the cache.
- By reusing an existing <xref:System.Text.RegularExpressions.Regex> object as long as its regular expression pattern is needed.

Because of the overhead of object instantiation and regular expression compilation, creating and rapidly destroying numerous <xref:System.Text.RegularExpressions.Regex> objects is an expensive process. For applications that use a large number of different regular expressions, you can optimize performance by using calls to static `Regex` methods and possibly by increasing the size of the regular expression cache.

## See also

- [.NET regular expression source generators](regular-expression-source-generators.md)
- [.NET regular expressions](regular-expressions.md)
