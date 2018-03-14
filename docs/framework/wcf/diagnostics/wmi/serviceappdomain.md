---
title: "ServiceAppDomain"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f28e5186-a66d-46c1-abe9-b50e07f8cb4f
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ServiceAppDomain
Maps a service to an application domain.  
  
## Syntax  
  
```  
class ServiceAppDomain  
{  
  Service ref;  
  AppDomainInfo ref;  
};  
```  
  
## Methods  
 The ServiceAppDomain class does not define any methods.  
  
## Properties  
 The ServiceAppDomain class has the following properties:  
  
### ref  
 Data type: Service  
Qualifiers: Key  
  
 Access type: Read-only  
  
 The service of this application domain.  
  
### ref  
 Data type: AppDomainInfo  
Qualifiers: Key  
  
 Access type: Read-only  
  
 Contains properties of the application domain.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|
