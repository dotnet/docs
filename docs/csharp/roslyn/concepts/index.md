---
title: .NET compiler SDK concepts and object model
description: This overview provides the background you need to work effectively with the .NET compiler SDK. You'll learn the API layers, the major types involved, and the overall object model.
author: billwagner
ms.author: wiwagn
ms.date: 10/10/2017
ms.topic: conceptual
ms.prod: .net
ms.devlang: devlang-csharp
ms.custom: mvc
---

# .NET Compiler SDK Concepts

The .NET Compiler SDK provides access to the deep understanding that
compilers build while processing code. Increasingly we rely on integrated
development environment (IDE) features such as IntelliSense, refactoring,
intelligent rename, "Find all references," and "Go to definition" to
increase our productivity. We rely on code analysis tools to improve our
code quality and code generators to aid in application construction. As
these tools get smarter, they need access to more and more of the deep
code knowledge that only compilers possess. This is the core mission of
the Roslyn APIs: opening up the black boxes and allowing tools and end
users to share in the wealth of information compilers have about our code.
Instead of being opaque source-code-in and object-code-out translators,
through Roslyn, compilers become platforms—APIs that you can use for code
related tasks in your tools and applications.

The .NET Compiler SDK \dramatically lowers the barrier
to entry for creating code focused tools and applications. It creates many
opportunities for innovation in areas such as meta-programming, code
generation and transformation, interactive use of the C# and VB languages,
and embedding of C# and VB in domain specific languages.

The .NET Compiler SDK Preview includes the latest language object models
for code generation, analysis, and refactoring. This section provides a
conceptual overview of the .NET Compiler SDK. Further details can be
found in the quickstarts, samples and tutorials sections.
