---
title: "ServiceBehaviorAttribute"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5faa266f-587f-4e03-828d-1c7dd5acfe65
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ServiceBehaviorAttribute
ServiceBehaviorAttribute  
  
## Syntax  
  
```  
class ServiceBehaviorAttribute : Behavior  
{  
  boolean AutomaticSessionShutdown;  
  string ConcurrencyMode;  
  string ConfigurationName;  
  boolean IgnoreExtensionDataObject;  
  boolean IncludeExceptionDetailInFaults;  
  string InstanceContextMode;  
  sint32 MaxItemsInObjectGraph;  
  string Name;  
  string Namespace;  
  boolean ReleaseServiceInstanceOnTransactionComplete;  
  boolean TransactionAutoCompleteOnSessionClose;  
  string TransactionIsolationLevel;  
  datetime TransactionTimeout;  
  boolean UseSynchronizationContext;  
  boolean ValidateMustUnderstand;  
};  
```  
  
## Methods  
 The ServiceBehaviorAttribute class does not define any methods.  
  
## Properties  
 The ServiceBehaviorAttribute class has the following properties:  
  
### AutomaticSessionShutdown  
 Data type: boolean  
  
 Access type: Read-only  
  
 Indicates whether to automatically close a session when a client closes an output session.  
  
### ConcurrencyMode  
 Data type: string  
Access type: Read-only  
  
 Indicates whether a service supports one thread, multiple threads, or reentrant calls.  
  
### ConfigurationName  
 Data type: string  
  
 Access type: Read-only  
  
 The name of the service configuration.  
  
### IgnoreExtensionDataObject  
 Data type: boolean  
  
 Access type: Read-only  
  
 Specifies whether to send unknown serialization data onto the wire.  
  
### IncludeExceptionDetailInFaults  
 Data type: boolean  
  
 Access type: Read-only  
  
 Specifies whether to include managed exception information in the detail of SOAP faults returned to the clients for debugging purposes.  
  
### InstanceContextMode  
 Data type: string  
  
 Access type: Read-only  
  
 Specifies when a new service object is created.  
  
### MaxItemsInObjectGraph  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum number of items allowed in a serialized object.  
  
### Name  
 Data type: string  
  
 Access type: Read-only  
  
 The name attribute of the service in WSDL.  
  
### Namespace  
 Data type: string  
  
 Access type: Read-only  
  
 The target namespace of the service in WSDL.  
  
### ReleaseServiceInstanceOnTransactionComplete  
 Data type: boolean  
  
 Access type: Read-only  
  
 Specifies whether the service object is recycled when the current transaction completes.  
  
### TransactionAutoCompleteOnSessionClose  
 Data type: boolean  
  
 Access type: Read-only  
  
 Specifies whether pending transactions are completed when the current session closes.  
  
### TransactionIsolationLevel  
 Data type: string  
  
 Access type: Read-only  
  
 Specifies the transaction isolation level.  
  
### TransactionTimeout  
 Data type: datetime  
  
 Access type: Read-only  
  
 The period within which a transaction must complete.  
  
### UseSynchronizationContext  
 Data type: boolean  
  
 Access type: Read-only  
  
 Specifies whether to use the current synchronization context to choose the thread execution.  
  
### ValidateMustUnderstand  
 Data type: boolean  
  
 Access type: Read-only  
  
 Specifies whether the system or the application enforces SOAP MustUnderstand header processing.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.ServiceBehaviorAttribute>
