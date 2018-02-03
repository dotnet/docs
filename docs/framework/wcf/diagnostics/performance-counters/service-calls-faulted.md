---
title: "Service: Calls Faulted"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6da7f100-3f61-4b3c-9409-fe1360829b8a
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Service: Calls Faulted
Counter Name: Calls Faulted.  
  
## Description  
 Number of calls to this service that have returned faults. In [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] applications, service methods communicate processing error information using SOAP fault messages. SOAP faults are message types that are included in the metadata for a service operation and therefore create a fault contract that clients can use to make their execution more robust or interactive. Since SOAP faults are expressed to clients in XML form, they are highly interoperable.  
  
## See Also  
 [Specifying and Handling Faults in Contracts and Services](../../../../../docs/framework/wcf/specifying-and-handling-faults-in-contracts-and-services.md)
