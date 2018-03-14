---
title: "DeliveryRequirementsAttribute"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 40c5435c-a325-4cf8-9dd0-d6e24b4a56a3
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# DeliveryRequirementsAttribute
DeliveryRequirementsAttribute  
  
## Syntax  
  
```  
class DeliveryRequirementsAttribute : Behavior  
{  
  string QueuedDeliveryRequirements;  
  boolean RequireOrderedDelivery;  
  string TargetContract;  
};  
```  
  
## Methods  
 The DeliveryRequirementsAttribute class does not define any methods.  
  
## Properties  
 The DeliveryRequirementsAttribute class has the following properties:  
  
### QueuedDeliveryRequirements  
 Data type: string  
  
 Access type: Read-only  
  
 Specifies whether the binding for a service supports contracts.  
  
### RequireOrderedDelivery  
 Data type: boolean  
  
 Access type: Read-only  
  
 Specifies whether the binding supports ordered messages.  
  
### TargetContract  
 Data type: string  
  
 Access type: Read-only  
  
 The contract to which it applies.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.DeliveryRequirementsAttribute>
