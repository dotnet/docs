---
description: "Learn more about: BC31194: Value of type 'type1' cannot be converted to 'type2"
title: "Value of type 'type1' cannot be converted to 'type2'"
ms.date: 07/20/2015
f1_keywords:
  - "vbc31194"
  - "bc31194"
helpviewer_keywords:
  - "BC31194"
ms.assetid: 03d50c31-addd-4c90-9c53-725b84f9782e
---
# BC31194: Value of type 'type1' cannot be converted to 'type2'

Value of type 'type1' cannot be converted to 'type2'. You can use the 'Value' property to get the string value of the first element of '\<parentElement>'.

 An attempt has been made to implicitly cast an XML literal to a specific type. The XML literal cannot be implicitly cast to the specified type.

 **Error ID:** BC31194

## To correct this error

- Use the `Value` property of the XML literal to reference its value as a `String`. Use the `CType` function, another type conversion function, or the <xref:System.Convert> class to cast the value as the specified type.

## See also

- <xref:System.Convert>
- [Type Conversion Functions](../functions/type-conversion-functions.md)
- [XML Literals](../xml-literals/index.md)
- [XML](../../programming-guide/language-features/xml/index.md)
