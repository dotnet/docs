---
title: "Differences Between Service Certificate Validation Done by Internet Explorer and WCF"
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
  - "service certificate validation [WCF]"
  - "certificates [WCF], service certificate validation"
ms.assetid: 9dffcab2-70a9-40f0-99fd-d3a0b296028f
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Differences Between Service Certificate Validation Done by Internet Explorer and WCF
Because of difference between the way Internet Explorer and [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] validate service certificates when HTTPS is used, it is possible that Internet Explorer will not be able to access the Help page or Web Services Description Language (WSDL) of a service even though a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] client is able to successfully send messages to the service endpoints. This is because Internet Explorer checks whether the service certificate has the `ServerAuthentication` object identifiers (OID) in the enhanced usage flags, whereas [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not enforce such a constraint. If Internet Explorer is unable to access the service Help page or the WSDL for the service, use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) to access the service metadata.  
  
## See Also  
 [Certificate Validation Differences Between HTTPS, SSL over TCP, and SOAP Security](../../../../docs/framework/wcf/feature-details/cert-val-diff-https-ssl-over-tcp-and-soap.md)  
 [How to: Retrieve Metadata and Implement a Compliant Service](../../../../docs/framework/wcf/feature-details/how-to-retrieve-metadata-and-implement-a-compliant-service.md)
