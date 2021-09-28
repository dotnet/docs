---
description: "Learn more about: BC40025: Type of member '<membername>' is not CLS-compliant"
title: "Type of member '<membername>' is not CLS-compliant"
ms.date: 07/20/2015
f1_keywords:
  - "bc40025"
  - "vbc40025"
helpviewer_keywords:
  - "BC40025"
ms.assetid: adbd34bb-43d2-4266-90e7-cd1afaf49b4e
---
# BC40025: Type of member '\<membername>' is not CLS-compliant

The data type specified for this member is not part of the [Language Independence and Language-Independent Components](../../../standard/language-independence.md) (CLS). This is not an error within your component, because the .NET Framework and Visual Basic support this data type. However, another component written in strictly CLS-compliant code might not support this data type. Such a component might not be able to interact successfully with your component.

 The following Visual Basic data types are not CLS-compliant:

- [SByte Data Type](../data-types/sbyte-data-type.md)

- [UInteger Data Type](../data-types/uinteger-data-type.md)

- [ULong Data Type](../data-types/ulong-data-type.md)

- [UShort Data Type](../data-types/ushort-data-type.md)

 By default, this message is a warning. For more information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).

 **Error ID:** BC40025

## To correct this error

- If your component interfaces only with other .NET Framework components, or does not interface with any other components, you do not need to change anything.

- If you are interfacing with a component not written for the .NET Framework, you might be able to determine, either through reflection or from documentation, whether it supports this data type. If it does, you do not need to change anything.

- If you are interfacing with a component that does not support this data type, you must replace it with the closest CLS-compliant type. For example, in place of `UInteger` you might be able to use `Integer` if you do not need the value range above 2,147,483,647. If you do need the extended range, you can replace `UInteger` with `Long`.

- If you are interfacing with Automation or COM objects, keep in mind that some types have different data widths than in the .NET Framework. For example, `uint` is often 16 bits in other environments. If you are passing a 16-bit argument to such a component, declare it as `UShort` instead of `UInteger` in your managed Visual Basic code.

## See also

- [Reflection](../../../framework/reflection-and-codedom/reflection.md)
