---
title: "XML literals and XML properties are not supported in embedded code within ASP.NET | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "vbc31200"
  - "bc31200"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC31200"
ms.assetid: 053e8cba-8584-45cc-9fa0-43d122779772
caps.latest.revision: 9
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# XML literals and XML properties are not supported in embedded code within ASP.NET
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

XML literals and XML properties are not supported in embedded code within ASP.NET. To use XML features, move the code to code-behind.  
  
 An XML literal or XML axis property is defined within embedded code (`<%= =>`) in an ASP.NET file.  
  
 **Error ID:** BC31200  
  
### To correct this error  
  
-   Move the code that includes the XML literal or XML axis property to an ASP.NET code-behind file.  
  
## See Also  
 [XML Literals](../../../visual-basic/language-reference/xml-literals/index.md)   
 [XML Axis Properties](../../../visual-basic/language-reference/xml-axis/xml-axis-properties.md)   
 [XML](../../../visual-basic/programming-guide/language-features/xml/index.md)