---
title: Linq.Nullable Module (F#)
description: Linq.Nullable Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 4947801e-9465-4546-9ed4-abb76175b4e4 
---

# Linq.Nullable Module (F#)

Functions for converting nullable values into nullable values of another type.

**Namespace/Module Path**: Microsoft.FSharp.Linq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
module Nullable
```

## Remarks
For more information about nullable types and nullable operators, see `System.Nullable` and [Nullable Operators &#40;F&#35;&#41;](Nullable-Operators-%5BFSharp%5D.md).


## Values


|Value|Description|
|-----|-----------|
|[byte](https://msdn.microsoft.com/library/9d0fd2ef-8b80-44a7-b504-a6e9105035a8) : System.Nullable&lt;'T&gt; -&gt; System.Nullable&lt;byte&gt;|Converts the argument to nullable byte, Nullable&lt;[byte](https://msdn.microsoft.com/library/17a98430-283a-4ff6-a475-e6999577179d)&gt;. This is a direct conversion for all primitive numeric types. The operation requires an appropriate static conversion method on the input type.|
|[char](https://msdn.microsoft.com/library/27c61925-0ccd-4f7f-b911-8f656d63eb6f) : System.Nullable&lt;'T&gt; -&gt; System.Nullable&lt;char&gt;|Converts the argument to a nullable character, Nullable&lt;[char](https://msdn.microsoft.com/library/3627f475-985b-4b4e-94d2-14f217c04958)&gt;. Numeric inputs are converted according to the UTF-16 encoding for characters. The operation requires an appropriate static conversion method on the input type.|
|[decimal](https://msdn.microsoft.com/library/fe77229c-542c-4359-b755-39b7a90fa79d) : System.Nullable&lt;'T&gt; -&gt; System.Nullable&lt;System.Decimal&gt;|Converts the argument to a nullable decimal, Nullable&lt;**System.Decimal**&gt; using a direct conversion for all primitive numeric types. The operation requires an appropriate static conversion method on the input type.|
|[enum](https://msdn.microsoft.com/library/d1149ef9-696f-4cf4-b4cd-94521606926b) : System.Nullable&lt;'T&gt; -&gt; System.Nullable&lt;'U when 'U : enum&gt;|Converts the argument to a particular nullable enum type.|
|[float](https://msdn.microsoft.com/library/0813ebd5-757b-43ec-8a3e-2aaafbb5e201) : System.Nullable&lt;'T&gt; -&gt; System.Nullable&lt;float&gt;|Converts the argument to a nullable 64-bit float, Nullable&lt;[float](https://msdn.microsoft.com/library/3fa76cae-e9b5-4672-8bdf-88ff6dbcf7b8)&gt;. This is a direct conversion for all primitive numeric types. The operation requires an appropriate static conversion method on the input type.|
|[float32](https://msdn.microsoft.com/library/9b2fd2f1-beec-4e7e-b9fb-4da0d9750213) : System.Nullable&lt;'T&gt; -&gt; System.Nullable&lt;float32&gt;|Converts the argument to a nullable 32-bit float, Nullable&lt;[float32](https://msdn.microsoft.com/library/9bf674b5-ea9a-4b08-ad42-4da313b6ebf0)&gt;. This is a direct conversion for all primitive numeric types. The operation requires an appropriate static conversion method on the input type.|
|[int](https://msdn.microsoft.com/library/efecf446-be62-444a-a6a6-f67504f119a9) : System.Nullable&lt;'T&gt; -&gt; System.Nullable&lt;int&gt;|Converts the argument to nullable signed 32-bit integer, Nullable&lt;[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)&gt;. This is a direct conversion for all primitive numeric types. The operation requires an appropriate static conversion method on the input type.|
|[int16](https://msdn.microsoft.com/library/953ba6ba-39ad-4f29-9c0d-22847d97e314) : System.Nullable&lt;'T&gt; -&gt; System.Nullable&lt;int16&gt;|Converts the argument to a nullable signed 16-bit integer, Nullable&lt;[int16](https://msdn.microsoft.com/library/608e612c-5a8e-40c4-912f-55788628cb9b)&gt;. This is a direct conversion for all primitive numeric types. The operation requires an appropriate static conversion method on the input type.|
|[int32](https://msdn.microsoft.com/library/c6790ad2-bab4-49be-84ba-16dee88090db) : System.Nullable&lt;'T&gt; -&gt; System.Nullable&lt;int32&gt;|Converts the argument to a nullable signed 32-bit integer, Nullable&lt;[int32](https://msdn.microsoft.com/library/6ab0ea34-03db-4874-a265-bef9c64f8eff)&gt;. This is a direct conversion for all primitive numeric types. The operation requires an appropriate static conversion method on the input type.|
|[int64](https://msdn.microsoft.com/library/5d95d9a6-4056-4061-a029-2f169feae88b): System.Nullable&lt;'T&gt; -&gt; System.Nullable&lt;int64&gt;|Converts the argument to a nullable signed 64-bit integer, Nullable&lt;[int64](https://msdn.microsoft.com/library/1bec11c0-45ac-469e-923b-22a1708c0701)&gt;. This is a direct conversion for all primitive numeric types. The operation requires an appropriate static conversion method on the input type.|
|[nativeint](https://msdn.microsoft.com/library/c4da00bb-d3cc-4b99-a958-b3cb39601ea8) : System.Nullable&lt;'T&gt; -&gt; System.Nullable&lt;nativeint&gt;|Converts the argument to a nullable signed native integer, Nullable&lt;[nativeint](https://msdn.microsoft.com/library/876c5aa7-683f-4912-a799-161732109c4f)&gt;. This is a direct conversion for all primitive numeric types. Otherwise the operation requires an appropriate static conversion method on the input type.|
|[sbyte](https://msdn.microsoft.com/library/44043d32-324b-4017-8546-016871776112) : System.Nullable&lt;'T&gt; -&gt; System.Nullable&lt;sbyte&gt;|Converts the argument to a nullable signed byte, Nullable&lt;[sbyte](https://msdn.microsoft.com/library/fbc28b7f-2dbf-4361-acb3-830886820068)&gt;. This is a direct conversion for all primitive numeric types. The operation requires an appropriate static conversion method on the input type.|
|[uint16](https://msdn.microsoft.com/library/f6321925-76ee-4499-a1f6-4f581b650efe): System.Nullable&lt;'T&gt; -&gt; System.Nullable&lt;uint16&gt;|Converts the argument to a nullable unsigned 16-bit integer, Nullable&lt;[uint16](https://msdn.microsoft.com/library/2ab2f1fa-344e-4fcf-a688-5024c589630b)&gt;. This is a direct conversion for all primitive numeric types. The operation requires an appropriate static conversion method on the input type.|
|[uint32](https://msdn.microsoft.com/library/678e7843-fab8-4053-b8c0-3214bea74913) : System.Nullable&lt;'T&gt; -&gt; System.Nullable&lt;uint32&gt;|Converts the argument to a nullable unsigned 32-bit integer, Nullable&lt;[uint32](https://msdn.microsoft.com/library/02aea3e2-e400-453a-a681-3a657afe1825)&gt;. This is a direct conversion for all primitive numeric types. The operation requires an appropriate static conversion method on the input type.|
|[uint64](https://msdn.microsoft.com/library/a90b1710-16d3-4f6a-ae02-f0a277006b8c) : System.Nullable&lt;'T&gt; -&gt; System.Nullable&lt;uint64&gt;|Converts the argument to a nullable unsigned 64-bit integer, Nullable&lt;[uint64](https://msdn.microsoft.com/library/3c4f3a04-06eb-48aa-b38e-16646bda2f33)&gt;. This is a direct conversion for all primitive numeric types. The operation requires an appropriate static conversion method on the input type.|
|[unativeint](https://msdn.microsoft.com/library/85721b5a-d241-4586-bd12-ec81547a3f7e) : System.Nullable&lt;'T&gt; -&gt; System.Nullable&lt;unativeint&gt;|Converts the argument to a nullable unsigned native integer, Nullable&lt;[unativeint](https://msdn.microsoft.com/library/9d2946a7-ace9-48a4-8cff-7894b8e7de86)&gt;, using a direct conversion for all primitive numeric types. Otherwise, the operation requires an appropriate static conversion method on the input type.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Microsoft.FSharp.Linq Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq-Namespace-%5BFSharp%5D.md)