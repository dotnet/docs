---
title: "Service: Calls Faulted Per Second"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 94247356-2b29-4b50-b639-91ca8c1cf3a9
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Service: Calls Faulted Per Second
Counter Name: Calls Faulted Per Second.  
  
## Description  
 Number of calls that have returned faults to this service in a second.  
  
 This counter is of performance counter type [PERF_COUNTER_COUNTER](http://go.microsoft.com/fwlink/?LinkID=94649), whose value is calculated using the following formula.  
  
 (N 1 - N 0 ) / ( (D 1 -D 0 ) / F)  
  
 In [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] applications, service methods communicate processing error information using SOAP fault messages. SOAP faults are message types that are included in the metadata for a service operation and therefore create a fault contract that clients can use to make their execution more robust or interactive. Since SOAP faults are expressed to clients in XML form, they are highly interoperable.  
  
## See Also  
 [Specifying and Handling Faults in Contracts and Services](../../../../../docs/framework/wcf/specifying-and-handling-faults-in-contracts-and-services.md)
