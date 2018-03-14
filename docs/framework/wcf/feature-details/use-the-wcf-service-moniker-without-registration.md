---
title: "How to: Use the Windows Communication Foundation Service Moniker without Registration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "COM [WCF], service monikers without registration"
ms.assetid: ee3cf5c0-24f0-4ae7-81da-73a60de4a1a8
caps.latest.revision: 16
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Use the Windows Communication Foundation Service Moniker without Registration
To connect to and communicate with a [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] service, a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client application must have the details of the service address, the binding configuration, and the service contract.  
  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service moniker typically obtains the required contract through prior registration of the required attribute types, but there might be cases where this is not feasible. In place of registration, the moniker can obtain the definition of the contract in the form of a Web Services Definition Language (WSDL) document, through the use of the `wsdl` parameter or through Metadata Exchange, through the use of the `mexAddress` parameter.  
  
 This enables scenarios such as the distribution of an Excel spreadsheet where some of the cell values are calculated through Web service interactions. In this scenario, it might not be feasible to register the service contract assembly on all clients that might open the document. The `wsdl` parameter or the `mexAddress` parameter enables a self-contained solution.  
  
> [!NOTE]
>  Mutual authentication must be used to protect against request and response tampering or spoofing. Specifically, it is important for clients to be assured that the Metadata Exchange endpoint that is responding is the intended trusted party.  
  
## Example  
 This example shows the use of the service moniker with a MEX contract. A service with the following contract is exposed with a wsHttpBinding.  
  
```  
using System.ServiceModel;  
  
...  
  
[ServiceContract(Namespace = "http://Microsoft.ServiceModel.Demo")]  
public interface IAffiliate  
{  
    [OperationContract]  
    bool NewAffiliate(string ID, string company, string fullname, string accountsCode);  
    [OperationContract]  
    bool RemoveAffiliate(string ID);  
    [OperationContract]  
    double RevenueCheckMonthly(ref string ID);  
    [OperationContract]  
    double RevenueCheckTotal(ref string ID);  
}  
```  
  
 To construct a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client for the remote service the following example moniker string can be used.  
  
```  
service4:mexAddress="http://servername/Affiliates/service.svc/mex",  
address="http://servername/Affiliates/service.svc",  
contract=IAffiliate, contractNamespace=http://Microsoft.ServiceModel.Demo,  
binding=WSHttpBinding_IAffiliate, bindingNamespace=http://tempuri.org/  
```  
  
 During the execution of the client application, the client performs a `WS-MetadataExchange` with the provided `mexAddress`. This might return the address, binding and contract details for a number of services. The `address`, `contract`, `contractNamespace`, `binding` and `bindingNamespace` parameters are used to identify the intended service. Once those parameters have been matched, the moniker constructs a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client with the appropriate contract definition and calls can then be made using the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client, as with the typed contract.  
  
> [!NOTE]
>  If the moniker is malformed or if the service is unavailable, the call to `GetObject` returns an error saying "Invalid Syntax". If you receive this error, make sure the moniker you are using is correct and the service is available.  
  
## See Also  
 [How to: Register and Configure a Service Moniker](../../../../docs/framework/wcf/feature-details/how-to-register-and-configure-a-service-moniker.md)
