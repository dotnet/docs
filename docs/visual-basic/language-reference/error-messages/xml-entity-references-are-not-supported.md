---
description: "Learn more about: BC31180: XML entity references are not supported"
title: "XML entity references are not supported"
ms.date: 07/20/2015
f1_keywords:
  - "vbc31180"
  - "bc31180"
helpviewer_keywords:
  - "BC31180"
ms.assetid: 2a393327-d8e2-4187-85b1-642b4f53b4ae
---
# BC31180: XML entity references are not supported

An entity reference (for example, `©`) that is not defined in the XML 1.0 specification is included as a value for an XML literal. Only `&`, `"`, `<`, `>`, and `'` XML entity references are supported in XML literals.

 **Error ID:** BC31180

## To correct this error

- Remove the unsupported entity reference.

## See also

- [XML Literals and the XML 1.0 Specification](../../programming-guide/language-features/xml/xml-literals-and-the-xml-1-0-specification.md)
- [XML Literals](../xml-literals/index.md)
- [XML](../../programming-guide/language-features/xml/index.md)
