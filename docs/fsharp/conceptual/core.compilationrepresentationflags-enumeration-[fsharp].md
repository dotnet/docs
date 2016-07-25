---
title: Core.CompilationRepresentationFlags Enumeration (F#)
description: Core.CompilationRepresentationFlags Enumeration (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b9d186dc-c4ac-4750-8f94-91a5a5c08a84 
---

# Core.CompilationRepresentationFlags Enumeration (F#)

Indicates one or more adjustments to the compiled representation of an F# type or member.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<Flags>]
type CompilationRepresentationFlags =
| None = 0
| Static = 1
| Instance = 2
| ModuleSuffix = 4
| UseNullAsTrueValue = 8
| Event
```

## Remarks
The following table shows the possible values and their meaning.


|Value|Description|
|-----|-----------|
|None|No special compilation representation.|
|Static|Compile an instance member as static.|
|Instance|Compile a member as instance even if null is used as a representation for this type.|
|ModuleSuffix|Append **Module** to the end of a module whose name clashes with a type name in the same namespace.|
|UseNullAsTrueValue|Permit the use of null as a representation for nullary discriminators in a discriminated union.|
|Event|Compile a property as a Common Language Infrastructure (CLI) event.|

This enumeration is often used with the [CompilationRepresentationAttribute](core.compilationrepresentationattribute-class-%5bfsharp%5d.md):

[!code-fsharp[Main](snippets/fscorelib2/snippet16.fs)]

F# modules are compiled as static classes, but this can sometimes cause naming conflicts with namespaces. In the above example, you may wish to also have a namespace named `Foo`, but you can't have both. Using `ModuleSuffix` instructs the compiler that the `Foo` module should be compiled to a class called `FooModule`. Other F# code will still refer to the `Foo` module, but from C# or Visual Basic .NET, the name of the class will be visible as `FooModule`.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[CompilationRepresentationAttribute](core.compilationrepresentationattribute-class-%5bfsharp%5d.md)
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)