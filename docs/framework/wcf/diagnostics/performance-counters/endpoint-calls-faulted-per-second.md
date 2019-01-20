---
title: "Endpoint: Calls Faulted Per Second"
ms.date: "03/30/2017"
ms.assetid: 9840fc0a-0e4d-4638-96fd-40e3ab9e4667
---
# Endpoint: Calls Faulted Per Second
Counter Name: Calls Faulted Per Second.  
  
## Description  
 Number of calls that have returned faults to this endpoint in a second.  
  
 This counter is of performance counter type [PERF_COUNTER_COUNTER](https://go.microsoft.com/fwlink/?LinkID=94649), whose value is calculated using the following formula.  
  
 (N 1 - N 0 ) / ( (D 1 -D 0 ) / F)  
  
 In Windows Communication Foundation (WCF) applications, service methods communicate processing error information using SOAP fault messages. SOAP faults are message types that are included in the metadata for a service operation and therefore create a fault contract that clients can use to make their execution more robust or interactive. Since SOAP faults are expressed to clients in XML form, they are highly interoperable.  
  
## See also
 [Specifying and Handling Faults in Contracts and Services](../../../../../docs/framework/wcf/specifying-and-handling-faults-in-contracts-and-services.md)
