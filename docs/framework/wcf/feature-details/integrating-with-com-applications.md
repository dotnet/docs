---
title: "Integrating with COM Applications"
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
  - "Windows Communication Foundation, COM integration"
  - "COM [WCF], Windows Communication Foundation integration"
  - "WCF, reusing code"
  - "Windows Communication Foundation, reusing code"
  - "COM [WCF]"
  - "WCF, COM integration"
ms.assetid: c98bda3e-6779-419e-8e6d-9aa94053026d
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Integrating with COM Applications
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] services can be integrated directly into your existing code by using the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service moniker. The service moniker can be used from a wide range of COM-based development environments, such as Office VBA, Visual Basic 6.0, or Visual C++ 6.0.  
  
## In This Section  
 [Integrating with COM Applications Overview](../../../../docs/framework/wcf/feature-details/integrating-with-com-applications-overview.md)  
 Gives an overview of the major parts of the integration process.  
  
 [How to: Register and Configure a Service Moniker](../../../../docs/framework/wcf/feature-details/how-to-register-and-configure-a-service-moniker.md)  
 To use the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service moniker within a COM application, register the required attributed types with COM, and configure the COM application and the moniker with the required binding configuration.  
  
 [How to: Use the Windows Communication Foundation Service Moniker without Registration](../../../../docs/framework/wcf/feature-details/use-the-wcf-service-moniker-without-registration.md)  
 Explains how to obtain the definition of the contract in the form of a Web Services Definition Language (WSDL) document or from a WS-MetadataExchange endpoint.  
  
 [How to: Use a Service Moniker with WSDL Contracts](../../../../docs/framework/wcf/feature-details/how-to-use-a-service-moniker-with-wsdl-contracts.md)  
 Describes how to call a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] sample using a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] WSDL moniker.  
  
 [How to: Use a Service Moniker with Metadata Exchange Contracts](../../../../docs/framework/wcf/feature-details/how-to-use-a-service-moniker-with-metadata-exchange-contracts.md)  
 Describes how to call a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] sample using a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] moniker that specifies a Mex endpoint.  
  
 [How to: Specify Channel Security Credentials](../../../../docs/framework/wcf/feature-details/how-to-specify-channel-security-credentials.md)  
 The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] service moniker supports the `IChannelCredentials` interface that allows a range of alternate methods for specifying channel credentials.  
  
## Reference  
 <xref:System.ServiceModel>  
  
## See Also  
 [Integrating with COM+ Applications](../../../../docs/framework/wcf/feature-details/integrating-with-com-plus-applications.md)
