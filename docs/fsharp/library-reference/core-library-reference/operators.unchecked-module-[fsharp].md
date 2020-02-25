---
title: Operators.Unchecked Module (F#)
description: Operators.Unchecked Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 79f4f35a-aae4-4f68-94a7-ca68ccc067f8
---

# Operators.Unchecked Module (F#)

This module contains basic operations which do not apply runtime and/or static checks.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
module Unchecked
```

## Values


|Value|Description|
|-----|-----------|
|[compare](https://msdn.microsoft.com/library/0d9da403-7b73-4222-b4e9-90953be16d2e)<br />**: 'T -&gt; 'T -&gt; int**|Perform generic comparison on two values where the type of the values is not statically required to have the comparison constraint.|
|[defaultof](https://msdn.microsoft.com/library/9ff97f2a-1bd4-4f4c-afbe-5886a74ab977)<br />**: 'T**|Generate a default value for any type. This is null for reference types, For structures, this is structure value where all fields have the default value. This function is unsafe in the sense that some F# values do not have proper **null** values.|
|[equals](https://msdn.microsoft.com/library/9374146b-4f23-4162-aca7-ddcf999abd8e)<br />**: 'T -&gt; 'T -&gt; bool**|Perform generic equality on two values where the type of the values is not statically required to satisfy the equality constraint.|
|[hash](https://msdn.microsoft.com/library/b29711ff-269e-474d-9535-3c2c39515a60)<br />**: 'T -&gt; int**|Perform generic hashing on a value where the type of the value is not statically required to satisfy the equality constraint.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)
