---
title: "Attribute &#39;&lt;attributename&gt;&#39; cannot be applied multiple times"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc30663"
  - "vbc30663"
helpviewer_keywords: 
  - "BC30663"
ms.assetid: 3760e7ff-7238-40a1-8676-77d858a64fc0
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# Attribute &#39;&lt;attributename&gt;&#39; cannot be applied multiple times
The attribute can only be applied once. The `AttributeUsage` attribute determines whether an attribute can be applied more than once.  
  
 **Error ID:** BC30663  
  
## To correct this error  
  
1.  Make sure the attribute is only applied once.  
  
2.  If you are using custom attributes you developed, consider changing their `AttributeUsage` attribute to allow multiple attribute usage, as with the following example.  
  
```vb  
<AttributeUsage(AllowMultiple := True)>  
```  
  
## See Also  
 <xref:System.AttributeUsageAttribute>  
 [Creating Custom Attributes](../../../visual-basic/programming-guide/concepts/attributes/creating-custom-attributes.md)  
 [AttributeUsage](../../../visual-basic/programming-guide/concepts/attributes/attributeusage.md)
