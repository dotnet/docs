---
title: "Operation Performance Counters"
ms.date: "03/30/2017"
ms.assetid: 333a51e0-f56e-4e1a-b359-5c91ff390568
---
# Operation Performance Counters
Operation performance counters are found under the `ServiceModelOperation 4.0.0.0` performance object when viewing with the Performance Monitor (Perfmon.exe). Each operation has an individual instance. That is, if a given contract has 10 operations, 10 operation counter instances are associated with that contract. The object instances are named using the following pattern:  
  
```  
(ServiceName).(ContractName).(OperationName)@(first endpoint listener address)  
```  
  
 This counter enables you to measure how the call is being used and how well the operation is performing.  
  
> [!CAUTION]
>  There is a limit on the length of a performance counter instance's name. When a Windows Communication Foundation (WCF) counter instance name exceeds the maximum length, WCF replaces a portion of the instance name with a hash value.  
  
## See also
- [Performance Counters](../../../../../docs/framework/wcf/diagnostics/performance-counters/index.md)
