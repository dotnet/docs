---
description: "Learn more about: BC40041: Type <typename> is not CLS-compliant"
title: "Type <typename> is not CLS-compliant"
ms.date: 07/20/2015
f1_keywords:
  - "bc40041"
  - "vbc40041"
helpviewer_keywords:
  - "BC40041"
ms.assetid: 634132c2-5646-44aa-98c6-f773e2e63882
---
# BC40041: Type \<typename> is not CLS-compliant

A variable, property, or function return is declared with a data type that is not CLS-compliant.

 For an application to be compliant with the [Language Independence and Language-Independent Components](../../../standard/language-independence.md) (CLS), it must use only CLS-compliant types.

 The following Visual Basic data types are not CLS-compliant:

- [SByte Data Type](../data-types/sbyte-data-type.md)

- [UInteger Data Type](../data-types/uinteger-data-type.md)

- [ULong Data Type](../data-types/ulong-data-type.md)

- [UShort Data Type](../data-types/ushort-data-type.md)

 **Error ID:** BC40041

## To correct this error

- If your application needs to be CLS-compliant, change the data type of this element to the closest CLS-compliant type. For example, in place of `UInteger` you might be able to use `Integer` if you do not need the value range above 2,147,483,647. If you do need the extended range, you can replace `UInteger` with `Long`.

- If your application does not need to be CLS-compliant, you do not need to change anything. You should be aware of its noncompliance, however.
