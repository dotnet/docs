---
description: "Learn more about: BC31200: XML literals and XML properties are not supported in embedded code within ASP.NET"
title: "XML literals and XML properties are not supported in embedded code within ASP.NET"
ms.date: 07/20/2015
f1_keywords:
  - "vbc31200"
  - "bc31200"
helpviewer_keywords:
  - "BC31200"
ms.assetid: 053e8cba-8584-45cc-9fa0-43d122779772
---
# BC31200: XML literals and XML properties are not supported in embedded code within ASP.NET

XML literals and XML properties are not supported in embedded code within ASP.NET. To use XML features, move the code to code-behind.

 An XML literal or XML axis property is defined within embedded code (`<%= =>`) in an ASP.NET file.

 **Error ID:** BC31200

## To correct this error

- Move the code that includes the XML literal or XML axis property to an ASP.NET code-behind file.

## See also

- [XML Literals](../xml-literals/index.md)
- [XML Axis Properties](../xml-axis/index.md)
- [XML](../../programming-guide/language-features/xml/index.md)
