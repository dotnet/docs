---
title: "Operation class"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b19d1496-ef06-4d0c-b2ae-e728ec00cca0
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Operation class
Operation  
  
## Syntax  
  
```  
class Operation  
{  
  string Action;  
  boolean AsyncPattern;  
  Behavior Behaviors[];  
  boolean IsCallback;  
  boolean IsInitiating;  
  boolean IsOneWay;  
  boolean IsTerminating;  
  string MethodSignature;  
  string Name;  
  string ParameterTypes[];  
  string ReplyAction;  
  string ReturnType;  
};  
```  
  
## Methods  
 The Operation class does not define any methods.  
  
## Properties  
 The Operation class has the following properties:  
  
### Action  
 Data type: string  
  
 Access type: Read-only  
  
 The WS-Addressing action of the request message.  
  
### AsyncPattern  
 Data type: boolean  
  
 Access type: Read-only  
  
 Indicates that an operation is implemented asynchronously using a `Begin`[open/close angle brackets] and `End`[open/close angle brackets] method pair in a service contract.  
  
### Behaviors  
 Data type: Behavior array  
  
 Access type: Read-only  
  
 The behaviors associated with this operation.  
  
### IsCallback  
 Data type: boolean  
  
 Access type: Read-only  
  
 True when the operation is a callback operation.  
  
### IsInitiating  
 Data type: boolean  
  
 Access type: Read-only  
  
 Indicates whether the method implements an operation that can initiate a session on the server.  
  
### IsOneWay  
 Data type: boolean  
  
 Access type: Read-only  
  
 Indicates whether an operation returns a reply message.  
  
### IsTerminating  
 Data type: boolean  
  
 Access type: Read-only  
  
 Indicates whether an operation returns a reply message.  
  
### MethodSignature  
 Data type: string  
  
 Access type: Read-only  
  
 The method signature of the operation.  
  
### Name  
 Data type: string  
  
 Access type: Read-only  
  
 The name of the operation.  
  
### ParameterTypes  
 Data type: string array  
  
 Access type: Read-only  
  
 The types of the parameters of the operation.  
  
### ReplyAction  
 Data type: string  
  
 Access type: Read-only  
  
 The value of the SOAP action for the reply message of the operation.  
  
### ReturnType  
 Data type: string  
  
 Access type: Read-only  
  
 The return type of the operation.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.Description.OperationDescription>
