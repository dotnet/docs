---
title: Compiler Directives
description: Learn about F# language preprocessor directives, conditional compilation directives, line directives, and compiler directives.
ms.date: 12/10/2018
f1_keywords:
 - "#endif_FS"
---
# Compiler Directives

This topic describes processor directives and compiler directives.

For F# Interactive (`dotnet fsi`) directives, see [Interactive Programming with F#](../tools/fsharp-interactive/index.md).

## Preprocessor Directives

A preprocessor directive is prefixed with the # symbol and appears on a line by itself. It is interpreted by the preprocessor, which runs before the compiler itself.

The following table lists the preprocessor directives that are available in F#.

|Directive|Description|
|---------|-----------|
|`#if` *symbol*|Supports conditional compilation. Code in the section after the `#if` is included if the *symbol* is defined. The symbol can also be negated with `!`.|
|`#else`|Supports conditional compilation. Marks a section of code to include if the symbol used with the previous `#if` is not defined.|
|`#endif`|Supports conditional compilation. Marks the end of a conditional section of code.|
|`#`[line] *int*,<br/>`#`[line] *int* *string*,<br/>`#`[line] *int* *verbatim-string*|Indicates the original source code line and file name, for debugging. This feature is provided for tools that generate F# source code.|
|`#nowarn` *warningcode*|Disables a compiler warning or warnings. To disable multiple warning numbers on the same line, separate each string by a space. <br/> For example: `#nowarn 9 42`|

The effect of disabling a warning applies to the entire file, including portions of the file that precede the directive.|

## Conditional Compilation Directives

Code that is deactivated by one of these directives appears dimmed in the Visual Studio Code Editor.

> [!NOTE]
> The behavior of the conditional compilation directives is not the same as it is in other languages. For example, you cannot use Boolean expressions involving symbols, and `true` and `false` have no special meaning. Symbols that you use in the `if` directive must be defined by the command line or in the project settings; there is no `define` preprocessor directive.

The following code illustrates the use of the `#if`, `#else`, and `#endif` directives. In this example, the code contains two versions of the definition of `function1`. When `VERSION1` is defined by using the [-define compiler option](./compiler-options.md), the code between the `#if` directive and the `#else` directive is activated. Otherwise, the code between `#else` and `#endif` is activated.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet7301.fs)]

There is no `#define` preprocessor directive in F#. You must use the compiler option or project settings to define the symbols used by the `#if` directive.

Conditional compilation directives can be nested. Indentation is not significant for preprocessor directives.

You can also negate a symbol with `!`. In this example, a string's value is something only when _not_ debugging:

```fsharp
#if !DEBUG
let str = "Not debugging!"
#else
let str = "Debugging!"
#endif
```

## Line Directives

When building, the compiler reports errors in F# code by referencing line numbers on which each error occurs. These line numbers start at 1 for the first line in a file. However, if you are generating F# source code from another tool, the line numbers in the generated code are generally not of interest, because the errors in the generated F# code most likely arise from another source. The `#line` directive provides a way for authors of tools that generate F# source code to pass information about the original line numbers and source files to the generated F# code.

When you use the `#line` directive, file names must be enclosed in quotation marks. Unless the verbatim token (`@`) appears in front of the string, you must escape backslash characters by using two backslash characters instead of one in order to use them in the path. The following are valid line tokens. In these examples, assume that the original file `Script1` results in an automatically generated F# code file when it is run through a tool, and that the code at the location of these directives is generated from some tokens at line 25 in file `Script1`.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet7303.fs)]

These tokens indicate that the F# code generated at this location is derived from some constructs at or near line `25` in `Script1`.

## See also

- [F# Language Reference](index.md)
- [Compiler Options](compiler-options.md)
