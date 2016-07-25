---
title: Quotations.DerivedPatterns Module (F#)
description: Quotations.DerivedPatterns Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 41e0c484-3bf5-41de-85cd-814f26f3d943
---

# Quotations.DerivedPatterns Module (F#)

Contains a set of derived F# active patterns to analyze F# expression objects

**Namespace/Module Path:** Microsoft.FSharp.Quotations

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
module DerivedPatterns
```

## Active Patterns


|Active Pattern|Description|
|--------------|-----------|
|[AndAlso](https://msdn.microsoft.com/library/6bff3ba2-02be-4ba0-8675-4c42844a3cf8)<br />**: Expr -&gt; (Expr &#42; Expr) option**|Recognizes expressions of the form **a &amp;&amp; b.**|
|[Applications](https://msdn.microsoft.com/library/b7b396fd-0242-4107-88e2-759fbae8ea75)<br />**: Expr -&gt; (Expr &#42; Expr list list) option**|Recognizes expressions that represent the application of a (possibly curried or tupled) first class function value.|
|[Bool](https://msdn.microsoft.com/library/8ec9d19e-c65e-44fb-bce4-c7df4e2f507c)<br />**: Expr -&gt; bool option**|Recognizes constant Boolean expressions.|
|[Byte](https://msdn.microsoft.com/library/6ef0a209-ccac-4f5c-a2c8-ee2f7ea8cd79)<br />**: Expr -&gt; byte option**|Recognizes constant byte expressions.|
|[Char](https://msdn.microsoft.com/library/f250d134-eff1-4c68-8654-4f12609ce462)<br />**: Expr -&gt; char option**|Recognizes constant Unicode character expressions.|
|[Double](https://msdn.microsoft.com/library/10bea93d-14ee-4ef7-bfed-348fb3cf8d4d)<br />**: Expr -&gt; float option**|Recognizes constant 64-bit floating point number expressions.|
|[Int16](https://msdn.microsoft.com/library/04b744ea-7970-4c23-b1d2-53b66dd93174)<br />**: Expr -&gt; int16 option**|Recognizes constant int16 expressions.|
|[Int32](https://msdn.microsoft.com/library/a59bfbeb-5213-422f-a00d-6aa5453c12bb)<br />**: Expr -&gt; int32 option**|Recognizes constant int32 expressions.|
|[Int64](https://msdn.microsoft.com/library/11f9b28a-fc3d-4393-a2b4-f5e610207e9b)<br />**: Expr -&gt; int64 option**|Recognizes constant int64 expressions.|
|[Lambdas](https://msdn.microsoft.com/library/87373e02-5eb9-424a-b40c-e86a726e10bf)<br />**: Expr -&gt; (Var list list &#42; Expr) option**|Recognizes expressions that represent a (possibly curried or tupled) first class function value.|
|[MethodWithReflectedDefinition](https://msdn.microsoft.com/library/943fab79-f0c3-43f3-ae91-7d43659b90b1)<br />**: MethodBase -&gt; Expr option**|Recognizes methods that have an associated ReflectedDefinition.|
|[OrElse](https://msdn.microsoft.com/library/9e5eedb1-a131-4f29-a6fb-ea1850eb65de)<br />**: Expr -&gt; (Expr &#42; Expr) option**|Recognizes expressions of the form **a &#124;&#124; b.**|
|[PropertyGetterWithReflectedDefinition](https://msdn.microsoft.com/library/e8c25ce7-d2fc-44ae-b540-c22963316d9e)<br />**: PropertyInfo -&gt; Expr option**|Recognizes property getters or values in modules that have an associated ReflectedDefinition.|
|[PropertySetterWithReflectedDefinition](https://msdn.microsoft.com/library/ebe4b18d-57b0-45b9-8e2d-3dfc5a3c6f19)<br />**: PropertyInfo -&gt; Expr option**|Recognizes property setters that have an associated ReflectedDefinition.|
|[SByte](https://msdn.microsoft.com/library/91b92dae-4a61-4a0f-b264-a6235227b2fd)<br />**: Expr -&gt; sbyte option**|Recognizes constant signed byte expressions.|
|[Single](https://msdn.microsoft.com/library/02a25920-18c4-491e-9a80-efd0212b99bc)<br />**: Expr -&gt; single option**|Recognizes constant 32-bit floating point number expressions.|
|[SpecificCall](https://msdn.microsoft.com/library/05a77b21-20fe-4b9a-8e07-aa999538198d)<br />**: Expr -&gt; Expr -&gt; (Expr option &#42; Type list &#42; Expr list) option**|A parameterized active pattern to recognize calls to a specified function or method. The returned elements are the optional target object (present if the target is an instance method), the generic type instantiation (non-empty if the target is a generic instantiation), and the arguments to the function or method.|
|[String](https://msdn.microsoft.com/library/9d736c5b-eb3a-44cb-8f12-260e8632fb2d)<br />**: Expr -&gt; string option**|Recognizes constant string expressions.|
|[UInt16](https://msdn.microsoft.com/library/94d513b9-2491-460e-92e0-a456d876c787)<br />**: Expr -&gt; uint16 option**|Recognizes constant unsigned int16 expressions.|
|[UInt32](https://msdn.microsoft.com/library/ac0b073a-acd9-4a3c-b131-e0342adb3a37)<br />**: Expr -&gt; uint32 option**|Recognizes constant unsigned int32 expressions.|
|[UInt64](https://msdn.microsoft.com/library/304aa9eb-c301-4d33-a07a-b23c0755d80d)<br />**: Expr -&gt; uint64 option**|Recognizes constant unsigned int64 expressions.|
|[Unit](https://msdn.microsoft.com/library/cebe4367-8f7a-4c01-887d-32264a4a81a5)<br />**: Expr -&gt; unit option**|Recognizes **()** constant expressions.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)
