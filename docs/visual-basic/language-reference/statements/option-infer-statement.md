---
description: "Learn more about: Option Infer Statement"
title: "Option Infer Statement"
ms.date: 07/20/2015
f1_keywords:
  - "vb.OptionInfer"
  - "vb.Infer"
helpviewer_keywords:
  - "variables [Visual Basic], declaring"
  - "Option Infer statement [Visual Basic]"
  - "Infer keyword [Visual Basic]"
  - "declaring variables [Visual Basic], inferred"
  - "inferred variable declaration"
ms.assetid: 4ad3e6e9-8f5b-4209-a248-de22ef6e4652
---
# Option Infer Statement

Enables the use of local type inference in declaring variables.

## Syntax

```vb
Option Infer { On | Off }
```

## Parts

|Term|Definition|
|---|---|
|`On`|Optional. Enables local type inference.|
|`Off`|Optional. Disables local type inference.|

## Remarks

To set `Option Infer` in a file, type `Option Infer On` or `Option Infer Off` at the top of the file, before any other source code. If the value set for `Option Infer` in a file conflicts with the value set in the IDE or on the command line, the value in the file has precedence.

When you set `Option Infer` to `On`, you can declare local variables without explicitly stating a data type. The compiler infers the data type of a variable from the type of its initialization expression.

In the following illustration, `Option Infer` is turned on. The variable in the declaration `Dim someVar = 2` is declared as an integer by type inference.

The following screenshot shows IntelliSense when Option Infer is on:

![Screenshot showing IntelliSense view when Option Infer is on.](./media/option-infer-statement/option-infer-as-integer-on.png)

In the following illustration, `Option Infer` is turned off. The variable in the declaration `Dim someVar = 2` is declared as an `Object` by type inference. In this example, the **Option Strict** setting is set to **Off** on the [Compile Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/compile-page-project-designer-visual-basic).

The following screenshot shows IntelliSense when Option Infer is off:

![Screenshot showing IntelliSense view when Option Infer is off.](./media/option-infer-statement/option-infer-as-object-off.png)

> [!NOTE]
> When a variable is declared as an `Object`, the run-time type can change while the program is running. Visual Basic performs operations called *boxing* and *unboxing* to convert between an `Object` and a value type, which makes execution slower. For information about boxing and unboxing, see the [Visual Basic Language Specification](~/_vblang/spec/conversions.md#value-type-conversions).

Type inference applies at the procedure level, and does not apply outside a procedure in a class, structure, module, or interface.

For additional information, see [Local Type Inference](../../programming-guide/language-features/variables/local-type-inference.md).

## When an Option Infer Statement Is Not Present

If the source code does not contain an `Option Infer` statement, the **Option Infer** setting on the [Compile Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/compile-page-project-designer-visual-basic) is used. If the command-line compiler is used, the [-optioninfer](../../reference/command-line-compiler/optioninfer.md) compiler option is used.

#### To set Option Infer in the IDE

1. In **Solution Explorer**, select a project. On the **Project** menu, click **Properties**.

2. Click the **Compile** tab.

3. Set the value in the **Option infer** box.

When you create a new project, the **Option Infer** setting on the **Compile** tab is set to the **Option Infer** setting in the **VB Defaults** dialog box. To access the **VB Defaults** dialog box, on the **Tools** menu, click **Options**. In the **Options** dialog box, expand **Projects and Solutions**, and then click **VB Defaults**. The initial default setting in **VB Defaults** is `On`.

#### To set Option Infer on the command line

Include the [-optioninfer](../../reference/command-line-compiler/optioninfer.md) compiler option in the **vbc** command.

## Default Data Types and Values

The following table describes the results of various combinations of specifying the data type and initializer in a `Dim` statement.

|Data type specified?|Initializer specified?|Example|Result|
|---|---|---|---|
|No|No|`Dim qty`|If `Option Strict` is off (the default), the variable is set to `Nothing`.<br /><br /> If `Option Strict` is on, a compile-time error occurs.|
|No|Yes|`Dim qty = 5`|If `Option Infer` is on (the default), the variable takes the data type of the initializer. See [Local Type Inference](../../programming-guide/language-features/variables/local-type-inference.md).<br /><br /> If `Option Infer` is off and `Option Strict` is off, the variable takes the data type of `Object`.<br /><br /> If `Option Infer` is off and `Option Strict` is on, a compile-time error occurs.|
|Yes|No|`Dim qty As Integer`|The variable is initialized to the default value for the data type. For more information, see [Dim Statement](dim-statement.md).|
|Yes|Yes|`Dim qty  As Integer = 5`|If the data type of the initializer is not convertible to the specified data type, a compile-time error occurs.|

## Example 1

The following examples demonstrate how the `Option Infer` statement enables local type inference.

[!code-vb[VbVbalrTypeInference#6](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrTypeInference/VB/Class1.vb#6)]

## Example 2

The following example demonstrates that the run-time type can differ when a variable is identified as an `Object`.

[!code-vb[VbVbalrTypeInference#11](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrTypeInference/VB/Class1.vb#11)]

## See also

- [Dim Statement](dim-statement.md)
- [Local Type Inference](../../programming-guide/language-features/variables/local-type-inference.md)
- [Option Compare Statement](option-compare-statement.md)
- [Option Explicit Statement](option-explicit-statement.md)
- [Option Strict Statement](option-strict-statement.md)
- [Visual Basic Defaults, Projects, Options Dialog Box](/visualstudio/ide/reference/visual-basic-defaults-projects-options-dialog-box)
- [-optioninfer](../../reference/command-line-compiler/optioninfer.md)
- [Boxing and Unboxing](../../../csharp/programming-guide/types/boxing-and-unboxing.md)
