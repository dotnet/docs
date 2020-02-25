---
title: CompilerServices.TypeProviderXmlDocAttribute Class (F#)
description: CompilerServices.TypeProviderXmlDocAttribute Class (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: dccb91e9-d102-4f89-802b-e9a509e5f3fc 
---

# CompilerServices.TypeProviderXmlDocAttribute Class (F#)

The `TypeProviderXmlDocAttribute` attribute can be added to types and members. The language service will display the [`CommentText`](https://msdn.microsoft.com/library/d154bea8-e774-40dc-88c0-072d14f277f8) property from the attribute in the appropriate place when the user  performs either of the following steps:

- Points to a type or member in the Visual Studio editor.

- Moves the cursor so that it appears next to or within the name of a type or member and then chooses the `Ctrl+K`, `I` keys.

**Namespace/Module Path**: Microsoft.FSharp.Core.CompilerServices

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AttributeUsage(32767, AllowMultiple = false)>]
type [TypeProviderXmlDocAttribute](https://msdn.microsoft.com/library/15df1059-16f1-4855-ab6a-860d60003c90) =
class
new TypeProviderXmlDocAttribute : string -> TypeProviderXmlDocAttribute
member this.CommentText : string
end
```

## Remarks
You can also use the short form of the name, `TypeProviderXmlDoc`.


## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/73324681-a597-444c-8e5b-9f115b768534)|Creates an instance of the attribute.|

## Instance Members

|Member|Description|
|------|-----------|
|[CommentText](https://msdn.microsoft.com/library/d154bea8-e774-40dc-88c0-072d14f277f8)|The text that describes the generated type or member.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Microsoft.FSharp.Core.CompilerServices Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core.CompilerServices-Namespace-%5BFSharp%5D.md)