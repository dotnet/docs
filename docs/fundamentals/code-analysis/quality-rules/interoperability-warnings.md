---
title: Portability and Interoperability rules (code analysis)
description: "Learn about code analysis rule Portability and Interoperability rules"
ms.date: 11/04/2016
ms.topic: reference
f1_keywords:
  - "vs.codeanalysis.Portablityrules"
  - "vs.codeanalysis.Interoperabilityrules"
helpviewer_keywords:
  - "managed code analysis rules, interoperability rules, portability rules"
  - "portability rules"
  - "warnings, portability"
  - "interoperability rules"
  - "warnings, interoperability"
author: gewarren
ms.author: gewarren
---
# Portability and interoperability rules

Portability rules support portability across different platforms. Interoperability rules support interaction with COM clients.

## In this section

| Rule | Description |
| - | - |
| [CA1401: P/Invokes should not be visible](ca1401.md) | A public or protected method in a public type has the System.Runtime.InteropServices.DllImportAttribute attribute (also implemented by the Declare keyword in Visual Basic). Such methods should not be exposed. |
| [CA1416: Validate platform compatibility](ca1416.md) | Using platform-dependent APIs on a component makes the code no longer work across all platforms. |
| [CA1417: Do not use `OutAttribute` on string parameters for P/Invokes](ca1417.md) | String parameters passed by value with the `OutAttribute` can destabilize the runtime if the string is an interned string. |
| [CA1418: Use valid platform string](ca1418.md) | Platform compatibility analyzer requires a valid platform name and version. |
