---
title: .NET compiler SDK concepts and object model | Microsoft Docs 
description: This overview provides the background you need to work effectively with the .NET compiler SDK. You'll learn the API layers, the major types involved, and the overall object model.
keywords: Roslyn, C#, Compiler, SDK, analyzer, codefix
author: billwagner
ms.author: wiwagn
ms.date: 10/10/2017
ms.topic: conceptual
ms.prod: .net
ms.devlang: devlang-csharp
ms.custom: mvc
---

# .NET Compiler SDK Concepts

Traditionally, compilers are black boxes -- source code goes in one end,
magic happens in the middle, and object files or assemblies come out the
other end. As compilers perform their magic, they build up deep understanding
of the code they are processing, but that knowledge is unavailable to anyone
but the compiler implementation wizards.  The information is promptly
forgotten after the translated output is produced.

For decades, this world view has served us well, but it is no longer sufficient.
Increasingly we rely on integrated development environment (IDE) features
such as IntelliSense, refactoring, intelligent rename, "Find all references,"
and "Go to definition" to increase our productivity. We rely on code analysis
tools to improve our code quality and code generators to aid in application
construction. As these tools get smarter, they need access to more and more
of the deep code knowledge that only compilers possess. This is the core
mission of Roslyn: opening up the black boxes and allowing tools and end
users to share in the wealth of information compilers have about our code.
Instead of being opaque source-code-in and object-code-out translators,
through Roslyn, compilers become platforms—APIs that you can use for code
related tasks in your tools and applications.

The transition to compilers as platforms dramatically lowers the barrier
to entry for creating code focused tools and applications. It creates many
opportunities for innovation in areas such as meta-programming, code
generation and transformation, interactive use of the C# and VB languages,
and embedding of C# and VB in domain specific languages.

Roslyn SDK Preview includes the latest drafts of new language object models
for code generation, analysis, and refactoring. We hope to include drafts
of API support for scripting and interactive use of C# and Visual Basic in
a future preview. This document provides a conceptual overview of Roslyn.
Further details can be found in the walkthroughs and samples included in the SDK Preview.
