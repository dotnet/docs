---
title: "Property let procedure not defined and property get procedure did not return an object | Microsoft Docs"
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
  - "vbrID451"
dev_langs: 
  - "VB"
ms.assetid: 8542382a-689f-4e1b-abc0-c1e2dadb92f4
caps.latest.revision: 8
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Property let procedure not defined and property get procedure did not return an object
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Certain properties, methods, and operations can only apply to `Collection` objects. You specified an operation or property that is exclusive to collections, but the object is not a collection.  
  
### To correct this error  
  
1.  Check the spelling of the object or property name, or verify that the object is a `Collection` object.  
  
2.  Look at the `Add`method used to add the object to the collection to be sure the syntax is correct and that any identifiers were spelled correctly.  
  
## See Also  
 <xref:Microsoft.VisualBasic.Collection>