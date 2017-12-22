---
title: "Contract1"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: aa00f6b3-7e1f-4213-841a-206463fca20b
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Contract
Contract  
  
## Syntax  
  
```  
class Contract  
{  
  sint32 AppDomainId;  
  Behavior Behaviors[];  
  string Name;  
  string Namespace;  
  Operation Operations[];  
  sint32 ProcessId;  
  Contract ref;  
  string SessionMode;  
  string Type;  
};  
```  
  
## Methods  
 The Contract class does not define any methods.  
  
## Properties  
 The Contract class has the following properties:  
  
### AppDomainId  
 Data type: sint32  
  
 Access type: Read-only  
  
 The appdomain id of the appdomain that hosts the contract.  
  
### Behaviors  
 Data type: Behavior array  
  
 Access type: Read-only  
  
 The behaviors associated with this contract.  
  
### Name  
 Data type: string  
  
 Access type: Read-only  
  
 The name of the contract in WSDL.  
  
### Namespace  
 Data type: string  
  
 Access type: Read-only  
  
 The namespace of the `portType` element in WSDL.  
  
### Operations  
 Data type: Operation array  
  
 Access type: Read-only  
  
 The operations of this contract.  
  
### ProcessId  
 Data type: sint32  
  
 Access type: Read-only  
  
 The process Id of the process that hosts the contract.  
  
### ref  
 Data type: Contract  
  
 Access type: Read-only  
  
 The type of callback when the contract is a duplex contract.  
  
### SessionMode  
 Data type: string  
  
 Access type: Read-only  
  
 Indicates whether the contract requires the binding associated with this contract to use channel sessions.  
  
### Type  
 Data type: string  
  
 Access type: Read-only  
  
 The type of the contract.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.Description.ContractDescription>
