---
title: "AsymmetricSecurityBindingElement"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 7bd3b6be-8f77-4927-93ae-6fa371893cca
caps.latest.revision: 8
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# AsymmetricSecurityBindingElement
AsymmetricSecurityBindingElement  
  
## Syntax  
  
```  
class AsymmetricSecurityBindingElement : SecurityBindingElement  
{  
  string MessageProtectionOrder;  
  boolean RequireSignatureConfirmation;  
};  
```  
  
## Methods  
 The AsymmetricSecurityBindingElement class does not define any methods.  
  
## Properties  
 The AsymmetricSecurityBindingElement class has the following properties:  
  
### MessageProtectionOrder  
 Data type: string  
  
 Access type: Read-only  
  
 The order of message encryption and signing for this binding.  
  
### RequireSignatureConfirmation  
 Data type: boolean  
  
 Access type: Read-only  
  
 Whether the binding requires signature confirmation.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.Channels.AsymmetricSecurityBindingElement>
