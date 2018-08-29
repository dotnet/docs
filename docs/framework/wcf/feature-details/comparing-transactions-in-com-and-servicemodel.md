---
title: "Comparing Transactions in COM+ and ServiceModel"
ms.date: "03/30/2017"
ms.assetid: e493bcdd-b91a-4486-853f-83dbcd1931b7
---
# Comparing Transactions in COM+ and ServiceModel
This topic discusses how to simulate the behavior of a transactional COM+ service using the Windows Communication Foundation (WCF) attributes the <xref:System.ServiceModel> namespace provides.  
  
## Emulating COM+ Using ServiceModel Attributes  
 The following table compares the <xref:System.EnterpriseServices.TransactionOption> enumeration used to create an `EnterpriseServices` transaction and how they correlate to the WCF attributes the <xref:System.ServiceModel> namespace provides.  
  
|COM+ attribute|WCF attributes|  
|---------------------|------------------------------------------------------------------------|  
|RequiresNew|<xref:System.ServiceModel.TransactionFlowAttribute> is set to <xref:System.ServiceModel.TransactionFlowOption.NotAllowed>.<br /><br /> <xref:System.ServiceModel.OperationBehaviorAttribute.TransactionScopeRequired%2A> is `true`.<br /><br /> The `TransactionFlow` attribute in the binding element is `false`.|  
|Required|<xref:System.ServiceModel.TransactionFlowAttribute> is set to <xref:System.ServiceModel.TransactionFlowOption.Allowed>.<br /><br /> <xref:System.ServiceModel.OperationBehaviorAttribute.TransactionScopeRequired%2A> is `true`.<br /><br /> The `TransactionFlow` attribute in the binding element is `true`.|  
|Supported|There is no direct equivalent. In general, you should adopt the behavior specified for `Required` instead.|  
|NotSupported|<xref:System.ServiceModel.OperationBehaviorAttribute.TransactionScopeRequired%2A> is `false`.<br /><br /> The `TransactionFlow` attribute in the binding element is `false`.|  
|Disabled|There is no direct equivalent. In general, you should adopt the behavior specified for `NotSupported` instead.|
