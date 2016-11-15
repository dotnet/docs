---
title: "&lt;type1&gt; &#39;&lt;typename&gt;&#39; cannot be declared &#39;Overrides&#39; because it does not override a &lt;type1&gt; in a base &lt;type2&gt; | Microsoft Docs"
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
  - "vbc30284"
  - "bc30284"
helpviewer_keywords: 
  - "BC30284"
ms.assetid: 8166bd09-dad3-495d-8cf7-66f90824a288
caps.latest.revision: 8
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
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
# &lt;type1&gt; &#39;&lt;typename&gt;&#39; cannot be declared &#39;Overrides&#39; because it does not override a &lt;type1&gt; in a base &lt;type2&gt;
A `Sub`, `Function`, or `Property` statement specifies `Overrides` when no type with the same name exists in a base class.  
  
 **Error ID:** BC30284  
  
### To correct this error  
  
1.  Check that the type name is spelled correctly.  
  
2.  Remove the superfluous `Overrides` keyword.  
  
## See Also  
 [NOT IN BUILD: Overriding Properties and Methods](http://msdn.microsoft.com/en-us/2167e8f5-1225-4b13-9ebd-02591ba90213)