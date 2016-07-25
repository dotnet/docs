---
title: Core.CompilationSourceNameAttribute Class (F#)
description: Core.CompilationSourceNameAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 911701de-bf65-40d4-a780-9e477d84f23a 
---

# Core.CompilationSourceNameAttribute Class (F#)

This attribute is inserted automatically by the F# compiler to tag methods which are given the [`CompiledName`](https://msdn.microsoft.com/library/fb4ca03a-86ae-4334-b6a0-3de01e98904d) attribute. It is not intended for use from user code.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.All, AllowMultiple = false)>]
[<Sealed>]
type CompilationSourceNameAttribute =
class
new CompilationSourceNameAttribute : string -> CompilationSourceNameAttribute
member this.SourceName :  string
end
```

## Remarks
You can also use the short form of the name, `CompilationSourceName`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/d27cb025-94af-4f28-801b-98e181ecea4d)|Creates an instance of the attribute.|

## Instance Members


|Member|Description|
|------|-----------|
|[SourceName](https://msdn.microsoft.com/library/9796f386-b537-467b-b832-00d9f111f512)|Indicates the name of the entity in F# source code.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)