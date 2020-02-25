---
title: Core.CompilerMessageAttribute Class (F#)
description: Core.CompilerMessageAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ea17302a-92f1-469d-a590-2019d49a227c 
---

# Core.CompilerMessageAttribute Class (F#)

Indicates that a message should be emitted when F# source code uses this construct.

**Namespace/Module Path**: Microsoft.FSharp.Core

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(AttributeTargets.All, AllowMultiple = false)>]
[<Sealed>]
type CompilerMessageAttribute =
class
new CompilerMessageAttribute : string * int -> CompilerMessageAttribute
member this.IsError :  bool with get, set
member this.IsHidden :  bool with get, set
member this.Message :  string
member this.MessageNumber :  int
end
```

## Remarks
You can also use the short form of the name, `CompilerMessage`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/93b9e5bf-35e9-4ce7-b8d6-1480a360ffec)|Creates an instance of the attribute.|

## Instance Members


|Member|Description|
|------|-----------|
|[IsError](https://msdn.microsoft.com/library/995cbc3a-5756-442a-884c-70757ab03d2d)|Indicates if the message should indicate a compiler error. Error numbers less than 10000 are considered reserved for use by the F# compiler and libraries.|
|[IsHidden](https://msdn.microsoft.com/library/968e521d-05b8-479c-bf61-9f32a4b42ef7)|Indicates if the construct should always be hidden in an editing environment.|
|[Message](https://msdn.microsoft.com/library/6ad3d2b4-06f6-43dd-a943-ef2685da22aa)|Indicates the warning message to be emitted when F# source code uses this construct|
|[MessageNumber](https://msdn.microsoft.com/library/27af826a-cf8e-4d44-a81b-82b7639b0206)|Indicates the number associated with the message.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)