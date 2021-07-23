---
description: "Learn more about: BC30712: Unable to load information for class '<classname>'"
title: "Unable to load information for class '<classname>'"
ms.date: 07/20/2015
f1_keywords:
  - "vbc30712"
  - "bc30712"
helpviewer_keywords:
  - "BC30712"
ms.assetid: c7ffbd6d-05c6-4261-b44b-1bcd521bb350
---
# BC30712: Unable to load information for class '\<classname>'

A reference was made to a class that is not available.

 **Error ID:** BC30712

## To correct this error

1. Verify that the class is defined and that you spelled the name correctly.

2. Try accessing one of the members declared in the module. In some cases, the debugging environment cannot locate members because the modules where they are declared have not been loaded yet.

## See also

- [Debugging in Visual Studio](/visualstudio/debugger/debugger-feature-tour)
