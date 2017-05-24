---
title: "&#39;Exit Sub&#39; is not valid in a Function or Property | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "bc30065"
  - "vbc30065"
helpviewer_keywords: 
  - "BC30065"
ms.assetid: d6426861-ba64-4dca-9100-262c6c058bd9
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
# &#39;Exit Sub&#39; is not valid in a Function or Property
`Exit Sub` appears in a `Function` procedure or a `Property` procedure. An `Exit` statement must match the block in which it occurs.  
  
 **Error ID:** BC30065  
  
## To correct this error  
  
-   Replace the `Exit Sub` with the `Exit Function` or `Exit Property` statement as appropriate.  
  
## See Also  
 [Sub Procedures](../../visual-basic/programming-guide/language-features/procedures/sub-procedures.md)   
 [Function Procedures](../../visual-basic/programming-guide/language-features/procedures/function-procedures.md)   
 [Property Procedures](../../visual-basic/programming-guide/language-features/procedures/property-procedures.md)