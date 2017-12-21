---
title: "Security Calls Not Authorized Per Second"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0f189767-8c05-478a-8f0b-9228e5d351e5
caps.latest.revision: 9
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Security Calls Not Authorized Per Second
Counter Name: Security Calls Not Authorized Per Second.  
  
## Description  
 Number of calls that failed authorization in this operation in a second.  
  
 This counter is incremented when the <xref:System.ServiceModel.ServiceAuthorizationManager.CheckAccess%2A> method returns `false`. It indicates that the incoming message is from a valid user and protected properly, but the user is not authorized to do specific tasks.  
  
 This counter is of performance counter type [PERF_COUNTER_COUNTER](http://go.microsoft.com/fwlink/?LinkID=94649), whose value is calculated using the following formula.  
  
 (N 1 - N 0 ) / ( (D 1 -D 0 ) / F)
