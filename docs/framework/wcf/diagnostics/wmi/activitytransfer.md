---
title: "ActivityTransfer"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fc40ef17-2a92-4ce2-853c-6ba8e5d571f3
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ActivityTransfer
Activity Transfer Event  
  
## Syntax  
  
```  
class ActivityTransfer : WSAT_TraceEvent  
{  
  object ActivityID;  
  object RelatedActivityID;  
};  
```  
  
## Methods  
 The ActivityTransfer class does not define any methods.  
  
## Properties  
 The ActivityTransfer class has the following properties:  
  
### ActivityID  
  
-   Data type: object  
    Access type: Read-only  
  
-   Activity ID  
  
### RelatedActivityID  
  
-   Data type: object  
    Access type: Read-only  
  
-   Related Activity ID  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel.|
