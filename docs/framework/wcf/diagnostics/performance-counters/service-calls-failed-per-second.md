---
title: "Service: Calls Failed Per Second"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5a2c7939-107d-4f0c-b43c-e02e079e8a9d
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Service: Calls Failed Per Second
Counter Name: Calls Failed Per Second.  
  
## Description  
 Number of calls that have unhandled exceptions, and are received by this service in a second.  
  
 This counter is of performance counter type [PERF_COUNTER_COUNTER](http://go.microsoft.com/fwlink/?LinkID=94649), whose value is calculated using the following formula.  
  
 (N 1 - N 0 ) / ( (D 1 -D 0 ) / F)  
  
 In managed code, exceptions are thrown when error conditions occur.  
  
 In managed code, exceptions are thrown when error conditions occur.  
  
 This counter is incremented every time there is an unhandled exception in this service.  
  
## See Also  
 [Specifying and Handling Faults in Contracts and Services](../../../../../docs/framework/wcf/specifying-and-handling-faults-in-contracts-and-services.md)
