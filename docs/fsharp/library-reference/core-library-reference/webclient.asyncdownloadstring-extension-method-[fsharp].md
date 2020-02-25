---
title: WebClient.AsyncDownloadString Extension Method (F#)
description: WebClient.AsyncDownloadString Extension Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2d5e6f3a-574b-4422-8628-38c02b109ca9 
---

# WebClient.AsyncDownloadString Extension Method (F#)

Returns an asynchronous computation that, when run, will wait for the download of the given URI.

**Namespace/Module Path:** Microsoft.FSharp.Control.WebExtensions

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
type System.Net.WebClient with
member AsyncDownloadString : Uri -> Async<string>

// Usage:
webClient.AsyncDownloadString (address)
```

#### Parameters
*address*
Type: **System.Uri**


The URI to retrieve.

## Return Value

An asynchronous computation ([Async](https://msdn.microsoft.com/library/03eb4d12-a01a-4565-a077-5e83f17cf6f7) object) that will wait for the return of the URI.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0

## See Also
[Control.WebExtensions Module &#40;F&#35;&#41;](Control.WebExtensions-Module-%5BFSharp%5D.md)