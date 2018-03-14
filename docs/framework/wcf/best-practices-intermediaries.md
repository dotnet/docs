---
title: "Best Practices: Intermediaries"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2d41b337-8132-4ac2-bea2-6e9ae2f00f8d
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Best Practices: Intermediaries
Care must be taken to handle faults correctly when calling intermediaries to make sure service side channels on the intermediary are closed properly.  
  
 Consider the following scenario. A client makes a call to an intermediary which then calls a back-end service.  The back-end service defines no fault contract, so any fault thrown from that service will be treated as an un-typed fault.  The back-end service throws an <xref:System.ApplicationException> and WCF correctly aborts the service-side channel. The <xref:System.ApplicationException> then surfaces as a <xref:System.ServiceModel.FaultException> that is thrown to the intermediary. The intermediary re-throws the <xref:System.ApplicationException>. WCF interprets this as an un-typed fault from the intermediary and forwards it on to the client. Upon receiving the fault, both the intermediary and the client fault their client-side channels. The intermediary’s service-side channel however remains open because WCF doesn’t know the fault is fatal.  
  
 The best practice in this scenario is to detect if the fault coming from the service is fatal and if so the intermediary should fault its service-side channel as shown in the following code snippet.  
  
```csharp  
catch (Exception e)  
{  
    bool faulted = service.State == CommunicationState.Faulted;  
    service.Abort();  
    if (faulted)  
    {  
        throw new ApplicationException(e.Message);  
    }  
    Else  
    {  
        throw;  
    }  
}  
```  
  
## See Also  
 [WCF Error Handling](../../../docs/framework/wcf/wcf-error-handling.md)  
 [Specifying and Handling Faults in Contracts and Services](../../../docs/framework/wcf/specifying-and-handling-faults-in-contracts-and-services.md)
