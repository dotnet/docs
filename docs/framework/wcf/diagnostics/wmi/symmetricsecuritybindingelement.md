---
title: "SymmetricSecurityBindingElement"
ms.date: "03/30/2017"
ms.assetid: b2e182b6-c041-4d80-a926-6058068d9f79
author: "BrucePerlerMS"
---
# SymmetricSecurityBindingElement
SymmetricSecurityBindingElement  
  
## Syntax  
  
```csharp
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
