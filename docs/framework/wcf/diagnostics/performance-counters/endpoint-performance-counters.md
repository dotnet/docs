---
title: "Endpoint Performance Counters"
ms.date: "03/30/2017"
ms.assetid: 7d44d576-bd4e-453b-8b76-a818ce90b806
---
# Endpoint Performance Counters
Endpoint performance counters capture data that reveals how an endpoint is accepting messages. They can be found under the `ServiceModelEndpoint 4.0.0.0` performance object when viewing with the Performance Monitor. The instances are named using this pattern:  
  
```  
(ServiceName).(ContractName)@(endpoint listener address)  
```  
  
 The data is similar to that collected for individual operations, but is only aggregated across the endpoint.  
  
> [!CAUTION]
>  There is a limit on the length of a performance counter instance's name. When a Windows Communication Foundation (WCF) counter instance name exceeds the maximum length, WCF replaces a portion of the instance name with a hash value.  
  
## See also

- [Performance Counters](../../../../../docs/framework/wcf/diagnostics/performance-counters/index.md)
