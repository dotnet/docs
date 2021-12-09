---
description: "C# reference"
title: "C# reference"
ms.date: 01/13/2021
ms.custom: "updateeachrelease"
f1_keywords: 
  - _CSharpKeyword
helpviewer_keywords: 
  - "Visual C#, language reference"
  - "language reference [C#]"
  - "Programmer's Reference for C#"
  - "C# language, reference"
  - "reference, C# language"
ms.assetid: 06de3167-c16c-4e1a-b3c5-c27841d4569a
---
# C# reference

This section provides reference material about C# keywords, operators, special characters, preprocessor directives, compiler options, and compiler errors and warnings.  
  
## In this section

 [C# Keywords](./keywords/index.md)  
 Provides links to information about C# keywords and syntax.  
  
 [C# Operators](./operators/index.md)  
 Provides links to information about C# operators and syntax.  

 [C# Special Characters](./tokens/index.md)  
 Provides links to information about special contextual characters in C# and their usage.  

 [C# Preprocessor Directives](preprocessor-directives.md)  
 Provides links to information about compiler commands for embedding in C# source code.  
  
 [C# Compiler Options](./compiler-options/index.md)  
 Includes information about compiler options and how to use them.  
  
 [C# Compiler Errors](./compiler-messages/index.md)  
 Includes code snippets that demonstrate the cause and correction of C# compiler errors and warnings.  
  
 [C# Language Specification](~/_csharplang/spec/introduction.md)  
 The C# 6.0 language specification. This is a draft proposal for the C# 6.0 language. This document will be refined through work with the ECMA C# standards committee. Version 5.0 has been released in December 2017 as the [Standard ECMA-334 5th Edition](https://www.ecma-international.org/wp-content/uploads/ECMA-334_5th_edition_december_2017.pdf) document.

The features that have been implemented in C# versions after 6.0 are represented in language specification proposals. These documents describe the deltas to the language spec in order to add these new features. These are in draft proposal form. These specifications will be refined and submitted to the ECMA standards committee for formal review and incorporation into a future version of the C# Standard.

 [C# 7.0 Specification Proposals](~/_csharplang/proposals/csharp-7.0/pattern-matching.md)  
 There are a number of new features implemented in C# 7.0. They include pattern matching, local functions, out variable declarations, throw expressions, binary literals, and digit separators. This folder contains the specifications for each of those features.
  
 [C# 7.1 Specification Proposals](~/_csharplang/proposals/csharp-7.1/async-main.md)  
 There are new features added in C# 7.1. First, you can write a `Main` method that returns `Task` or `Task<int>`. This enables you to add the `async` modifier to `Main`. The `default` expression can be used without a type in locations where the type can be inferred. Also, tuple member names can be inferred. Finally, pattern matching can be used with generics.

 [C# 7.2 Specification Proposals](~/_csharplang/proposals/csharp-7.2/readonly-ref.md)  
 C# 7.2 added a number of small features. You can pass arguments by readonly reference using the `in` keyword. There are a number of low-level changes to support compile-time safety for `Span` and related types. You can use named arguments where later arguments are positional, in some situations. The `private protected` access modifier enables you to specify that callers are limited to derived types implemented in the same assembly. The `?:` operator can resolve to a reference to a variable. You can also format hexadecimal and binary numbers using a leading digit separator.

 [C# 7.3 Specification Proposals](~/_csharplang/proposals/csharp-7.3/blittable.md)  
 C# 7.3 is another point release that includes several small updates. You can use new constraints on generic type parameters. Other changes make it easier to work with `fixed` fields, including using [`stackalloc`](./operators/stackalloc.md) allocations. Local variables declared with the `ref` keyword may be reassigned to refer to new storage. You can place attributes on auto-implemented properties that target the compiler-generated backing field. Expression variables can be used in initializers. Tuples can be compared for equality (or inequality). There have also been some improvements to overload resolution.
  
 [C# 8.0 Specification Proposals](~/_csharplang/proposals/csharp-8.0/nullable-reference-types.md)  
 C# 8.0 is available with .NET Core 3.0. The features include nullable reference types, recursive pattern matching, default interface methods, async streams, ranges and indexes, pattern based using and using declarations, null coalescing assignment, and readonly instance members.

 [C# 9 Specification Proposals](~/_csharplang/proposals/csharp-9.0/records.md)  
 C# 9 is available with .NET 5. The features include records, top-level statements, pattern matching enhancements, init only setters, target-typed new expressions, module initializers, extending partial methods, static anonymous functions, target-typed conditional expressions, covariant return types, extension GetEnumerator in foreach loops, lambda discard parameters, attributes on local functions, native sized integers, function pointers, suppress emitting localsinit flag, and unconstrained type parameter annotations.

[C# 10 Specification Proposals](~/_csharplang/proposals/csharp-10.0/record-structs.md)\
C# 10 is available with .NET 6. The features include record structs, parameterless struct constructors, global using directives, file-scoped namespaces, extended property patterns, improved interpolated strings, constant interpolated strings, lambda improvements, caller-argument expression, enhanced `#line` directives, generic attributes, improved definite assignment analysis, and `AsyncMethodBuilder` override.

## Related sections  

 [Using the Visual Studio Development Environment for C#](/visualstudio/get-started/csharp)  
 Provides links to conceptual and task topics that describe the IDE and Editor.  
  
 [C# Programming Guide](../programming-guide/index.md)  
 Includes information about how to use the C# programming language.
