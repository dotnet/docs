---
title: "ServiceMetadataBehavior"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0f194476-72f1-467e-bdce-674306316e64
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ServiceMetadataBehavior
ServiceMetadataBehavior  
  
## Syntax  
  
```  
class ServiceMetadataBehavior : Behavior  
{  
  string ExternalMetadataLocation;  
  boolean HttpGetEnabled;  
  string HttpGetUrl;  
  boolean HttpsGetEnabled;  
  string HttpsGetUrl;  
};  
```  
  
## Methods  
 The ServiceMetadataBehavior class does not define any methods.  
  
## Properties  
 The ServiceMetadataBehavior class has the following properties:  
  
### ExternalMetadataLocation  
 Data type: string  
  
 Access type: Read-only  
  
 Sets the location to which the service redirects metadata requests.  
  
### HttpGetEnabled  
 Data type: boolean  
  
 Access type: Read-only  
  
 Controls whether the service publishes its WSDL at the address controlled by the `HttpGetUrl` attribute.  
  
### HttpGetUrl  
 Data type: string  
  
 Access type: Read-only  
  
 Sets the location at which the service WSDL is published for retrieval using HTTP.  
  
### HttpsGetEnabled  
 Data type: boolean  
  
 Access type: Read-only  
  
 Controls whether the service publishes its WSDL over HTTPS at the address controlled by the `HttpsGetUrl` attribute.  
  
### HttpsGetUrl  
 Data type: string  
  
 Access type: Read-only  
  
 Sets the location at which the service WSDL is published for retrieval using HTTPS.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.Description.ServiceMetadataBehavior>
