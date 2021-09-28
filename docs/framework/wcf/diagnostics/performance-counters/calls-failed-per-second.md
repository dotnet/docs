---
description: "Learn more about: Calls Failed Per Second"
title: "Calls Failed Per Second"
ms.date: "03/30/2017"
ms.assetid: e4ef3773-f650-4876-99cf-4d0c02aa03d4
---
# Calls Failed Per Second

Counter Name: Calls Failed Per Second  
  
## Description  

 Number of calls with unhandled exceptions in this operation in a second.  
  
 This counter is of performance counter type [PERF_COUNTER_COUNTER](/previous-versions/windows/it-pro/windows-server-2003/cc740048(v=ws.10)), whose value is calculated using the following formula.  
  
 (N 1 - N 0 ) / ( (D 1 -D 0 ) / F)  
  
 This counter is incremented every time there is an unhandled exception in this operation.  
  
## See also

- [Specifying and Handling Faults in Contracts and Services](../../specifying-and-handling-faults-in-contracts-and-services.md)
