---
title: "Property let procedure not defined and property get procedure did not return an object | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vbrID451"
dev_langs: 
  - "VB"
ms.assetid: 8542382a-689f-4e1b-abc0-c1e2dadb92f4
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
# Property let procedure not defined and property get procedure did not return an object
Certain properties, methods, and operations can only apply to `Collection` objects. You specified an operation or property that is exclusive to collections, but the object is not a collection.  
  
## To correct this error  
  
1.  Check the spelling of the object or property name, or verify that the object is a `Collection` object.  
  
2.  Look at the `Add`method used to add the object to the collection to be sure the syntax is correct and that any identifiers were spelled correctly.  
  
## See Also  
 <xref:Microsoft.VisualBasic.Collection>