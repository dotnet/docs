---
title: "Comparing Transactions in COM+ and ServiceModel"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e493bcdd-b91a-4486-853f-83dbcd1931b7
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Comparing Transactions in COM+ and ServiceModel
This topic discusses how to simulate the behavior of a transactional COM+ service using the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] attributes the <xref:System.ServiceModel> namespace provides.  
  
## Emulating COM+ Using ServiceModel Attributes  
 The following table compares the <xref:System.EnterpriseServices.TransactionOption> enumeration used to create an `EnterpriseServices` transaction and how they correlate to the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] attributes the <xref:System.ServiceModel> namespace provides.  
  
|COM+ attribute|[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] attributes|  
|---------------------|------------------------------------------------------------------------|  
|RequiresNew|<xref:System.ServiceModel.TransactionFlowAttribute> is set to <xref:System.ServiceModel.TransactionFlowOption.NotAllowed>.<br /><br /> <xref:System.ServiceModel.OperationBehaviorAttribute.TransactionScopeRequired%2A> is `true`.<br /><br /> The `TransactionFlow` attribute in the binding element is `false`.|  
|Required|<xref:System.ServiceModel.TransactionFlowAttribute> is set to <xref:System.ServiceModel.TransactionFlowOption.Allowed>.<br /><br /> <xref:System.ServiceModel.OperationBehaviorAttribute.TransactionScopeRequired%2A> is `true`.<br /><br /> The `TransactionFlow` attribute in the binding element is `true`.|  
|Supported|There is no direct equivalent. In general, you should adopt the behavior specified for `Required` instead.|  
|NotSupported|<xref:System.ServiceModel.OperationBehaviorAttribute.TransactionScopeRequired%2A> is `false`.<br /><br /> The `TransactionFlow` attribute in the binding element is `false`.|  
|Disabled|There is no direct equivalent. In general, you should adopt the behavior specified for `NotSupported` instead.|
