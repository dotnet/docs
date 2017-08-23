---
title: Code Formatting Guidelines (F#)
description: Learn code indentation formatting guidelines for the F# programming language for readability, aesthetics, standardization, and compilation.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 3f79717c-f84e-448d-9ce4-90e40a644ba1 
---

# Code Formatting Guidelines

This topic summarizes code indentation guidelines for F#. Because the F# language is sensitive to line breaks and indentation, it is not just a readability issue, aesthetic issue, or coding standardization issue to format your code correctly. You must format your code correctly for it to compile correctly.


## General Rules for Indentation
When indentation is required, you must use spaces, not tabs. At least one space is required. Your organization can create coding standards to specify the number of spaces to use for indentation; three or four spaces of indentation at each level where indentation occurs is typical. You can configure Visual Studio to match your organization's indentation standards by changing the options in the `Options` dialog box, which is available from the `Tools` menu. In the `Text Editor` node, expand `F#` and then click `Tabs`. For a description of the available options, see [Options, Text Editor, All Languages, Tabs](https://msdn.microsoft.com/library/7sffa753.aspx).

In general, when the compiler parses your code, it maintains an internal stack that indicates the current level of nesting. When code is indented, a new level of nesting is created, or pushed onto this internal stack. When a construct ends, the level is popped. Indentation is one way to signal the end of a level and pop the internal stack, but certain tokens also cause the level to be popped, such as the `end` keyword, or a closing brace or parenthesis.

Code in a multiline construct, such as a type definition, function definition, `try...with` construct, and looping constructs, must be indented relative to the opening line of the construct. The first indented line establishes a column position for subsequent code in the same construct. The indentation level is called a *context*. The column position sets a minimum column, referred to as an *offside line*, for subsequent lines of code that are in the same context. When a line of code is encountered that is indented less than this established column position, the compiler assumes that the context has ended and that you are now coding at the next level up, in the previous context. The term *offside* is used to describe the condition in which a line of code triggers the end of a construct because it is not indented far enough. In other words, code to the left of an offside line is offside. In correctly indented code, you take advantage of the offside rule in order to delineate the end of constructs. If you use indentation improperly, an offside condition can cause the compiler to issue a warning or can lead to the incorrect interpretation of your code.

Offside lines are determined as follows.


- An `=` token associated with a `let` introduces an offside line at the column of the first token after the `=` sign.


- In an `if...then...else` expression, the column position of the first token after the `then` keyword or the `else` keyword introduces an offside line.


- In a `try...with` expression, the first token after `try` introduces an offside line.


- In a `match` expression, the first token after `with` and the first token after each `->` introduce offside lines.


- The first token after `with` in a type extension introduces an offside line.


- The first token after an opening brace or parenthesis, or after the `begin` keyword, introduces an offside line.


- The first character in the keywords `let`, `if`, and `module` introduce offside lines.


The following code examples illustrate the indentation rules. Here, the print statements rely on indentation to associate them with the appropriate context. Every time the indentation shifts, the context is popped and returns to the previous context. Therefore, a space is printed at the end of each iteration; "Done!" is only printed one time because the offside indentation establishes that it is not part of the loop. The printing of the string "Top-level context" is not part of the function. Therefore, it is printed first, during the static initialization, before the function is called.

[!code-fsharp[Main](../../../samples/snippets/fsharp/code-formatting/snippet1.fs)]

The output is as follows.

```
Top-level context

(Negative number) Zero 1 2 3 Done!
```

When you break long lines, the continuation of the line must be indented farther than the enclosing construct. For example, function arguments must be indented farther than the first character of the function name, as shown in the following code.

[!code-fsharp[Main](../../../samples/snippets/fsharp/code-formatting/snippet2.fs)]

There are exceptions to these rules, as described in the next section.


## Indentation in Modules
Code in a local module must be indented relative to the module, but code in a top-level module does not have to be indented. Namespace elements do not have to be indented.

The following code examples illustrate this.

[!code-fsharp[Main](../../../samples/snippets/fsharp/code-formatting/snippet3.fs)]
[!code-fsharp[Main](../../../samples/snippets/fsharp/code-formatting/snippet4.fs)]

For more information, see [Modules](modules.md).


## Exceptions to the Basic Indentation Rules
The general rule, as described in the previous section, is that code in multiline constructs must be indented relative to the indentation of the first line of the construct, and that the end of the construct is determined by when the first offside line occurs. An exception to the rule about when contexts end is that some constructs, such as the `try...with` expression, the `if...then...else` expression, and the use of `and` syntax for declaring mutually recursive functions or types, have multiple parts. You indent the later parts, such as `then` and `else` in an `if...then...else` expression, at the same level as the token that starts the expression, but instead of indicating an end to the context, it represents the next part of the same context. Therefore, an `if...then...else` expression can be written as in the following code example.

[!code-fsharp[Main](../../../samples/snippets/fsharp/code-formatting/snippet5.fs)]

The exception to the offside rule applies only to the `then` and `else` keywords. Therefore, although it is not an error to indent the `then` and `else` further, failing to indent the lines of code in a `then` block produces a warning. This is illustrated in the following lines of code.

[!code-fsharp[Main](../../../samples/snippets/fsharp/code-formatting/snippet6.fs)]
[!code-fsharp[Main](../../../samples/snippets/fsharp/code-formatting/snippet7.fs)]

For code in an `else` block, an additional special rule applies. The warning in the previous example occurs only on the code in the `then` block, not on the code in the `else` block. This allows you to write code that checks for various conditions at the beginning of a function without forcing the rest of the code for the function, which might be in an `else` block, to be indented. Thus, you can write the following without producing a warning.

[!code-fsharp[Main](../../../samples/snippets/fsharp/code-formatting/snippet8.fs)]

Another exception to the rule that contexts end when a line is not indented as far as a previous line is for infix operators, such as `+` and `|>`. Lines that start with infix operators are permitted to begin `(1 + oplength)` columns before the normal position without triggering an end to the context, where `oplength` is the number of characters that make up the operator. This causes the first token after the operator to align with the previous line.

For example, in the following code, the `+` symbol is permitted to be indented two columns less than the previous line.

[!code-fsharp[Main](../../../samples/snippets/fsharp/code-formatting/snippet9.fs)]

Although indentation usually increases as the level of nesting becomes higher, there are several constructs in which the compiler allows you to reset the indentation to a lower column position.

The constructs that permit a reset of column position are as follows:


- Bodies of anonymous functions. In the following code, the print expression starts at a column position that is farther to the left than the `fun` keyword. However, the line must not start at a column to the left of the start of the previous indentation level (that is, to the left of the `L` in `List`).
[!code-fsharp[Main](../../../samples/snippets/fsharp/code-formatting/snippet10.fs)]

- Constructs enclosed by parentheses or by `begin` and `end` in a `then` or `else` block of an `if...then...else` expression, provided the indentation is no less than the column position of the `if` keyword. This exception allows for a coding style in which an opening parenthesis or `begin` is used at the end of a line after `then` or `else`.


- Bodies of modules, classes, interfaces, and structures delimited by `begin...end`, `{...}`, `class...end`, or `interface...end`. This allows for a style in which the opening keyword of a type definition can be on the same line as the type name without forcing the whole body to be indented farther than the opening keyword.
[!code-fsharp[Main](../../../samples/snippets/fsharp/code-formatting/snippet13.fs)]


## See Also
[F# Language Reference](index.md)
