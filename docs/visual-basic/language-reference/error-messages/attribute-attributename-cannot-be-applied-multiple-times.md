---
title: "Attribute &#39;&lt;attributename&gt;&#39; cannot be applied multiple times | Microsoft Docs"
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
  - "bc30663"
  - "vbc30663"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30663"
ms.assetid: 3760e7ff-7238-40a1-8676-77d858a64fc0
caps.latest.revision: 9
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Attribute &#39;&lt;attributename&gt;&#39; cannot be applied multiple times
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

The attribute can only be applied once. The `AttributeUsage` attribute determines whether an attribute can be applied more than once.  
  
 **Error ID:** BC30663  
  
### To correct this error  
  
1.  Make sure the attribute is only applied once.  
  
2.  If you are using custom attributes you developed, consider changing their `AttributeUsage` attribute to allow multiple attribute usage, as with the following example.  
  
    ```  
    <AttributeUsage(AllowMultiple := True)>  
    ```  
  
## See Also  
 <xref:System.AttributeUsageAttribute>   
 [Creating Custom Attributes](../Topic/Creating%20Custom%20Attributes%20\(C%23%20and%20Visual%20Basic\).md)   
 [AttributeUsage](../Topic/AttributeUsage%20\(C%23%20and%20Visual%20Basic\).md)