---
title: Documentation rules (code analysis)
description: "Learn about code analysis rule Documentation rules"
ms.date: 09/16/2019
ms.topic: reference
f1_keywords:
  - "vs.codeanalysis.documentationrules"
helpviewer_keywords:
  - "documentation rules"
  - "managed code analysis rules, documentation rules"
  - "warnings, documentation"
author: mavasani
ms.author: mavasani
---
# Documentation rules

Documentation rules support writing well-documented libraries through the correct use of [XML documentation comments](../../../csharp/language-reference/xmldoc/recommended-tags.md) for externally visible APIs.

## In this section

| Rule | Description |
| - | - |
| [CA1200: Avoid using cref tags with a prefix](ca1200.md) | The [cref](../../../csharp/language-reference/xmldoc/recommended-tags.md) attribute in an XML documentation tag means "code reference". It specifies that the inner text of the tag is a code element, such as a type, method, or property. Avoid using `cref` tags with prefixes, because it prevents the compiler from verifying references. It also prevents the Visual Studio integrated development environment (IDE) from finding and updating these symbol references during refactorings. |
