---
title: "#Region directive"
description: "Learn how to group related lines of code using region directives in Visual Basic."
ms.date: 05/14/2021
f1_keywords:
  - "vb.Region"
  - "vb.#Region"
helpviewer_keywords:
  - "Visual Basic compiler, compiler directives"
  - "#region directive"
  - "region directive (#region)"
  - "#Region keyword [Visual Basic]"
---
# #Region directive

Collapses and hides sections of code in Visual Basic files.

## Syntax

```vb
#Region string_literal
' 0 or more statements
#End Region
```

## Parts

|Term|Definition|
|---|---|
|`#Region`|Required. Specify the start of a region.|
|`string_literal`|Required. String (enclosed between double quotes) that acts as the title of a region when it is collapsed. Regions are collapsed by default.|
|`#End Region`|Required. Terminates the `#Region` block.|

## Remarks

Use the `#Region` directive to specify a block of code to expand or collapse when using the outlining feature of Visual Studio IDE. You can place, or *nest*, regions within other regions to group similar regions together.

## Example

This example uses the `#Region` directive.

[!code-vb[VbVbalrConditionalComp#4](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrConditionalComp/VB/Class1.vb#4)]

## See also

- [#If...Then...#Else Directives](if-then-else-directives.md)
- [Outlining](/visualstudio/ide/outlining)
- [How to: Collapse and Hide Sections of Code](../../programming-guide/program-structure/how-to-collapse-and-hide-sections-of-code.md)
