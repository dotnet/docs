---
title: IEventLoop.Invoke<'T> Method
description: IEventLoop.Invoke<'T> Method
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 02/26/2020
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 00b071d2-ba92-4b87-b291-5ca5f837b357 
---

# IEventLoop.Invoke<'T> Method

Request that the given operation be run synchronously on the event loop.

**Namespace/Module Path:** Microsoft.FSharp.Compiler.Interactive

**Assembly:** FSharp.Compiler.Interactive.Settings (in FSharp.Compiler.Interactive.Settings.dll)


## Syntax

```fsharp
// Signature:
abstract this.Invoke : (unit -> 'T) -> 'T

// Usage:
iEventLoop.Invoke (func)
```

#### Parameters
*func*
Type: [unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)**-&gt; 'T**

A function to run on the event loop.

## See Also
[Interactive.IEventLoop Interface](Interactive.IEventLoop-Interface.md)

[Microsoft.FSharp.Compiler.Interactive Namespace](index.md)
