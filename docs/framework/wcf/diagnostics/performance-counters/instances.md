---
title: "Instances"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c8cf3460-0ca1-4411-8262-e9ecaf7f0a31
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Instances
Counter Name: Instances.  
  
## Description  
 Number of instance contexts that the service currently contains.  
  
 Most of the time, the number of instance contexts is identical to the number of instances. However, the following scenarios are exception to this rule.  
  
-   A service method calls the <xref:System.ServiceModel.Dispatcher.IInstanceProvider.ReleaseInstance%2A> method explicitly.  
  
-   A <xref:System.ServiceModel.ReleaseInstanceMode> is applied to an <xref:System.ServiceModel.OperationBehaviorAttribute> instance.  
  
## See Also  
 <xref:System.ServiceModel.OperationBehaviorAttribute>
