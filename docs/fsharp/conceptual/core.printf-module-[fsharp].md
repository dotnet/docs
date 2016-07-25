---
title: Core.Printf Module (F#)
description: Core.Printf Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5adc9ddc-8648-40c0-8402-4d53d07c772b 
---

# Core.Printf Module (F#)

Extensible `printf`-style formatting for numbers and other datatypes.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
module Printf
```

## Remarks
Format specifications are strings with `%` markers indicating format placeholders. Format placeholders consist of: `%[flags][width][.precision][type]` where the type is interpreted as in the following table:

|Type|Description|
|----|-----------|
|`%b`|Formats a `bool`, formatted as `true` or `false`.|
|`%c`|Formats a character.|
|`%s`|Formats a `string`, formatted as its contents, without interpreting any escape characters.|
|`%d, %i`|Formats any basic integer type formatted as a decimal integer, signed if the basic integer type is signed.|
|`%u`|Formats any basic integer type formatted as an unsigned decimal integer.|
|`%x`|Formats any basic integer type formatted as an unsigned hexadecimal integer, using lowercase letters a through f.|
|`%X`|Formats any basic integer type formatted as an unsigned hexadecimal integer, using uppercase letters A through F.|
|`%o`|Formats any basic integer type formatted as an unsigned octal integer.|
|`%e, %E, %f, %F, %g, %G`|Formats any basic floating point type (`float`, `float32`) formatted using a C-style floating point format specifications.|
|`%e, %E`|Formats a signed value having the form `[-]d.dddde[sign]ddd` where `d` is a single decimal digit, `dddd` is one or more decimal digits, `ddd` is exactly three decimal digits, and sign is + or -.|
|`%f`|Formats a signed value having the form `[-]dddd.dddd`, where `dddd` is one or more decimal digits. The number of digits before the decimal point depends on the magnitude of the number, and the number of digits after the decimal point depends on the requested precision.|
|`%g, %G`|Formats a signed value printed in f or e format, whichever is more compact for the given value and precision.|
|`%M`|Formats a `System.Decimal` value.|
|`%O`|Formats any value, printed by boxing the object and using its `ToString` method.|
|`%A, %+A`|Formats any value, printed with the default layout settings. Use `%+A` to print the structure of discriminated unions with internal and private representations.|
|`%a`|A general format specifier, requires two arguments. The first argument is a function which accepts two arguments: first, a context parameter of the appropriate type for the given formatting function (for example, a `System.IO.TextWriter`), and second, a value to print and which either outputs or returns appropriate text.<br /><br />The second argument is the particular value to print.|
|`%t`|A general format specifier, requires one argument: a function which accepts a context parameter of the appropriate type for the given formatting function (a `System.IO.TextWriter`)and which either outputs or returns appropriate text. Basic integer types are `byte`, `sbyte`, `int16`, `uint16`, `int32`, `uint32`, `int64`, `uint64`, `nativeint`, and `unativeint`. Basic floating point types are `float` and `float32`.|
The optional *width* is an integer indicating the minimal width of the result. For instance, `%6d` prints an integer, prefixing it with spaces to fill at least 6 characters. If width is `&#42;`, then an extra integer argument is taken to specify the corresponding width.

Valid flags are described in the following table.



||
|-|
|`0`|Specifies to add zeros instead of spaces to make up the required width.|
|`-`|Specifies to left-justify the result within the width specified.|
|`+`|Specifies to add a `+` character if the number is positive (to match a `-` sign for negative numbers).|
|`' '`(space)|Specifies to add an extra space if the number is positive (to match a `-` sign for negative numbers).|
|`#`|Invalid.|

## Type Abbreviations


|Type|Description|
|----|-----------|
|type [BuilderFormat&lt;'T,'Result&gt;](https://msdn.microsoft.com/library/79f817c8-9d0c-440c-9174-d6ef1eabcaa0)|Represents a statically-analyzed format associated with writing to a **System.Text.StringBuilder**. The first type parameter indicates the arguments of the format operation and the last the overall return type.|
|type [BuilderFormat&lt;'T&gt;](https://msdn.microsoft.com/library/e6479548-d3ad-4522-baa5-987d52d7ce4a)|Represents a statically-analyzed format associated with writing to a **System.Text.StringBuilder**. The type parameter indicates the arguments and return type of the format operation.|
|type [StringFormat&lt;'T,'Result&gt;](https://msdn.microsoft.com/library/d69a911f-3a25-42fa-bd51-a9c9c1102fa8)|Represents a statically-analyzed format when formatting builds a string. The first type parameter indicates the arguments of the format operation and the last the overall return type.|
|type [StringFormat&lt;'T&gt;](https://msdn.microsoft.com/library/4226a2e7-9ebc-466f-8547-da79f0b05cd1)|Represents a statically-analyzed format when formatting builds a string. The type parameter indicates the arguments and return type of the format operation.|
|type [TextWriterFormat&lt;'T,'Result&gt;](https://msdn.microsoft.com/library/869f361a-8789-4c2d-acfc-38adec848c68)|Represents a statically-analyzed format associated with writing to a **System.IO.TextWriter**. The first type parameter indicates the arguments of the format operation and the last the overall return type.|
|type [TextWriterFormat&lt;'T&gt;](https://msdn.microsoft.com/library/2080c4a5-7bdd-4a01-8e01-10b498af92de)|Represents a statically-analyzed format associated with writing to a **System.IO.TextWriter**. The type parameter indicates the arguments and return type of the format operation.|

## Values


|Value|Description|
|-----|-----------|
|[bprintf](https://msdn.microsoft.com/library/5448c060-a61d-4f3d-a9ec-e0cc998b4d87)<br />**: StringBuilder -&gt; BuilderFormat&lt;'T&gt; -&gt; 'T**|Prints to a **System.Text.StringBuilder**.|
|[eprintf](https://msdn.microsoft.com/library/6746910a-35c1-47bb-94b2-656490525326)<br />**: TextWriterFormat&lt;'T&gt; -&gt; 'T**|Prints formatted output to **stderr**.|
|[eprintfn](https://msdn.microsoft.com/library/af397b4e-8f8b-4a9e-84df-ef18e0ebf82a)<br />**: TextWriterFormat&lt;'T&gt; -&gt; 'T**|Prints formatted output to **stderr**, adding a newline.|
|[failwithf](https://msdn.microsoft.com/library/c97d327a-edda-4202-acc8-ed8dc90709de)<br />**: StringFormat&lt;'T,'Result&gt; -&gt; 'T**|Prints to a string buffer and raises an exception with the given result. Helper printers must return strings.|
|[fprintf](https://msdn.microsoft.com/library/18f16c19-14e9-4eea-b147-cc302132c1e8)<br />**: TextWriter -&gt; TextWriterFormat&lt;'T&gt; -&gt; 'T**|Prints to a text writer.|
|[fprintfn](https://msdn.microsoft.com/library/f927a4fa-122c-4547-a87d-6dca9197c4e3)<br />**: TextWriter -&gt; TextWriterFormat&lt;'T&gt; -&gt; 'T**|Prints to a text writer, adding a newline.|
|[kbprintf](https://msdn.microsoft.com/library/c7e58e8a-9038-4922-9624-8fa2f9f590fd)<br />**: (unit -&gt; 'Result) -&gt; StringBuilder -&gt; BuilderFormat&lt;'T,'Result&gt; -&gt; 'T**|Like [bprintf](https://msdn.microsoft.com/library/5448c060-a61d-4f3d-a9ec-e0cc998b4d87), but calls the specified function to generate the result. See [kprintf](https://msdn.microsoft.com/library/fa31f68e-f039-4406-b9e1-688945430124).|
|[kfprintf](https://msdn.microsoft.com/library/3aeb13e7-7a4d-4bd3-8265-b9350c7a2610)<br />**: (unit -&gt; 'Result) -&gt; TextWriter -&gt; TextWriterFormat&lt;'T,'Result&gt; -&gt; 'T**|Like [fprintf](https://msdn.microsoft.com/library/18f16c19-14e9-4eea-b147-cc302132c1e8), but calls the specified function to generate the result. See [kprintf](https://msdn.microsoft.com/library/fa31f68e-f039-4406-b9e1-688945430124).|
|[kprintf](https://msdn.microsoft.com/library/fa31f68e-f039-4406-b9e1-688945430124)<br />**: (string -&gt; 'Result) -&gt; StringFormat&lt;'T,'Result&gt; -&gt; 'T**|Like [printf](https://msdn.microsoft.com/library/f21a2219-5d06-4211-82a3-c4538fc47f34), but calls the specified function to generate the result. For example, these let the printing force a flush after all output has been entered onto the channel, but not before.|
|[ksprintf](https://msdn.microsoft.com/library/03e98a01-11af-4f2c-902f-451cfca943e5)<br />**: (string -&gt; 'Result) -&gt; StringFormat&lt;'T,'Result&gt; -&gt; 'T**|Like [sprintf](https://msdn.microsoft.com/library/d66bc456-582f-48ec-8054-ca48d99d6ffd), but calls the specified function to generate the result. See [kprintf](https://msdn.microsoft.com/library/fa31f68e-f039-4406-b9e1-688945430124).|
|[printf](https://msdn.microsoft.com/library/f21a2219-5d06-4211-82a3-c4538fc47f34)<br />**: TextWriterFormat&lt;'T&gt; -&gt; 'T**|Prints formatted output to **stdout**.|
|[printfn](https://msdn.microsoft.com/library/ec1e8178-0caa-453c-9bdd-e48519401e0d)<br />**: TextWriterFormat&lt;'T&gt; -&gt; 'T**|Prints formatted output to **stdout**, adding a newline.|
|[sprintf](https://msdn.microsoft.com/library/d66bc456-582f-48ec-8054-ca48d99d6ffd)<br />**: StringFormat&lt;'T&gt; -&gt; 'T**|Prints to a string by using an internal string buffer and returns the result as a string. Helper printers must return strings.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

Supported in: 2, 3

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)