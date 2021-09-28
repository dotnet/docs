---
description: "Learn more about: BC40042: Type of optional value for optional parameter <parametername> is not CLS-compliant"
title: "Type of optional value for optional parameter <parametername> is not CLS-compliant"
ms.date: 07/20/2015
f1_keywords:
  - "BC40042"
  - "vbc40042"
helpviewer_keywords:
  - "BC40042"
ms.assetid: 1d6eae29-4ad3-4434-bde4-a53b6051adf5
---
# BC40042: Type of optional value for optional parameter \<parametername> is not CLS-compliant

A procedure is marked as `<CLSCompliant(True)>` but declares an [Optional](../modifiers/optional.md) parameter with default value of a noncompliant type.

 For a procedure to be compliant with the [Language Independence and Language-Independent Components](../../../standard/language-independence.md) (CLS), it must use only CLS-compliant types. This applies to the types of the parameters, the return type, and the types of all its local variables. It also applies to the default values of optional parameters.

 The following Visual Basic data types are not CLS-compliant:

- [SByte Data Type](../data-types/sbyte-data-type.md)

- [UInteger Data Type](../data-types/uinteger-data-type.md)

- [ULong Data Type](../data-types/ulong-data-type.md)

- [UShort Data Type](../data-types/ushort-data-type.md)

 When you apply the <xref:System.CLSCompliantAttribute> attribute to a programming element, you set the attribute's `isCompliant` parameter to either `True` or `False` to indicate compliance or noncompliance. There is no default for this parameter, and you must supply a value.

 If you do not apply <xref:System.CLSCompliantAttribute> to an element, it is considered to be noncompliant.

 By default, this message is a warning. For information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).

 **Error ID:** BC40042

## To correct this error

- If the optional parameter must have a default value of this particular type, remove <xref:System.CLSCompliantAttribute>. The procedure cannot be CLS-compliant.

- If the procedure must be CLS-compliant, change the type of this default value to the closest CLS-compliant type. For example, in place of `UInteger` you might be able to use `Integer` if you do not need the value range above 2,147,483,647. If you do need the extended range, you can replace `UInteger` with `Long`.

- If you are interfacing with Automation or COM objects, keep in mind that some types have different data widths than in the .NET Framework. For example, `int` is often 16 bits in other environments. If you are accepting a 16-bit integer from such a component, declare it as `Short` instead of `Integer` in your managed Visual Basic code.
