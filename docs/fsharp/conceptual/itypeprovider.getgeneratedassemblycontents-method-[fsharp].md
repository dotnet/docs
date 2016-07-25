---
title: ITypeProvider.GetGeneratedAssemblyContents Method (F#)
description: ITypeProvider.GetGeneratedAssemblyContents Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3837a922-12cc-4123-b95d-d254926ce267 
---

# ITypeProvider.GetGeneratedAssemblyContents Method (F#)

Get the physical contents of the given logical provided assembly.

**Namespace/Module Path**: Microsoft.FSharp.Core.CompilerServices

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
abstract this.GetGeneratedAssemblyContents : System.Reflection.Assembly -> byte[]

// Usage:
iTypeProvider.GetGeneratedAssemblyContents (assembly)
```

#### Parameters
*assembly*
Type: **System.Reflection.Assembly**


The generated assembly.

## Return Value
The contents of the generated assembly, as a byte array.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[CompilerServices.ITypeProvider Interface &#40;F&#35;&#41;](CompilerServices.ITypeProvider-Interface-%5BFSharp%5D.md)

[Microsoft.FSharp.Core.CompilerServices Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core.CompilerServices-Namespace-%5BFSharp%5D.md)