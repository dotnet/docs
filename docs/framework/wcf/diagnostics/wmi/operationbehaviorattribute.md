---
title: "OperationBehaviorAttribute"
ms.date: "03/30/2017"
ms.assetid: 8c9b0755-9e83-411f-bdcb-61a586022797
---
# OperationBehaviorAttribute
OperationBehaviorAttribute  
  
## Syntax  
  
```csharp
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
  
## See also
- <xref:System.ServiceModel.OperationBehaviorAttribute>
