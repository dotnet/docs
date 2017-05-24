---
title: "Constant &#39;&lt;constantname&gt;&#39; cannot depend on its own value | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "bc30500"
  - "vbc30500"
helpviewer_keywords: 
  - "BC30500"
ms.assetid: 0dad89bc-9196-492f-acd9-7777757362f7
caps.latest.revision: 8
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
# Constant &#39;&lt;constantname&gt;&#39; cannot depend on its own value
You created a circular dependency in your code, where a constant depends on its own value. For example, `Const a = Const b; Const b = Const a`.  
  
 **Error ID:** BC30500  
  
## To correct this error  
  
1.  Check your code to see where the constant is being evaluated, and modify it accordingly.  
  
## See Also  
 [NOTINBUILD Constants Overview](http://msdn.microsoft.com/en-us/5c7f57fb-48b2-4a2f-afee-79d8e3adf15b)