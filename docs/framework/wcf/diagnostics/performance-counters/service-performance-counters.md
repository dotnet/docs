---
title: "Service Performance Counters"
ms.date: "03/30/2017"
ms.assetid: 4210f549-31f2-4ea7-99bd-69eaffb98ddf
---
# Service Performance Counters
Service performance counters measure the service behavior as a whole and can be used to diagnose the performance of the whole service. They can be found under the `ServiceModelService 4.0.0.0` performance object when viewing with Performance Monitor (Perfmon.exe). The instances are named using the following pattern:  
  
```  
ServiceName@ServiceBaseAddress  
```  
  
> [!CAUTION]
>  There is a limit on the length of a performance counter instance's name. When a Windows Communication Foundation (WCF) counter instance name exceeds the maximum length, WCF replaces a portion of the instance name with a hash value.  
  
## See also
- [Performance Counters](../../../../../docs/framework/wcf/diagnostics/performance-counters/index.md)
