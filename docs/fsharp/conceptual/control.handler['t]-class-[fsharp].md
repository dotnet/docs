---
title: Control.Handler<'T> Class (F#)
description: Control.Handler<'T> Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a3961db9-0d45-4a04-b70c-1f32a23399eb 
---

# Control.Handler<'T> Class (F#)

A delegate type associated with the F# event type [`IEvent`](https://msdn.microsoft.com/library/7976554f-9aa8-451f-a69d-d4670c064432).

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
type Handler<'T> =
class
abstract this.Invoke : obj * 'T -> unit
end
```

## Remarks
This type is named `FSharpHandler` in compiled assemblies. If you are accessing the type from a language other than F#, or through reflection, use this name.


## Instance Members

|Member|Description|
|------|-----------|
|[Invoke](https://msdn.microsoft.com/library/0f42e201-6463-4d42-a659-44f29138b4cd)|Calls the function or functions associated with the event handler.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)