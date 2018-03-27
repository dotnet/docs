---
title: The .NET Compiler Platform SDK (Roslyn APIs)
description: Learn to use the .NET Compiler Platform SDK (also called the Roslyn APIs) to understand .NET code, spot errors, and fix those errors.
keywords: roslyn, analyzer, code fix
author: billwagner
ms.author: wiwagn
ms.date: 10/10/2017
ms.topic: conceptual
ms.prod: .net
ms.devlang: devlang-csharp
ms.custom: mvc
---

# The .NET Compiler Platform SDK

Compilers build a detailed model of application code as they validate the
syntax and semantics of that code. They use this model to build the
executable output from the source code. The .NET Compiler Platform SDK provides
access to this model. Increasingly, we rely on integrated
development environment (IDE) features such as IntelliSense, refactoring,
intelligent rename, "Find all references," and "Go to definition" to
increase our productivity. We rely on code analysis tools to improve our
code quality, and code generators to aid in application construction. As
these tools get smarter, they need access to more and more of the model
that only compilers create as they process application code. This is the core mission of
the Roslyn APIs: opening up the black boxes and allowing tools and end
users to share in the wealth of information compilers have about our code.
Instead of being opaque source-code-in and object-code-out translators,
through Roslyn, compilers become platforms: APIs that you can use for
code-related tasks in your tools and applications.

## .NET Compiler Platform SDK concepts

The .NET Compiler Platform SDK dramatically lowers the barrier
to entry for creating code focused tools and applications. It creates many
opportunities for innovation in areas such as meta-programming, code
generation and transformation, interactive use of the C# and VB languages,
and embedding of C# and VB in domain specific languages.

The .NET Compiler Platform SDK enables you to build ***analyzers*** and 
***code fixes*** that find and correct coding mistakes. ***Analyzers***
understand the syntax and structure of code and detect practices that
should be corrected. ***Code fixes*** provide one or more suggested fixes
for addressing coding mistakes found by analyzers. Typically, an analyzer
and the associated code fixes are packaged together in a single project. 

Analyzers and code fixes use static analysis to understand code. They
do not run the code or provide other testing benefits. They can, however,
point out practices that often lead to bugs, unmaintanable code, or
standard guideline validation.

The .NET Compiler Platform SDK provides a single set of APIs that enable
you to examine and understand a C# or Visual Basic codebase. Because you
can use this single codebase, you can write analyzers and code fixes more
easily by leveraging the syntactic and semantic analysis APIs provided by
the .NET Compiler Platform SDK. Freed from the large task of replicating
the anaysis done by the compiler, you can concentrate on the more focused
task of finding and fixing common coding errors for your project or library.

A smaller benefit is that your analyzers and code fixes are smaller and
use much less memory when loaded in Visual Studio than they would
if you wrote your own codebase to understand the code in a project. By
leveraging the same classes used by the compiler and Visual Studio, you
can create your own static analysis tools. This means your team
can use analyzers and code fixes without a noticeable impact on the IDE's
performance.

There are three main scenarios for writing analyzers and code fixes:

1. [*Enforce team coding standards*](#enforce-team-coding-standards)
1. [*Provide guidance with library packages*](#provide-guidance-with-library-packages)
1. [*Provide general coding guidance*](#provide-general-coding-guidance)

## Enforce team coding standards

Many teams have coding standards that are enforced through code reviews
with other team members. Analyzers and code fixes can make this process
much more efficient. Code reviews happen when a developer shares his work
with others on the team. He will have invested all the time needed to
complete a new feature before getting any comments. Weeks may go by
while he reinforces habits that don't match the team's practices.

Analyzers run as a developer writes code. He gets immediate feedback that
encourages following the guidance immediately. He builds habits to write
compliant code as soon as he begins prototyping. When the feature is
ready for humans to review, all the standard guidance has been enforced.

Teams can build analyzers and code fixes that look for the most common
practices that violate team coding practices. These can be installed on
each developer's machine to enforce the standards.

## Provide guidance with library packages

There are a wealth of libraries available for .NET developers on NuGet.
Some of these come from Microsoft, some from third-party companies, and
others from community members and volunteers. These libraries get more
adoption and higher reviews when developers can succeed with those
libraries.

In addition to providing documentation, you can provide analyzers and
code fixes that find and correct common mis-uses of your library. These
immediate corrections will help developers succeed more quickly. 

You can package analyzers and code fixes with your library on NuGet. In that
scenario, every developer who installs your NuGet package will also install
the analyzer package. All developers using your library will immediately
get guidance from your team in the form of immediate feedback on mistakes
and suggested corrections.

## Provide general guidance

The .NET developer community has discovered through experience patterns that
work well and patterns that are best avoided. Several community members
have created analyzers that enforce those recommended patterns. As we learn
more, there is always room for new ideas.

These analyzers can be uploaded to the 
[Visual Studio Marketplace](https://marketplace.visualstudio.com/vs) and downloaded
by developers using Visual Studio. Newcomers to the language and the platform
learn accepted practices quickly and become productive earlier in their .NET
journey. As these become more widely used, the community adopts these
practices.

## Next steps

The .NET Compiler Platform SDK includes the latest language object models
for code generation, analysis, and refactoring. This section provides a
conceptual overview of the .NET Compiler Platform SDK. Further details can be
found in the quickstarts, samples and tutorials sections.

You can learn more about the concepts in the .NET Compiler Platform SDK in these four topics:

 - [Explore code with the syntax visualizer](syntax-visualizer.md)
 - [Understand the compiler API model](compiler-api-model.md)
 - [Work with syntax](work-with-syntax.md)
 - [Work with semantics](work-with-semantics.md)
 - [Work with a workspace](work-with-workspace.md)
 
To get started, you'll need to install the **.NET Compiler Platform SDK**:

[!INCLUDE[interactive-note](~/includes/roslyn-installation.md)]

<!--

Turn this on as more of the conceptual content is in place:
- Try the [Quickstarts](quickstart/index.md) to create your first tutorial.
- Experiment with one of the [Tutorials](tutorials/index.md).
- Explore the [Samples](samples/index.md) to see some simple analyzers.
- Read the [Concepts](concepts/index.md) to understand the ideas behind analyzers and code fixes.

-->
