---
title: ExtraTopLevelOperators.printfn<'T> Function (F#)
description: ExtraTopLevelOperators.printfn<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d0233cc5-f8f3-404b-8884-1881d788ec45 
---

# ExtraTopLevelOperators.printfn<'T> Function (F#)

The `printfn` function prints to `stdout` using the given format, and adds a newline.

**Namespace/Module Path:** Microsoft.FSharp.Core.ExtraTopLevelOperators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
printfn : TextWriterFormat<'T> -> 'T

// Usage:
printfn format
```

#### Parameters
*format*
Type: [TextWriterFormat](https://msdn.microsoft.com/library/2080c4a5-7bdd-4a01-8e01-10b498af92de)**&lt;'T&gt;**


## Remarks
This function is named `PrintFormatLine` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code example demonstrates the use of `printfn` with various format specifiers. For more information on format specifiers, see [Printf Module](https://msdn.microsoft.com/library/ea074733-6b5d-498c-ac88-7e4e0f8ded25).

[!code-fsharp[Main](snippets/fscorelib2/snippet9.fs)]

**Output**

```
Printing Boolean values: false true
Printing strings (note literal printing of string with special character): test1C:\test2
Printing an integer in decimal form, with and without a width: -123       1891
Printing an integer in lowercase hexadecimal: ffffff85 or 0x763
Printing as an unsigned integer: 4294967173 1891
Printing an integer as uppercase hexadecimal: FFFFFF85 or 0x763
Printing as an octal integer: 37777777605 3543
Printing in columns.  10099900        15       230       869  -8388114
10099841        74       289       574  -8388055
10099782       133       348       429  -8387996
10099723       192       407       342  -8387937
10099664       251       466       284  -8387878
10099605       310       525       243  -8387819
10099546       369       584       213  -8387760
10099487       428       643       189  -8387701
10099428       487       702       170  -8387642
10099369       546       761       154  -8387583
10099310       605       820       141  -8387524
10099251       664       879       130  -8387465
10099192       723       938       121  -8387406
10099133       782       997       113  -8387347
10099074       841      1056       106  -8387288
10099015       900      1115        99  -8387229
Printing floating point numbers 3.141593e+000 6.022000e+023
Printing floating point numbers 3.141593E+000 6.022000E+023
Printing floating point numbers 3.141593 602200000000000000000000.000000
Printing floating point numbers 3.141593 602200000000000000000000.000000
Printing floating point numbers 3.14159 6.022E+23
Using the width and precision modifiers: 3.14159e+000 6.022e+023
Using the flags:Zero Pad:|0000001001| Plus:|     +1001 |LeftJustify:|1001      | SpacePad:| 1001|
zero pad   | |+- both   | |- and ' ' | |' ' and 0 | | normal
|0000000195| |-30       | |-15       | |-000000869| |      -195|
|0000000178| |-13       | | 2        | |-000001020| |      -178|
|0000000161| |+4        | | 19       | |-000001234| |      -161|
|0000000144| |+21       | | 36       | |-000001562| |      -144|
|0000000127| |+38       | | 53       | |-000002127| |      -127|
|0000000110| |+55       | | 70       | |-000003333| |      -110|
|0000000093| |+72       | | 87       | |-000007691| |       -93|
|0000000076| |+89       | | 104      | | 000024998| |       -76|
|0000000059| |+106      | | 121      | | 000004761| |       -59|
|0000000042| |+123      | | 138      | | 000002631| |       -42|
|0000000025| |+140      | | 155      | | 000001818| |       -25|
|0000000008| |+157      | | 172      | | 000001388| |        -8|
|-000000009| |+174      | | 189      | | 000001123| |         9|
Decimal: 0.124
Print as object: 12 1.1 test FSI_0006+clo@159-44
[|1; 2; 3|]
Printing from a function (no args): X
Printing from a function with arg: Printing 10.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0

## See Also
[Core.ExtraTopLevelOperators Module &#40;F&#35;&#41;](Core.ExtraTopLevelOperators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)