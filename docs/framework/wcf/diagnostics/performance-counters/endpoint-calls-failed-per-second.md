---
description: "Learn more about: Endpoint: Calls Failed Per Second"
title: "Endpoint: Calls Failed Per Second"
ms.date: "03/30/2017"
ms.assetid: bcbe9da4-c8dd-4e27-b630-11611adc7580
---
# Endpoint: Calls Failed Per Second

Counter Name: Calls Failed Per Second.  
  
## Description  

 Number of calls that have unhandled exceptions and are received by this endpoint in a second.  
  
 This counter is of performance counter type [PERF_COUNTER_COUNTER](/previous-versions/windows/it-pro/windows-server-2003/cc740048(v=ws.10)), whose value is calculated using the following formula.  
  
 (N 1 - N 0 ) / ( (D 1 -D 0 ) / F)  
  
 This counter is incremented every time there is an unhandled exception at this endpoint.  
  
## See also

- [Specifying and Handling Faults in Contracts and Services](../../specifying-and-handling-faults-in-contracts-and-services.md)
