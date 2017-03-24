---
title: "Cannot refer to &#39;&lt;name&gt;&#39; because it is a member of the value-typed field &#39;&lt;name&gt;&#39; of class &#39;&lt;classname&gt;&#39; which has &#39;System.MarshalByRefObject&#39; as a base class | Microsoft Docs"
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
  - "vbc30310"
  - "bc30310"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30310"
ms.assetid: 2aeb8872-7c87-4f01-98ef-9714ba3eebbe
caps.latest.revision: 9
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Cannot refer to &#39;&lt;name&gt;&#39; because it is a member of the value-typed field &#39;&lt;name&gt;&#39; of class &#39;&lt;classname&gt;&#39; which has &#39;System.MarshalByRefObject&#39; as a base class
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

The `System.MarshalByRefObject` class enables applications that support remote access to objects across application domain boundaries. Types must inherit from the `MarshalByRejectObject` class when the type is used across application domain boundaries. The state of the object must not be copied because the members of the object are not usable outside the application domain in which they were created.  
  
 **Error ID:** BC30310  
  
### To correct this error  
  
1.  Check the reference to make sure the member being referred to is valid.  
  
2.  Explicitly qualify the member with the `Me` keyword.  
  
## See Also  
 <xref:System.MarshalByRefObject>   
 [Dim Statement](../../../visual-basic/language-reference/statements/dim-statement.md)