---
title: "General Naming Conventions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "names [.NET Framework], conflicts"
  - "type names, conflicts"
  - "language-specific type names"
  - "names [.NET Framework], about naming guidelines"
  - "names [.NET Framework], abbreviations"
  - "abbreviation naming guidelines"
  - "acronym naming guidelines"
  - "Hungarian notation"
  - "names [.NET Framework], type names"
  - "names [.NET Framework], acronyms"
ms.assetid: d3a77ea1-75d2-4969-a8c3-3e1e3e1aaedc
caps.latest.revision: 18
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# General Naming Conventions
This section describes general naming conventions that relate to word choice, guidelines on using abbreviations and acronyms, and recommendations on how to avoid using language-specific names.  
  
## Word Choice  
 **✓ DO** choose easily readable identifier names.  
  
 For example, a property named `HorizontalAlignment` is more English-readable than `AlignmentHorizontal`.  
  
 **✓ DO** favor readability over brevity.  
  
 The property name `CanScrollHorizontally` is better than `ScrollableX` (an obscure reference to the X-axis).  
  
 **X DO NOT** use underscores, hyphens, or any other nonalphanumeric characters.  
  
 **X DO NOT** use Hungarian notation.  
  
 **X AVOID** using identifiers that conflict with keywords of widely used programming languages.  
  
 According to Rule 4 of the Common Language Specification (CLS), all compliant languages must provide a mechanism that allows access to named items that use a keyword of that language as an identifier. C#, for example, uses the @ sign as an escape mechanism in this case. However, it is still a good idea to avoid common keywords because it is much more difficult to use a method with the escape sequence than one without it.  
  
## Using Abbreviations and Acronyms  
 **X DO NOT** use abbreviations or contractions as part of identifier names.  
  
 For example, use `GetWindow` rather than `GetWin`.  
  
 **X DO NOT** use any acronyms that are not widely accepted, and even if they are, only when necessary.  
  
## Avoiding Language-Specific Names  
 **✓ DO** use semantically interesting names rather than language-specific keywords for type names.  
  
 For example, `GetLength` is a better name than `GetInt`.  
  
 **✓ DO** use a generic CLR type name, rather than a language-specific name, in the rare cases when an identifier has no semantic meaning beyond its type.  
  
 For example, a method converting to <xref:System.Int64> should be named `ToInt64`, not `ToLong` (because <xref:System.Int64> is a CLR name for the C#-specific alias `long`). The following table presents several base data types using the CLR type names (as well as the corresponding type names for C#, Visual Basic, and C++).  
  
|C#|Visual Basic|C++|CLR|  
|---------|------------------|-----------|---------|  
|**sbyte**|**SByte**|**char**|**SByte**|  
|**byte**|**Byte**|**unsigned char**|**Byte**|  
|**short**|**Short**|**short**|**Int16**|  
|**ushort**|**UInt16**|**unsigned short**|**UInt16**|  
|**int**|**Integer**|**int**|**Int32**|  
|**uint**|**UInt32**|**unsigned int**|**UInt32**|  
|**long**|**Long**|**__int64**|**Int64**|  
|**ulong**|**UInt64**|**unsigned __int64**|**UInt64**|  
|**float**|**Single**|**float**|**Single**|  
|**double**|**Double**|**double**|**Double**|  
|**bool**|**Boolean**|**bool**|**Boolean**|  
|**char**|**Char**|**wchar_t**|**Char**|  
|**string**|**String**|**String**|**String**|  
|**object**|**Object**|**Object**|**Object**|  
  
 **✓ DO**  use a common name, such as `value` or `item`, rather than repeating the type name, in the rare cases when an identifier has no semantic meaning and the type of the parameter is not important.  
  
## Naming New Versions of Existing APIs  
 **✓ DO** use a name similar to the old API when creating new versions of an existing API.  
  
 This helps to highlight the relationship between the APIs.  
  
 **✓ DO** prefer adding a suffix rather than a prefix to indicate a new version of an existing API.  
  
 This will assist discovery when browsing documentation, or using Intellisense. The old version of the API will be organized close to the new APIs, because most browsers and Intellisense show identifiers in alphabetical order.  
  
 **✓ CONSIDER** using a brand new, but meaningful identifier, instead of adding a suffix or a prefix.  
  
 **✓ DO** use a numeric suffix to indicate a new version of an existing API, particularly if the existing name of the API is the only name that makes sense (i.e., if it is an industry standard) and if adding any meaningful suffix (or changing the name) is not an appropriate option.  
  
 **X DO NOT** use the "Ex" (or a similar) suffix for an identifier to distinguish it from an earlier version of the same API.  
  
 **✓ DO** use the "64" suffix when introducing versions of APIs that operate on a 64-bit integer (a long integer) instead of a 32-bit integer. You only need to take this approach when the existing 32-bit API exists; don’t do it for brand new APIs with only a 64-bit version.  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See Also  
 [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)  
 [Naming Guidelines](../../../docs/standard/design-guidelines/naming-guidelines.md)
