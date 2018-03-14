---
title: "ServiceToEndpointAssociation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 03c3cd15-e1b2-4dc2-bdc2-59fdccdae110
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ServiceToEndpointAssociation
Maps a service to an endpoint.  
  
## Syntax  
  
```  
class ServiceToEndpointAssociation  
{  
  Service ref;  
  Endpoint ref;  
};  
```  
  
## Methods  
 The ServiceToEndpointAssociation class does not define any methods.  
  
## Properties  
 The ServiceToEndpointAssociation class has the following properties:  
  
### ref  
 Data type: Service  
  
 Access type: Read-only  
Qualifiers: Key  
  
 The service associated with the endpoint.  
  
### ref  
 Data type: Endpoint  
  
 Access type: Read-only  
Qualifiers: Key  
  
 The endpoint associated with the service.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|
