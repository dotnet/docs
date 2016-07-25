---
title: Numerics.BigInteger Structure (F#)
description: Numerics.BigInteger Structure (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f2dc200c-5e24-4e58-9e46-fe4c8dc51b22
---

# Numerics.BigInteger Structure (F#)

The type of arbitrary-sized integers

**Namespace/Module Path**: System.Numerics

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<CustomEquality>]
[<CustomComparison>]
type BigInteger =
struct
interface IComparable
new BigInteger : int64 -> BigInteger
new BigInteger : int -> BigInteger
static member Abs : BigInteger -> BigInteger
static member DivRem : BigInteger * BigInteger * byref<BigInteger> -> BigInteger
static member GreatestCommonDivisor : BigInteger * BigInteger -> BigInteger
static member Parse : string -> BigInteger
static member Pow : BigInteger * int32 -> BigInteger
member this.IsOne :  bool
member this.IsZero :  bool
static member One :  BigInteger
member this.Sign :  int
static member Zero :  BigInteger
static member ( + ) : BigInteger * BigInteger -> BigInteger
static member ( / ) : BigInteger * BigInteger -> BigInteger
static member ( = ) : BigInteger * BigInteger -> bool
static member op_Explicit : BigInteger -> int32
static member op_Explicit : BigInteger -> int64
static member op_Explicit : BigInteger -> float
static member ( > ) : BigInteger * BigInteger -> bool
static member ( >= ) : BigInteger * BigInteger -> bool
static member ( <> ) : BigInteger * BigInteger -> bool
static member ( < ) : BigInteger * BigInteger -> bool
static member ( <= ) : BigInteger * BigInteger -> bool
static member ( % ) : BigInteger * BigInteger -> BigInteger
static member ( * ) : BigInteger * BigInteger -> BigInteger
static member ( - ) : BigInteger * BigInteger -> BigInteger
static member ( ~- ) : BigInteger -> BigInteger
static member ( ~+ ) : BigInteger -> BigInteger
end
```

## Remarks
This type is provided for use only with the F# Core Library Versions that targets .NET Framework 2.0. If you are using .NET Framework 4, use the .NET Framework 4 type with the same name, `System.Numerics.BigInteger`.


## Constructors

|Member|Description|
|------|-----------|
|[new](https://msdn.microsoft.com/library/fff96d3e-1684-42d6-af72-2285cf04c64c)|Construct a BigInteger value for the given 64-bit integer|

## Instance Members

|Member|Description|
|------|-----------|
|[IsOne](https://msdn.microsoft.com/library/7e362983-bb74-44d2-9cfb-c77ab661bfa1)|Return true if a big integer is 'one'|
|[IsZero](https://msdn.microsoft.com/library/06f310da-edee-4d33-9260-33c965eb4147)|Return true if a big integer is 'zero'|
|[Sign](https://msdn.microsoft.com/library/1a8adc99-f9c6-42d3-8e00-047656547f6f)|Return the sign of a big integer: 0, +1 or -1|

## Static Members

|Member|Description|
|------|-----------|
|[( % )](https://msdn.microsoft.com/library/c1098b52-c340-4b83-b9a1-2affbfd00dff)|Return the modulus of big integers|
|[( &#42; )](https://msdn.microsoft.com/library/9ceac02a-7bee-4f33-8c05-0ca15b5863ac)|Return the product of big integers|
|[( + )](https://msdn.microsoft.com/library/0383c671-6fda-4812-acb2-b7e7bc71b4f4)|Return the sum of two big integers|
|[( - )](https://msdn.microsoft.com/library/a7a27d62-b3e7-4a4a-8497-e360553279ac)|Return the difference of two big integers|
|[( / )](https://msdn.microsoft.com/library/3061e935-9ea2-4a6f-934e-a2d308327647)|Return the ratio of two big integers|
|[( &lt; )](https://msdn.microsoft.com/library/d69244cc-11b0-476d-ab49-02b34089c192)|This operator is for consistency when this type be used from other CLI languages|
|[( &lt;= )](https://msdn.microsoft.com/library/481e590e-02e2-4d47-a23b-e5f3d0fe5c9c)|This operator is for consistency when this type be used from other CLI languages|
|[( &lt;&gt; )](https://msdn.microsoft.com/library/040ba3af-05de-4ba0-952a-d3fd1dc0c9d1)|This operator is for consistency when this type be used from other CLI languages|
|[( = )](https://msdn.microsoft.com/library/d1402608-1f27-4c62-ac22-ddc27be11af0)|This operator is for consistency when this type be used from other CLI languages|
|[( &gt; )](https://msdn.microsoft.com/library/2d017353-bb32-46b0-91d6-54dd8fcd14f9)|This operator is for consistency when this type be used from other CLI languages|
|[( &gt;= )](https://msdn.microsoft.com/library/95baad38-df50-426a-90ae-f32262e37eb0)|This operator is for consistency when this type be used from other CLI languages|
|[( ~+ )](https://msdn.microsoft.com/library/27a2b730-b819-4267-9935-66ecfb382125)|Return the given big integer|
|[( ~- )](https://msdn.microsoft.com/library/f997fbca-de2c-4155-a6a4-a3b3b621e1fa)|Return the negation of a big integer|
|[Abs](https://msdn.microsoft.com/library/d04d798e-7d68-4a76-84a8-d1f5f45ac603)|Compute the absolute value of a big integer|
|[DivRem](https://msdn.microsoft.com/library/e21e83de-d515-4c1b-9dca-f74b6ddcfc84)|Compute the ratio and remainder of two big integers|
|[GreatestCommonDivisor](https://msdn.microsoft.com/library/8cec1345-1053-4364-821a-cd5f0665bd5b)|Return the greatest common divisor of two big integers|
|[One](https://msdn.microsoft.com/library/6c90baae-7d3d-4271-8d5e-1234167e8587)|Get the big integer for one|
|[op_Explicit](https://msdn.microsoft.com/library/b6008388-1861-4ae1-b280-d34facb86cfe)|Convert a big integer to a floating point number|
|[Parse](https://msdn.microsoft.com/library/c40b2466-bbfa-4b01-af23-20f47ab4d326)|Parse a big integer from a string format|
|[Pow](https://msdn.microsoft.com/library/c0576b04-97ca-45e9-9b9a-f2dbcf97cd75)|Return n^m for two big integers|
|[Zero](https://msdn.microsoft.com/library/9a2bd30a-0c44-46c9-9f1e-1c6bc9199f18)|Get the big integer for zero|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0

## See Also
[System.Numerics Namespace &#40;F&#35;&#41;](System.Numerics-Namespace-%5BFSharp%5D.md)
