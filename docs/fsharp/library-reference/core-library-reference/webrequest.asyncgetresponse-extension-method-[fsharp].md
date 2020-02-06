---
title: WebRequest.AsyncGetResponse Extension Method (F#)
description: WebRequest.AsyncGetResponse Extension Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5528e42f-6337-4617-9d42-a4f767073f29 
---

# WebRequest.AsyncGetResponse Extension Method (F#)

Returns an asynchronous computation that, when run, will wait for a response to the given **System.Net.WebRequest**.

**Namespace/Module Path:** Microsoft.FSharp.Control.WebExtensions

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
type System.Net.WebRequest with
member AsyncGetResponse : unit -> Async<WebResponse>

// Usage:
webRequest.AsyncGetResponse ()
```

## Return Value
An asynchronous computation ([Async](https://msdn.microsoft.com/library/03eb4d12-a01a-4565-a077-5e83f17cf6f7) object) that waits for response to the web request.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0


## See Also
[Control.WebExtensions Module &#40;F&#35;&#41;](Control.WebExtensions-Module-%5BFSharp%5D.md)

