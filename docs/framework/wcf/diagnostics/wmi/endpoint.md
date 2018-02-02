---
title: "Endpoint"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fe63370d-81a1-40f3-97c2-59cb357c78d2
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Endpoint
Endpoint  
  
## Syntax  
  
```  
class Endpoint  
{  
  string Address;  
  string AddressHeaders[];  
  string AddressIdentity;  
  sint32 AppDomainId;  
  Behavior Behaviors[];  
  Binding Binding;  
  string ContractName;  
  string CounterInstanceName;  
  string ListenUri;  
  string Name;  
  sint32 ProcessId;  
  Contract ref;  
};  
```  
  
## Methods  
 The Endpoint class defines the following method.  
  
|Method|Description|  
|------------|-----------------|  
|[GetOperationCounterInstanceName](../../../../../docs/framework/wcf/diagnostics/wmi/getoperationcounterinstancename.md)|Retrieves the operation performance counter instance name|  
  
## Properties  
 The Endpoint class has the following properties:  
  
### Address  
 Data type: string  
  
 Access type: Read-only  
  
 A URI that contains the address of the endpoint.  
  
### AddressHeaders  
 Data type: string array  
  
 Access type: Read-only  
  
 The collection of address headers attached to this endpoint.  
  
### AddressIdentity  
 Data type: string  
  
 Access type: Read-only  
  
 The identity of the endpoint.  
  
### AppDomainId  
 Data type: sint32  
  
 Access type: Read-only  
  
 The appdomain id of the appdomain that hosts the endpoint.  
  
### Behaviors  
 Data type: Behavior array  
  
 Access type: Read-only  
  
 The collection of behaviors implemented by this endpoint.  
  
### Binding  
 Data type: Binding  
  
 Access type: Read-only  
  
 The binding used by this endpoint.  
  
### ContractName  
 Data type: string  
  
 Access type: Read-only  
  
 A string that specifies which contract this endpoint is exposing.  
  
### CounterInstanceName  
 Data type: string  
  
 Access type: Read-only  
  
 The name of the instance of performance counters of the endpoint.  
  
### ListenUri  
 Data type: string  
  
 Access type: Read-only  
  
 The Uri the endpoint listens on.  
  
### Name  
 Data type: string  
  
 Access type: Read-only  
  
 The unique name of this endpoint.  
  
### ProcessId  
 Data type: sint32  
  
 Access type: Read-only  
  
 The process Id of the process that hosts the endpoint.  
  
### ref  
 Data type: Contract  
  
 Access type: Read-only  
  
 The contract this endpoint is exposing.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|
