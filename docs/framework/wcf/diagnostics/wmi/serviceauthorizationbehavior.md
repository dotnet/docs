---
title: "ServiceAuthorizationBehavior"
ms.date: "03/30/2017"
ms.assetid: 77dad8e8-fea4-4d1c-b366-2f01a2a87f78
---
# ServiceAuthorizationBehavior
ServiceAuthorizationBehavior  
  
## Syntax  
  
```csharp
class ServiceAuthorizationBehavior : Behavior  
{  
  boolean ImpersonateCallerForAllOperations;  
  string PrincipalPermissionMode;  
  string RoleProvider;  
  string ServiceAuthorizationManager;  
};  
```  
  
## Methods  
 The ServiceAuthorizationBehavior class does not define any methods.  
  
## Properties  
 The ServiceAuthorizationBehavior class has the following properties:  
  
### ImpersonateCallerForAllOperations  
 Data type: boolean  
  
 Access type: Read-only  
  
 A value that controls whether the service attempts to impersonate using the credentials provided by the incoming message.  
  
### PrincipalPermissionMode  
 Data type: string  
  
 Access type: Read-only  
  
 The principal used to carry out operations on the server.  
  
### RoleProvider  
 Data type: string  
  
 Access type: Read-only  
  
 The name of the ASP.NET role provider.  
  
### ServiceAuthorizationManager  
 Data type: string  
  
 Access type: Read-only  
  
 The authorization manager used for custom authorization.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See also

- <xref:System.ServiceModel.Description.ServiceAuthorizationBehavior>
