---
title: Core.LanguagePrimitives Module (F#)
description: Core.LanguagePrimitives Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: cb088a7c-6d2e-4b70-86b8-6f37e6461226 
---

# Core.LanguagePrimitives Module (F#)

Language primitives associated with the F# language

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
module LanguagePrimitives
```

## Modules


|Module|Description|
|------|-----------|
|module [ErrorStrings](https://msdn.microsoft.com/library/0ca17818-f52f-40d5-aecc-56ab492a00a4)|For internal use only|
|module [HashCompare](https://msdn.microsoft.com/library/fe998b54-ec12-4502-90eb-27a465a43e73)|The F# compiler emits calls to some of the functions in this module as part of the compiled form of some language constructs|
|module [IntrinsicFunctions](https://msdn.microsoft.com/library/1700df47-c8f8-4231-bc57-d7f18dcb14ac)|The F# compiler emits calls to some of the functions in this module as part of the compiled form of some language constructs|
|module [IntrinsicOperators](https://msdn.microsoft.com/library/dcf5e30b-7e6c-4f12-9498-2ee4d7e73eb0)|The F# compiler emits calls to some of the functions in this module as part of the compiled form of some language constructs|

## Values


|Value|Description|
|-----|-----------|
|[AdditionDynamic](https://msdn.microsoft.com/library/194d2028-9542-4331-9d64-f2a18c08fa9a)<br />**: 'T1 -&gt; 'T2 -&gt; 'U**|A compiler intrinsic that implements dynamic invocations to the **+** operator.|
|[CheckedAdditionDynamic](https://msdn.microsoft.com/library/fe16816c-3ff3-47f6-81c9-03e43587939b)<br />**: 'T1 -&gt; 'T2 -&gt; 'U**|A compiler intrinsic that implements dynamic invocations to the checked **+** operator.|
|[CheckedMultiplyDynamic](https://msdn.microsoft.com/library/1d4117f7-8bec-4a38-905b-6da4855d4322)<br />**: 'T1 -&gt; 'T2 -&gt; 'U**|A compiler intrinsic that implements dynamic invocations to the checked **+** operator.|
|[DecimalWithMeasure](https://msdn.microsoft.com/library/a5368bef-3458-4452-812a-0dbe4114e331)<br />**: decimal -&gt; decimal&lt;'u&gt;**|Creates a decimal value with units-of-measure|
|[DivideByInt](https://msdn.microsoft.com/library/24b70b03-c9fb-4edf-b04e-c9d8355fe1ca)<br />**: ^T -&gt; int -&gt; ^T**|Divides a value by an integer.|
|[DivideByIntDynamic](https://msdn.microsoft.com/library/32d5d11f-0742-4a96-a76a-6a373e8ab92c)<br />**: 'T -&gt; int -&gt; 'T**|A compiler intrinsic that implements dynamic invocations for the **DivideByInt** primitive.|
|[EnumOfValue](https://msdn.microsoft.com/library/d39fae1e-9037-4eb2-8964-0e1bafa0f396)<br />**: 'T -&gt; enum**|Creates an enumeration value from an underlying value.|
|[EnumToValue](https://msdn.microsoft.com/library/56ef4a08-f191-48d6-9df5-28b1baaefe3c)<br />**: 'Enum -&gt; 'T**|Gets the underlying value for an enumeration value.|
|[FastGenericComparer](https://msdn.microsoft.com/library/9513a22a-2b7c-45d4-ac80-228826015c37)<br />**: IComparer&lt;'T&gt;**|Creates an F# comparer object for the given type|
|[FastGenericEqualityComparer](https://msdn.microsoft.com/library/f2b9050e-104f-4d87-87ca-f10e8fbb791a)<br />**: IEqualityComparer&lt;'T&gt;**|Create an F# hash/equality object for the given type|
|[FastLimitedGenericEqualityComparer](https://msdn.microsoft.com/library/8d6de104-6a02-4805-bb97-d2670e5555a5)<br />**: int -&gt; IEqualityComparer&lt;'T&gt;**|Create an F# hash/equality object for the given type using node-limited hashing when hashing F# records, lists and union types.|
|[Float32WithMeasure](https://msdn.microsoft.com/library/cbedfd6d-5490-437e-a01c-815fada8666f)<br />**: float -&gt; float&lt;'u&gt;**|Creates a **float32** value with units-of-measure.|
|[FloatWithMeasure](https://msdn.microsoft.com/library/69520bc7-d67b-46b8-9004-7cac9646b8d9)<br />**: float32 -&gt; float32&lt;'u&gt;**|Creates a **float** value with units-of-measure.|
|[GenericComparer](https://msdn.microsoft.com/library/537d7c61-4109-4b86-a33e-a6de70bbbe74)<br />**: IComparer**|A static F# comparer object.|
|[GenericComparison](https://msdn.microsoft.com/library/593650cc-029a-422f-b412-6e9fb5b0b5eb)<br />**: 'T -&gt; 'T -&gt; int**|Compares two values.|
|[GenericComparisonWithComparer](https://msdn.microsoft.com/library/7e4ae86f-4f64-4b3d-97b7-53ce2ac6c572)<br />**: IComparer -&gt; 'T -&gt; 'T -&gt; int**|Compare two values. May be called as a recursive case from an implementation of **System.IComparable&#96;1** to ensure consistent NaN comparison semantics.|
|[GenericEquality](https://msdn.microsoft.com/library/68bf55cb-fd55-4883-90e7-98df080d8938)<br />**: 'T -&gt; 'T -&gt; bool**|Compares two values for equality using partial equivalence relation semantics ([nan] &lt;&gt; [nan]).|
|[GenericEqualityComparer](https://msdn.microsoft.com/library/2a3c5735-f863-45e8-80bb-00cc6b18e1b8)<br />**: IEqualityComparer**|Returns an F# comparer object suitable for hashing and equality. This hashing behavior of the returned comparer is not limited by an overall node count when hashing F# records, lists and union types.|
|[GenericEqualityER](https://msdn.microsoft.com/library/b0018d4f-24dd-44f8-bb68-abf8f52ad763)<br />**: 'T -&gt; 'T -&gt; bool**|Compares two values for equality using equivalence relation semantics ([nan] = [nan]).|
|[GenericEqualityERComparer](https://msdn.microsoft.com/library/319db71d-6996-483b-a575-8f4a2b4d291d)<br />**: IEqualityComparer**|Return an F# comparer object suitable for hashing and equality. This hashing behavior of the returned comparer is not limited by an overall node count when hashing F# records, lists and union types. This equality comparer has equivalence relation semantics ([nan] = [nan]).|
|[GenericEqualityWithComparer](https://msdn.microsoft.com/library/6002b544-660c-4000-818d-047d4304c3a7)<br />**: IEqualityComparer -&gt; 'T -&gt; 'T -&gt; bool**|Compare two values for equality|
|[GenericGreaterOrEqual](https://msdn.microsoft.com/library/1944551e-ac7e-4a91-9496-0b42582bf9fd)<br />**: 'T -&gt; 'T -&gt; bool**|Compares two values|
|[GenericGreaterThan](https://msdn.microsoft.com/library/3da1f345-3ecd-481d-acc3-df06d2ee9b87)<br />**: 'T -&gt; 'T -&gt; bool**|Compares two values|
|[GenericHash](https://msdn.microsoft.com/library/68b1207f-757a-45a1-8bc3-21dc82bf24a8)<br />**: 'T -&gt; int**|Hashes a value according to its structure. This hash is not limited by an overall node count when hashing F# records, lists and union types.|
|[GenericHashWithComparer](https://msdn.microsoft.com/library/9bd694ff-6755-4004-9f8f-8d2d93ac582b)<br />**: IEqualityComparer -&gt; 'T -&gt; int**|Recursively hashes a part of a value according to its structure.|
|[GenericLessOrEqual](https://msdn.microsoft.com/library/14d8a7bb-41fe-4323-a4ed-91d65f7124ac)<br />**: 'T -&gt; 'T -&gt; bool**|Compares two values|
|[GenericLessThan](https://msdn.microsoft.com/library/b8e15fb7-ffb5-458e-8ba4-0d1c244c38c3)<br />**: 'T -&gt; 'T -&gt; bool**|Compares two values|
|[GenericLimitedHash](https://msdn.microsoft.com/library/1ada2a57-433f-4fa7-b8ce-1aa010d626c7)<br />**: int -&gt; 'T -&gt; int**|Hashes a value according to its structure. Use the given limit to restrict the hash when hashing F# records, lists and union types.|
|[GenericMaximum](https://msdn.microsoft.com/library/27a7cef8-4f85-4ad0-aa5b-6872f3216997)<br />**: 'T -&gt; 'T -&gt; 'T**|Takes the maximum of two values structurally according to the order given by [GenericComparison](https://msdn.microsoft.com/library/593650cc-029a-422f-b412-6e9fb5b0b5eb).|
|[GenericMinimum](https://msdn.microsoft.com/library/38cf4200-7264-41d8-a1cf-68508a42af8d)<br />**: 'T -&gt; 'T -&gt; 'T**|Takes the minimum of two values structurally according to the order given by [GenericComparison](https://msdn.microsoft.com/library/593650cc-029a-422f-b412-6e9fb5b0b5eb).|
|[GenericOne](https://msdn.microsoft.com/library/37b01ef1-6d50-4ec4-bf58-9b6c4dab2721)<br />**: ^T**|Resolves to the one value for any primitive numeric type or any type with a static member called **One**.|
|[GenericOneDynamic](https://msdn.microsoft.com/library/8a62ebbb-bd57-4592-9b71-e5e3c48e1dac)<br />**: unit -&gt; 'T**|Resolves to the one value for any primitive numeric type or any type with a static member called **One**..|
|[GenericZero](https://msdn.microsoft.com/library/ee57aa71-2825-4684-8988-700884b56daf)<br />**: ^T**|Resolves to the zero value for any primitive numeric type or any type with a static member called **Zero**.|
|[GenericZeroDynamic](https://msdn.microsoft.com/library/65da4ba8-7f9c-4031-bedf-f453e91b026a)<br />**: unit -&gt; 'T**|Resolves to the zero value for any primitive numeric type or any type with a static member called **Zero**.|
|[Int16WithMeasure](https://msdn.microsoft.com/library/5c8b94dd-3305-4a55-8988-9d2faeef80b4)<br />**: int16 -&gt; int16&lt;'u&gt;**|Creates an **int16** value with units-of-measure|
|[Int32WithMeasure](https://msdn.microsoft.com/library/43060a52-e85c-4f7d-a9f8-78a5e09b2ab6)<br />**: int32 -&gt; int32&lt;'u&gt;**|Creates an **int32** value with units-of-measure|
|[Int64WithMeasure](https://msdn.microsoft.com/library/31111e95-e224-4af9-bf90-29832c30b16e)<br />**: int64 -&gt; int64&lt;'u&gt;**|Creates an **int64** value with units-of-measure|
|[MultiplyDynamic](https://msdn.microsoft.com/library/be75703d-ac9a-4b79-93cb-0a7067f99a4f)<br />**: 'T1 -&gt; 'T2 -&gt; 'U**|A compiler intrinsic that implements dynamic invocations to the **+** operator.|
|[ParseInt32](https://msdn.microsoft.com/library/b6cbd33a-517f-479a-a5f2-8eb570634216)<br />**: string -&gt; int32**|Parses an **int32** according to the rules used by the overloaded **int32** conversion operator when applied to strings|
|[ParseInt64](https://msdn.microsoft.com/library/6a036957-106f-4ee7-b3d5-5effd5c28ab7)<br />**: string -&gt; int64**|Parses an **int64** according to the rules used by the overloaded **int64** conversion operator when applied to strings|
|[ParseUInt32](https://msdn.microsoft.com/library/35d8ca9e-c63d-424c-8ddb-cf5dae8b23e6)<br />**: string -&gt; uint32**|Parses an **uint32** according to the rules used by the overloaded **uint32** conversion operator when applied to strings|
|[ParseUInt64](https://msdn.microsoft.com/library/1f1b0a0e-7042-4dd8-80eb-56404d28eca0)<br />**: string -&gt; uint64**|Parses an **uint64** according to the rules used by the overloaded **uint64** conversion operator when applied to strings|
|[PhysicalEquality](https://msdn.microsoft.com/library/1783ed93-63f4-4936-832f-4bf0db6e3586)<br />**: 'T -&gt; 'T -&gt; bool**|Reference/physical equality. True if boxed versions of the inputs are reference-equal, OR if both are primitive numeric types and the implementation of **System.Object.Equals(System.Object)** for the type of the first argument returns true on the boxed versions of the inputs.|
|[PhysicalHash](https://msdn.microsoft.com/library/8c93ad8b-70d2-4035-9961-ba0f84d9458b)<br />**: 'T -&gt; int**|The physical hash. Hashes on the object identity, except for value types, where we hash on the contents.|
|[SByteWithMeasure](https://msdn.microsoft.com/library/cba10503-d220-4a72-9a63-b3c181af2d4e)<br />**: sbyte -&gt; sbyte&lt;'u&gt;**|Creates an **sbyte** value with units-of-measure|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)