---
description: "Learn more about: BC42319: XML comment exception must have a 'cref' attribute"
title: "XML comment exception must have a 'cref' attribute"
ms.date: 07/20/2015
f1_keywords:
  - "bc42319"
  - "vbc42319"
helpviewer_keywords:
  - "BC42319"
ms.assetid: 62eeeba3-6811-48be-b1ef-c2e4feda3177
---
# BC42319: XML comment exception must have a 'cref' attribute

The \<exception> tag provides a way to document the exceptions that may be thrown by a method. The required `cref` attribute designates the name of a member, which is checked by the documentation generator. If the member exists, it is translated to the canonical element name in the documentation file.

**Error ID:** BC42319

## To correct this error

Add the `cref` attribute to the exception as follows:

```xml
<exception cref="member">description</exception>
```

## See also

- [\<exception>](../xmldoc/exception.md)
- [How to: Create XML Documentation](../../programming-guide/program-structure/how-to-create-xml-documentation.md)
- [XML Comment Tags](../xmldoc/index.md)
