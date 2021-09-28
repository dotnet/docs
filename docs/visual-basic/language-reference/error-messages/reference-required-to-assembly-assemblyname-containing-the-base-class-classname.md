---
description: "Learn more about: BC30007: Reference required to assembly '<assemblyname>' containing the base class '<classname>'"
title: "Reference required to assembly '<assemblyname>' containing the base class '<classname>'"
ms.date: 07/20/2015
f1_keywords:
  - "bc30007"
  - "vbc30007"
helpviewer_keywords:
  - "BC30007"
ms.assetid: 5f34cf47-6c6e-4954-bd8e-d6b020b75fb7
---
# BC30007: Reference required to assembly '\<assemblyname>' containing the base class '\<classname>'

Reference required to assembly '\<assemblyname>' containing the base class '\<classname>'. Add one to your project.

 The class is defined in a dynamic-link library (DLL) or assembly that is not directly referenced in your project. The Visual Basic compiler requires a reference to avoid ambiguity in case the class is defined in more than one DLL or assembly.

 **Error ID:** BC30007

## To correct this error

- Include the name of the unreferenced DLL or assembly in your project references.

## See also

- [Managing references in a project](/visualstudio/ide/managing-references-in-a-project)
- [Troubleshooting Broken References](/visualstudio/ide/troubleshooting-broken-references)
