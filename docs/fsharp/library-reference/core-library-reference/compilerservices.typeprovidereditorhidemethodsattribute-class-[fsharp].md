---
title: CompilerServices.TypeProviderEditorHideMethodsAttribute Class (F#)
description: CompilerServices.TypeProviderEditorHideMethodsAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 7de44d71-7ec9-4cf6-a31c-975b30680b6f 
---

# CompilerServices.TypeProviderEditorHideMethodsAttribute Class (F#)

Indicates that a code editor should hide all `System.Object` methods from the Intellisense menus for instances of a provided type

**Namespace/Module Path**: Microsoft.FSharp.Core.CompilerServices

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(5132, AllowMultiple = false)>]
type [TypeProviderEditorHideMethodsAttribute](https://msdn.microsoft.com/library/dea2241e-f83c-465f-aa01-8211b68842a7) =
class
new TypeProviderEditorHideMethodsAttribute : unit -> TypeProviderEditorHideMethodsAttribute
end
```

## Remarks
You can also use the short form of the name, `TypeProviderEditorHideMethods`.


## Constructors


|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/3bda463c-7f2d-49ec-9cdb-e559eef57428)|Creates an instance of the attribute.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Microsoft.FSharp.Core.CompilerServices Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core.CompilerServices-Namespace-%5BFSharp%5D.md)