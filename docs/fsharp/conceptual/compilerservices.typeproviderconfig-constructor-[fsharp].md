---
title: CompilerServices.TypeProviderConfig Constructor (F#)
description: CompilerServices.TypeProviderConfig Constructor (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b0947576-5cf3-4f77-87c8-3a01de0a514e 
---

# CompilerServices.TypeProviderConfig Constructor (F#)

Constructor for `TypeProviderConfig`.

**Namespace/Module Path**: Microsoft.FSharp.Core.CompilerServices

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
new TypeProviderConfig : string * string * string [] * string -> TypeProviderConfig

// Usage:
new TypeProviderConfig (resolutionFolder, runtimeAssembly, referencedAssemblies, temporaryFolder)
```

#### Parameters
*resolutionFolder*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)


The folder in which the resolution is occurring. Typically the project folder.


*runtimeAssembly*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)


*referencedAssemblies*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


*temporaryFolder*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[CompilerServices.TypeProviderConfig Class &#40;F&#35;&#41;](CompilerServices.TypeProviderConfig-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Core.CompilerServices Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core.CompilerServices-Namespace-%5BFSharp%5D.md)