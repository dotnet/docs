---
title: "Troubleshooting Inherited Event Handlers in Visual Basic | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "troubleshooting events"
  - "inherited events"
  - "troubleshooting Visual Basic, event handlers"
  - "event handling, troubleshooting"
  - "event handlers, troubleshooting"
ms.assetid: e1c8759f-5370-4308-8476-8c48b73509bf
caps.latest.revision: 11
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Troubleshooting Inherited Event Handlers in Visual Basic
[!INCLUDE[vs2017banner](../../../../includes/vs2017banner.md)]

This topic lists common issues that arise with event handlers in inherited components.  
  
## Procedures  
  
#### Code in Event Handler Executes Twice for Every Call  
  
-   An inherited event handler must not include a [Handles](../../../../visual-basic/language-reference/statements/handles-clause.md) clause. The method in the base class is already associated with the event and will fire accordingly. Remove the `Handles` clause from the inherited method.  
  
     [!code-vb[VbVbalrEvents#32](../../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrEvents/VB/Class1.vb#32)]  
  
-   If the inherited method does not have a `Handles` keyword, verify that your code does not contain an extra [AddHandler Statement](../../../../visual-basic/language-reference/statements/addhandler-statement.md) or any additional methods that handle the same event.  
  
## See Also  
 [Events](../../../../visual-basic/programming-guide/language-features/events/events.md)