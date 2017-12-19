---
title: Work with the .NET Compiler Platform SDK semantic model
description: This overview provides an understanding of the type you use to understand and manipulate the semantic model of your code.
author: billwagner
ms.author: wiwagn
ms.date: 10/15/2017
ms.topic: conceptual
ms.prod: .net
ms.devlang: devlang-csharp
ms.custom: mvc
---

# Work with semantics

[Syntax trees](work-with-syntax.md) represent the lexical and syntactic structure of source code. Although this information alone is enough to describe all the declarations and logic in the source, it is not enough information to identify what is being referenced. A name
may represent:

- a type
- a field
- a method
- a local variable

Although each of these is uniquely different, determining which one an identifier actually refers to often requires a deep understanding of the language rules. 

There are program elements represented in source code, and programs can also refer to previously compiled libraries, packaged in assembly files. Although no source code, and therefore no syntax nodes or trees, are available for assemblies, programs can still refer to elements inside them.

For those tasks, you need the **Semantic model**.

In addition to a syntactic model of the source code, a semantic model encapsulates the language rules, giving you an easy way to correctly match identifiers with the correct program element being referenced.

## Compilation

A compilation is a representation of everything needed to compile a C# or Visual Basic program, which includes all the assembly references, compiler options, and source files. 

Because all this information is in one place, the elements contained in the source code can be described in more detail. The compilation represents each declared type, member, or variable as a symbol. The compilation contains a variety of methods that help you find and relate the symbols that have either been declared in the source code or imported as metadata from an assembly.

Similar to syntax trees, compilations are immutable. After you create a compilation, it cannot be changed by you or anyone else you might be sharing it with. However, you can create a new compilation from an existing compilation, specifying a change as you do so. For example, you might create a compilation that is the same in every way as an existing compilation, except it may include an additional source file or assembly reference.

## Symbols

A symbol represents a distinct element declared by the source code or imported from an assembly as metadata. Every namespace, type, method, property, field, event, parameter, or local variable is represented by a symbol. 

A variety of methods and properties on the <xref:Microsoft.CodeAnalysis.Compilation> type help you find symbols. For example, you can find a symbol for a declared type by its common metadata name. You can also access the entire symbol table as a tree of symbols rooted by the global namespace.

Symbols also contain additional information that the compiler determines from the source or metadata, such as other referenced symbols. Each kind of symbol is represented by a separate interface derived from <xref:Microsoft.CodeAnalysis.ISymbol>, each with its own methods and properties detailing the information the compiler has gathered. Many of these properties directly reference other symbols. For example, the <xref:Microsoft.CodeAnalysis.IMethodSymbol.ReturnType?displayProperty=nameWithType> property
tells you the actual type symbol that the method declaration references.

Symbols present a common representation of namespaces, types, and members, between source code and metadata. For example, a method that was declared in source code and a method that was imported from metadata are both represented by an <xref:Microsoft.CodeAnalysis.IMethodSymbol> with the same properties.

Symbols are similar in concept to the CLR type system as represented by the <xref:System.Reflection> API, yet they are richer in that they model more than just types. Namespaces, local variables, and labels are all symbols. In addition, symbols are a representation of language concepts, not CLR concepts. There is a lot of overlap, but there are many meaningful distinctions as well. For instance, an iterator method in C# or Visual Basic is a single symbol. However, when the iterator method is translated to CLR metadata, it is a type and multiple methods.

## Semantic model

A semantic model represents all the semantic information for a single source file. You can use it to discover the following: 

* The symbols referenced at a specific location in source.
* The resultant type of any expression.
* All diagnostics, which are errors and warnings.
* How variables flow in and out of regions of source.
* The answers to more speculative questions.
