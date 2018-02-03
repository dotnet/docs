---
title: "ClientCredentials"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 41dffd6b-8f14-4fed-aefb-2a1bb168efb3
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ClientCredentials
ClientCredentials  
  
## Syntax  
  
```  
class ClientCredentials : Behavior  
{  
  string ClientCertificate;  
  string HttpDigest;  
  string IssuedToken;  
  string Peer;  
  string ServiceCertificate;  
  boolean SupportInteractive;  
  string UserName;  
  string Windows;  
};  
```  
  
## Methods  
 The ClientCredentials class does not define any methods.  
  
## Properties  
 The ClientCredentials class has the following properties:  
  
### ClientCertificate  
 Data type: string  
  
 Access type: Read-only  
  
 The X.509 certificate the client uses to authenticate to the service.  
  
### HttpDigest  
 Data type: string  
  
 Access type: Read-only  
  
 The current Http Digest credential.  
  
### IssuedToken  
 Data type: string  
  
 Access type: Read-only  
  
 The endpoint address and binding used to contact the local security token service.  
  
### Peer  
 Data type: string  
  
 Access type: Read-only  
  
 The credentials that the peer node uses to authenticate itself to other nodes in the mesh.  
  
### ServiceCertificate  
 Data type: string  
  
 Access type: Read-only  
  
 The service's X.509 certificate.  
  
### SupportInteractive  
 Data type: boolean  
  
 Access type: Read-only  
  
 A Boolean value that specifies whether the credential supports interactive negotiation.  
  
### UserName  
 Data type: string  
  
 Access type: Read-only  
  
 The username and password the client uses to authenticate itself to the service.  
  
### Windows  
 Data type: string  
  
 Access type: Read-only  
  
 The windows credentials the client uses to authenticate itself to the service.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.Description.ClientCredentials>
