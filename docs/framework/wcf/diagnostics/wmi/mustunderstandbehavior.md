---
title: "MustUnderstandBehavior"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 911ed04a-c4b8-4c72-a5c3-fc7b4e3b4348
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# MustUnderstandBehavior
MustUnderstandBehavior  
  
## Syntax  
  
```  
class MustUnderstandBehavior : Behavior  
{  
  boolean ValidateMustUnderstand;  
};  
```  
  
## Methods  
 The MustUnderstandBehavior class does not define any methods.  
  
## Properties  
 The MustUnderstandBehavior class has the following property:  
  
### ValidateMustUnderstand  
 Data type: boolean  
  
 Access type: Read-only  
  
 When `true`, all SOAP headers with the `MustUnderstand` attribute that are not handled cause the behavior to throw an exception.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.Description.MustUnderstandBehavior>
