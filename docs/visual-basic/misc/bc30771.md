---
title: "&#39;WebMethod&#39; attribute will not affect this member because its containing class is not exposed as a web service | Microsoft Docs"
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
  - "vbc30771"
  - "bc30771"
helpviewer_keywords: 
  - "BC30771"
ms.assetid: 20b09f6a-b61a-4d89-9ca5-4632b5e68e65
caps.latest.revision: 9
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
# &#39;WebMethod&#39; attribute will not affect this member because its containing class is not exposed as a web service
The <xref:System.Web.Services.WebMethodAttribute> attribute makes a method callable from remote Web clients, but only when the method's class derives from <xref:System.Web.Services.WebService>.  
  
 **Error ID:** BC30771  
  
### To correct this error  
  
-   Change the class to derive from <xref:System.Web.Services.WebService>.  
  
     — or —  
  
-   Remove the <xref:System.Web.Services.WebMethodAttribute> attribute from the method.  
  
## See Also  
 [NIB: Walkthrough: Creating a Web Service Using Visual Basic or Visual C#](http://msdn.microsoft.com/en-us/295f4c3f-9540-4bd1-b1cc-3e9cb9675cc7)