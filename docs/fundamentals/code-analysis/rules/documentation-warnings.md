---
title: Documentation warnings
ms.date: 09/16/2019
ms.topic: reference
f1_keywords:
  - "vs.codeanalysis.documentationrules"
helpviewer_keywords:
  - "documentation warnings"
  - "managed code analysis warnings, documentation warnings"
  - "warnings, documentation"
author: mavasani
ms.author: mavasani
manager: jillfra
ms.workload:
  - "multiple"
---
# Documentation warnings

Documentation warnings support writing well-documented libraries through the correct use of [XML documentation comments](/dotnet/csharp/codedoc) for externally visible APIs.

## In this section

| Rule | Description |
| - | - |
| [CA1200: Avoid using cref tags with a prefix](../code-quality/ca1200.md) | The [cref](/dotnet/csharp/programming-guide/xmldoc/cref-attribute) attribute in an XML documentation tag means "code reference". It specifies that the inner text of the tag is a code element, such as a type, method, or property. Avoid using `cref` tags with prefixes, because it prevents the compiler from verifying references. It also prevents the Visual Studio integrated development environment (IDE) from finding and updating these symbol references during refactorings. |

## See also

- [Code analysis warnings](../code-quality/code-analysis-for-managed-code-warnings.md)
