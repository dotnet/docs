---
title: "&#39;&lt;propertyname&gt;&#39; implicitly defines &#39;&lt;membername&gt;&#39;, which conflicts with a member of the same name in &lt;type&gt; &#39;&lt;typename&gt;&#39; | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "bc31060"
  - "vbc31060"
helpviewer_keywords: 
  - "BC31060"
ms.assetid: 33d3ca8b-711b-4f76-9b79-d5428b28dd2f
caps.latest.revision: 9
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
# &#39;&lt;propertyname&gt;&#39; implicitly defines &#39;&lt;membername&gt;&#39;, which conflicts with a member of the same name in &lt;type&gt; &#39;&lt;typename&gt;&#39;
The name of a type member conflicts with the name of a member implicitly created for a property. Properties implicitly create several implicit variables that can conflict with defined members.  
  
 **Error ID:** BC31060  
  
## To correct this error  
  
-   Rename the explicitly declared member to remove the naming conflict.  
  
## See Also  
 [NOT IN BUILD: How to: Add Fields and Properties to a Class](http://msdn.microsoft.com/en-us/ae53f61b-3abc-413e-8931-703c5f5e8fc2)   
 [Property Procedures](../../visual-basic/programming-guide/language-features/procedures/property-procedures.md)   
 [NOT IN BUILD: Properties and Property Procedures](http://msdn.microsoft.com/en-us/23e2a1ec-7e9d-4109-8940-c703d981077b)