---
title: "&#39;&lt;keyword&gt;&#39; accessor of &#39;&lt;propertyname&gt;&#39; is obsolete: &#39;&lt;errormessage&gt;&#39; (Visual Basic Error) | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vbc30911"
  - "bc30911"
helpviewer_keywords: 
  - "BC30911"
ms.assetid: b690be0c-4dca-4f79-88ed-4ee3e3f1f90b
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent

translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# &#39;&lt;keyword&gt;&#39; accessor of &#39;&lt;propertyname&gt;&#39; is obsolete: &#39;&lt;errormessage&gt;&#39; (Visual Basic Error)
A statement attempts to read or write a property for which the corresponding procedure has been marked with the <xref:System.ObsoleteAttribute> attribute and the directive to treat it as an error.  
  
 You can mark any programming element as being no longer in use by applying <xref:System.ObsoleteAttribute> to it. If you do this, you can set the attribute's <xref:System.ObsoleteAttribute.IsError%2A> property to either `True` or `False`. If you set it to `True`, the compiler treats an attempt to use the element as an error. If you set it to `False`, or let it default to `False`, the compiler issues a warning if there is an attempt to use the element.  
  
 **Error ID:** BC30911  
  
## To correct this error  
  
1.  Examine the quoted error message and take appropriate action.  
  
2.  Ensure that the source-code reference is spelling the property name correctly.  
  
3.  Avoid accessing the property in the way (reading or writing) that generated this message.  
  
## See Also  
 [NOT IN BUILD: Attributes Used in Visual Basic](http://msdn.microsoft.com/en-us/22231318-8a40-49af-9245-e0aab723563b)   
 [NOT IN BUILD: Application of Attributes](http://msdn.microsoft.com/en-us/2b1703ed-4437-49b3-bc0b-568094324f47)   
 [Property Procedures](../../visual-basic/programming-guide/language-features/procedures/property-procedures.md)