---
title: Compiler Directives (F#)
description: Learn about F# language preprocessor directives, conditional compilation directives, line directives, and compiler directives.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 93aef07a-6747-4ce4-a10f-a05168978af6 
---

# Compiler Directives

This topic describes processor directives and compiler directives.


## Preprocessor Directives
A preprocessor directive is prefixed with the # symbol and appears on a line by itself. It is interpreted by the preprocessor, which runs before the compiler itself.

The following table lists the preprocessor directives that are available in F#.


|Directive|Description|
|---------|-----------|
|`#if` *symbol*|Supports conditional compilation. Code in the section after the `#if` is included if the *symbol* is defined.|
|`#else`|Supports conditional compilation. Marks a section of code to include if the symbol used with the previous `#if` is not defined.|
|`#endif`|Supports conditional compilation. Marks the end of a conditional section of code.|
|`#`[line] *int*,<br/>`#`[line] *int* *string*,<br/>`#`[line] *int* *verbatim-string*|Indicates the original source code line and file name, for debugging. This feature is provided for tools that generate F# source code.|
|`#nowarn` *warningcode*|Disables a compiler warning or warnings. To disable a warning, find its number from the compiler output and include it in quotation marks. Omit the "FS" prefix. To disable multiple warning numbers on the same line, include each number in quotation marks, and separate each string by a space. For example:

`#nowarn "9" "40"`


The effect of disabling a warning applies to the entire file, including portions of the file that precede the directive.|

## Conditional Compilation Directives
Code that is deactivated by one of these directives appears dimmed in the Visual StudioCode Editor.


>[!NOTE] 
The behavior of the conditional compilation directives is not the same as it is in other languages. For example, you cannot use Boolean expressions involving symbols, and `true` and `false` have no special meaning. Symbols that you use in the `if` directive must be defined by the command line or in the project settings; there is no `define` preprocessor directive.


The following code illustrates the use of the `#if`, `#else`, and `#endif` directives. In this example, the code contains two versions of the definition of `function1`. When `VERSION1` is defined by using the [-define compiler option](https://msdn.microsoft.com/library/434394ae-0d4a-459c-a684-bffede519a04), the code between the `#if` directive and the `#else` directive is activated. Otherwise, the code between `#else` and `#endif` is activated.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-2/snippet7301.fs)]

There is no `#define` preprocessor directive in F#. You must use the compiler option or project settings to define the symbols used by the `#if` directive.

Conditional compilation directives can be nested. Indentation is not significant for preprocessor directives.


## Line Directives
When building, the compiler reports errors in F# code by referencing line numbers on which each error occurs. These line numbers start at 1 for the first line in a file. However, if you are generating F# source code from another tool, the line numbers in the generated code are generally not of interest, because the errors in the generated F# code most likely arise from another source. The `#line` directive provides a way for authors of tools that generate F# source code to pass information about the original line numbers and source files to the generated F# code.

When you use the `#line` directive, file names must be enclosed in quotation marks. Unless the verbatim token (`@`) appears in front of the string, you must escape backslash characters by using two backslash characters instead of one in order to use them in the path. The following are valid line tokens. In these examples, assume that the original file `Script1` results in an automatically generated F# code file when it is run through a tool, and that the code at the location of these directives is generated from some tokens at line 25 in file `Script1`.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-2/snippet7303.fs)]

These tokens indicate that the F# code generated at this location is derived from some constructs at or near line `25` in `Script1`.


## Compiler Directives
Compiler directives resemble preprocessor directives, because they are prefixed with a # sign, but instead of being interpreted by the preprocessor, they are left for the compiler to interpret and act on.

The following table lists the compiler directive that is available in F#.


|Directive|Description|
|---------|-----------|
|`#light` ["on"&#124;"off"]|Enables or disables lightweight syntax, for compatibility with other versions of ML. By default, lightweight syntax is enabled. Verbose syntax is always enabled. Therefore, you can use both lightweight syntax and verbose syntax. The directive `#light` by itself is equivalent to `#light "on"`. If you specify `#light "off"`, you must use verbose syntax for all language constructs. Syntax in the documentation for F# is presented with the assumption that you are using lightweight syntax. For more information, see [Verbose Syntax](verbose-syntax.md).|
For interpreter (fsi.exe) directives, see [Interactive Programming with F#](../tutorials/fsharp-interactive/index.md).


## See Also
[F# Language Reference](index.md)

[Compiler Options](compiler-options.md)

