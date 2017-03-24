---
title: "Accessing User Data (Visual Basic) | Microsoft Docs"
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
  - "domain names, retrieving"
  - "data [Visual Basic], accessing user data"
  - "My.User object, tasks"
  - "user data, domain"
  - "user names, retrieving"
  - "user data, accessing"
  - "login names"
  - "examples [Visual Basic], accessing user data"
ms.assetid: 32492a15-ee59-4a63-a1f1-9b24cc13140a
caps.latest.revision: 17
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Accessing User Data (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

This section contains topics dealing with the `My.User` object and tasks that you can accomplish with it.  
  
 The `My.User` object provides access to information about the logged-on user by returning an object that implements the <xref:System.Security.Principal.IPrincipal> interface.  
  
## Tasks  
  
|To|See|  
|--------|---------|  
|Get the user's login name|<xref:Microsoft.VisualBasic.ApplicationServices.User.Name%2A>|  
|Get the user's domain name, if the application uses Windows authentication|<xref:Microsoft.VisualBasic.ApplicationServices.User.CurrentPrincipal>|  
|Determine the user's role|<xref:Microsoft.VisualBasic.ApplicationServices.User.IsInRole%2A>|  
  
## See Also  
 <xref:Microsoft.VisualBasic.ApplicationServices.User>