---
description: "Learn more about: -optionstrict"
title: "-optionstrict"
ms.date: 07/20/2015
f1_keywords:
  - "-optionstrict"
helpviewer_keywords:
  - "-optionstrict compiler option [Visual Basic]"
  - "optionstrict compiler option [Visual Basic]"
  - "/optionstrict compiler option [Visual Basic]"
ms.assetid: c7b10086-0fa4-49db-b3c8-4ae0db5957da
---
# -optionstrict

Enforces strict type semantics to restrict implicit type conversions.

## Syntax

```console
-optionstrict[+ | -]
-optionstrict[:custom]
```

## Arguments

`+` &#124; `-`  
Optional. The `-optionstrict+` option restricts implicit type conversion. The default for this option is `-optionstrict-`. The `-optionstrict+` option is the same as `-optionstrict`. You can use both for permissive type semantics.

`custom`  
Required. Warn when strict language semantics are not respected.

## Remarks

When `-optionstrict+` is in effect, only widening type conversions can be made implicitly. Implicit narrowing type conversions, such as assigning a `Decimal` type object to an integer type object, are reported as errors.

To generate warnings for implicit narrowing type conversions, use `-optionstrict:custom`. Use `-nowarn:numberlist` to ignore particular warnings and `-warnaserror:numberlist` to treat particular warnings as errors.

### To set -optionstrict in the Visual Studio IDE

1. Have a project selected in **Solution Explorer**. On the **Project** menu, click **Properties.**

2. Click the **Compile** tab.

3. Modify the value in the **Option Strict** box.

### To set -optionstrict programmatically

See [Option Strict Statement](../../language-reference/statements/option-strict-statement.md).

## Example

The following code compiles `Test.vb` using strict type semantics.

```console
vbc -optionstrict+ test.vb
```

## See also

- [Visual Basic Command-Line Compiler](index.md)
- [-optioncompare](optioncompare.md)
- [-optionexplicit](optionexplicit.md)
- [-optioninfer](optioninfer.md)
- [-nowarn](nowarn.md)
- [-warnaserror (Visual Basic)](warnaserror.md)
- [Sample Compilation Command Lines](sample-compilation-command-lines.md)
- [Option Strict Statement](../../language-reference/statements/option-strict-statement.md)
- [Visual Basic Defaults, Projects, Options Dialog Box](/visualstudio/ide/reference/visual-basic-defaults-projects-options-dialog-box)
