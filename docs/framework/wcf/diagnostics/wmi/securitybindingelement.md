---
title: "SecurityBindingElement"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ef93b6e6-3524-48a8-94d3-c8837f1872f9
caps.latest.revision: 8
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# SecurityBindingElement
SecurityBindingElement  
  
## Syntax  
  
```  
class SecurityBindingElement : BindingElement  
{  
  string DefaultAlgorithmSuite;  
  boolean IncludeTimestamp;  
  string KeyEntropyMode;  
  LocalServiceSecuritySettings LocalServiceSecuritySettings;  
  string MessageSecurityVersion;  
  string SecurityHeaderLayout;  
};  
```  
  
## Methods  
 The SecurityBindingElement class does not define any methods.  
  
## Properties  
 The SecurityBindingElement class has the following properties:  
  
### DefaultAlgorithmSuite  
 Data type: string  
  
 Access type: Read-only  
  
 Specifies the algorithms to use with the binding.  
  
### IncludeTimestamp  
 Data type: boolean  
  
 Access type: Read-only  
  
 A Boolean value that specifies whether each message contains a timestamp.  
  
### KeyEntropyMode  
 Data type: string  
  
 Access type: Read-only  
  
 The source of entropy used to create keys.  
  
### LocalServiceSecuritySettings  
 Data type: LocalServiceSecuritySettings  
  
 Access type: Read-only  
  
 The binding specific security properties for the local service.  
  
### MessageSecurityVersion  
 Data type: string  
  
 Access type: Read-only  
  
 The version used for message security.  
  
### SecurityHeaderLayout  
 Data type: string  
  
 Access type: Read-only  
  
 The order of elements in the security header for this binding.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.Channels.SecurityBindingElement>
