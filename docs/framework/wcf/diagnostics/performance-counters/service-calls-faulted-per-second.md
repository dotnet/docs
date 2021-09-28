---
description: "Learn more about: Service: Calls Faulted Per Second"
title: "Service: Calls Faulted Per Second"
ms.date: "03/30/2017"
ms.assetid: 94247356-2b29-4b50-b639-91ca8c1cf3a9
---
# Service: Calls Faulted Per Second

Counter Name: Calls Faulted Per Second.  
  
## Description  

 Number of calls that have returned faults to this service in a second.  
  
 This counter is of performance counter type [PERF_COUNTER_COUNTER](/previous-versions/windows/it-pro/windows-server-2003/cc740048(v=ws.10)), whose value is calculated using the following formula.  
  
 (N 1 - N 0 ) / ( (D 1 -D 0 ) / F)  
  
 In Windows Communication Foundation (WCF) applications, service methods communicate processing error information using SOAP fault messages. SOAP faults are message types that are included in the metadata for a service operation and therefore create a fault contract that clients can use to make their execution more robust or interactive. Since SOAP faults are expressed to clients in XML form, they are highly interoperable.  
  
## See also

- [Specifying and Handling Faults in Contracts and Services](../../specifying-and-handling-faults-in-contracts-and-services.md)
