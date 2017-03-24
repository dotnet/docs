---
title: "XML namespace URI &#39;&lt;uri&gt;&#39; can be bound only to &#39;xmlns&#39; | Microsoft Docs"
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
  - "bc31183"
  - "vbc31183"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC31183"
ms.assetid: 0ab1dbce-8397-4959-b2cd-f58798b051a0
caps.latest.revision: 6
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# XML namespace URI &#39;http://www.w3.org/XML/1998/namespace&#39; can be bound only to &#39;xmlns&#39;
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

The URI http://www.w3.org/XML/1998/namespace is used in an XML namespace declaration. This URI is a reserved namespace and cannot be included in an XML namespace declaration.  
  
 **Error ID:** BC31183  
  
### To correct this error  
  
-   Remove the XML namespace declaration or replace the URI http://www.w3.org/XML/1998/namespace with a valid namespace URI.  
  
## See Also  
 [Imports Statement (XML Namespace)](../../../visual-basic/language-reference/statements/imports-statement-xml-namespace.md)   
 [XML Literals](../../../visual-basic/language-reference/xml-literals/index.md)   
 [XML](../../../visual-basic/programming-guide/language-features/xml/index.md)