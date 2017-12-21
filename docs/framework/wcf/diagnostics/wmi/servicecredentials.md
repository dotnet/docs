---
title: "ServiceCredentials"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9c780793-4785-46f7-add9-ac1ebeadb614
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ServiceCredentials
ServiceCredentials  
  
## Syntax  
  
```  
class ServiceCredentials : Behavior  
{  
  string ClientCertificate;  
  string IssuedTokenAuthentication;  
  string Peer;  
  string SecureConversationAuthentication;  
  string ServiceCertificate;  
  string UserNameAuthentication;  
  string WindowsAuthentication;  
};  
```  
  
## Methods  
 The ServiceCredentials class does not define any methods.  
  
## Properties  
 The ServiceCredentials class has the following properties:  
  
### ClientCertificate  
 Data type: string  
  
 Access type: Read-only  
  
 The client certificate authentication and provisioning settings for this service.  
  
### IssuedTokenAuthentication  
 Data type: string  
  
 Access type: Read-only  
  
 The current issued token authentication settings for this service.  
  
### Peer  
 Data type: string  
  
 Access type: Read-only  
  
 The current credential authentication and provisioning settings to be used by peer transport endpoints.  
  
### SecureConversationAuthentication  
 Data type: string  
  
 Access type: Read-only  
  
 Specifies the current secure conversation settings.  
  
### ServiceCertificate  
 Data type: string  
  
 Access type: Read-only  
  
 The certificate associated with this service.  
  
### UserNameAuthentication  
 Data type: string  
  
 Access type: Read-only  
  
 The username/password settings for this service.  
  
### WindowsAuthentication  
 Data type: string  
  
 Access type: Read-only  
  
 The Windows authentication settings for this service.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.Description.ServiceCredentials>
