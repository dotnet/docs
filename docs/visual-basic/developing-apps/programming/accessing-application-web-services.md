---
title: "Accessing Application Web Services (Visual Basic) | Microsoft Docs"
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
  - "Web services, My.WebServices object"
  - "My.WebServices object"
  - "applications [Visual Basic], Web services"
ms.assetid: 8ad5405b-e771-42b1-82d3-ce97af2cea9e
caps.latest.revision: 12
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Accessing Application Web Services (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

The `My.WebServices` object provides an instance of each Web service referenced by the current project. Each instance is instantiated on demand. You can access these Web services through the properties of the `My.WebServices` object. The name of the property is the same as the name of the Web service that the property accesses. Any class that inherits from <xref:System.Web.Services.Protocols.SoapHttpClientProtocol> is a Web service.  
  
## Tasks  
 The following table lists possible ways to access Web services referenced by an application.  
  
|||  
|-|-|  
|To|See|  
|Call a Web service|[My.WebServices Object](../../../visual-basic/language-reference/objects/my-webservices-object.md)|  
|Call a Web service asynchronously and handle an event when it completes|[How to: Call a Web Service Asynchronously](../../../visual-basic/developing-apps/programming/how-to-call-a-web-service-asynchronously.md)|  
  
## See Also  
 [My.WebServices Object](../../../visual-basic/language-reference/objects/my-webservices-object.md)