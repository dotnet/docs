---
title: Control.WebExtensions Module (F#)
description: Control.WebExtensions Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 0a136977-aa89-463a-8c56-9c658de7d803 
---

# Control.WebExtensions Module (F#)

A module of extension members providing asynchronous operations for some basic Web operations.

**Namespace/Module Path:** Microsoft.FSharp.Control

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AutoOpen>]
module WebExtensions
```

## Extension Members


|Extension Member|Description|
|----------------|-----------|
|[AsyncDownloadString](https://msdn.microsoft.com/library/8a85a9b7-f712-4cac-a0ce-0a797f8ea32a)<br />**: Uri -&gt; Async&lt;string&gt;**|Returns an asynchronous computation that, when run, will wait for the download of the given URI.|
|[AsyncGetResponse](https://msdn.microsoft.com/library/09a60c31-e6e2-4b5c-ad23-92a86e50060c)<br />**: unit -&gt; Async&lt;WebResponse&gt;**|Returns an asynchronous computation that, when run, will wait for a response to the given web request.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Microsoft.FSharp.Control Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Control-Namespace-%5BFSharp%5D.md)