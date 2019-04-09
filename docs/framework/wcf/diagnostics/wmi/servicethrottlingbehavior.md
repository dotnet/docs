---
title: "ServiceThrottlingBehavior"
ms.date: "03/30/2017"
ms.assetid: 37b9e517-1f1f-4ec4-9fcb-2b8016794f5b
---
# ServiceThrottlingBehavior
ServiceThrottlingBehavior  
  
## Syntax  
  
```csharp  
class ServiceThrottlingBehavior : Behavior  
{  
  sint32 MaxConcurrentCalls;  
  sint32 MaxConcurrentInstances;  
  sint32 MaxConcurrentSessions;  
};  
```  
  
## Methods  
 The ServiceThrottlingBehavior class does not define any methods.  
  
## Properties  
 The ServiceThrottlingBehavior class has the following properties:  
  
### MaxConcurrentCalls  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum number of messages actively processing across all dispatcher objects in a ServiceHost.  
  
### MaxConcurrentInstances  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum number of service objects that can execute at one time.  
  
### MaxConcurrentSessions  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum number of sessions a host can accept at one time.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See also

- <xref:System.ServiceModel.Description.ServiceThrottlingBehavior>
