---
title: LanguagePrimitives.IntrinsicOperators Module (F#)
description: LanguagePrimitives.IntrinsicOperators Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e14690d9-8dae-4b5c-8ecc-805ba4994ecb 
---

# LanguagePrimitives.IntrinsicOperators Module (F#)

The F# compiler emits calls to some of the functions in this module as part of the compiled form of some language constructs

**Namespace/Module Path:** Microsoft.FSharp.Core.LanguagePrimitives

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
module IntrinsicOperators
```

## Values


|Value|Description|
|-----|-----------|
|[( &amp; )](https://msdn.microsoft.com/library/bb78aa6d-71e0-4b22-8a5e-b7d146006ab6)|Computed the Boolean AND operation. When used as a binary operator the right hand value is evaluated only on demand.|
|[( &amp;&amp; )](https://msdn.microsoft.com/library/4478ac61-9f1d-4eb2-82ed-512471fa96d4)|Computes the Boolean AND operation. When used as a binary operator the right hand value is evaluated only on demand|
|[( &#124;&#124; )](https://msdn.microsoft.com/library/1b6ed28c-e033-4693-a89a-90cf9e342c15)|Computes the Boolean OR operation. When used as a binary operator the right hand value is evaluated only on demand|
|[( ~&amp; )](https://msdn.microsoft.com/library/2a980a73-cb52-41c9-bbfa-096930fc12e8)|Returns the address of the argument as a managed pointer. Uses of this value may result in the generation of unverifiable code.|
|[( ~&amp;&amp; )](https://msdn.microsoft.com/library/894f4c19-a8ae-4db4-b5b6-6ce2ffe0f1c8)|Returns the address of the argument as a native pointer. Uses of this value may result in the generation of unverifiable code.|
|[or](https://msdn.microsoft.com/library/17443474-fee0-4292-8df4-970e14cfcf28)|Computes the Boolean OR operation. When used as a binary operator the right hand value is evaluated only on demand.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.LanguagePrimitives Module &#40;F&#35;&#41;](Core.LanguagePrimitives-Module-%5BFSharp%5D.md)