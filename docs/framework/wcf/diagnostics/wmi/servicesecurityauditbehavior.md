---
title: "ServiceSecurityAuditBehavior"
ms.date: "03/30/2017"
ms.assetid: 2c5809e7-5364-44ce-bc71-848be4672e2a
author: "BrucePerlerMS"
---
# ServiceSecurityAuditBehavior
ServiceSecurityAuditBehavior  
  
## Syntax  
  
```  
class ServiceSecurityAuditBehavior : Behavior  
{  
  string AuditLogLocation;  
  string MessageAuthenticationAuditLevel;  
  string ServiceAuthorizationAuditLevel;  
  boolean SuppressAuditFailure;  
};  
```  
  
## Methods  
 The ServiceSecurityAuditBehavior class does not define any methods.  
  
## Properties  
 The ServiceSecurityAuditBehavior class has the following properties:  
  
### AuditLogLocation  
 Data type: string  
  
 Access type: Read-only  
  
 The location of the audit log.  
  
### MessageAuthenticationAuditLevel  
 Data type: string  
  
 Access type: Read-only  
  
 The type of message authentication level that is used to log audit events.  
  
### ServiceAuthorizationAuditLevel  
 Data type: string  
  
 Access type: Read-only  
  
 The types of authorization events that are recorded in the audit log.  
  
### SuppressAuditFailure  
 Data type: boolean  
  
 Access type: Read-only  
  
 A boolean value that specifies the behavior for suppressing failures of writing to the audit log.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.Description.ServiceSecurityAuditBehavior>
