---
title: "Service: Security Calls Not Authorized"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3024b20a-5250-4bd1-a38c-c6d79f89610b
caps.latest.revision: 5
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Service: Security Calls Not Authorized
Counter Name: Security Calls Not Authorized.  
  
## Description  
 This counter is incremented when the <xref:System.ServiceModel.ServiceAuthorizationManager.CheckAccess%2A> method returns `false`. It indicates that the incoming message is from a valid user and protected properly, but the user is not authorized to do specific tasks.
