---
description: "Learn more about: BC40027: Return type of function '<procedurename>' is not CLS-compliant"
title: "Return type of function '<procedurename>' is not CLS-compliant"
ms.date: 07/20/2015
f1_keywords:
  - "bc40027"
  - "vbc40027"
helpviewer_keywords:
  - "BC40027"
ms.assetid: 33c088c7-48e7-400c-920e-6d8967e1f3fc
---
# BC40027: Return type of function '\<procedurename>' is not CLS-compliant

A `Function` procedure is marked as `<CLSCompliant(True)>` but returns a type that is marked as `<CLSCompliant(False)>`, is not marked, or does not qualify because it is a noncompliant type.

 For a procedure to be compliant with the [Language Independence and Language-Independent Components](../../../standard/language-independence.md) (CLS), it must use only CLS-compliant types. This applies to the types of the parameters, the return type, and the types of all its local variables.

 The following Visual Basic data types are not CLS-compliant:

- [SByte Data Type](../data-types/sbyte-data-type.md)

- [UInteger Data Type](../data-types/uinteger-data-type.md)

- [ULong Data Type](../data-types/ulong-data-type.md)

- [UShort Data Type](../data-types/ushort-data-type.md)

 When you apply the <xref:System.CLSCompliantAttribute> to a programming element, you set the attribute's `isCompliant` parameter to either `True` or `False` to indicate compliance or noncompliance. There is no default for this parameter, and you must supply a value.

 If you do not apply the <xref:System.CLSCompliantAttribute> to an element, it is considered to be noncompliant.

 By default, this message is a warning. For information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).

 **Error ID:** BC40027

## To correct this error

- If the `Function` procedure must return this particular type, remove the <xref:System.CLSCompliantAttribute>. The procedure cannot be CLS-compliant.

- If the `Function` procedure must be CLS-compliant, change the return type to the closest CLS-compliant type. For example, in place of `UInteger` you might be able to use `Integer` if you do not need the value range above 2,147,483,647. If you do need the extended range, you can replace `UInteger` with `Long`.

- If you are interfacing with Automation or COM objects, keep in mind that some types have different data widths than in the .NET Framework. For example, `int` is often 16 bits in other environments. If you are returning a 16-bit integer to such a component, declare it as `Short` instead of `Integer` in your managed Visual Basic code.
