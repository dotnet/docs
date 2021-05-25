---
description: "Learn more about: BC40035: <proceduresignature1> is not CLS-compliant because it overloads <proceduresignature2> which differs from it only by array of array parameter types or by the rank of the array parameter types"
title: "<proceduresignature1> is not CLS-compliant because it overloads <proceduresignature2> which differs from it only by array of array parameter types or by the rank of the array parameter types"
ms.date: 07/20/2015
f1_keywords:
  - "vbc40035"
  - "bc40035"
helpviewer_keywords:
  - "BC40035"
ms.assetid: 50a66dbe-2c1e-41bf-96bc-369301c891ac
---
# BC40035: \<proceduresignature1> is not CLS-compliant because it overloads \<proceduresignature2> which differs from it only by array of array parameter types or by the rank of the array parameter types

A procedure or property is marked as `<CLSCompliant(True)>` when it overrides another procedure or property and the only difference between their parameter lists is the nesting level of a jagged array or the rank of an array.

 In the following declarations, the second and third declarations generate this error:

 `Overloads Sub ProcessArray(arrayParam() As Integer)`

 `Overloads Sub ProcessArray(arrayParam()() As Integer)`

 `Overloads Sub ProcessArray(arrayParam(,) As Integer)`

 The second declaration changes the original one-dimensional parameter `arrayParam` to an array of arrays. The third declaration changes `arrayParam` to a two-dimensional array (rank 2). While Visual Basic allows overloads to differ only by one of these changes, such overloading is not compliant with the [Language Independence and Language-Independent Components](../../../standard/language-independence.md) (CLS).

 When you apply the <xref:System.CLSCompliantAttribute> to a programming element, you set the attribute's `isCompliant` parameter to either `True` or `False` to indicate compliance or noncompliance. There is no default for this parameter, and you must supply a value.

 If you do not apply the <xref:System.CLSCompliantAttribute> to an element, it is considered to be noncompliant.

 By default, this message is a warning. For information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).

 **Error ID:** BC40035

## To correct this error

- If you require CLS compliance, define your overloads to differ from each other in more ways than only the changes cited on this Help page.
- If you require that the overloads differ only by the changes cited on this Help page, remove the <xref:System.CLSCompliantAttribute> from their definitions or mark them as `<CLSCompliant(False)>`.

## See also

- [Procedure Overloading](../../programming-guide/language-features/procedures/procedure-overloading.md)
- [Overloads](../modifiers/overloads.md)
