---
title: Array.exactlyOne<'T> Function (F#)
description: Array.exactlyOne<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: erikschierboom
manager: danielfe
ms.date: 03/13/2017
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e8315847-d65e-49c9-8cf2-450b8b395ffc
---

# Array.exactlyOne<'T> Function (F#)

Returns the only element of the array.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Array

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.exactlyOne : 'T [] -> 'T

// Usage: 
Array.exactlyOne array
```

#### Parameters
*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when the input does not have precisely one element.|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input array is null|


## Return Value
The last element of the array.


## Remarks
This function is named `ExactlyOne` in the .NET assembly. If accessing the member from a .NET language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable


## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
