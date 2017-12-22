---
title: "OperationBehaviorAttribute"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8c9b0755-9e83-411f-bdcb-61a586022797
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# OperationBehaviorAttribute
OperationBehaviorAttribute  
  
## Syntax  
  
```  
class OperationBehaviorAttribute : Behavior  
{  
  boolean AutoDisposeParameters;  
  string Impersonation;  
  string ReleaseInstanceMode;  
  boolean TransactionAutoComplete;  
  boolean TransactionScopeRequired;  
};  
```  
  
## Methods  
 The OperationBehaviorAttribute class does not define any methods.  
  
## Properties  
 The OperationBehaviorAttribute class has the following properties:  
  
### AutoDisposeParameters  
 Data type: boolean  
  
 Access type: Read-only  
  
 The state of the auto-dispose feature for parameters.  
  
### Impersonation  
 Data type: string  
  
 Access type: Read-only  
  
 Indicates the level of caller impersonation that the operation supports.  
  
### ReleaseInstanceMode  
 Data type: string  
  
 Access type: Read-only  
  
 Indicates when in the course of an operation invocation to recycle the object.  
  
### TransactionAutoComplete  
 Data type: boolean  
  
 Access type: Read-only  
  
 Indicates whether to automatically commit the current transaction if no unhandled exceptions occur.  
  
### TransactionScopeRequired  
 Data type: boolean  
  
 Access type: Read-only  
  
 Indicates whether the operation requires a transaction.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.OperationBehaviorAttribute>
