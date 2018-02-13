---
title: "CallbackBehavior"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 42acd302-2b62-4849-a2d1-a03084343ecd
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CallbackBehavior
CallbackBehavior  
  
## Syntax  
  
```  
class CallbackBehavior : Behavior  
{  
  boolean AutomaticSessionShutdown;  
  string ConcurrencyMode;  
  boolean IgnoreExtensionDataObject;  
  boolean IncludeExceptionDetailInFaults;  
  boolean MaxItemsInObjectGraph;  
  boolean UseSynchronizationContext;  
  boolean ValidateMustUnderstand;  
};  
```  
  
## Methods  
 The CallbackBehavior class does not define any methods.  
  
## Properties  
 The CallbackBehavior class has the following properties:  
  
### AutomaticSessionShutdown  
 Data type: boolean  
  
 Access type: Read-only  
  
 When true, the session is automatically closed when a service closes a duplex session.  
  
### ConcurrencyMode  
 Data type: string  
Access type: Read-only  
  
 Specifies whether the service supports one thread, multiple threads, or reentrant calls.  
  
### IgnoreExtensionDataObject  
 Data type: boolean  
  
 Access type: Read-only  
  
 A value that specifies whether to send unknown serialization data onto the wire.  
  
### IncludeExceptionDetailInFaults  
 Data type: boolean  
  
 Access type: Read-only  
  
 When enabled, details about exceptions on the callback are attached to the faults returned to the service.  
  
### MaxItemsInObjectGraph  
 Data type: boolean  
  
 Access type: Read-only  
  
 The maximum number of items allowed in a serialized object.  
  
### UseSynchronizationContext  
 Data type: boolean  
  
 Access type: Read-only  
  
 Specifies whether to use the current synchronization context to choose the thread of execution.  
  
### ValidateMustUnderstand  
 Data type: boolean  
  
 Access type: Read-only  
  
 Specifies whether the system or the application enforces SOAP MustUnderstand header processing.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.CallbackBehaviorAttribute>
