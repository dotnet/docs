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
# Exposing the Compiler APIs

<< Say something>>

## Compiler Pipeline Functional Areas

Roslyn exposes the C# and Visual Basic compiler’s code analysis to you
as a consumer by providing an API layer that mirrors a traditional compiler
pipeline.

![compiler pipeline](media/compiler-pipeline.png)

Each phase of this pipeline is now a separate component. First the
parse phase, where source is tokenized and parsed into syntax that follows
the language grammar. Second the declaration phase, where declarations
from source and imported metadata are analyzed to form named symbols.
Next the bind phase, where identifiers in the code are matched to symbols.
Finally, the emit phase, where all the information built up by the compiler
is emitted as an assembly.

![compiler pipeline api](media/compiler-pipeline-api.png)
 
Corresponding to each of those phases, an object model is surfaced that
allows access to the information at that phase. The parsing phase is exposed
as a syntax tree, the declaration phase as a hierarchical symbol table, the
binding phase as a model that exposes the result of the compiler’s semantic
analysis and the emit phase as an API that produces IL byte codes.

![compiler api lang service](images/compiler-pipeline-lang-svc.png)

Each compiler combines these components together as a single end-to-end whole.

To ensure that the public Compiler APIs are sufficient for building world-class
IDE features, the language services that will be used to power the C#
and VB experiences in Visual Studio vNext have been rebuilt using them. For
instance, the code outlining and formatting features use the syntax trees,
the Object Browser and navigation features use the symbol table, refactorings
and Go to Definition use the semantic model, and Edit and Continue uses all of
these, including the Emit API. These experiences may be previewed on Visual
Studio 2013 through the “Roslyn” End-User Preview. This preview is required
in order to build and test applications build on top of Roslyn SDK meant
for integration into Visual Studio though Roslyn APIs can be used in your
own applications independently of Visual Studio without requiring the
End-User Preview.

## API Layers

Roslyn consists of two main layers of APIs – the Compiler APIs and Workspaces APIs.

![api layers](media/api-layers.png)

### Compiler APIs

The compiler layer contains the object models that correspond with
information exposed at each phase of the compiler pipeline, both syntactic
and semantic. The compiler layer also contains an immutable snapshot of a
single invocation of a compiler, including assembly references, compiler
options, and source code files. There are two distinct APIs that represent
the C# language and the Visual Basic language. These two APIs are similar
in shape but tailored for high-fidelity to each individual language. This
layer has no dependencies on Visual Studio components.

### Diagnostic APIs

As part of their analysis the compiler may produce a set of diagnostics
covering everything from syntax, semantic, and definite assignment errors
to various warnings and informational diagnostics. The Compiler API layer
exposes diagnostics through an extensible API allowing for user-defined
analyzers to be plugged into a Compilation and user-defined diagnostics,
such as those produced by tools like StyleCop or FxCop, to be produced
alongside compiler-defined diagnostics. Producing diagnostics in this
way has the benefit of integrating naturally with tools such as MSBuild
and Visual Studio which depend on diagnostics for experiences such as
halting a build based on policy and showing live squiggles in the editor
and suggesting code fixes.

### Scripting APIs

As a part of the compiler layer, the team created hosting/scripting APIs
for executing code snippets and accumulating a runtime execution context.
The REPL uses these APIs.

### Workspaces APIs

The Workspaces layer contains the Workspace API, which is the starting
point for doing code analysis and refactoring over entire solutions. It
assists you in organizing all the information about the projects in a
solution into single object model, offering you direct access to the compiler
layer object models without needing to parse files, configure options or
manage project to project dependencies.

In addition, the Workspaces layer surfaces a set of commonly used APIs used
when implementing code analysis and refactoring tools that function within
a host environment like the Visual Studio IDE, such as the Find All References,
Formatting, and Code Generation APIs.

This layer has no dependencies on Visual Studio components.
