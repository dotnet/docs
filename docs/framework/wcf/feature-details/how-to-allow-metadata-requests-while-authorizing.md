---
title: "How To: Allow Metadata Requests While Authorizing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "allowing metadata requests while authorizing [WCF]"
ms.assetid: 90cec34f-b619-452b-a056-8b1c0de49d05
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How To: Allow Metadata Requests While Authorizing
During custom authorization, it may be necessary to allow a request for metadata to be processed. The following topic walks through the steps to validate such a request.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] authorization, see [Authorization](../../../../docs/framework/wcf/feature-details/authorization-in-wcf.md).  
  
### To allow metadata requests during authorization  
  
1.  Create an extension of the <xref:System.ServiceModel.ServiceAuthorizationManager> class.  
  
2.  Override the <xref:System.ServiceModel.ServiceAuthorizationManager.CheckAccessCore%2A> method. The method returns `true` or `false` depending on whether authorization is allowed. Information about the current procedure is found in the <xref:System.ServiceModel.OperationContext> passed as a parameter to the method.  
  
3.  In the override, check the contract name, namespace, and the action as shown in the following example. If the conditions are valid, then return `true.`  
  
4.  Use the extensibility point to employ the class. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [How to: Create a Custom Authorization Manager for a Service](../../../../docs/framework/wcf/extending/how-to-create-a-custom-authorization-manager-for-a-service.md).  
  
## Example  
 The following example shows an override of the <xref:System.ServiceModel.ServiceAuthorizationManager.CheckAccessCore%2A> method.  
  
 [!code-csharp[C_HowtoCheckForMexRequestsInAuthorization#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howtocheckformexrequestsinauthorization/cs/source.cs#1)]
 [!code-vb[C_HowtoCheckForMexRequestsInAuthorization#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howtocheckformexrequestsinauthorization/vb/source.vb#1)]  
  
## See Also  
 <xref:System.ServiceModel.ServiceAuthorizationManager>  
 [Authorization](../../../../docs/framework/wcf/feature-details/authorization-in-wcf.md)  
 [Managing Claims and Authorization with the Identity Model](../../../../docs/framework/wcf/feature-details/managing-claims-and-authorization-with-the-identity-model.md)
