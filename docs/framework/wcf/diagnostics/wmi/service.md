---
title: "Service"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 999806e1-6376-409e-b998-b0af391adfe7
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Service
Service  
  
## Syntax  
  
```  
class Service  
{  
  string BaseAddresses[];  
  Behavior Behaviors[];  
  string ConfigurationName;  
  string CounterInstanceName;  
  string DistinguishedName;  
  string Extensions[];  
  string Metadata[];  
  string Name;  
  string Namespace;  
  datetime Opened;  
  Channel OutgoingChannels[];  
  sint32 ProcessId;  
};  
```  
  
## Methods  
 The Service class does not define any methods.  
  
## Properties  
 The Service class has the following properties:  
  
### BaseAddresses  
 Data type: string array  
  
 Access type: Read-only  
  
 The base addresses used by the service.  
  
### Behaviors  
 Data type: Behavior array  
  
 Access type: Read-only  
  
 The behaviors associated with this service.  
  
### ConfigurationName  
 Data type: string  
  
 Access type: Read-only  
  
 ServiceElement_BehaviorConfiguration  
  
### CounterInstanceName  
 Data type: string  
  
 Access type: Read-only  
  
 Instance name of the instance of the performance counters of the service.  
  
### DistinguishedName  
 Data type: string  
  
 Access type: Read-only  
  
 Service name at the address.  
  
### Extensions  
 Data type: string array  
  
 Access type: Read-only  
  
 The instance contexts for the extensions of the service instance.  
  
### Metadata  
 Data type: string array  
  
 Access type: Read-only  
  
 The service metadata settings.  
  
### Name  
 Data type: string  
  
 Access type: Read-only  
  
 The unique name of this service.  
  
### Namespace  
 Data type: string  
  
 Access type: Read-only  
  
 The namespace of the service.  
  
### Opened  
 Data type: datetime  
  
 Access type: Read-only  
  
 The time the service was opened.  
  
### OutgoingChannels  
 Data type: Channel array  
  
 Access type: Read-only  
  
 The channels that are outgoing from the service instance.  
  
### ProcessId  
 Data type: sint32  
  
 Access type: Read-only  
  
 The process id of the process that hosts the service.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|
