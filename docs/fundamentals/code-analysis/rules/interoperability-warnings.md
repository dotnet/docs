---
title: Portability and Interoperability Warnings
ms.date: 11/04/2016
ms.topic: reference
f1_keywords:
  - "vs.codeanalysis.Portablityrules"
  - "vs.codeanalysis.Interoperabilityrules"
helpviewer_keywords:
  - "managed code analysis warnings, interoperability warnings, portability warnings"
  - "portability warnings"
  - "warnings, portability"
  - "interoperability warnings"
  - "warnings, interoperability"
ms.assetid: 95de6eb3-40c4-4063-9f59-25cb70e3b2b3
author: mikejo5000
ms.author: mikejo
manager: jillfra
ms.workload:
  - "multiple"
---
# Portability and Interoperability Warnings

Portability warnings support portability across different platforms. Interoperability warnings support interaction with COM clients.

## In This Section

| Rule | Description |
| - | - |
| [CA1401: P/Invokes should not be visible](../code-quality/ca1401.md) | A public or protected method in a public type has the System.Runtime.InteropServices.DllImportAttribute attribute (also implemented by the Declare keyword in Visual Basic). Such methods should not be exposed. |
| [CA1416: Validate platform compatibility](../code-quality/ca1416.md) | Using platform-dependent APIs on a component makes the code no longer work across all platforms. |
| [CA1417: Do not use `OutAttribute` on string parameters for P/Invokes](../code-quality/ca1417.md) | String parameters passed by value with the `OutAttribute` can destabilize the runtime if the string is an interned string. |
