---
title: "Naming Resources"
ms.date: "10/22/2008"
ms.technology: dotnet-standard
helpviewer_keywords: 
  - "names [.NET Framework], localized resources"
  - "localization, naming guidelines"
  - "resource names"
  - "global applications, naming guidelines"
  - "international applications, naming guidelines"
ms.assetid: 8b0e97f3-7877-44fd-bc76-e05d36d5d79c
author: "KrzysztofCwalina"
---
# Naming Resources
Because localizable resources can be referenced via certain objects as if they were properties, the naming guidelines for resources are similar to property guidelines.  
  
 **✓ DO** use PascalCasing in resource keys.  
  
 **✓ DO** provide descriptive rather than short identifiers.  
  
 **X DO NOT** use language-specific keywords of the main CLR languages.  
  
 **✓ DO** use only alphanumeric characters and underscores in naming resources.  
  
 **✓ DO** use the following naming convention for exception message resources.  
  
 The resource identifier should be the exception type name plus a short identifier of the exception:  
  
 `ArgumentExceptionIllegalCharacters`  
 `ArgumentExceptionInvalidName`  
 `ArgumentExceptionFileNameIsMalformed`  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See also

- [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)
- [Naming Guidelines](../../../docs/standard/design-guidelines/naming-guidelines.md)
