---
title: "SymmetricSecurityBindingElement"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b2e182b6-c041-4d80-a926-6058068d9f79
caps.latest.revision: 7
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# SymmetricSecurityBindingElement
SymmetricSecurityBindingElement  
  
## Syntax  
  
```  
class SymmetricSecurityBindingElement : SecurityBindingElement  
{  
  string MessageProtectionOrder;  
  boolean RequireSignatureConfirmation;  
};  
```  
  
## Methods  
 The SymmetricSecurityBindingElement class does not define any methods.  
  
## Properties  
 The SymmetricSecurityBindingElement class has the following properties:  
  
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
 <xref:System.ServiceModel.Channels.SymmetricSecurityBindingElement>
