---
title: Core.Operators Module (F#)
description: Core.Operators Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 0f84a595-0342-4549-bebf-382f1b7c3603 
---

# Core.Operators Module (F#)

Basic F# Operators. This module is automatically opened in all F# code.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
[<AutoOpen>]
module Operators
```

## Remarks
For an overview of operators in F#, see [Symbol and Operator Reference &#40;F&#35;&#41;](Symbol-and-Operator-Reference-%5BFSharp%5D.md).


## Modules


|Module|Description|
|------|-----------|
|module [Checked](https://msdn.microsoft.com/library/6e3326ec-0f93-4ab9-ae33-235ab6eb0028)|This module contains the basic arithmetic operations with overflow checks.|
|module [OperatorIntrinsics](https://msdn.microsoft.com/library/3935ecdd-dc7f-43ac-9a5e-87258642fdf2)|A module of compiler intrinsic functions for efficient implementations of F# integer ranges and dynamic invocations of other F# operators|
|module [Unchecked](https://msdn.microsoft.com/library/4489ee14-8fae-42af-96b2-51b6c94b5c47)|This module contains basic operations which do not apply runtime and/or static checks|

## Values


|Value|Description|
|-----|-----------|
|[( ! )](https://msdn.microsoft.com/library/4693bc7d-c9b9-46a1-b7cc-7f16e99ca530)<br />**: 'T ref -&gt; 'T**|Dereference a mutable reference cell.|
|[( % )](https://msdn.microsoft.com/library/943ef92c-4638-4702-b50b-fa5160c7b97b)<br />**: ^T1 -&gt; ^T2 -&gt; ^T3**|Overloaded modulo operator.|
|[( &amp;&amp;&amp; )](https://msdn.microsoft.com/library/f55a7657-11ac-4085-a05a-808779e4dcd9)<br />**: ^T -&gt; ^T -&gt; ^T**|Overloaded bitwise AND operator.|
|[( &#42; )](https://msdn.microsoft.com/library/3b2eba90-d43b-45c9-bb1f-f17d40fb2eb8)<br />**: ^T1 -&gt; ^T2 -&gt; ^T3**|Overloaded multiplication operator.|
|[( &#42;&#42; )](https://msdn.microsoft.com/library/4648b5ab-7999-4a22-9f09-10f7d272d9d5)<br />**: ^T -&gt; ^U -&gt; ^T**|Overloaded exponentiation operator.|
|[( + )](https://msdn.microsoft.com/library/67b8d50f-5675-4bdc-bd41-807181aca5aa)<br />**: ^T1 -&gt; ^T2 -&gt; ^T3**|Overloaded addition operator.|
|[( - )](https://msdn.microsoft.com/library/d6a2e812-d25f-47a9-8d2f-d2c023730372)<br />**: ^T1 -&gt; ^T2 -&gt; ^T3**|Overloaded subtraction operator.|
|[( .. )](https://msdn.microsoft.com/library/ebe9fda6-3706-4eb7-96c9-2b1389f6c138)<br />**: ^T -&gt; ^T -&gt; seq&lt;^T&gt;**|The standard overloaded range operator, e.g. **[n..m]** for lists, **seq {n..m}** for sequences.|
|[( .. .. )](https://msdn.microsoft.com/library/57cae22a-bf12-4872-b7d9-e4e0b5ff6b93)<br />**: ^T -&gt; ^Step -&gt; ^T -&gt; seq&lt;^T&gt;**|The standard overloaded skip range operator, e.g. **[n..skip..m]** for lists, **seq {n..skip..m}** for sequences.|
|[( / )](https://msdn.microsoft.com/library/0b2e9fce-c5c8-43f1-bccb-c3cd94e95672)<br />**: ^T1 -&gt; ^T2 -&gt; ^T3**|Overloaded division operator.|
|[( := )](https://msdn.microsoft.com/library/34a4ab7c-643b-4720-976a-cb56a9db9844)<br />**: 'T ref -&gt; 'T -&gt; unit**|Assigns to a mutable reference cell.|
|[( &lt; )](https://msdn.microsoft.com/library/50147f6e-f4fc-450d-ba6d-9b66a5a90dac)<br />**: 'T -&gt; 'T -&gt; bool**|Structural less-than comparison.|
|[( &lt;&lt; )](https://msdn.microsoft.com/library/c0293938-8230-46c3-a775-0d539854171f)<br />**: ('T2 -&gt; 'T3) -&gt; ('T1 -&gt; 'T2) -&gt; 'T1 -&gt; 'T3**|Composes two functions, the function on the right being applied first.|
|[( &lt;&lt;&lt; )](https://msdn.microsoft.com/library/b57270b5-5cc7-4a76-aa7f-6c4b9543da63)<br />**: ^T -&gt; int32 -&gt; ^T**|Overloaded byte-shift left operator by a specified number of bits.|
|[( &lt;= )](https://msdn.microsoft.com/library/dfea6208-c6dd-4b83-a6f8-3f9cad3c9c21)<br />**: 'T -&gt; 'T -&gt; bool**|Structural less-than-or-equal comparison.|
|[( &lt;&gt; )](https://msdn.microsoft.com/library/dbcec78d-9cf0-40d2-b099-681d2f61b45e)<br />**: 'T -&gt; 'T -&gt; bool**|Structural inequality.|
|[( &lt;&#124; )](https://msdn.microsoft.com/library/fcbd0345-3d2a-4903-a855-a09a06e4c780)<br />**: ('T -&gt; 'U) -&gt; 'T -&gt; 'U**|Apply a function to a value, the value being on the right, the function on the left.|
|[( &lt;&#124;&#124; )](https://msdn.microsoft.com/library/caca1c07-955d-45b2-a1e8-85a387ff9a24)<br />**: ('T1 -&gt; 'T2 -&gt; 'U) -&gt; 'T1 &#42; 'T2 -&gt; 'U**|Apply a function to two values, the values being a pair on the right, the function on the left.|
|[( &lt;&#124;&#124;&#124; )](https://msdn.microsoft.com/library/d9d24615-7f76-4ed8-8e31-3edc6d2ea45b)<br />**: ('T1 -&gt; 'T2 -&gt; 'T3 -&gt; 'U) -&gt; 'T1 &#42; 'T2 &#42; 'T3 -&gt; 'U**|Apply a function to three values, the values being a triple on the right, the function on the left.|
|[( = )](https://msdn.microsoft.com/library/5b1167e1-cc30-4d26-9f1d-556b2a308187)<br />**: 'T -&gt; 'T -&gt; bool**|Structural equality.|
|[( &gt; )](https://msdn.microsoft.com/library/22954f96-f585-47a1-8199-ac2a7c85d7e0)<br />**: 'T -&gt; 'T -&gt; bool**|Structural greater-than.|
|[( &gt;= )](https://msdn.microsoft.com/library/376e1388-824c-43cb-87f4-3e3d40e360d3)<br />**: 'T -&gt; 'T -&gt; bool**|Structural greater-than-or-equal.|
|[( &gt;&gt; )](https://msdn.microsoft.com/library/b604e1f2-7d61-4ff0-aa0d-0b691b17bd0b)<br />**: ('T1 -&gt; 'T2) -&gt; ('T2 -&gt; 'T3) -&gt; 'T1 -&gt; 'T3**|Compose two functions, the function on the left being applied first.|
|[( &gt;&gt;&gt; )](https://msdn.microsoft.com/library/ccd5491d-7290-4711-87a6-1966fb70f136)<br />**: ^T -&gt; int32 -&gt; ^T**|Overloaded byte-shift right operator by a specified number of bits.|
|[( @ )](https://msdn.microsoft.com/library/d5d8efb9-85fb-4500-ad83-1a4df4ceaf27)<br />**: 'T list -&gt; 'T list -&gt; 'T list**|Concatenates two lists.|
|[( ^ )](https://msdn.microsoft.com/library/f7078883-8fca-4cc8-a2ab-54127fba6f96)<br />**: string -&gt; string -&gt; string**|Concatenates two strings. The operator '+' may also be used.|
|[( ^^^ )](https://msdn.microsoft.com/library/6e37643f-f7bd-4efb-893f-59730d8275b4)<br />**: ^T -&gt; ^T -&gt; ^T**|Overloaded bitwise XOR operator.|
|[( &#124;&gt; )](https://msdn.microsoft.com/library/698b9e4a-a6d7-4ab1-8809-b2fdba783070)<br />**: 'T1 -&gt; ('T1 -&gt; 'U) -&gt; 'U**|Apply a function to a value, the value being on the left, the function on the right.|
|[( &#124;&#124;&gt; )](https://msdn.microsoft.com/library/6018719e-de1a-4d1f-8f91-88a35a4f0e8e)<br />**: 'T1 &#42; 'T2 -&gt; ('T1 -&gt; 'T2 -&gt; 'U) -&gt; 'U**|Apply a function to two values, the values being a pair on the left, the function on the right.|
|[( &#124;&#124;&#124; )](https://msdn.microsoft.com/library/69f82f6e-98f3-468c-b5cd-a0b4b411ddb2)<br />**: ^T -&gt; ^T -&gt; ^T**|Overloaded bitwise OR operator|
|[( &#124;&#124;&#124;&gt; )](https://msdn.microsoft.com/library/0b5a6221-904a-4cf8-9fd4-ad5a4ec3817b)<br />**: 'T1 &#42; 'T2 &#42; 'T3 -&gt; ('T1 -&gt; 'T2 -&gt; 'T3 -&gt; 'U) -&gt; 'U**|Apply a function to three values, the values being a triple on the left, the function on the right.|
|[( ~- )](https://msdn.microsoft.com/library/f6c4a5ca-7803-49d2-85fa-0ac3e0c2b3eb)<br />**: ^T -&gt; ^T**|Overloaded prefix plus operator.|
|[( ~- )](https://msdn.microsoft.com/library/8350b9b2-2f8c-4fd5-8c81-afacc5196d14)<br />**: ^T -&gt; ^T**|Overloaded unary negation.|
|[( ~~~ )](https://msdn.microsoft.com/library/80822c6d-b0a8-445c-adbc-2dd78954cc5d)<br />**: ^T -&gt; ^T**|Overloaded bitwise NOT operator.|
|[abs](https://msdn.microsoft.com/library/9cf0a350-111e-45df-a2d0-306884aeb937)<br />**: ^T -&gt; ^T**|Absolute value of the given number.|
|[acos](https://msdn.microsoft.com/library/cf603ed6-5ecd-47f9-890c-910b8d8a547d)<br />**: ^T -&gt; ^T**|Inverse cosine of the given number.|
|[asin](https://msdn.microsoft.com/library/b6f06c65-abef-4cde-aed1-4670763d0821)<br />**: ^T -&gt; ^T**|Inverse sine of the given number.|
|[atan](https://msdn.microsoft.com/library/ef98907a-5ee3-4c4a-80fc-681164fb8e8d)<br />**: ^T -&gt; ^T**|Inverse tangent of the given number.|
|[atan2](https://msdn.microsoft.com/library/799c1100-8969-4126-bcb0-ce0153572f18)<br />**: ^T1 -&gt; ^T2 -&gt; 'T2**|Inverse tangent of **x/y** where **x** and **y** are specified separately.|
|[box](https://msdn.microsoft.com/library/ff7846fb-95c3-4f45-bcca-8e007195fcea)<br />**: 'T -&gt; obj**|Boxes a strongly typed value.|
|[byte](https://msdn.microsoft.com/library/b87dc8ce-d08f-4fec-b1c7-3fab94640902)<br />**: ^T -&gt; byte**|Converts the argument to byte. This is a direct conversion for all primitive numeric types. For strings, the input is converted using **System.Byte.Parse(System.String)** with **System.Globalization.CultureInfo.InvariantCulture** settings. Otherwise the operation requires an appropriate static conversion method on the input type.|
|[ceil](https://msdn.microsoft.com/library/cbe3a3de-4b3e-4dc9-8231-4a3ce2a94dfd)<br />**: ^T -&gt; ^T**|Ceiling of the given number.|
|[char](https://msdn.microsoft.com/library/1f440627-e76b-485c-b186-04e94a87c556)<br />**: ^T -&gt; char**|Converts the argument to character. Numeric inputs are converted according to the UTF-16 encoding for characters. String inputs must be exactly one character long. For other input types the operation requires an appropriate static conversion method on the input type.|
|[compare](https://msdn.microsoft.com/library/295e1320-0955-4c3d-ac31-288fa80a658c)<br />**: 'T -&gt; 'T -&gt; int**|Generic comparison.|
|[cos](https://msdn.microsoft.com/library/720da6d2-619a-434c-ab57-726249b38946)<br />**: ^T -&gt; ^T**|Cosine of the given number.|
|[cosh](https://msdn.microsoft.com/library/a7d9ad01-6274-48d6-bc18-6c8c823b50fe)<br />**: ^T -&gt; ^T**|Hyperbolic cosine of the given number.|
|[decimal](https://msdn.microsoft.com/library/cfdcb2aa-9a7e-480a-8d8b-2155f9a50f95)<br />**: ^T -&gt; decimal**|Converts the argument to **System.Decimal** using a direct conversion for all primitive numeric types. For strings, the input is converted using **System.UInt64.Parse(System.String)** with **System.Globalization.CultureInfo.InvariantCulture** settings. Otherwise the operation requires an appropriate static conversion method on the input type.|
|[decr](https://msdn.microsoft.com/library/aec92e58-b4d2-4634-9a7d-7cc2336979f5)<br />**: int ref -&gt; unit**|Decrement a mutable reference cell containing an integer.|
|[defaultArg](https://msdn.microsoft.com/library/926539d7-bee7-444c-96db-9ef382b0b535)<br />**: 'T option -&gt; 'T -&gt; 'T**|Used to specify a default value for an optional argument in the implementation of a function.|
|[enum](https://msdn.microsoft.com/library/ece84451-8d9b-4030-b7f4-1265e0940bd3)<br />**: int32 -&gt; ^U**|Converts the argument to a particular **enum** type.|
|[exit](https://msdn.microsoft.com/library/8c44e492-5c5e-4e8a-b581-f7f3755eb2ee)<br />**: int -&gt; 'T**|Exit the current hardware isolated process, if security settings permit, otherwise raise an exception. Calls **System.Environment.Exit(System.Int32)**.|
|[exp](https://msdn.microsoft.com/library/97d1feb3-b35e-4cc8-a598-74066fce46a3)<br />**: ^T -&gt; ^T**|Exponential of the given number.|
|[Failure](https://msdn.microsoft.com/library/202c0c4c-5786-4cba-9276-f12c5945779d)<br />**: string -&gt; exn**|Builds a **System.Exception** object.|
|[failwith](https://msdn.microsoft.com/library/b168262a-4e63-4c9e-82c7-b952276a36be)<br />**: string -&gt; 'T**|Throw a **System.Exception** exception.|
|[float](https://msdn.microsoft.com/library/a5879ba5-c5fd-4dbc-b26c-896879c5e526)<br />**: ^T -&gt; float**|Converts the argument to 64-bit float. This is a direct conversion for all primitive numeric types. For strings, the input is converted using **System.Double.Parse(System.String)** with **System.Globalization.CultureInfo.InvariantCulture** settings. Otherwise the operation requires an appropriate static conversion method on the input type.|
|[float32](https://msdn.microsoft.com/library/9603115e-9693-46c1-bf3d-b3d15f2d187a)<br />**: ^T -&gt; float32**|Converts the argument to 32-bit float. This is a direct conversion for all primitive numeric types. For strings, the input is converted using **System.Single.Parse(System.String)** with **System.Globalization.CultureInfo.InvariantCulture** settings. Otherwise the operation requires an appropriate static conversion method on the input type.|
|[floor](https://msdn.microsoft.com/library/11c38695-dc81-4614-9cee-d03f1fc98a5e)<br />**: ^T -&gt; ^T**|Floor of the given number.|
|[fst](https://msdn.microsoft.com/library/da3d2f84-1907-45a6-95be-0b1325c9be71)<br />**: 'T1 &#42; 'T2 -&gt; 'T1**|Return the first element of a tuple, **fst (a,b) = a**.|
|[hash](https://msdn.microsoft.com/library/a83c0432-919e-407d-9ffc-8cf34fbc6daa)<br />**: 'T -&gt; int**|A generic hash function, designed to return equal hash values for items that are equal according to the **=** operator. By default it will use structural hashing for F# union, record and tuple types, hashing the complete contents of the type. The exact behavior of the function can be adjusted on a type-by-type basis by implementing **System.Object.GetHashCode** for each type.|
|[id](https://msdn.microsoft.com/library/4e20e561-9240-4482-8097-aeb481812506)<br />**: 'T -&gt; 'T**|The identity function.|
|[ignore](https://msdn.microsoft.com/library/7b42722c-525d-4352-995d-20400234aa99)<br />**: 'T -&gt; unit**|Ignore the passed value. This is often used to throw away results of a computation.|
|[incr](https://msdn.microsoft.com/library/86692cc2-d36c-4e97-a551-f05e39d80a98)<br />**: int ref -&gt; unit**|Increment a mutable reference cell containing an integer.|
|[infinity](https://msdn.microsoft.com/library/f3295d39-98ca-446a-9c29-9fd0789b8063)<br />**: float**|Equivalent to **System.Double.PositiveInfinity****.**|
|[infinityf](https://msdn.microsoft.com/library/2c73458f-1214-4bbc-9145-4896bc7efa97)<br />**: float32**|Equivalent to **System.Single.PositiveInfinity****.**|
|[int](https://msdn.microsoft.com/library/ed07c5c9-2686-4e62-82c7-147ca9b0b9ef)<br />**: ^T -&gt; int**|Converts the argument to signed 32-bit integer. This is a direct conversion for all primitive numeric types. For strings, the input is converted using **System.Int32.Parse(System.String)** with **System.Globalization.CultureInfo.InvariantCulture** settings. Otherwise the operation requires an appropriate static conversion method on the input type.|
|[int16](https://msdn.microsoft.com/library/f9dbb4d8-e58c-4ed7-940c-33bb17936a72)<br />**: ^T -&gt; int16**|Converts the argument to signed 16-bit integer. This is a direct conversion for all primitive numeric types. For strings, the input is converted using **System.Int16.Parse(System.String)** with **System.Globalization.CultureInfo.InvariantCulture** settings. Otherwise the operation requires an appropriate static conversion method on the input type.|
|[int32](https://msdn.microsoft.com/library/3783cd5f-5caa-42f9-8f1f-bc152d4f5633)<br />**: ^T -&gt; int32**|Converts the argument to signed 32-bit integer. This is a direct conversion for all primitive numeric types. For strings, the input is converted using **System.Int32.Parse(System.String)****)** with **System.Globalization.CultureInfo.InvariantCulture** settings. Otherwise the operation requires an appropriate static conversion method on the input type.|
|[int64](https://msdn.microsoft.com/library/ead1a4b8-1966-43c9-8300-d3966586356e)<br />**: ^T -&gt; int64**|Converts the argument to signed 64-bit integer. This is a direct conversion for all primitive numeric types. For strings, the input is converted using **System.Int64.Parse(System.String)** with **System.Globalization.CultureInfo.InvariantCulture** settings. Otherwise the operation requires an appropriate static conversion method on the input type.|
|[invalidArg](https://msdn.microsoft.com/library/d9f49313-8f14-4b1a-a31c-881615e307f8)<br />**: string -&gt; string -&gt; 'T**|Throw a **System.ArgumentException** exception.|
|[invalidOp](https://msdn.microsoft.com/library/c4df4f23-dfdd-4b3e-9fea-da9886634c9e)<br />**: string -&gt; 'T**|Throw a **System.InvalidOperationException** exception.|
|[limitedHash](https://msdn.microsoft.com/library/499fba7c-6b04-47e7-aeda-05420e6e2d21)<br />**: int -&gt; 'T -&gt; int**|A generic hash function. This function has the same behavior as [hash](https://msdn.microsoft.com/library/a83c0432-919e-407d-9ffc-8cf34fbc6daa), however the default structural hashing for F# union, record and tuple types stops when the given limit of nodes is reached. The exact behavior of the function can be adjusted on a type-by-type basis by implementing **System.Object.GetHashCode** for each type.|
|[lock](https://msdn.microsoft.com/library/cf1fe60b-0fa1-485e-b81d-af4859c4558d)<br />**: 'Lock -&gt; (unit -&gt; 'T) -&gt; 'T**|Execute the function as a mutual-exclusion region using the input value as a lock.|
|[log](https://msdn.microsoft.com/library/ae542476-3ee6-4311-af90-70cc4a6985c7)<br />**: ^T -&gt; ^T**|Natural logarithm of the given number.|
|[log10](https://msdn.microsoft.com/library/b51ce6ee-27dc-4af2-aef8-cc93bf9c1c61)<br />**: ^T -&gt; ^T**|Logarithm to base 10 of the given number.|
|[max](https://msdn.microsoft.com/library/9a988328-00e9-467b-8dfa-e7a6990f6cce)<br />**: 'T -&gt; 'T -&gt; 'T**|Maximum based on generic comparison.|
|[min](https://msdn.microsoft.com/library/adea4fd7-bfad-4834-989c-7878aca81fed)<br />**: 'T -&gt; 'T -&gt; 'T**|Minimum based on generic comparison.|
|[nan](https://msdn.microsoft.com/library/37b82d1c-3949-4a3b-bc02-7b142c439b91)<br />**: float**|Equivalent to **System.Double.NaN****.**|
|[nanf](https://msdn.microsoft.com/library/bd7d55d7-4caf-4555-8396-0e1df27e5f76)<br />**: float32**|Equivalent to **System.Single.NaN****.**|
|[nativeint](https://msdn.microsoft.com/library/706363ac-1354-4d69-b6a0-c424683fddcc)<br />**: ^T -&gt; nativeint**|Converts the argument to signed native integer. This is a direct conversion for all primitive numeric types. Otherwise the operation requires an appropriate static conversion method on the input type.|
|[not](https://msdn.microsoft.com/library/d6962f70-3a4a-4dba-8d54-bb0b95fe1348)<br />**: bool -&gt; bool**|Negate a logical value.|
|[nullArg](https://msdn.microsoft.com/library/8fa712d7-9492-475d-aa5f-ebeac76805a0)<br />**: string -&gt; 'T**|Throw an **System.ArgumentNullException** exception.|
|[pown](https://msdn.microsoft.com/library/c6163b1d-a8f9-4a87-8704-f34d8b2918ff)<br />**: ^T -&gt; int -&gt; ^T**|Overloaded power operator. If **n &gt; 0** then equivalent to **x&#42;...&#42;x** for **n** occurrences of **x**.|
|[raise](https://msdn.microsoft.com/library/04e33b68-2f21-4d65-bb1e-9a8b2debbe51)<br />**: Exception -&gt; 'T**|Raises an exception.|
|[ref](https://msdn.microsoft.com/library/0785a0a0-8e5d-47cf-bd7a-adb2f4074d73)<br />**: 'T -&gt; 'T ref**|Create a mutable reference cell.|
|[reraise](https://msdn.microsoft.com/library/4317fb2f-86b2-4611-bc9f-3f58add4b393)<br />**: unit -&gt; 'T**|Rethrows an exception. This should only be used when handling an exception.|
|[round](https://msdn.microsoft.com/library/8c09309b-f834-4fd9-a6fe-a7254fdf1183)<br />**: ^T -&gt; ^T**|Round the given number.|
|[sbyte](https://msdn.microsoft.com/library/b7ee5eae-c41c-4a8e-9228-cce76811363c)<br />**: ^T -&gt; sbyte**|Converts the argument to signed byte. This is a direct conversion for all primitive numeric types. For strings, the input is converted using **System.SByte.Parse(System.String)** with **System.Globalization.CultureInfo.InvariantCulture** settings. Otherwise the operation requires an appropriate static conversion method on the input type.|
|[seq](https://msdn.microsoft.com/library/acceb5cd-dfad-4e62-ade6-bb6512ebb67b)<br />**: seq&lt;'T&gt; -&gt; seq&lt;'T&gt;**|Builds a sequence using sequence expression syntax.|
|[sign](https://msdn.microsoft.com/library/f45dd870-f208-4b7c-b9d3-7bfbf783124e)<br />**: ^T -&gt; int**|Sign of the given number.|
|[sin](https://msdn.microsoft.com/library/0233772a-96b8-451b-9189-ceba5c8dbc6b)<br />**: ^T -&gt; ^T**|Sine of the given number.|
|[sinh](https://msdn.microsoft.com/library/06aa6cec-a7ad-45fa-9aaf-9ebd43831936)<br />**: ^T -&gt; ^T**|Hyperbolic sine of the given number.|
|[sizeof](https://msdn.microsoft.com/library/b077d28c-2010-439c-baa1-2fedf07d788a)<br />**: int**|Returns the internal size of a type in bytes. For example, **sizeof&lt;int&gt;** returns 4.|
|[snd](https://msdn.microsoft.com/library/79fd5480-070e-4c4c-999a-3f005e2f5d2d)<br />**: 'T1 &#42; 'T2 -&gt; 'T2**|Return the second element of a tuple, **snd (a,b) = b**.|
|[sqrt](https://msdn.microsoft.com/library/0f242424-6764-450a-bad5-134a399529eb)<br />**: ^T -&gt; ^T**|Square root of the given number.|
|[stderr](https://msdn.microsoft.com/library/e08bbd03-1f99-499c-b2e8-93b045f46a02)<br />**: TextWriter**|Reads the value of the property **System.Console.Error**.|
|[stdin](https://msdn.microsoft.com/library/d7a290e9-a46f-445c-84df-502eff38b8a2)<br />**: TextReader**|Reads the value of the property **System.Console.In**.|
|[stdout](https://msdn.microsoft.com/library/56dc929c-8589-4465-9d50-8aebd29ef456)<br />**: TextWriter**|Reads the value of the property **System.Console.Out**.|
|[string](https://msdn.microsoft.com/library/fb1e8767-fa72-4bf4-8737-7fea355d55b0)<br />**: ^T -&gt; string**|Converts the argument to a string using **System.Object.ToString**.|
|[tan](https://msdn.microsoft.com/library/97c2a187-587d-42a2-ac6c-0372ffd210f0)<br />**: ^T -&gt; ^T**|Tangent of the given number.|
|[tanh](https://msdn.microsoft.com/library/596ebd17-5c71-4d9d-a8de-3c68b076ac5f)<br />**: ^T -&gt; ^T**|Hyperbolic tangent of the given number.|
|[truncate](https://msdn.microsoft.com/library/9f6a6ebd-8324-4288-acb1-5d390c7aef3d)<br />**: ^T -&gt; ^T**|Overloaded truncate operator.|
|[typedefof](https://msdn.microsoft.com/library/3d215077-adc1-4261-a74f-04b22a09916e)<br />**: Type**|Generate a **System.Type** representation for a type definition. If the input type is a generic type instantiation then return the generic type definition associated with all such instantiations.|
|[typeof](https://msdn.microsoft.com/library/ff825d1b-e11d-48d5-9a23-a65e8a170491)<br />**: Type**|Generate a **System.Type** runtime representation of a static type. The static type is still maintained on the value returned.|
|[uint16](https://msdn.microsoft.com/library/5c4e0a16-ac7c-4b69-b599-53b19b0670e3)<br />**: ^T -&gt; uint16**|Converts the argument to unsigned 16-bit integer. This is a direct conversion for all primitive numeric types. For strings, the input is converted using **System.UInt16.Parse(System.String)** with **System.Globalization.CultureInfo.InvariantCulture** settings. Otherwise the operation requires an appropriate static conversion method on the input type.|
|[uint32](https://msdn.microsoft.com/library/65c25d6f-7f26-4d12-96fa-d0120b3b8edd)<br />**: ^T -&gt; uint32**|Converts the argument to unsigned 32-bit integer. This is a direct conversion for all primitive numeric types. For strings, the input is converted using **System.UInt32.Parse(System.String)** with **System.Globalization.CultureInfo.InvariantCulture** settings. Otherwise the operation requires an appropriate static conversion method on the input type.|
|[uint64](https://msdn.microsoft.com/library/b934a391-204c-49fa-8137-b73a6faf15d6)<br />**: ^T -&gt; uint64**|Converts the argument to unsigned 64-bit integer. This is a direct conversion for all primitive numeric types. For strings, the input is converted using **System.UInt64.Parse(System.String)** with **System.Globalization.CultureInfo.InvariantCulture** settings. Otherwise the operation requires an appropriate static conversion method on the input type.|
|[unativeint](https://msdn.microsoft.com/library/5255e9e6-2837-4d00-ac64-ddb6b9b03bba)<br />**: ^T -&gt; nativeint**|Converts the argument to unsigned native integer using a direct conversion for all primitive numeric types. Otherwise the operation requires an appropriate static conversion method on the input type.|
|[unbox](https://msdn.microsoft.com/library/7b320e53-f295-4097-bf77-893c7e4f0a0d)<br />**: obj -&gt; 'T**|Unboxes a strongly typed value. This is the inverse of **box**, **unbox&lt;'T&gt;(box&lt;'T&gt; a)** equals **a**.|
|[using](https://msdn.microsoft.com/library/de177834-c364-4a08-967b-8bd9dea1979d)<br />**: 'T -&gt; ('T -&gt; 'U) -&gt; 'U**|Clean up resources associated with the input object after the completion of the given function. Cleanup occurs even when an exception is raised by the protected code.|

## Active Patterns

|Active Pattern|Description|
|--------------|-----------|
|[( &#124;Failure&#124;_&#124; )](https://msdn.microsoft.com/library/22287ccd-b1f4-4136-aaef-2700277219f9)<br />**: exn -&gt; string option**|Matches **System.Exception** objects whose runtime type is precisely **System.Exception****.**|
|[( &#124;KeyValue&#124; )](https://msdn.microsoft.com/library/fab30359-280d-41b3-b056-e9aa78490fa3)<br />**: KeyValuePair&lt;'Key,'Value&gt; -&gt; 'Key &#42; 'Value**|An active pattern to match values of type **System.Collections.Generic.KeyValuePair&#96;2**|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)